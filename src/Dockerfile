FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /App 
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust
COPY invent/ ./
EXPOSE 5000 
EXPOSE 5001
ENTRYPOINT ["dotnet", "InventarioGEI.dll"]