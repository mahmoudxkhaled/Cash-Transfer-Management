//using My_Transfers.Class;
//using Microsoft.Data.SqlClient;

//namespace My_Transfers.Service;

//public class AuthService
//{
//    private readonly IConfiguration _configuration;

//    public AuthService(IConfiguration configuration)
//    {
//        _configuration = configuration;
//    }

//    public User AuthenticateUser(Login model)
//    {
//        using (var connection = new SqlConnection(_configuration.GetConnectionString("YourConnectionString")))
//        {
//            connection.Open();

//            // Ensure to hash and salt the password in a real-world scenario
//            var query = "SELECT Id, Username, Password FROM Users WHERE Username = @Username AND Password = @Password";

//            var user = connection.QueryFirstOrDefault<User>(query, new { model.Username, model.Password });

//            return user;
//        }
//    }
//}
