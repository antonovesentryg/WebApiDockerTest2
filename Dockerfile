#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./WebApiDockerTest2/WebApiDockerTest2.csproj", "WebApiDockerTest2/"]
RUN dotnet restore "WebApiDockerTest2/WebApiDockerTest2.csproj"
COPY . .
WORKDIR "/src/WebApiDockerTest2"
RUN dotnet build "WebApiDockerTest2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiDockerTest2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiDockerTest2.dll"]