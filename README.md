# Grafana overview <!-- omit in toc -->

## Contents <!-- omit in toc -->

- [1. Telemetry](#1-telemetry)
  - [1.1. What is Telemetry?](#11-what-is-telemetry)
  - [1.2. Examples of Telemetric Data](#12-examples-of-telemetric-data)
  - [1.3. What's is the challenge?](#13-whats-is-the-challenge)
  - [1.4. Grafana](#14-grafana)
  - [1.5. Alerts in Grafana](#15-alerts-in-grafana)
- [2. Integrations](#2-integrations)
  - [2.1. AWS CloudWatch](#21-aws-cloudwatch)
- [3. Administration](#3-administration)

# 1. Telemetry

## 1.1. What is Telemetry?

- Telemetry is the automatic recording and transmission of data from remote or inaccessible sources to an IT system in a different location form monitoring and analysis.

## 1.2. Examples of Telemetric Data

- Average of time taken to connect to a database over time.
- The number of received orders per minute.
- The average value of refunds per day.

## 1.3. What's is the challenge?

- Organizations rely more and more on telemetric data.
- Companies want to bring different data together.
- Telemetric data reside in different datasources.

## 1.4. Grafana

- Visualizes Time Series (telemetry) Data.
  - Time Series data has time stamps attached to it: One Order at 01/01/2022.
- Brings data from different datasources together.
- Defines alerts.
- Is extensible through plugins.

## 1.5. Alerts in Grafana

- Alerts are defined Graph Panel.
- Eachg Graph Panel can have one to many alerts.
- Alerts rise when a Rule is violated.
- A Rule indicates if a value on the graph is above or below a threshold.
- Rules are stored in and evaluated by Rule Engine.

![Alert diagram](/Images/AlertDiagram.png)

# 2. Integrations

## 2.1. AWS CloudWatch

![CloudWatch Datasource diagram](/Images/CloudWatchDatasource.png)

# 3. Administration

![Administration diagram](/Images/AdministrationDiagram.png)
