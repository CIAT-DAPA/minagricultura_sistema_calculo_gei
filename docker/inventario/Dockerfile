FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /App 
RUN apt-get update && \
    apt-get install -y \
        vim \
        unzip \
        wget \
        jq
RUN curl -LJO $(curl -Ls https://api.github.com/repos/CIAT-DAPA/minagricultura_sistema_calculo_gei/releases/latest | jq -r '.assets[].browser_download_url')
RUN unzip releaseGEI.zip
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust
COPY ./script.sh ./
COPY ./variables.properties ./
RUN bash script.sh
EXPOSE 5000 
EXPOSE 5001
ENTRYPOINT ["dotnet", "InventarioGEI.dll"]