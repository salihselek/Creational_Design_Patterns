//GarantiBank garantiBank = new("uid1", "123");
//garantiBank.ConnectionGaranti();


//VakifBank vakifBank = new(new() { UserCode = "user1", Email = "salih@ss.com" }, "123");
//vakifBank.ValidateCredential();
//if (vakifBank.isAuthentication)
//{
//}

//HalkBank halkBank = new HalkBank("user1");
//halkBank.Password = "123";

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
    public GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu.");
        _userCode = userCode;
        _password = password;
    }
    public void ConnectionGaranti() => Console.WriteLine($"{nameof(GarantiBank)} - Connected.");
    public void SendMoney(int amount) => Console.WriteLine($"{amount} money sent.");
}
class HalkBank : IBank
{
    string _userCode, _password;
    public HalkBank(string userCode)
    {
        Console.WriteLine($"{nameof(HalkBank)} nesnesi oluşturuldu.");
        _userCode = userCode;
    }
    public string Password { set { _password = value; } }
    public void Send(int amount, string accountNumber) => Console.WriteLine($"{amount} money sent.");
}
class VakifBank : IBank
{
    string _userCode, _email, _password;
    public bool isAuthentication { get; set; }
    public VakifBank(CredentialVakifBank credential, string password)
    {
        Console.WriteLine($"{nameof(VakifBank)} nesnesi oluşturuldu.");
        _userCode = credential.UserCode;
        _email = credential.Email;
        _password = password;
    }
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
    public IBank CreateInstance()
    {
        GarantiBank garanti = new("uid1", "123");
        garanti.ConnectionGaranti();
        return garanti;
    }
}
class HalkBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        HalkBank halkBank = new HalkBank("user1");
        halkBank.Password = "123";
        return halkBank;
    }
}
class VakifBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        VakifBank vakifBank = new(new() { UserCode = "user1", Email = "salih@ss.com" }, "123");
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
            BankType.VakifBank => new VakifBankFactory(),
            BankType.HalkBank => new HalkBankFactory(),
            BankType.Garanti => new GarantiFactory(),
        };

        return bankFactory.CreateInstance();
    }
}
#endregion