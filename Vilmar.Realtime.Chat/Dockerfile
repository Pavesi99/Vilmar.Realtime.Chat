#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5173
EXPOSE 7039

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Vilmar.Realtime.Chat/Vilmar.Realtime.Chat.csproj", "Vilmar.Realtime.Chat/"]
RUN dotnet restore "./Vilmar.Realtime.Chat/./Vilmar.Realtime.Chat.csproj"
COPY . .
WORKDIR "/src/Vilmar.Realtime.Chat"
RUN dotnet build "./Vilmar.Realtime.Chat.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Vilmar.Realtime.Chat.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vilmar.Realtime.Chat.dll"]