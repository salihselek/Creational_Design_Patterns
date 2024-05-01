
#region Abstract Factory

interface IFactory
{
    IProduct CreateProduct();
}

#endregion

#region Concrete Factories

class AFactory : IFactory
{
    public IProduct CreateProduct()
    {
        A a = new A();
        return a;
    }
}
class BFactory : IFactory
{
    public IProduct CreateProduct()
    {
        B b = new B();
        return b;
    }
}
class CFactory : IFactory
{
    public IProduct CreateProduct()
    {
        C c = new C();
        return c;
    }
}

#endregion

#region Abstract Product

interface IProduct
{
    void Run();
}

#endregion

#region Concrete Product

class A : IProduct
{
    public A()
    {
        Console.WriteLine($"{nameof(A)} nesnesi üretildi.");
    }
    public void Run()
    {
        Console.WriteLine($"{nameof(A)} runnig.");
    }
}
class B : IProduct
{
    public B()
    {
        Console.WriteLine($"{nameof(B)} nesnesi üretildi.");
    }
    public void Run()
    {
        Console.WriteLine($"{nameof(B)} runnig.");
    }
}
class C : IProduct
{
    public C()
    {
        Console.WriteLine($"{nameof(C)} nesnesi üretildi.");
    }
    public void Run()
    {
        Console.WriteLine($"{nameof(C)} runnig.");
    }
}

#endregion

#region Creator
enum ProductType
{
    A, B, C
}
class ProductCreator
{
    public static IProduct GetInstance(ProductType productType)
    {
        IFactory _factory = productType switch
        {
            ProductType.A => new AFactory(),
            ProductType.B => new BFactory(),
            ProductType.C => new CFactory()
        };
        return _factory.CreateProduct();
    }
}

#endregion