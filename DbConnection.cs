namespace DatabaseStoredProcedureRunner;

public class DbConnection
{
    public string ServerName { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public bool UseWindowsAuth { get; set; } = false;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public DbConnection(string serverName, string databaseName, bool useWindowsAuth, string username, string password) 
    {

        ServerName = serverName;
        DatabaseName = databaseName;
        UseWindowsAuth = useWindowsAuth;
        Username = username;
        Password = password;

    }
    public string CreateConnectionString()
    {

        string connectionString = string.Empty;

        try
        {

            connectionString = $"Server={ServerName};Database={DatabaseName};";

            if (UseWindowsAuth == false)
            {

                connectionString += $"User ID={Username};Password={Password};";

            }
            else
            {

                connectionString += "Integrated Security=True;";

            }

            connectionString += "TrustServerCertificate=True;";

        }
        catch (Exception)
        {
            connectionString = string.Empty;
        }

        return connectionString;

    }
    public bool IsValid()
    {

        bool isValid = true;

        if (string.IsNullOrEmpty(ServerName) || string.IsNullOrEmpty(DatabaseName))
        {
        
            isValid = false;
        
        }

        if (UseWindowsAuth == false && (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)))
        {

            isValid = false;

        }

        return isValid;

    }

}
