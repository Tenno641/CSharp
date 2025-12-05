using DesignPatterns.HighLevel;

FlyweightFactory factory = new();
Client client = new Client(factory);

client.operation("Hello");
client.operation("Hey");
client.operation("Word");
client.operation("Welcome");
