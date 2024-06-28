using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.Xml;
using Microsoft.Data.SqlClient;
using System.Reflection;
namespace DatabaseInterface;

public class Recordset
{
    private readonly string clientId;
    public Recordset(string ClientId)
    {
        clientId = ClientId;
    }
    public async Task <List<object>> OpenList(string SQL)
    {
        IList<object> list =await RunWebApiSQL(SQL);
        return list.ToList();
    }
    public async Task<DataTable> Open(string SQL)
    {
        DataTable list = await RunWebApiDataTable(SQL);
        return list;
    }
    public DataTable OpenSql(string SQL)
    {
        SqlConnection Cn = new SqlConnection("Data Source=.;Initial Catalog=Adams2;User ID=sa;Password=123@123qw;Connection Timeout=30;TrustServerCertificate=True");
        Cn.Open();
        SqlDataAdapter Adt = new SqlDataAdapter(SQL, Cn);
        DataTable dt = new DataTable();
        Adt.Fill(dt);
        return dt;
    }
    public async Task <DataTable> OpenSql(string SQL,string ConnectionString)
    {
        SqlConnection Cn = new SqlConnection(ConnectionString);
        Cn.Open();
        SqlDataAdapter Adt = new SqlDataAdapter(SQL, Cn);
        DataTable dt = new DataTable();
        Adt.Fill(dt);
        return dt;
    }


    public async Task<IList<object>> RunWebApiSQL(string SQL)
    {
        try
        {
            var data = new List<object>();
            var httpcl = new HttpClient();
            var response = "";
            var apiUri = $"http://gravity-erp.com:8094/api/GB/RunSQL/{clientId}";
            var Data = Encoding.UTF8.GetBytes(SQL);

            ////////////////////

            System.Net.HttpWebRequest? request;

            request = System.Net.WebRequest.Create(apiUri) as System.Net.HttpWebRequest;

            if (Data != null)
            {
                request.ContentLength = Data.Length;
                request.ContentType = "text/plain";
                request.Method = HttpMethod.Post.Method;

                using (var requestStream = request.GetRequestStream())
                {

                    requestStream.Write(Data, 0, Data.Length);
                    requestStream.Close();
                }
                using (var responseStream = request.GetResponse().GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        response = reader.ReadToEnd();
                    }
                }

                try
                {
                    data = System.Text.Json.JsonSerializer.Deserialize<List<object>>(response).ToList();
                }
                catch (Exception ex)
                {
                    //await File.AppendAllTextAsync(Statics.AssemblyDirectory + "\\log.txt", $"=> {this.GetType().FullName.ToString()} => {ex.Message} , {ex.InnerException?.Message} , {System.Text.Json.JsonSerializer.Serialize(ex.InnerException.Data)}");
                }

            }
            else
            {

            }

            /////////////////////
            return await Task.FromResult(data);
        }
        catch (Exception eex)
        {


        }

        return await Task.FromResult(new List<object>());
    }
    public async Task<DataTable> RunWebApiDataTable(string SQL)
    {
        try
        {
            var data = new DataTable();
            var httpcl = new HttpClient();
            var response = "";
            var apiUri = $"http://gravity-erp.com:8094/api/GB/RunSQL/{clientId}";
            var Data = Encoding.UTF8.GetBytes(SQL);

            ////////////////////

            System.Net.HttpWebRequest? request;

            request = System.Net.WebRequest.Create(apiUri) as System.Net.HttpWebRequest;

            if (Data != null)
            {
                request.ContentLength = Data.Length;
                request.ContentType = "text/plain";
                request.Method = HttpMethod.Post.Method;

                using (var requestStream = request.GetRequestStream())
                {

                    requestStream.Write(Data, 0, Data.Length);
                    requestStream.Close();
                }
                using (var responseStream = request.GetResponse().GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        response = reader.ReadToEnd();
                    }
                }

                try
                {
                    data= JsonConvert.DeserializeObject<DataTable> (response);
                }
                catch (Exception ex)
                {
                    //await File.AppendAllTextAsync(Statics.AssemblyDirectory + "\\log.txt", $"=> {this.GetType().FullName.ToString()} => {ex.Message} , {ex.InnerException?.Message} , {System.Text.Json.JsonSerializer.Serialize(ex.InnerException.Data)}");
                }

            }
            else
            {

            }

            /////////////////////
            return await Task.FromResult(data);
        }
        catch (Exception eex)
        {


        }

        return await Task.FromResult(new DataTable());
    }


    public async Task<int> ExecuteNonQueryAsync(string SQL, string ConnectionString)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var apiUri = $"http://gravity-erp.com:8094/api/GB/RunSQL/{clientId}";
                var data = Encoding.UTF8.GetBytes(SQL);

                using (var content = new ByteArrayContent(data))
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");

                    var response = await httpClient.PostAsync(apiUri, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (int.TryParse(responseContent, out int affectedRows))
                        {
                            return affectedRows;
                        }
                        else
                        {
                            // Log or handle the case where parsing fails
                        }
                    }
                    else
                    {
                        // Log or handle the case where the HTTP request is not successful
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
        }

        return 0; // Default value in case of errors
    }



    //public async Task<TResult> RunWebApiSQL<TResult>(string SQL)
    //{
    //    var apiUri = $"http://gravity-erp.com:8094/api/GB/RunSQL/{clientId}";
    //    var httpcl = new HttpClient();
    //    var response = "";
    //    var Data = Encoding.UTF8.GetBytes(SQL);

    //    ////////////////////

    //    System.Net.HttpWebRequest? request;

    //    request = System.Net.WebRequest.Create(apiUri) as System.Net.HttpWebRequest;

    //    if (Data != null)
    //    {
    //        request.ContentLength = Data.Length;
    //        request.ContentType = "text/plain";
    //        request.Method = HttpMethod.Post.Method;

    //        using (var requestStream = request.GetRequestStream())
    //        {

    //            requestStream.Write(Data, 0, Data.Length);
    //            requestStream.Close();
    //        }

    //    }
    //    else
    //    {
    //        using (var responseStream = request.GetResponse().GetResponseStream()) using (StreamReader reader = new StreamReader(responseStream)) response = reader.ReadToEnd();
    //    }

    //    /////////////////////


    //    try
    //    {
    //        var data = System.Text.Json.JsonSerializer.Deserialize<TResult>(response);
    //        return await Task.FromResult(data);
    //    }
    //    catch (Exception ex)
    //    {
    //        await File.AppendAllTextAsync(Statics.AssemblyDirectory, $"=> {this.GetType().FullName.ToString()} => {ex.Message} , {ex.InnerException?.Message} , {System.Text.Json.JsonSerializer.Serialize(ex.InnerException.Data)}");
    //        return await Task.FromResult((dynamic)$"=> {this.GetType().FullName.ToString()} => {ex.Message} , {ex.InnerException?.Message} , {System.Text.Json.JsonSerializer.Serialize(ex.InnerException.Data)}");
    //    }

    //}

    public async Task RunWebApiSQLs(string SQL)
    {
        var apiUri = $"http://gravity-erp.com:8094/api/GB/RunSQL/{clientId}";
        var httpcl = new HttpClient();
        var response = "";
        var Data = Encoding.UTF8.GetBytes(SQL);

        ////////////////////

        System.Net.HttpWebRequest? request;

        request = System.Net.WebRequest.Create(apiUri) as System.Net.HttpWebRequest;

        if (Data != null)
        {
            request.ContentLength = Data.Length;
            request.ContentType = "text/plain";
            request.Method = HttpMethod.Post.Method;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(Data, 0, Data.Length);
                requestStream.Close();
            }
            using (var responseStream = request.GetResponse().GetResponseStream()) 
                using (StreamReader reader = new StreamReader(responseStream)) 
                    response = reader.ReadToEnd();
        }
        else
        {
            using (var responseStream = request.GetResponse().GetResponseStream()) using (StreamReader reader = new StreamReader(responseStream)) response = reader.ReadToEnd();
        }

        /////////////////////

        try
        {
            // No need to deserialize if TResult is void
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw;

        }
    }

}
