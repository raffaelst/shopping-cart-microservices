#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ordering/OrdersApi/OrdersApi.csproj", "Ordering/OrdersApi/"]
COPY ["ShoppingCart.SharedLib/Messaging.InterfacesConstants/Messaging.InterfacesConstants.csproj", "ShoppingCart.SharedLib/Messaging.InterfacesConstants/"]
COPY ["Ordering/CrossCutting/Orders.Infra.IoC/Orders.Infra.IoC.csproj", "Ordering/CrossCutting/Orders.Infra.IoC/"]
COPY ["Ordering/Core/Interfaces/Orders.Repository.Interface/Orders.Repository.Interface.csproj", "Ordering/Core/Interfaces/Orders.Repository.Interface/"]
COPY ["Ordering/Core/Orders.Domain/Orders.Domain.csproj", "Ordering/Core/Orders.Domain/"]
COPY ["Ordering/Core/Interfaces/Orders.Service.Interface/Orders.Application.Interface.csproj", "Ordering/Core/Interfaces/Orders.Service.Interface/"]
COPY ["Ordering/Core/Orders.Application/Orders.Application.csproj", "Ordering/Core/Orders.Application/"]
COPY ["Ordering/Core/Orders.Infra.Data/Orders.Infra.Data.csproj", "Ordering/Core/Orders.Infra.Data/"]
RUN dotnet restore "Ordering/OrdersApi/OrdersApi.csproj"
COPY . .
WORKDIR "/src/Ordering/OrdersApi"
RUN dotnet build "OrdersApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrdersApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrdersApi.dll"]