FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Toy.Executor/Toy.Executor.csproj", "Toy.Executor/"]
RUN dotnet restore "Toy.Executor/Toy.Executor.csproj"
COPY . .
WORKDIR "/src/Toy.Executor"
RUN dotnet build "Toy.Executor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Toy.Executor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Toy.Executor.dll"]
