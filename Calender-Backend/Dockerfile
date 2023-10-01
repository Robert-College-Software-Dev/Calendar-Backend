FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Calender-Backend/Calender-Backend.csproj", "Calender-Backend/"]
RUN dotnet restore "Calender-Backend/Calender-Backend.csproj"
COPY . .
WORKDIR "/src/Calender-Backend"
RUN dotnet build "Calender-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calender-Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calender-Backend.dll"]
