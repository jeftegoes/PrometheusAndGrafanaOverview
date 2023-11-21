# Grafana overview <!-- omit in toc -->

## Contents <!-- omit in toc -->

- [1. Telemetry](#1-telemetry)
  - [1.1. What is Telemetry?](#11-what-is-telemetry)
  - [1.2. Examples of Telemetric Data](#12-examples-of-telemetric-data)
  - [1.3. What's is the challenge?](#13-whats-is-the-challenge)
- [2. Grafana](#2-grafana)
  - [2.1. Alerts in Grafana](#21-alerts-in-grafana)
  - [2.2. Integrations](#22-integrations)
    - [2.2.1. AWS CloudWatch](#221-aws-cloudwatch)
  - [2.3. Administration](#23-administration)
- [3. Prometheus](#3-prometheus)
  - [3.1. Third-party exporters](#31-third-party-exporters)
  - [3.2. Retrieving Metrics](#32-retrieving-metrics)
    - [3.2.1. Data Model](#321-data-model)
    - [3.2.2. Data Types](#322-data-types)
      - [3.2.2.1. Scalar](#3221-scalar)
      - [3.2.2.2. Instant Vectors](#3222-instant-vectors)
      - [3.2.2.3. Range Vectors](#3223-range-vectors)
    - [3.2.3. Opeators](#323-opeators)
    - [3.2.4. Comparison Binary Operators](#324-comparison-binary-operators)
    - [3.2.5. Set Binary Operators](#325-set-binary-operators)
    - [3.2.6. Aggregation Operators](#326-aggregation-operators)
  - [3.3. Functions](#33-functions)
  - [3.4. Alerting](#34-alerting)
  - [3.5. Recording Rules](#35-recording-rules)
  - [3.6. Service Discovery](#36-service-discovery)
  - [3.7. Push Gateway](#37-push-gateway)
  - [3.8. Node Exporter](#38-node-exporter)
  - [3.9. Scraping Wintows Metrics](#39-scraping-wintows-metrics)
  - [3.10. Authentication](#310-authentication)
    - [3.10.1. Command to enable SSL / HTTPs](#3101-command-to-enable-ssl--https)
    - [3.10.2. Securing Push Gateway HTTPs + Auth](#3102-securing-push-gateway-https--auth)
    - [3.10.3. Securing Alert Manager](#3103-securing-alert-manager)
- [4. Tips \& Tricks](#4-tips--tricks)
  - [4.1. Docker](#41-docker)
  - [4.2. Dotnet MetricServer](#42-dotnet-metricserver)

# 1. Telemetry

![Telemetry diagram](Images/TelemetryDiagram.png)

## 1.1. What is Telemetry?

- Telemetry is the automatic recording and transmission of data from remote or inaccessible sources to an IT system in a different location form monitoring and analysis.
- In software refers to the collection of business and diagnosis data from the software in production, and store and visualise it for the purpose of diagnosing production issues or improving the business.

## 1.2. Examples of Telemetric Data

- Average of time taken to connect to a database over time.
- The number of received orders per minute.
- The average value of refunds per day.
- How many erros and exceptions?
- What is the response time?
- How many times api is called?
- How many servers?
- How many users from Brazil?

## 1.3. What's is the challenge?

- Organizations rely more and more on telemetric data.
- Companies want to bring different data together.
- Telemetric data reside in different datasources.

# 2. Grafana

- Open-source software to:
  - Visualizes Time Series (telemetry) Data.
    - Time Series data has time stamps attached to it: One Order at 01/01/2022.
  - Brings data from different datasources together.
  - Defines alerts.
  - Is extensible through plugins.
  - Multi-organizational.

## 2.1. Alerts in Grafana

- Alerts are defined Graph Panel.
- Eachg Graph Panel can have one to many alerts.
- Alerts rise when a Rule is violated.
- A Rule indicates if a value on the graph is above or below a threshold.
- Rules are stored in and evaluated by Rule Engine.

![Alert diagram](/Images/AlertDiagram.png)

## 2.2. Integrations

### 2.2.1. AWS CloudWatch

![CloudWatch Datasource diagram](/Images/CloudWatchDatasource.png)

## 2.3. Administration

![Administration diagram](/Images/AdministrationDiagram.png)

# 3. Prometheus

- General view
  ![Data Collection](Images/DataCollection.png)

## 3.1. Third-party exporters

- There are a number of libraries and servers which help in exporting existing metrics from third-party systems as Prometheus metrics.
- This is useful for cases where it is not feasible to instrument a given system with Prometheus metrics directly (for example, HAProxy or Linux system stats).

## 3.2. Retrieving Metrics

### 3.2.1. Data Model

- Prometheus stores data as **time series**.
- Every time series is identified by metric name and labels.
- Labels are a key and value pair.
- Labels are optional:
  - `<metric name> {key=value, key=value, ...}`
  - `auth_api_hit {count=1, time_taken=800}`

### 3.2.2. Data Types

- **PromQL** = rometheus Query Language.

#### 3.2.2.1. Scalar

- Float
- String
- Store
  - `prometheus_http_requests_total {code="200", job="prometheus"}`
  - Query
    - `prometheus_http_requests_total {code=~"2.*", job="prometheus"}`
    - `prometheus_http_requests_total {code=200, job="prometheus"}`

#### 3.2.2.2. Instant Vectors

- Instant vector selectors allow the selection of a set of time series and a single sample value for each at a given timestamp (instant).
- Only a metric name is specified.
- Result can be filered by providing labels.
- `auth_api_hit 1`
- `auth_api_hit {count=1, time_taken=800}`

#### 3.2.2.3. Range Vectors

- Range Vectors are similar to Instant Vectors except they select a range of samples.
  - `label_name[time_spec]`.
  - `auth_api_hit[5m]`.

### 3.2.3. Opeators

| Operator | Description    |
| -------- | -------------- |
| +        | Addition       |
| -        | Subtraction    |
| \*       | Multiplication |
| /        | Division       |
| %        | Modulo         |
| ^        | Power          |

- Scalar + Instant Vector.
  - Applies to every value of instant vector.
- Instant Vector + Instant Vector.
  - Applies to every value of left vector and its matching value in the right vector.

### 3.2.4. Comparison Binary Operators

| Operator | Description        |
| -------- | ------------------ |
| ==       | Equal              |
| !=       | Non-equal          |
| >        | Greater            |
| <        | Less-than          |
| >=       | Greater or Equal   |
| <=       | Less-than or Equal |

### 3.2.5. Set Binary Operators

- Set binary operators can be applied on Instant Vectors only.
  - `and`
  - `or`
  - `unless`

### 3.2.6. Aggregation Operators

- Aggregate the elements of a single Instant Vector.
- The result is a new Instant Vector with aggregated values.

| Operator     | Description                                                   |
| ------------ | ------------------------------------------------------------- |
| sum          | Calculates sum over dimensions                                |
| min          | Selects mininum over dimensions                               |
| max          | Selects maximum over dimensions                               |
| avg          | Selects average over dimensions                               |
| count        | Selects number of elements over dimensions                    |
| group        | Group elements. All values in resulting vector are equal to 1 |
| count_values | Counts the number of elements with the same values            |
| topk         | Largest elements by sample value                              |
| bottomk      | Smallest elements by sample value                             |
| stddev       | Finds population standard deviation over dimensions           |
| stdvar       | Finds population standard variation over dimensions           |

## 3.3. Functions

- Checks if an **Instant Vector** has any members Returns an empty vector if parameter has elements.
  - `absent(<Instant Vector>)`
- Checks if a **Range Vector** has any members Returns an empty vector if parameter has elements.
  - `absent_over_time(<Range Vector>)`
- Converts all values to their absolute value e.g., -5 to 5.
  - `abs(<Instant Vector>)`
- Converts all values to their nearest larger integer e.g.,1.6 to 2.
  - `ceil(<Instant Vector>)`
- Converts all values to their nearest smaller integer e.g., 1.6 to 1.
  - `flor(<Instant Vector>)`
- `clamp(<Instant Vector>, min, max)`
  - `clamp_min(<Instant Vector>, min)`
  - `clamp_max(<Instant Vector>, max)`

## 3.4. Alerting

## 3.5. Recording Rules

- Computed metrics:
  - `avg`
  - `sum`
  - `count`
- Rules are defined in .yml files.
- In linux-based operating systems put .yml files in /etc/prometheus/rules.
- In other operating syustems put .yml files in a folder i.e. "rules".

## 3.6. Service Discovery

- Prometheus provides a generic HTTP Service Discovery, that enables it to discover targets over an HTTP endpoint.
- The HTTP Service Discovery is complimentary to the supported service discovery mechanisms, and is an alternative to File-based Service Discovery.

## 3.7. Push Gateway

- A push gateway is a component of Prometheus.
  - It's part of Prometheus, which what it does basically is that it acts as temporary storage, where application can send the metric to it.
  - ![Push Gateway](Images/PushGateway.png)
- Implementation detail
  - ![Push Gateway](Images/PushGatewaySimpleCommunication.png)

## 3.8. Node Exporter

- Every UNIX-based kernel e.g. computer is called a Node.
- **Node Exporter** is an official Prometheus exporter for collecting metrics that are exposed by Unix-based kernls e.g. Linux and Ubuntu.
- Example of metrics are CPU, Disk, Memory and Network I/O.
- **Node Exporter** can be extended with pluggable metric collectors.

## 3.9. Scraping Wintows Metrics

- There is no official Prometheus exporter for Windows.
- WMI: Windows Management Instrumentation.
  - **Infrasctructure for management data and operations on Windows-based operating systems.**
- WMS Exporter is a third-party Prometheus exporter for Windows.

## 3.10. Authentication

- There are many aspects to protect when we think about Prometheus, like:
- Securing Web UI.
- Securing Push Gateway.
- Securing Exporters.
- Securing Alert Manager.

### 3.10.1. Command to enable SSL / HTTPs

`openssl req -new -newkey rsa:2048 -days 365 -nodes -x509 -keyout node_exporter.key -out node_exporter.crt -subj "/C=BE/ST=Antwerp/L=Brasschaat/O=Inuits/CN=localhost" `

### 3.10.2. Securing Push Gateway HTTPs + Auth

- Basic auth:

```
  - job_name: "pushgateway"
    scheme: https
    tls_config:
      ca_file: /usr/local/etc/prom.crt
      server_name: 'localhost'
    basic_auth:
      username: admin
      password: password
    static_configs:
    - targets: ["localhost:9091"]
```

- Example pushgateway.yml:

```
  tls_server_config:
    cert_file: /usr/local/etc/prom.crt
    key_file:  /usr/local/etc/prom.key

  basic_auth_users:
    admin: <my_key>
```

- Command to start with web.yml
  - `./pushgateway --web.config.file=/usr/local/etc/pushgateway.yml`

### 3.10.3. Securing Alert Manager

- Example prometheus.yml:
  ```
    alerting:
      alertmanagers:
      - scheme: https
        tls_config:
          ca_file: /usr/local/etc/prom.crt
          server_name: 'localhost'
        basic_auth:
          username: admin
          password: password
      - static_configs:
        - targets:
          - localhost:9093
  ```

# 4. Tips & Tricks

## 4.1. Docker

- Since the targets are not running inside the prometheus container, they cannot be accessed through localhost.
- You need to access them through the host private IP or by replacing localhost with `docker.for.mac.localhost` or `host.docker.internal`.
  - On Windows:
    - `host.docker.internal` (tested on win10, win11)
  - On Mac
    - `docker.for.mac.localhost`
  - Example:
  ```
    - job_name: "pushgateway"
      static_configs:
        - targets: ["host.docker.internal:9092"]
  ```

## 4.2. Dotnet MetricServer

- To avoid this error _Unhandled exception. System.Net.HttpListenerException (5): Access is denied_.
  - Run this command `netsh http add urlacl url=http://+:8008/ user=Everyone listen=yes` as administrator.
