using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace KEP
{
    public class database//Establishing connection and creating connection
    {
        public database(SQLiteConnection connection1)
        {
            connection1 = new SQLiteConnection("Data source= database.db;Version=3");
            connection1.Open();//if table doesnt exist ill create it and it will display nothing
            String createSQL = "create table if not exists Customers(id integer primary key autoincrement, FullName varchar(100), Email    varchar(50),    PhoneNum varchar(12),    Birthday  varchar(20),    Request  varchar(100),    Address varchar(100),    Date     varchar(50));";
            SQLiteCommand command = new SQLiteCommand(createSQL, connection1);
            command.ExecuteNonQuery();
            connection1.Close();
        }
    }
}
