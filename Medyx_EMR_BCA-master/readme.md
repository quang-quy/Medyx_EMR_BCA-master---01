# MEDYX

## setup

### server

```shell
dotnet restore
```

### frontend package install

```shell
yarn --cwd Client
```


### frontend dev

```shell
yarn --cwd Client serve
```

### frontend build 

```shell
yarn --cwd Client build
```

### create model entity

> :warning: **If already have Models by EF**: Dont run this command!

```cmd
Scaffold-DbContext Name=ConnectionStrings:Medyx_EMR_BCA_SQLConnectionString Microsoft.EntityFrameworkCore.SqlServer -Context MedyxDbContext -Output Db -f -v
```

### update model if table change
```cmd
Scaffold-DbContext Name=ConnectionStrings:Medyx_EMR_BCA_SQLConnectionString Microsoft.EntityFrameworkCore.SqlServer -Context MedyxDbContext -Output Db -f -v -t tableA,tableB
```
	1. copy field of model from folder Db to model in folder ApiAssets/Models
	2. update DBContext
### run serve

```shell
dotnet run
```