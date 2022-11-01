FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Resturant-managment/Resturant-managment.csproj", "Resturant-managment/"]
RUN dotnet restore "Resturant-managment/Resturant-managment.csproj"
COPY . .
WORKDIR "/src/Resturant-managment"
RUN dotnet build "Resturant-managment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Resturant-managment.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Resturant-managment.dll"]
