```sh
az group create --name rgSuga --location WestUS2
```

```sh
az deployment group create --resource-group rgSuga --template-file template.json --parameters keyVaultName=sugaVault
```

```sh
az keyvault secret set --vault-name sugaVault --name "DB" --value "db:URL"
```

```sh
az group delete --name rgSuga
```
