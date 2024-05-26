#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/QuizMaster.TelegramBot/QuizMaster.TelegramBot.csproj", "src/QuizMaster.TelegramBot/"]
COPY ["src/QuizMaster.DataAccess/QuizMaster.DataAccess.csproj", "src/QuizMaster.DataAccess/"]
COPY ["src/QuizMaster.Domain/QuizMaster.Domain.csproj", "src/QuizMaster.Domain/"]
RUN dotnet restore "./src/QuizMaster.TelegramBot/QuizMaster.TelegramBot.csproj"
COPY . .
WORKDIR "/src/src/QuizMaster.TelegramBot"
RUN dotnet build "./QuizMaster.TelegramBot.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QuizMaster.TelegramBot.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuizMaster.TelegramBot.dll"]