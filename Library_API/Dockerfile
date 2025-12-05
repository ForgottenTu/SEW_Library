FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Library_API/Library_API.csproj", "Library_API/"]
RUN dotnet restore "Library_API/Library_API.csproj"
COPY . .
WORKDIR "/src/Library_API"
RUN dotnet build "Library_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Library_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library_API.dll"]
