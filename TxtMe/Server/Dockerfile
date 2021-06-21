#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["TxtMe/Server/TxtMe.Server.csproj", "TxtMe/Server/"]
COPY ["TxtMe/Client/TxtMe.Client.csproj", "TxtMe/Client/"]
COPY ["TxtMe/Shared/TxtMe.Shared.csproj", "TxtMe/Shared/"]
RUN dotnet restore "TxtMe/Server/TxtMe.Server.csproj"
COPY . .
WORKDIR "/src/TxtMe/Server"
RUN dotnet build "TxtMe.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TxtMe.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TxtMe.Server.dll"]