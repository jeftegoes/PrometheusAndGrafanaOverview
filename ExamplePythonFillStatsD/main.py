import statsd

for counter in range(0, 100):
    stats_client = statsd.StatsClient("localhost", 8125)
    stats_client.incr("shoehub.test:1|c")
    stats_client.timing("stats.timed", 320)
    print(f"Metric {counter} was sent!")
