using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace accesdapi
{
  
    public  class DBAPI
    {
        public  string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\db\db.mdb";
        public  void ConnectionInit()
        {
            string strSQL = "SELECT * FROM Абоненты";
            // Create a connection    
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create a command and set its connection    
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                // Open the connection and execute the select command.    
                try
                {
                    // Open connecton    
                    connection.Open();
                    // Execute command    
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("------------Original data----------------");
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1}", reader["ФИО"].ToString(), reader["Адрес"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // The connection is automatically closed becasuse of using block.    
            }
            Console.ReadKey();
        }
        public List<Phone> ReadDataFromDb()
        {
           
            List<Phone> list = new List<Phone>();   
            string SELECT = "SELECT * FROM Абоненты";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                 
                OleDbCommand command = new OleDbCommand(SELECT, connection);
           
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Phone phone = new Phone();
                            // Console.WriteLine("{0} {1}", reader["ФИО"].ToString(), reader["Адрес"].ToString());
                            phone.Name = reader["ФИО"].ToString();
                            phone.Number = reader["Номер"].ToString();
                            phone.Location = reader["Адрес"].ToString();
                            string calls1 = reader["Городские звонки"].ToString();
                            Int32.TryParse(calls1, out int c1);
                            phone.Calls1 = c1;
                            string calls2 = reader["Междугородние звонки"].ToString();
                            Int32.TryParse(calls2, out int c2);
                            phone.Calls2 = c2;
                            list.Add(phone);
                        }
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new List<Phone>();
                }
                // The connection is automatically closed becasuse of using block.    
            }

        }
        public string InsertDataToDb(Phone phone)
        {
            List<Phone> list = new List<Phone>();
            string INSERT = $"INSERT INTO Абоненты( [ФИО],[Адрес],[Городские звонки],[Междугородние звонки],[Номер]) VALUES ('{phone.Name}','{phone.Location}','{phone.Calls1}','{phone.Calls2}','{phone.Number}')";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(INSERT, connection);

                try
                {
                    connection.Open();
                    command.ExecuteReader();


                    return "Success!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return $"Eroror:{ex.Message}";
                }
            }
        }
        public void UpdateDataToDb()
        {

        }
        public string DeleteAllDataFromDb(string tablename)
        {
            List<Phone> list = new List<Phone>();
            string DELETE = $"DELETE  FROM {tablename}";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(DELETE, connection);
                try
                {
                    connection.Open();
                    command.ExecuteReader();


                    return "DELETED!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return $"Eroror:{ex.Message}";
                }
            }
        }
        public string DeleteDataFromDbById(string tablename,string id)
        {
            List<Phone> list = new List<Phone>();
            string DELETE = $"DELETE FROM {tablename} WHERE [КОД] = {id}";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(DELETE, connection);
                try
                {
                    connection.Open();
                    command.ExecuteReader();


                    return "DELETED!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return $"Eroror:{ex.Message}";
                }
            }
        }
    }
}
