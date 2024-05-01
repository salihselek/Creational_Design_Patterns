/*
 nesneye ihtiyaç olan yerlerde, nesneyi oluşturmak yerine nesneyi istiyoruz.
 */

for (int i = 0; i < 10; i++)
{
    try
    {
        A a1 = (A)ProductCreator.GetInstance(ProductType.A);
        a1.Run();


        B b1 = (B)ProductCreator.GetInstance(ProductType.B);
        b1.Run();
    }
    catch (Exception ex)
    {
        throw;
    }
}

#region Abstract Product

interface IProduct
{
    void Run();
}

#endregion


#region Concrete Product

class A : IProduct
{
    public void Run()
    {
        Console.WriteLine($"{nameof(A)} runnig.");
    }
}
class B : IProduct
{
    public void Run()
    {
        Console.WriteLine($"{nameof(B)} runnig.");
    }
}
class C : IProduct
{
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
        IProduct _product = null;
        switch (productType)
        {
            case ProductType.A:
                _product = new A();
                //...ekstra çalışmalar
                break;
            case ProductType.B:
                _product = new B();
                //...ekstra çalışmalar
                break;
            case ProductType.C:
                _product = new C();
                //...ekstra çalışmalar
                break;
        }
        return _product;
    }
}

#endregion