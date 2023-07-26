FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LetsMeet.Api/LetsMeet.Api.csproj", "LetsMeet.Api/"]
RUN dotnet restore "LetsMeet.Api/LetsMeet.Api.csproj"
COPY . .
WORKDIR "/src/LetsMeet.Api"
RUN dotnet build "LetsMeet.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LetsMeet.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LetsMeet.Api.dll"]
