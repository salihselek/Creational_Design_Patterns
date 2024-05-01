
BankCreator bankCreator = new BankCreator();
GarantiBank garanti1 = (GarantiBank)bankCreator.Create(BankType.Garanti);
HalkBank halk1 = (HalkBank)bankCreator.Create(BankType.HalkBank);
VakifBank vakif1 = (VakifBank)bankCreator.Create(BankType.VakifBank);

GarantiBank garanti2 = (GarantiBank)bankCreator.Create(BankType.Garanti);
HalkBank halk2 = (HalkBank)bankCreator.Create(BankType.HalkBank);
VakifBank vakif2 = (VakifBank)bankCreator.Create(BankType.VakifBank);

#region Abstract Product
interface IBank
{

}
#endregion

#region Concrete Products

class GarantiBank : IBank
{
    string _userCode, _password;
    GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu.");
        _userCode = userCode;
        _password = password;
    }
    static GarantiBank() => _garantiBank = new("uid1", "123");

    static GarantiBank _garantiBank;

    static public GarantiBank GetInstance() => _garantiBank;
    public void ConnectionGaranti() => Console.WriteLine($"{nameof(GarantiBank)} - Connected.");
    public void SendMoney(int amount) => Console.WriteLine($"{amount} money sent.");
}
class HalkBank : IBank
{
    string _userCode, _password;
    HalkBank(string userCode)
    {
        Console.WriteLine($"{nameof(HalkBank)} nesnesi oluşturuldu.");
        _userCode = userCode;
    }
    static HalkBank _halkBank;
    static HalkBank() => _halkBank = new HalkBank("user1");
    static public HalkBank GetInstance() => _halkBank;

    public string Password { set { _password = value; } }
    public void Send(int amount, string accountNumber) => Console.WriteLine($"{amount} money sent.");
}
class VakifBank : IBank
{
    string _userCode, _email, _password;
    public bool isAuthentication { get; set; }
    VakifBank(CredentialVakifBank credential, string password)
    {
        Console.WriteLine($"{nameof(VakifBank)} nesnesi oluşturuldu.");
        _userCode = credential.UserCode;
        _email = credential.Email;
        _password = password;
    }
    static VakifBank() => _vakifBank = new(new() { UserCode = "user1", Email = "salih@ss.com" }, "123");

    static VakifBank _vakifBank;
    static public VakifBank GetInstance() => _vakifBank;
    public void ValidateCredential()
    {
        if (true)//validating
            isAuthentication = true;
        isAuthentication = false;
    }

    public void SendMoneyToAccountNumber(int amount, string recipientName, string accountNumber) => Console.WriteLine($"{amount} money sent.");
}
class CredentialVakifBank
{
    public string UserCode { get; set; }
    public string Email { get; set; }
}

#endregion

#region Abstract Factory
interface IBankFactory
{
    IBank CreateInstance();
}
#endregion

#region Concrete Factories

class GarantiFactory : IBankFactory
{
    GarantiFactory() { }
    static GarantiFactory _garantiFactory;
    static GarantiFactory() => _garantiFactory = new GarantiFactory();
    static public GarantiFactory GetInstance => _garantiFactory;
    public IBank CreateInstance()
    {
        GarantiBank garanti = GarantiBank.GetInstance();
        garanti.ConnectionGaranti();
        return garanti;
    }
}
class HalkBankFactory : IBankFactory
{
    HalkBankFactory() { }
    static HalkBankFactory() => _halkBankFactory = new();
    static HalkBankFactory _halkBankFactory;
    static public HalkBankFactory GetInstance => _halkBankFactory;
    public IBank CreateInstance()
    {
        HalkBank halkBank = HalkBank.GetInstance(); ;
        halkBank.Password = "123";
        return halkBank;
    }
}
class VakifBankFactory : IBankFactory
{
    VakifBankFactory() { }
    static VakifBankFactory() => _vakifBankFactory = new();
    static VakifBankFactory _vakifBankFactory;
    static public VakifBankFactory GetInstance => _vakifBankFactory;
    public IBank CreateInstance()
    {
        VakifBank vakifBank = VakifBank.GetInstance();
        vakifBank.ValidateCredential();
        return vakifBank;
    }
}

#endregion

#region Creator
enum BankType
{
    Garanti, HalkBank, VakifBank
}
class BankCreator
{
    public IBank Create(BankType bankType)
    {
        IBankFactory bankFactory = bankType switch
        {
            BankType.VakifBank => VakifBankFactory.GetInstance,
            BankType.HalkBank => HalkBankFactory.GetInstance,
            BankType.Garanti => GarantiFactory.GetInstance,
        };

        return bankFactory.CreateInstance();
    }
}
#endregion