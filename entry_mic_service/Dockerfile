#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["entry_mic_service/entry_mic_service.csproj", "entry_mic_service/"]
RUN dotnet restore "entry_mic_service/entry_mic_service.csproj"
COPY . .
WORKDIR "/src/entry_mic_service"
RUN dotnet build "entry_mic_service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "entry_mic_service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "entry_mic_service.dll"]