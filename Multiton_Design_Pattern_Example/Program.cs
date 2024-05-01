var mssql = Database.GetInstance("mssql");

mssql.ConnectionString("configuration");
mssql.Connection();

var oracle = Database.GetInstance("oracle", "oracleconfig");
var mongo = Database.GetInstance("mongo");


var mssql2 = Database.GetInstance("mssql");
var oracle2 = Database.GetInstance("oracle");
var mongo2 = Database.GetInstance("mongo");
 
class Database
{
    private Database()
    {
        Console.WriteLine($"{nameof(Database)} nesnesi oluşturuldu.");
    }

    static Dictionary<string, Database> _databases = new();
    public static Database GetInstance(string key)
    {
        if (!_databases.ContainsKey(key))
            _databases[key] = new Database();

        return _databases[key];
    }

    string connectionString = "";
    public static Database GetInstance(string key, string connectionString)
    {
        Database database = GetInstance(key);
        database.ConnectionString(connectionString);
        return database;
    }

    public void Connection()
    {
        Console.WriteLine("Connected");
    }

    public void Disonnected()
    {
        Console.WriteLine("Disconnected");
    }
    public void ConnectionString(string connectionString)
    {
        this.connectionString = connectionString;
    }
}