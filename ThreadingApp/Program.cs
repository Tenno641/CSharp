 static void RunThreads()
{
    Thread[] threads = new Thread[]
    {
                new Thread(Greet),
                new Thread(Greet),
                new Thread(Greet)
    };
    foreach (Thread thread in threads)
    {
        thread.Start();
    }
}

 static void Greet()
{
    Console.WriteLine($"Hello from thread with ID: {Thread.CurrentThread.ManagedThreadId}");
}