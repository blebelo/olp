FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./
COPY ["src/OnlineLearningPlatform.Web.Host/*.csproj", "./src/OnlineLearningPlatform.Web.Host/"]
COPY ["src/OnlineLearningPlatform.Web.Core/*.csproj", "./src/OnlineLearningPlatform.Web.Core/"]
COPY ["src/OnlineLearningPlatform.Application/*.csproj", "./src/OnlineLearningPlatform.Application/"]
COPY ["src/OnlineLearningPlatform.Core/*.csproj", "./src/OnlineLearningPlatform.Core/"]
COPY ["src/OnlineLearningPlatform.EntityFrameworkCore/*.csproj", "./src/OnlineLearningPlatform.EntityFrameworkCore/"]
COPY ["src/OnlineLearningPlatform.Migrator/*.csproj", "./src/OnlineLearningPlatform.Migrator/"]
COPY ["test/OnlineLearningPlatform.Tests/*.csproj", "./test/OnlineLearningPlatform.Tests/"]
COPY ["test/OnlineLearningPlatform.Web.Tests/*.csproj", "./test/OnlineLearningPlatform.Web.Tests/"]

RUN dotnet restore "src/OnlineLearningPlatform.Web.Host/OnlineLearningPlatform.Web.Host.csproj"

COPY . .

RUN dotnet publish "src/OnlineLearningPlatform.Web.Host/OnlineLearningPlatform.Web.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "OnlineLearningPlatform.Web.Host.dll"]
