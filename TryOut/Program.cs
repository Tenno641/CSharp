void Method1(int number, string word) => Console.WriteLine($"{number}.{word}");
void Method2(int number, string word) => Console.WriteLine($"{number}v1.2 . {word}v1.2");

Method methodsChain = Method1;
methodsChain += Method1;
methodsChain += Method2;

methodsChain(1, "wordy");

EmailPriceChangeNotifier emailPriceChangeNotifier = new(30_000);
PushPriceChangeNotifier pushPriceChangeNotifier = new(25_000);

GoldPriceReader goldPriceReader = new();
goldPriceReader.eventHandler += emailPriceChangeNotifier.Update;
goldPriceReader.eventHandler += pushPriceChangeNotifier.Update;
for(int i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrentPrice();
}

public delegate void Method(int number, string word);
public delegate void PriceRead(decimal price);
public class GoldPriceReader
{
    public event EventHandler<PriceEventArgs>? eventHandler;
    public void ReadCurrentPrice()
    {
        decimal currentGoldPrice = new Random().Next(
            20_000, 50_000);
        eventHandler?.Invoke(this, new PriceEventArgs(currentGoldPrice));
    }
}

public class PriceEventArgs : EventArgs
{
    public decimal Price { get; }
    public PriceEventArgs(decimal price)
    {
        Price = price;
    }
}

public class EmailPriceChangeNotifier
{
    private readonly decimal _notificationThreshold;

    public EmailPriceChangeNotifier(
        decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(object? sender, PriceEventArgs e)
    {
        if (e.Price > _notificationThreshold)
        {
            //imagine this is actually sending an email
            Console.WriteLine(
                $"Sending an email saying that " +
                $"the gold price exceeded {_notificationThreshold} " +
                $"and is now {e.Price}\n");
        }
    }
}

public class PushPriceChangeNotifier{
    private readonly decimal _notificationThreshold;

    public PushPriceChangeNotifier(
        decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(object? sender, PriceEventArgs e)
    {
        if (e.Price > _notificationThreshold)
        {
            //imagine this is actually sending a push notification
            Console.WriteLine(
                $"Sending a push notification saying that " +
                $"the gold price exceeded {_notificationThreshold} " +
                $"and is now {e.Price}\n");
        }
    }
}