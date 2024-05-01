
//new Example();
//new Example();
//new Example();
//new Example();
//new Example();

Example e1 = Example.GetInstance;
Example e2 = Example.GetInstance;
Example e3 = Example.GetInstance;
Example e4 = Example.GetInstance;
Example e5 = Example.GetInstance;

class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu.");
    }

    /// <summary>
    /// static constructer uygulama üzerinde bu sınıf için ilk nesne oluşturulurken yada ilk static member kullanılırken default const dan önce ilk çağrılır.
    /// 2. yöntem için
    /// </summary>
    static Example()
    {
        _example = new Example();
    }
    static Example _example;
    public static Example GetInstance
    {
        get
        {
            #region 1. Yöntem

            //if (_example == null) _example = new Example();
            //return _example;

            #endregion

            #region 2. Yöntem

            return _example;

            #endregion
        }
    }
}