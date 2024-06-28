using DatabaseInterface;
using System.Data;


    public   class GetListSqlCls
    {
        static string SQL = "";
        static string SQL1 = "";
        static string _ListName = "";
        public  DataTable Dt = new();
        public string  GetListSql(string ListName,string ConStr)
        {
            SQL= "SELECT * FROM POS_LIST_SQL WHERE SQL_KEY='" + ListName + "'";
            Dt  =   RunSQL.RunSQLDt(SQL, ConStr).Result;
            if(Dt != null)
            {
                string Dtrs = Dt.Rows[0].ItemArray[1].ToString();
                return Dtrs;
            }
            else   return "";
           
        }

    }

