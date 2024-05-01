

DatabaseCreator creator = new();
Database mssql = creator.Create(new MsSqlDatabaseFactory());
Database mysql = creator.Create(new MySqlDatabaseFactory());

Console.WriteLine();

//Abstract Product
enum ConnectionState
{
    Open, Close
}
abstract class Connection
{
    public abstract bool Connect();
    public abstract bool DisConnect();
    public abstract ConnectionState State { get; set; }
    public abstract string ConnectionString { get; set; }
}

abstract class Command
{
    public abstract void Execute(string query);
}

//Concrete Product
class MsSqlConnection : Connection
{
    public override ConnectionState State { get; set; }
    public override string ConnectionString { get; set; }

    public override bool Connect()
    {
        Console.WriteLine("MsSql connection bağlantısı gerçekleşti.");
        State = ConnectionState.Open;
        return true;
    }

    public override bool DisConnect()
    {
        Console.WriteLine("MsSql connection bağlantısı koparıldı.");
        State = ConnectionState.Close;
        return true;
    }
}

//Concrete Product
class MySqlConnection : Connection
{
    public override ConnectionState State { get; set; }
    public override string ConnectionString { get; set; }

    public override bool Connect()
    {
        Console.WriteLine("MySql connection bağlantısı gerçekleşti.");
        State = ConnectionState.Open;
        return true;
    }

    public override bool DisConnect()
    {
        Console.WriteLine("MySql connection bağlantısı koparıldı.");
        State = ConnectionState.Close;
        return true;
    }
}

//Concrete Product
class MsSqlCommand : Command
{
    public override void Execute(string query)
    {
        Console.WriteLine(query);
    }
}

//Concrete Product
class MySqlCommand : Command
{
    public override void Execute(string query)
    {
        Console.WriteLine(query);
    }
}

//Abstraact Factory
abstract class DatabaseFactory
{
    public abstract Connection CreateConnection();
    public abstract Command CreateCommand();
}

//Concrete Factory
class MsSqlDatabaseFactory : DatabaseFactory
{
    public override Command CreateCommand()
    {
        MsSqlCommand command = new();
        return command;
    }

    public override Connection CreateConnection()
    {
        MsSqlConnection connection = new();
        connection.ConnectionString = "Mssql Connection bağlantı";
        return connection;
    }
}

class MySqlDatabaseFactory : DatabaseFactory
{
    public override Command CreateCommand()
    {
        MySqlCommand command = new();
        return command;
    }

    public override Connection CreateConnection()
    {
        MySqlConnection connection = new();
        connection.ConnectionString = "Mysql Connection bağlantı";
        return connection;
    }
}

class Database
{
    public Connection Connection { get; set; }
    public Command Command { get; set; }
}
class DatabaseCreator
{
    public Database Create(DatabaseFactory databaseFactory)
    {
        return new()
        {
            Command = databaseFactory.CreateCommand(),
            Connection = databaseFactory.CreateConnection()
        };
    }
}
