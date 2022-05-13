#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RentalCarApi/RentalCarApi.csproj", "RentalCarApi/"]
COPY ["RentalCarCore/RentalCarCore.csproj", "RentalCarCore/"]
COPY ["RentalCarInfrastructure/RentalCarInfrastructure.csproj", "RentalCarInfrastructure/"]
RUN dotnet restore "RentalCarApi/RentalCarApi.csproj"

COPY . .
WORKDIR /src/RentalCarApi
RUN dotnet build 
FROM build AS publish
WORKDIR /src/RentalCarApi
RUN dotnet publish  -c Release -o /src/publish
FROM base AS final
WORKDIR /app



COPY --from=publish /src/publish .
COPY --from=publish /src/RentalCarApi/Json/Dealer.json ./
COPY --from=publish /src/RentalCarApi/Json/User.json ./
COPY --from=publish /src/publish .
#ENTRYPOINT ["dotnet", "RentalCarApi.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet RentalCarApi.dll