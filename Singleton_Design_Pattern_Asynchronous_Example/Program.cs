List<Task> tasks = new List<Task>();

for (int i = 0; i < 100; i++)
{
    tasks.Add(Task.Run(() =>
    {
        Example.GetInstance();
    }));
}

await Task.WhenAll(tasks);


//var t1 = Task.Run(() =>
//{
//    Example.GetInstance();
//});

//var t2 = Task.Run(() =>
//{
//    Example.GetInstance();
//});

//await Task.WhenAll(t1, t2);
//var t3 = Task.Run(() =>
//{
//    Example.GetInstance();
//});

//var t4 = Task.Run(() =>
//{
//    Example.GetInstance();
//});

//await Task.WhenAll(t3, t4);


/// <summary>
/// asenkron süreçler de nesneden 1 den fazla üretme sorunu olabilir. Bunu lock ile yada static constructer ile çözebiliriz
/// </summary>
class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu.");
    }
    static Example()
    {
        _example = new Example();
    }
    static Example _example;
    //static object _obj = new object();
    static public Example GetInstance()
    {
        //lock (_obj)
        //{
        //    if (_example == null)
        //        _example = new Example();
        //}
        return _example;
    }

}