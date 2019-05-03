FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["SimpleCalculatorClient/SimpleCalculatorClient.csproj", "SimpleCalculatorClient/"]

RUN dotnet restore "SimpleCalculatorClient/SimpleCalculatorClient.csproj"
COPY . .
WORKDIR "/src/SimpleCalculatorClient"
RUN dotnet build "SimpleCalculatorClient.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SimpleCalculatorClient.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SimpleCalculatorClient.dll"]