```sh
az group create --name rgSuga --location EastUS2
```

```sh
 az deployment group create --resource-group rgSuga --template-file template.json --parameters sqlServerName=sugasql administratorLogin=suga administratorLoginPassword=Sugan@1234!@#$
```

```sh
 az group delete --name rgSuga
```
