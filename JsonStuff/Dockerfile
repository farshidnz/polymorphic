FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["JsonStuff/JsonStuff.csproj", "JsonStuff/"]
RUN dotnet restore "JsonStuff/JsonStuff.csproj"
COPY . .
WORKDIR "/src/JsonStuff"
RUN dotnet build "JsonStuff.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JsonStuff.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JsonStuff.dll"]
