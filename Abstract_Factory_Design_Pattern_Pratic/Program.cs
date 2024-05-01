/*
 * Geliştirici olarak Computer ihtiyaç duyulan noktada, computer alt bileşenlerini oluşturmak doğru değildir.
 */

//Computer computer1 = new Computer();

//CPU cpu1 = new CPU();
//computer1.CPU = cpu1;

//RAM ram1 = new RAM();
//computer1.RAM = ram1;

//VideoCard videoCard1 = new VideoCard();
//computer1.VideoCard = videoCard1;


//Computer computer2 = new Computer(new(), new(), new());


ComputerCreator creator = new();
Computer asus = creator.CreateComputer(new AsusFactory());

Computer toshiba = creator.CreateComputer(new ToshibaFactory());


class Computer
{
    public Computer()
    {

    }
    public Computer(ICPU cpu, IRAM ram, IVideoCard videoCard)
    {
        CPU = cpu;
        RAM = ram;
        VideoCard = videoCard;
    }

    public ICPU CPU { get; set; }
    public IRAM RAM { get; set; }
    public IVideoCard VideoCard { get; set; }
}

#region Abstract Products
interface ICPU
{

}

interface IRAM
{

}
interface IVideoCard
{

}
#endregion

#region Concrete Products

class CPU : ICPU
{
    public CPU(string text) => Console.WriteLine(text);
}
class RAM : IRAM
{
    public RAM(string text) => Console.WriteLine(text);
}
class VideoCard : IVideoCard
{
    public VideoCard(string text) => Console.WriteLine(text);
}
#endregion

#region Abstract Factory
interface IComputerFactory
{
    ICPU CreateCPU();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();
}
#endregion

#region Concrete Factories
class AsusFactory : IComputerFactory
{
    public ICPU CreateCPU() => new CPU("Asus CPU üretildi.");

    public IRAM CreateRAM() => new RAM("Asus RAM üretildi.");

    public IVideoCard CreateVideoCard() => new VideoCard("Asus VideoCard üretildi.");
}


class ToshibaFactory : IComputerFactory
{
    public ICPU CreateCPU() => new CPU("Toshiba CPU üretildi.");

    public IRAM CreateRAM() => new RAM("Toshiba RAM üretildi.");

    public IVideoCard CreateVideoCard() => new VideoCard("Toshiba VideoCard üretildi.");
}

class MSIFactory : IComputerFactory
{
    public ICPU CreateCPU() => new CPU("MSI CPU üretildi.");

    public IRAM CreateRAM() => new RAM("MSI RAM üretildi.");

    public IVideoCard CreateVideoCard() => new VideoCard("MSI VideoCard üretildi.");
}
#endregion

#region Creator
class ComputerCreator
{
    ICPU _cpu;
    IRAM _ram;
    IVideoCard _videoCard;
    public Computer CreateComputer(IComputerFactory computerFactory)
    {
        _cpu = computerFactory.CreateCPU();
        _ram = computerFactory.CreateRAM();
        _videoCard = computerFactory.CreateVideoCard();

        return new(_cpu, _ram, _videoCard);
    }

}
#endregion