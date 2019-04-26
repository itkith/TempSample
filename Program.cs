using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NaskMeAnalytics
{
    
    class Program
    {
        static void Main(string[] args)
        {
            List<TblEvent> lstEvents = null;
            List<decimal> ProcessedEventIds = new List<decimal>();
            List<decimal> UnprocessedEventIds = new List<decimal>();
            FileStream fs = new FileStream("UtilityLog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter LobjFile = new StreamWriter(fs);

            Console.WriteLine("Start...");
          //  Console.ReadLine();
            try
            {
                Console.WriteLine("Connecting to NaskMe DB...");
                using(NaskMeDataContext datacontext = new NaskMeDataContext())
                {
                    //Retreiving Events that need to be shifted from NaskmeDB to Redshift DB
                    lstEvents = datacontext.TblEvents.Where(x => x.Active == true && (x.IsProcessed ?? 0) == 0).Take(100).ToList();
                    if(lstEvents != null && lstEvents.Count >0)
                    {
                        Console.WriteLine("Starting to Process " + lstEvents.Count.ToString() + " Events.");
                    }
                    else
                    {
                        Console.WriteLine("No Events to process as of now.");
                    }
                
                }
               // Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while retreiving Events from NaskMe DB." + ex.Message);
                //Console.ReadLine();
            }
            try
            {
                /*String mainDbName = "naskmeanalyticsdb";
                String endpointAddress = "naskmeanalytics.cf9jftxdlvhy.us-west-1.redshift.amazonaws.com";
                int endpointPort = 5439;
                string masterUsername = "naskme";
                string password = "Key4Kunji2018";
                string odbcConnectionString = string.Concat("Driver={PostgreSQL Unicode(x64)}; Server=", endpointAddress
                    , "; Database=", mainDbName, "; UID=", masterUsername, "; PWD=", password
                    , "; Port=", endpointPort);*/
                string odbcConnectionDsn = "DSN=MyRedShift";
                string query = "SELECT EventId,Name,UserId,ObjectId,IsShared,SharedWith,IsMotherlode,MotherlodeItem,MotherlodeId,IsDone,Active,ActionType,Price,DateCreated,DateModified,ProcessedDate,objectname FROM TblRDEventsTemp;";
                // using (OdbcConnection conn = new OdbcConnection(odbcConnectionString))
                using (OdbcConnection conn = new OdbcConnection(odbcConnectionDsn))
                {
                    try
                    {
                        OdbcDataAdapter da = null;

                        if (lstEvents != null && lstEvents.Count > 0)//If there are some events to be shifted to RedShift DB
                        {
                            conn.Open();
                            foreach (TblEvent myevent in lstEvents) //Loop through events
                            {
                                Console.WriteLine("Processing Event : " + myevent.EventId);
                                //LobjFile.WriteLine(System.DateTime.Now.ToShortDateString() + " Processing Event : " + myevent.EventId );
                                try
                                {
                                    da = new OdbcDataAdapter(query, conn);
                                    da.InsertCommand = new OdbcCommand("INSERT INTO TblRDEventsTemp (EventId,Name,UserId,ObjectId,IsShared,SharedWith,IsMotherlode,MotherlodeItem,MotherlodeId,IsDone,Active,ActionType,Price,DateCreated,DateModified,ProcessedDate, objectname) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", conn);
                                    da.InsertCommand.Parameters.Add("EventId", OdbcType.Numeric).Value = myevent.EventId;
                                    da.InsertCommand.Parameters.Add("Name", OdbcType.VarChar, 100).Value = myevent.Name;
                                    da.InsertCommand.Parameters.Add("UserId", OdbcType.Numeric).Value = myevent.UserId;
                                    da.InsertCommand.Parameters.Add("ObjectId", OdbcType.Numeric).Value = myevent.ObjectId;
                                    da.InsertCommand.Parameters.Add("IsShared", OdbcType.Bit).Value = myevent.IsShared;
                                    da.InsertCommand.Parameters.Add("SharedWith", OdbcType.VarChar, 400).Value = myevent.SharedWith;
                                    da.InsertCommand.Parameters.Add("IsMotherlode", OdbcType.Bit).Value = myevent.IsMotherload;
                                    da.InsertCommand.Parameters.Add("MotherlodeItem", OdbcType.VarChar, 400).Value = myevent.MotherloadItem;
                                    da.InsertCommand.Parameters.Add("MotherlodeId", OdbcType.Numeric).Value = myevent.MotherloadId;
                                    da.InsertCommand.Parameters.Add("IsDone", OdbcType.Bit).Value = myevent.IsDone;
                                    da.InsertCommand.Parameters.Add("Active", OdbcType.Bit).Value = myevent.Active;
                                    da.InsertCommand.Parameters.Add("ActionType", OdbcType.VarChar, 100).Value = myevent.ActionType;
                                    da.InsertCommand.Parameters.Add("Price", OdbcType.VarChar, 100).Value = myevent.Price;
                                    da.InsertCommand.Parameters.Add("DateCreated", OdbcType.DateTime).Value = myevent.DateCreated;
                                    da.InsertCommand.Parameters.Add("DateModified", OdbcType.DateTime).Value = myevent.DateModified;
                                    da.InsertCommand.Parameters.Add("ProcessedDate", OdbcType.DateTime).Value = System.DateTime.UtcNow;
                                    da.InsertCommand.Parameters.Add("ObjectName", OdbcType.VarChar).Value = myevent.ObjectName;
                                    da.InsertCommand.ExecuteNonQuery();

                                    ProcessedEventIds.Add(myevent.EventId);
                                    Console.WriteLine(System.DateTime.Now.ToShortDateString() + " Processing Event : " + myevent.EventId + "... Success");
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine("Processing Event : " + myevent.EventId + "... Failure");
                                    Console.WriteLine("Error while inserting into TblRDEvents. EventId : " + myevent.EventId+". Error : "+ex.Message);
                                    LobjFile.WriteLine(System.DateTime.Now.ToShortDateString() +" Processing Event : " + myevent.EventId + "... Failure." +ex.Message);
                                    UnprocessedEventIds.Add(myevent.EventId);
                                    continue;
                                }
 
                            }//End Foreach loop
                            conn.Close();

                            using (NaskMeDataContext datacontext = new NaskMeDataContext())
                            {
                                if (ProcessedEventIds != null && ProcessedEventIds.Count > 0)
                                {
                                    string Evnid = String.Join(",", ProcessedEventIds);
                                    var result = datacontext.pr_UpdateEventStatus(Evnid, 1);
                                }
                                if (UnprocessedEventIds != null && UnprocessedEventIds.Count > 0)
                                {
                                    string Evntid = String.Join(",", ProcessedEventIds);
                                    var result = datacontext.pr_UpdateEventStatus(Evntid, 2);
                                }
                                datacontext.SubmitChanges();
                               
                            }

                        }

                        

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception "+ ex.Message);
                        LobjFile.WriteLine(System.DateTime.Now.ToShortDateString() + " Exception : " + ex.Message);
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if(conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        LobjFile.Close();
                        LobjFile.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Console.ReadKey();
                //Console.ReadLine();
                LobjFile.WriteLine(System.DateTime.Now.ToShortDateString() + " Error in main."+e.Message);
            }
            

            Console.WriteLine("Done...");
            //Console.ReadKey();
        }
      
    }
}
