FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SampleCodeApp/SampleCodeApp.csproj", "SampleCodeApp/"]
RUN dotnet restore "SampleCodeApp/SampleCodeApp.csproj"
COPY . .
WORKDIR "/src/SampleCodeApp"
RUN dotnet build "SampleCodeApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleCodeApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleCodeApp.dll"]
