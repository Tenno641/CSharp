using System.Globalization;
using System.Text;

decimal price = 252.252m;

string result = string.Format("Price {0:C}", price);
Console.WriteLine(result);

string date = string.Format("date {0:D}", DateTime.Now);
Console.WriteLine(date);

CultureInfo currentCulture = CultureInfo.CurrentCulture;
Console.WriteLine(currentCulture);

CultureInfo.CurrentCulture = new CultureInfo("ar-SA");
Console.OutputEncoding = Encoding.UTF8;

string result2 = string.Format("Price {0:C}", price);
Console.WriteLine(result2);

string date2 = string.Format("date {0:D}", DateTime.Now);
Console.WriteLine(date2);

