#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomerNotification/NotificationService/NotificationService.csproj", "CustomerNotification/NotificationService/"]
COPY ["CustomerNotification/EmailService/EmailService.csproj", "CustomerNotification/EmailService/"]
COPY ["Faces.SharedLib/Messaging.InterfacesConstants/Messaging.InterfacesConstants.csproj", "Faces.SharedLib/Messaging.InterfacesConstants/"]
RUN dotnet restore "CustomerNotification/NotificationService/NotificationService.csproj"
COPY . .
WORKDIR "/src/CustomerNotification/NotificationService"
RUN dotnet build "NotificationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotificationService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices10.NotificationService.dll"]