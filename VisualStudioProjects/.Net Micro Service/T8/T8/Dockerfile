#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["T8/T8.csproj", "T8/"]
RUN dotnet restore "T8/T8.csproj"
COPY . .
WORKDIR "/src/T8"
RUN dotnet build "T8.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "T8.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "T8.dll"]