using Prometheus;

var register = Metrics.NewCustomRegistry();
var factory = Metrics.WithCustomRegistry(register);

var pusher = new MetricPusher(new MetricPusherOptions
{
    Endpoint = "http://localhost:9092/metrics",
    Job = "Dotnet PushGateway Example",
    Instance = "Instance Test",
    Registry = register
});

pusher.Start();

var cancellationTokenSource = new CancellationTokenSource();

var requestGenerator = new Thread(() =>
{
    while (!cancellationTokenSource.Token.IsCancellationRequested)
    {
        var gauge = factory.CreateGauge("dotnet_pushgateway_test", "test");
        gauge.Set(new Random(DateTime.Now.Millisecond).Next() * 100);
        Thread.Sleep(100);
        Console.WriteLine("Running... {0}", DateTime.Now);
    }
});

requestGenerator.Start();
Console.WriteLine("Press ENTER to stop the application.");
Console.ReadLine();

cancellationTokenSource.Cancel();
pusher.Stop();