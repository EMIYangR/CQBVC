#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Hello_Console/Hello_Console.csproj", "Hello_Console/"]
RUN dotnet restore "Hello_Console/Hello_Console.csproj"
COPY . .
WORKDIR "/src/Hello_Console"
RUN dotnet build "Hello_Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hello_Console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hello_Console.dll"]