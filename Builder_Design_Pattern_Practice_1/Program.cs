/*
Araba mercedes = new();
mercedes.KM = 0;
mercedes.Marka = "Mercedes";
mercedes.Model = "CLA";
mercedes.Vites = true;

Araba bmw = new();
bmw.KM = 10;
bmw.Marka = "BMW";
bmw.Model = "X6";
bmw .Vites = false;
*/


ArabaDirector director = new();
Araba opel = director.Build(new OpelBuilder());
opel.ToString();
Araba mercedes = director.Build(new MercedesBuilder());
mercedes.ToString();
Araba bmw = director.Build(new BMWBuilder());
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


#region Interface ile AbstractBuilder ın tasarlanması

////Abstract Builder
//interface IArabaBuilder
//{
//    public Araba Araba { get; }

//    IArabaBuilder SetMarka();
//    IArabaBuilder SetModel();
//    IArabaBuilder SetKM();
//    IArabaBuilder SetVites();
//}

////Concrete Builder
//class OpelBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }

//    public OpelBuilder() => Araba = new();


//    public IArabaBuilder SetKM()
//    {
//        Araba.KM = 0;
//        return this;
//    }

//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Opel";
//        return this;
//    }

//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "Astra";
//        return this;
//    }

//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}

////Concrete Builder
//class MercedesBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }
//    public MercedesBuilder() => Araba = new();

//    public IArabaBuilder SetKM()
//    {
//        Araba.KM = 100;
//        return this;
//    }

//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Mercedes";
//        return this;
//    }

//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "CLA";
//        return this;
//    }

//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}

////Concrete Builder
//class BMWBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }
//    public BMWBuilder() => Araba = new();

//    public IArabaBuilder SetKM()
//    {
//        Araba.KM = 10;
//        return this;
//    }

//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "BMW";
//        return this;
//    }

//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "X6";
//        return this;
//    }

//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = false;
//        return this;
//    }
//}

////Director
//class ArabaDirector
//{
//    public Araba Build(IArabaBuilder arabaBuilder)
//    {
//        //arabaBuilder.SetMarka();
//        //arabaBuilder.SetModel();
//        //arabaBuilder.SetKM();
//        //arabaBuilder.SetVites();

//        arabaBuilder.SetMarka()
//            .SetModel()
//            .SetKM()
//            .SetVites();

//        return arabaBuilder.Araba;
//    }
//}
#endregion

#region Abstract class ile AbstractBuilder ın tasarlanması

//Abstract Builder
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

//Concrete Builder
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

//Concrete Builder
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

//Concrete Builder
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
#endregion