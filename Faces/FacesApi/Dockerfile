#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Faces/FacesApi/FacesApi.csproj", "Faces/FacesApi/"]
RUN dotnet restore "Faces/FacesApi/FacesApi.csproj"
COPY . .
WORKDIR "/src/Faces/FacesApi"
RUN dotnet build "FacesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FacesApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices10.FacesApi.dll"]