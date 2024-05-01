/*
 *Abstract Factory Design pattern e ekstra olarak, Factory Method Design pattern de uygulanmıştır. AsusFactory gibi facttory lerin üretimi Creator a geçirilmiştir.
 */

ComputerCreator creator = new();
Computer asus = creator.CreateComputer(ComputerType.Asus);
Computer toshiba = creator.CreateComputer(ComputerType.Toshiba);
Computer msi = creator.CreateComputer(ComputerType.MSI);


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

enum ComputerType
{
    Asus, Toshiba, MSI
}
class ComputerCreator
{
    ICPU _cpu;
    IRAM _ram;
    IVideoCard _videoCard;
    public Computer CreateComputer(ComputerType computerType)
    {
        IComputerFactory computerFactory = computerType switch
        {
            ComputerType.Asus => new AsusFactory(),
            ComputerType.Toshiba => new ToshibaFactory(),
            ComputerType.MSI => new MSIFactory(),
        };

        _cpu = computerFactory.CreateCPU();
        _ram = computerFactory.CreateRAM();
        _videoCard = computerFactory.CreateVideoCard();

        return new(_cpu, _ram, _videoCard);
    }

}
#endregion