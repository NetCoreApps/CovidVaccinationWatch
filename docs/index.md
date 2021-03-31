---
title: COVID Vac Watch Service Docs
---

COVID Vac Watch is a demo endpoint that takes data from a public "Our World In Data" repository and exposes the daily vaccination rates of the United States via a ServiceStack service.
> This is a **DEMO** application only and should not be used as a primary source of information. Please see [Our World In Data Repository](https://github.com/owid/covid-19-data) for source of data. 

## Original source

Data is pulled from `owid/covid-19-data` repository and specifically makes use of the [US State Vaccination data](https://github.com/owid/covid-19-data/blob/master/public/data/vaccinations/us_state_vaccinations.csv).

This data is only updated once per startup or manual reset to reduce how ofen it pulls from GitHub source.
