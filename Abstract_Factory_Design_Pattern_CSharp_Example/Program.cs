//Database msSql = new();
//msSql.Connection = new();
//msSql.Connection.ConnectionString = "...";
//msSql.Type = DatabaseType.MsSql;
//msSql.Command = new();

//var result = msSql.Connection.Connect();
//if (result && msSql.Connection.State == ConnectionState.Open)
//{
//    msSql.Command.Execute("select * from ..");
//}
//msSql.Connection.Disconnect();

//Database oracle = new();
//oracle.Connection = new();
//oracle.Connection.ConnectionString = "...";
//oracle.Type = DatabaseType.Oracle;
//oracle.Command = new();



DatabaseCreator creator = new();
Database mssql = creator.Create(new MsSqlDatabaseFactory());



Database oracle = creator.Create(new OracleDatabaseFactory());

Console.WriteLine();

enum DatabaseType
{
    Oracle,
    MsSql,
    MySql,
    PostgreSql
}
class Database
{
    public Database() { }
    public Database(DatabaseType type, AbstractConnection connection, AbstractCommand command)
    {
        Type = type;
        Connection = connection;
        Command = command;
    }

    public DatabaseType Type { get; set; }
    public AbstractConnection Connection { get; set; }
    public AbstractCommand Command { get; set; }
}
enum ConnectionState
{
    Open, Close
}

//Abstract Product
abstract class AbstractConnection
{
    public abstract string ConnectionString { get; set; }
    public abstract ConnectionState State { get; set; }
    public abstract bool Connect();
    public abstract bool Disconnect();
}


//Abstract Product
abstract class AbstractCommand
{
    public abstract void Execute(string query);
}

//Concrete Product
class Connection : AbstractConnection
{
    string _connectionString;
    public Connection() { }
    public Connection(string connectionString) => _connectionString = connectionString;
    public override string ConnectionString { get => _connectionString; set => _connectionString = value; }
    public override ConnectionState State { get; set; }
    public override bool Connect()
    {
        State = ConnectionState.Open;
        return true;
    }

    public override bool Disconnect()
    {
        State = ConnectionState.Close;
        return false;
    }
}

//Concrete Product
class Command : AbstractCommand
{
    public override void Execute(string query)
    {
        // executing
    }
}

//Abstract Factory
abstract class DatabaseFactory
{
    public abstract AbstractConnection CreateConnection();
    public abstract AbstractCommand CreateCommand();
}


//Concrete Factory
class MsSqlDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "MsSql connection string";
        return connection;
    }
}


//Concrete Factory
class OracleDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "Oracle connection string";
        return connection;
    }
}

//Concrete Factory
class MySqlDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "MySql connection string";
        return connection;
    }
}

//Concrete Factory
class PostgreSqlDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "PostgreSql connection string";
        return connection;
    }
}

//Creator
class DatabaseCreator
{
    AbstractConnection _connection;
    AbstractCommand _command;
    public Database Create(DatabaseFactory databaseFactory)
    {
        _connection = databaseFactory.CreateConnection();
        _command = databaseFactory.CreateCommand();


        return new()
        {
            Command = _command,
            Connection = _connection,
            Type = (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseFactory.GetType().Name.Replace("DatabaseFactory", ""))
        };
    }
}