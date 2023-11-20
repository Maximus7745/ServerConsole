using ServerConsole;

Parallel.For(0, 50, i =>
{
    if (i % 5 == 0)
        Server.AddToCount(i);
    else
        Console.WriteLine(Server.GetCount());
});

