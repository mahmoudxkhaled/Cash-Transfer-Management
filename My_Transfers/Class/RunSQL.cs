using DatabaseInterface;
using Microsoft.AspNetCore.Components;
using System.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using System.Reflection;



public static class RunSQL
{

    public static async Task<DataTable> RunSQLDt(string SQL, string ConStr)
    {
        string ClientId = new GlobalVariables().ClientId;
        Recordset Rs = new Recordset(ClientId);
        DataTable Dt = await Rs.OpenSql(SQL, ConStr);
        return Dt;
    }



    public static async Task<List<T>> RunSQLList<T>(string SQL, string ConStr) where T : new()
    {
        string ClientId = new GlobalVariables().ClientId;
        Recordset Rs = new Recordset(ClientId);
        DataTable Dt = await Rs.OpenSql(SQL, ConStr);

        // Convert DataTable to List<T>
        List<T> resultList = ConvertDataTableToList<T>(Dt);

        return resultList;
    }
    public static async Task RunSQLNonQuery(string SQL, string ConStr)
    {
        string ClientId = new GlobalVariables().ClientId;
        Recordset Rs = new Recordset(ClientId);
        DataTable Dt = await Rs.OpenSql(SQL, ConStr);
        // string ClientId = new GlobalVariables().ClientId;
        // Recordset Rs = new Recordset(ClientId);

        // // Assuming Rs.ExecuteNonQueryAsync returns the affected rows count
        //await Rs.RunWebApiSQLs(SQL);

    }

    private static List<T> ConvertDataTableToList<T>(DataTable dataTable) where T : new()
    {
        List<T> list = new List<T>();

        foreach (DataRow row in dataTable.Rows)
        {
            T item = new T();

            foreach (DataColumn column in dataTable.Columns)
            {
                PropertyInfo property = typeof(T).GetProperty(column.ColumnName);
                property?.SetValue(item, row[column]);
            }

            list.Add(item);
        }

        return list;
    }

}

