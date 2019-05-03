FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SimpleCalculator/SimpleCalculator.csproj", "SimpleCalculator/"]
RUN dotnet restore "SimpleCalculator/SimpleCalculator.csproj"
COPY . .
WORKDIR "/src/SimpleCalculator"
RUN dotnet build "SimpleCalculator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SimpleCalculator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SimpleCalculator.dll"]