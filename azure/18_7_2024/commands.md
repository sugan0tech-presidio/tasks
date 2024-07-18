```sh 
az deployment group create --name sugaStorage --resource-group rgSuga --template-file azure.json
```

```sh  
az deployment group create --name sugaStorage --resource-group rgSuga --template-file templateWithValidations.json --parameters storageName=sugaStorage  storageAccountType=Standard_LRS
```

