# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# WORKDIR /app
# EXPOSE 80
# EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY ["Resturant-managment/Resturant-managment.csproj", "Resturant-managment/"]
# RUN dotnet restore "Resturant-managment/Resturant-managment.csproj"
# COPY . .
# WORKDIR "/src/Resturant-managment"
# RUN dotnet build "Resturant-managment.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "Resturant-managment.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Resturant-managment.dll"]
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Resturant-managment/Resturant-managment.csproj" --disable-parallel
RUN dotnet publish "./Resturant-managment/Resturant-managment.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0


WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
EXPOSE 7099
EXPOSE 5042
ENTRYPOINT ["dotnet", "Resturant-managment.dll"]
