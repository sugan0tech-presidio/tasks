docker pull for sqlserver
```bash
docker pull mcr.microsoft.com/mssql/server
```
docker run command for sqlserver
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Sugan123" -p 1433:1433 -d mcr.microsoft.com/mssql/server
```
