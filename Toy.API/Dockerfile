FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Toy.API/Toy.API.csproj", "Toy.API/"]
RUN dotnet restore "Toy.API/Toy.API.csproj"
COPY . .
WORKDIR "/src/Toy.API"
RUN dotnet build "Toy.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Toy.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Toy.API.dll"]
