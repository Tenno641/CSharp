void Method1(int number, string word) => Console.WriteLine($"{number}.{word}");
void Method2(int number, string word) => Console.WriteLine($"{number}v1.2 . {word}v1.2");

Method methodsChain = Method1;
methodsChain += Method1;
methodsChain += Method2;

methodsChain(1, "wordy");

EmailPriceChangeNotifier emailPriceChangeNotifier = new(30_000);
PushPriceChangeNotifier pushPriceChangeNotifier = new(25_000);

GoldPriceReader goldPriceReader = new();
goldPriceReader.priceRead += emailPriceChangeNotifier.Update;
goldPriceReader.priceRead += pushPriceChangeNotifier.Update;

for(int i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrentPrice();
}

public delegate void Method(int number, string word);
public delegate void PriceRead(decimal price);
public class GoldPriceReader
{
    public event PriceRead? priceRead;

    public void ReadCurrentPrice()
    {
        decimal currentGoldPrice = new Random().Next(
            20_000, 50_000);
        priceRead?.Invoke(currentGoldPrice);

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

    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            //imagine this is actually sending an email
            Console.WriteLine(
                $"Sending an email saying that " +
                $"the gold price exceeded {_notificationThreshold} " +
                $"and is now {price}\n");
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

    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            //imagine this is actually sending a push notification
            Console.WriteLine(
                $"Sending a push notification saying that " +
                $"the gold price exceeded {_notificationThreshold} " +
                $"and is now {price}\n");
        }
    }
}