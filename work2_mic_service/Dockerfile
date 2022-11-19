#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["work2_mic_service/work2_mic_service.csproj", "work2_mic_service/"]
RUN dotnet restore "work2_mic_service/work2_mic_service.csproj"
COPY . .
WORKDIR "/src/work2_mic_service"
RUN dotnet build "work2_mic_service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "work2_mic_service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "work2_mic_service.dll"]