#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoppingCart.Web/ShoppingCart.Mvc/ShoppingCart.Mvc.csproj", "ShoppingCart.Web/ShoppingCart.Mvc/"]
COPY ["ShoppingCart.SharedLib/Messaging.InterfacesConstants/Messaging.InterfacesConstants.csproj", "ShoppingCart.SharedLib/Messaging.InterfacesConstants/"]
RUN dotnet restore "ShoppingCart.Web/ShoppingCart.Mvc/ShoppingCart.Mvc.csproj"
COPY . .
WORKDIR "/src/ShoppingCart.Web/ShoppingCart.Mvc"
RUN dotnet build "ShoppingCart.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCart.Mvc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.Mvc.dll"]