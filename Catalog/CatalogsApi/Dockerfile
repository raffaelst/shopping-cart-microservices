#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Catalog/CatalogsApi/CatalogsApi.csproj", "Catalog/CatalogsApi/"]
RUN dotnet restore "Catalog/CatalogsApi/CatalogsApi.csproj"
COPY . .
WORKDIR "/src/Catalog/CatalogsApi"
RUN dotnet build "CatalogsApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogsApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogsApi.dll"]