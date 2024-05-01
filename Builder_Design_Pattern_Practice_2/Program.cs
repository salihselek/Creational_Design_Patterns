
//ArabaDirector director = new();
//Araba opel = director.Build(new OpelBuilder());
//opel.ToString();
//Araba mercedes = director.Build(new MercedesBuilder());
//mercedes.ToString();
//Araba bmw = director.Build(new BMWBuilder());
//bmw.ToString();

ArabaDirector director = new();
Araba opel = director.Build(BuilderCreator.Create(BuilderType.Opel));
opel.ToString();
Araba mercedes = director.Build(BuilderCreator.Create(BuilderType.Mercedes));
mercedes.ToString();
Araba bmw = director.Build(BuilderCreator.Create(BuilderType.BMW));
bmw.ToString();

//Product
class Araba
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public double KM { get; set; }
    public bool Vites { get; set; }
    public override string ToString()
    {
        Console.WriteLine($"{Marka} marka araba {Model} modelinde {KM} kilomentrede {Vites} vites olarak üretilmiştir.");
        return base.ToString();
    }
}

//Abstract Builder & Product
abstract class ArabaBuilder
{
    protected Araba _araba;
    public Araba Araba { get => _araba; }
    public ArabaBuilder() => _araba = new();

    public abstract ArabaBuilder SetMarka();
    public abstract ArabaBuilder SetModel();
    public abstract ArabaBuilder SetKM();
    public abstract ArabaBuilder SetVites();
}

//Concrete Builder & Product
class OpelBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        Araba.KM = 0;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        Araba.Marka = "Opel";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        Araba.Model = "Astra";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        Araba.Vites = true;
        return this;
    }
}

//Concrete Builder & Product
class MercedesBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        Araba.KM = 100;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        Araba.Marka = "Mercedes";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        Araba.Model = "CLA";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        Araba.Vites = true;
        return this;
    }
}

//Concrete Builder & Product
class BMWBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        Araba.KM = 10;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        Araba.Marka = "BMW";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        Araba.Model = "X6";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        Araba.Vites = false;
        return this;
    }
}

//Director
class ArabaDirector
{
    public Araba Build(ArabaBuilder arabaBuilder)
    {
        //arabaBuilder.SetMarka();
        //arabaBuilder.SetModel();
        //arabaBuilder.SetKM();
        //arabaBuilder.SetVites();

        arabaBuilder.SetMarka()
            .SetModel()
            .SetKM()
            .SetVites();

        return arabaBuilder.Araba;
    }
}

//Creator
class BuilderCreator
{
    static public ArabaBuilder Create(BuilderType builderType)
    {
        return builderType switch
        {
            BuilderType.Opel => new OpelBuilder(),
            BuilderType.Mercedes => new MercedesBuilder(),
            BuilderType.BMW => new BMWBuilder(),
        };
    }
}

enum BuilderType
{
    Opel, Mercedes, BMW
}