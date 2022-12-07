# Docker 🐳

To run the containers, you must first modify the environment variables according to your needs and after that create the images.
#

## Database 🛢

### Environment variables ⚙

Inside the database/admin folder there is an .env file, the environment variables found there are the following:

* DATABASE_HOST: Write the host you want for the db (by default it will be 127.0.0.1)
* POSTGRES_USER: Write the user you want for the db
* POSTGRES_PASSWORD: Write the password you want for the db
* POSTGRES_DB: Write the name you want for the db
* USER_ADMIN: Write the email of the person who will be the admin of the system and will be in charge of registering the other users. Make sure that the email is written the same as it appears in the active directory, with the upper and lower case letters it has

### Dockerfile 🚀

To build the image you have to be inside the database folder and execute the following command:

```
docker build -t postgresgei:latest .
```
 
Aftert that execute the following command to run the container

```
docker run --name postgei -it -p 5432:5432 --env-file ./admin/.env postgresgei:latest
```
#

## Inventario 💻

### Environment variables ⚙

Inside the inventory/ folder there is a variables.properties file and an .env file, the environment variables found in the variables.properties file are as follows:

* HOST: Write the IP address where it will be the db
* PORT: Write the port where the db server listen
* USER: Write the user that you wrote in the .env from db
* DATABASE: Write the name of the database that you wrote in the .env from db
* PASS: Write the pass that you wrote in the .env from db
* DOMAIN: Write the host that you wrote in the .env from db
* TENANT_ID: Enter the tenant Id that appears in the azure portal from your active directory
* CLIENT_ID: Enter the client Id that appears in the azure portal from your active directory

And inside the .env file are the following environment variables:

* DOTNET_GENERATE_ASPNET_CERTIFICATE: Set true if you want that dotnet generate the ssl certificate
* ASPNETCORE_URLS: Wrire the port in the next format https://+:5000
* ASPNETCORE_ENVIRONMENT: Write release or development depending on the environment to be run
#

### Dockerfile 🚀

To build the image you have to be inside the inventario folder and execute the following command:

```
docker build -t inventariogei:latest .
```
 
Aftert that execute the following command to run the container

```
docker run --name gei -p 5000:5000 -p 5001:5001 --env-file ./.env inventariogei
```
#
## Docker-compose
If you want to run all containers, you can run docker-compose with the following command and inside the docker folder:

```
docker compose up
```
