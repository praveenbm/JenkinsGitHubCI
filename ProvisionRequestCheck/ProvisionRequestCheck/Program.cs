using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace ProvisionRequestCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please Enter Domain Name:");
                String domainName = Console.ReadLine();
                if (domainName!=string.Empty && domainName!="")
                {
                    Console.WriteLine(Environment.NewLine);
                    string instruction = "Please Enter @ 1 for Webhosting Provisioning @ 2 for Sharepoint Provisioning @ 3 for Exchange company Provisioning @ 4 for Exchange User Provisioning";
                    instruction = instruction.Replace("@", Environment.NewLine);
                    Console.WriteLine(instruction);

                    String requestType = Console.ReadLine();
                    Console.WriteLine(Environment.NewLine);
                    string conn = string.Empty;
                    string query = string.Empty;
                    string result = string.Empty;
                    switch (requestType)
                    {
                        case "1":
                            {
                                Console.WriteLine("Webhosting Provisioning");
                                conn = Convert.ToString(ConfigurationManager.ConnectionStrings["WHCon"]);
                               // query = ConfigurationManager.AppSettings["QueryWH"];
                                query = "select * from WHAccountProvisioningQueue where DomainName='@domainName@'";
                                query = query.Replace("@domainName@", domainName);
                                result = GetData(conn, query, domainName);
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("Sharepoint Provisioning");
                                conn = Convert.ToString(ConfigurationManager.ConnectionStrings["SPCon"]);
                               // query = ConfigurationManager.AppSettings["QuerySP"];
                                query = "select * from SPCompanyProvisioningQueue where DomainName='@domainName@' ";
                                query = query.Replace("@domainName@", domainName);
                                result = GetData(conn, query, domainName);
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Exchange company Provisioning");
                                conn = Convert.ToString(ConfigurationManager.ConnectionStrings["EXCon"]);
                               // query = ConfigurationManager.AppSettings["QueryEX"];
                                query = "select * from CompanyProvision where DomainName='@domainName@'";
                                query = query.Replace("@domainName@", domainName);
                                result = GetData(conn, query, domainName);
                                break;
                            }

                        case "4":
                            {
                                Console.WriteLine("Exchange User Provisioning");
                                conn = Convert.ToString(ConfigurationManager.ConnectionStrings["EXCon"]);
                                //query = ConfigurationManager.AppSettings["QueryEX"];
                                query = "select * from UserProvision where DomainName='@domainName@'";
                                query = query.Replace("@domainName@", domainName);
                                result = GetData(conn, query, domainName);
                                break;
                            }
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }                   


                }
                else
                {
                    Console.WriteLine("Invalid Domain Name");
                }               
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               // Console.WriteLine(ex);
            }

        }


        public static bool CheckColumn(string columnName, SqlDataReader read)
        {
            for (int i = 0; i < read.FieldCount; i++)
            {

                if (read.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false; 
        }

        public static string GetData(string conn, string query, string domainName)
        {
            string result = string.Empty;
            SqlConnection sqlCon = null;
            try
            {
                sqlCon = new SqlConnection(conn);
                sqlCon.Open();
                string commandString = query;//"select * from WHAccountProvisioningQueue where DomainName='" + domainName + "'";
                SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
                SqlDataReader read = sqlCmd.ExecuteReader();

                if (read.HasRows)
                {
                    Console.WriteLine("Request Status: Request Present");                   
                    while (read.Read())
                    {
                        Console.WriteLine("----------------------------------------------------------------------------");
                        if (read["ProvisioningID"]!=null)
                        Console.WriteLine("ProvisioningID: "+read["ProvisioningID"]);
                        if (read["StartTime"] != null)
                        Console.WriteLine("StartTime: " + read["StartTime"]);
                        if (read["AccountHolderID"] != null)
                        Console.WriteLine("AccountHolderID: " + read["AccountHolderID"]);
                        if (CheckColumn("UserID",read))
                            Console.WriteLine("UserID: " + read["UserID"]);                        
                        if (read["Status"] != null)
                        Console.WriteLine("Status: " + read["Status"]);
                        if (read["CallbackMessage"] != null)
                        Console.WriteLine("CallbackMessage:"+read["CallbackMessage"]);
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("----------------------------------------------------------------------------");
                        Console.WriteLine(Environment.NewLine);
                    }
                                       
                }
                else
                {
                    result = "Request Not Present"+Environment.NewLine+" Note: For Sharepoint domain name starts with 'http://' ex: http://<domainname>";
                    Console.WriteLine("Request Status:" + result);  
                }
            }
            catch(Exception ex)
            {
                result = result + "Exception:" + ex;
            }
            finally
            {
                sqlCon.Close();
            }          

            return result;
        }
    }
}
