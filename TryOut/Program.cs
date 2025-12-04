using Listy;


Listy.LinkedList<string> listy = new Listy.LinkedList<string>();
listy.AddToFront("fron_1");
listy.AddToFront("front_2");
listy.AddToFront("front_3");
listy.Add("end_1");
listy.Add("end_2");
Console.WriteLine(listy.Contains("front_3"));
foreach(string? number in listy)
{
    Console.WriteLine(number);
}
