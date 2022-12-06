VARIABLESFILE=variables.properties

if [ -f "$VARIABLESFILE" ]
then
source $VARIABLESFILE
echo Editanto el archivo appsettings.json
  cat > ./appsettings.json <<EOF
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "Domain": "${DOMAIN}",
    "TenantId": "${TENANT_ID}",
    "ClientId": "${CLIENT_ID}",
    "CallbackPath": "/signin-oidc"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "IdentityConnection": "Host=${HOST};Port=${PORT};Pooling=true;Database=${DATABASE};User Id=${USER};Password=${PASS};"
  }
}
EOF

echo "archivo creado"
cat appsettings.json
else
    echo "Archivo de variables no encontrado."
fi

