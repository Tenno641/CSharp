var cancellationTokenSource = new CancellationTokenSource();

try
{
    var task = Task.Run(() => NeverEndingMethod(cancellationTokenSource), cancellationTokenSource.Token);
    var task2 = Task.Run(() => NeverEndingMethod2(cancellationTokenSource), cancellationTokenSource.Token);
    Task.WaitAll(task, task2);
} catch(AggregateException ex)
{
    foreach(Exception exception in ex.InnerExceptions)
    {
        Console.WriteLine(exception.Message);
        Console.WriteLine(exception);
    }
}
//string userInput;
//do
//{
//    userInput = Console.ReadLine();
//} while (userInput != "cancel");
//cancellationTokenSource.Cancel();

void NeverEndingMethod(CancellationTokenSource tokenSource)
{
    while (true)
    {
        //tokenSource.Token.ThrowIfCancellationRequested();
        throw new NullReferenceException("lol awy");
        throw new NullReferenceException("el mrar el tafe7");
        Thread.Sleep(1000);
        Console.WriteLine("Another one");
    }
}

void NeverEndingMethod2(CancellationTokenSource tokenSource)
{
    while (true)
    {
        //tokenSource.Token.ThrowIfCancellationRequested();
        throw new NullReferenceException("el mrar el tafe7");
        Thread.Sleep(1000);
        Console.WriteLine("Another one");
    }
}