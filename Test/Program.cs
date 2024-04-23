
namespace MyProject;

class Program
{
    static async Task Main(string[] args)
    {
        var bomb = new Bomb();
        await bomb.TriggerCountdown(5);
    }
}

class Bomb
{
    public async Task TriggerCountdown(int countDownFrom)
    {
        var timer = new PeriodicTimer(TimeSpan.FromSeconds(1.0));
        var secondsRemaining = countDownFrom;

        Console.WriteLine("This bomb will explode in...");
        while (await timer.WaitForNextTickAsync()) 
        {
            if (secondsRemaining > 0)
            {
                Console.WriteLine(string.Format("{0} seconds,", secondsRemaining));
                secondsRemaining--;
            }
            else
            {
                Console.WriteLine("BOOM!");
                timer.Dispose();
            }
        }
    }
}
