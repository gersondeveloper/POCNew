using System;
using System.Collections.Generic;
using System.Text;

namespace POCOi.Shared
{
    public static class Settings
    {
        // public static string ConnectionString = @"DATA SOURCE=127.0.0.1:1521/XE;DBA PRIVILEGE=SYSDBA;PERSIST SECURITY INFO=True;USER ID=gerson; PASSWORD=gerson123";
        //public static string ConnectionString = @"DATA SOURCE=10.58.1.195:1549/nfedx01;PERSIST SECURITY INFO=True;USER ID=isuser; PASSWORD=N0v0Fr0nt3nd_";

        //public static string ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=10.58.1.195)(Port=1549)))(CONNECT_DATA=(SERVICE_NAME=nfedx01)));User Id=isuser;Password=N0v0Fr0nt3nd_;"; 


        public static string ConnectionString="User Id=isuser;Password=N0v0Fr0nt3nd_;Data Source=10.58.1.195:1549/nfedx01;";


    }
}
