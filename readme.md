### Docker MSSQL Server
Download docker image for sql server and activate it
```docker
docker pull microsoft/mssql-server-linux
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=ProductApi(!)' -e 'MSSQL_PID=Express' -p 1433:1433 --name=catalogdb microsoft/mssql-server-linux
docker start catalogdb

```