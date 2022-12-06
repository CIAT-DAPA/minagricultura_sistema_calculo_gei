FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /App 
RUN apt-get update && \
    apt-get install -y \
        vim \
        unzip \
        wget 
RUN wget https://github.com/CIAT-DAPA/minagricultura_sistema_calculo_gei/releases/download/1.0.0/invent.zip
RUN unzip invent.zip 
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust
COPY ./script.sh ./
COPY ./variables.properties ./
RUN bash script.sh
EXPOSE 5000 
EXPOSE 5001
ENTRYPOINT ["dotnet", "InventarioGEI.dll"]