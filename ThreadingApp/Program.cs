static Task Test(string? input)
{
    var task = Task.Run(() => ParseToIntAndPrint(input))
     .ContinueWith(
        faultedTask => faultedTask.Exception?.Handle(ex =>
        {
            if (HandleExceptionMessage<ArgumentNullException>(ex, "The input if null.")) return true;
            if (HandleExceptionMessage<FormatException>(ex, "The input is not in a correct format.")) return true;
            if (HandleExceptionMessage<ArgumentOutOfRangeException>(ex, "Unexpected exception type")) return false;
            return false;
        }), TaskContinuationOptions.OnlyOnFaulted);

    return task;
}
static bool HandleExceptionMessage<T>(Exception exception, string message = "")
{
    if (exception is T)
    {
        Console.WriteLine(message);
        return true;
    }
    return false;
}

static void ParseToIntAndPrint(string? input)
{
    if (input is null)
    {
        throw new ArgumentNullException();
    }

    if (long.TryParse(input, out long result))
    {
        if (result > int.MaxValue)
        {
            throw new ArgumentOutOfRangeException("The number is too big for an int.");
        }
        Console.WriteLine("Parsing successful, the result is: " + result);
    }
    else
    {
        throw new FormatException();
    }
}