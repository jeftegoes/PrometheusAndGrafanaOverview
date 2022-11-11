- [1. Telemetry](#1-telemetry)
  - [1.1. What is Telemetry?](#11-what-is-telemetry)
  - [1.2. Examples of Telemetric Data](#12-examples-of-telemetric-data)
  - [1.3. Whats is the challenge?](#13-whats-is-the-challenge)
  - [1.4. Grafana](#14-grafana)
  - [1.5. What is Graphinte?](#15-what-is-graphinte)
    - [1.5.1. Buckets in Graphite](#151-buckets-in-graphite)
  - [What is StatsD?](#what-is-statsd)

# 1. Telemetry

## 1.1. What is Telemetry?

- Telemetry is the automatic recording and transmission of data from remote or inacessible sources to an IT system in a different location form monitoring and analysis.

## 1.2. Examples of Telemetric Data

- Average of time taken to connect to a database over time.
- The number of received orders per minute.
- The average value of refunds per day.

## 1.3. Whats is the challenge?

- Organisations rely more and more on telemetric data.
- Companies want to bring different data together.
- Telemetric data reside in different datasources.

## 1.4. Grafana

- Visualizes Time Series (telemetry) Data.
  - Time Series data has time stamps attached to it: One Order at 01/01/2022.
- Brings data from different datasources together.
- Defines alerts.
- Is extensible through plugins.

## 1.5. What is Graphinte?

- Graphite is predominantly used for storing telemetric data.
- Providers a rich set of functions to work with telemetric data.
- Is free and open source.
- Is easy to setup and use, and is enterprise-ready.
- Supports timers, counters and gauges.

### 1.5.1. Buckets in Graphite

- A bucket is a collection of telemetry data.
- Bucket tree is identified by a "." character. e.g. Shoes.Loafers.Count.
- The value of a counter bucket is increased by the value it receives.
- A ageuge bucket value is set by the valie it receives.
- A timer's value is set by the value it receives.

## What is StatsD?

- Is used for collecting data and passing them to Graphite.
- Data is sent to StatsD as plain text.
- By default works on UUDP protocol.
- Data format is `<bucket>:<value>|Type`
- Example: `Sales.Jackets:1|C`

