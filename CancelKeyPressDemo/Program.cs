
// https://www.meziantou.net/handling-cancelkeypress-using-a-cancellationtoken.htm
using var cts = new CancellationTokenSource();
Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true;
    cts.Cancel();
};

await MainAsync(args, cts.Token);

static async Task MainAsync(string[] args, CancellationToken cancellationToken)
{
    try
    {
        while (true)
        {
            Console.WriteLine("Waiting..");
            await Task.Delay(10_000, cancellationToken);
        }
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Operation canceled");
    }
}
