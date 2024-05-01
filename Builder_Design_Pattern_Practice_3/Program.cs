//Yemek sulu = new();
//sulu.TuzOrani = 3;
//sulu.Adi = "Çorba";
//sulu.YemekTipi = YemekTipi.Sulu;

//Yemek etli = new();
//etli.TuzOrani = 5;
//etli.Adi = "Etli Pilav";
//etli.YemekTipi = YemekTipi.Etli;

YemekDirector director = new YemekDirector();
Yemek sulu = director.YemekYap(new SuluYemekBuilder());
sulu.TarifiGoster();
Yemek etli = director.YemekYap(new EtliYemekBuilder());
etli.TarifiGoster();
Yemek sebzeli = director.YemekYap(new SebzeliYemekBuilder());
sebzeli.TarifiGoster();

enum YemekTipi
{
    Sulu, Etli, Sebzeli
}
//Abstract Builder
abstract class YemekBuilder
{
    protected Yemek _yemek;
    public Yemek Yemek { get => _yemek; }
    public YemekBuilder() => _yemek = new();

    public abstract YemekBuilder SetYemekTipi();
    public abstract YemekBuilder SetAdi();
    public abstract YemekBuilder SetTuzOrani();
}

//Concrete Builder
class SuluYemekBuilder : YemekBuilder
{
    public override YemekBuilder SetAdi()
    {
        _yemek.Adi = "Sulu";
        return this;
    }

    public override YemekBuilder SetTuzOrani()
    {
        _yemek.TuzOrani = 3;
        return this;
    }

    public override YemekBuilder SetYemekTipi()
    {
        _yemek.YemekTipi = YemekTipi.Sulu;
        return this;
    }
}

//Concrete Builder
class EtliYemekBuilder : YemekBuilder
{
    public override YemekBuilder SetAdi()
    {
        _yemek.Adi = "Etli";
        return this;
    }

    public override YemekBuilder SetTuzOrani()
    {
        _yemek.TuzOrani = 5;
        return this;
    }

    public override YemekBuilder SetYemekTipi()
    {
        _yemek.YemekTipi = YemekTipi.Etli;
        return this;
    }
}

//Concrete Builder
class SebzeliYemekBuilder : YemekBuilder
{
    public override YemekBuilder SetAdi()
    {
        _yemek.Adi = "Sebzeli";
        return this;
    }

    public override YemekBuilder SetTuzOrani()
    {
        _yemek.TuzOrani = 1;
        return this;
    }

    public override YemekBuilder SetYemekTipi()
    {
        _yemek.YemekTipi = YemekTipi.Sebzeli;
        return this;
    }
}

//Director
class YemekDirector
{
    public Yemek YemekYap(YemekBuilder yemekBuilder)
    {
        return yemekBuilder
             .SetYemekTipi()
             .SetTuzOrani()
             .SetAdi()
             .Yemek;
    }
}

//Product
class Yemek
{
    public YemekTipi YemekTipi { get; set; }
    public string Adi { get; set; }
    public int TuzOrani { get; set; }

    public void TarifiGoster() => Console.WriteLine($"Yemek Tipi : {this.YemekTipi.ToString()} => Yemek Adı :  {this.Adi} => Tuz Oranı :  {this.TuzOrani}");
}
