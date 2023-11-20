using System.Diagnostics;
using Prometheus;

var counter = Metrics.CreateCounter("dotnet_counter", "My Dotnet Counter", ["foo", "bar"]);
var gauge = Metrics.CreateGauge("dotnet_gauge", "My Gauge", ["foo", "bar"]);
var summary = Metrics.CreateSummary("dotnet_summary", "My Summary");

void RaiseException()
{
    throw new NotImplementedException(string.Empty);
}
var server = new MetricServer(8008);
server.Start();

var watcher = new Stopwatch();
watcher.Start();
Thread.Sleep(1000);
watcher.Stop();

summary.Observe(watcher.ElapsedMilliseconds);

try
{
    counter.WithLabels("1", "2").CountExceptions(() => RaiseException());
}
catch
{

}

while (true)
{
    counter.Inc();
    gauge.WithLabels("1", "2").Set(100);
    gauge.Dec(10);

    Thread.Sleep(1000);
}