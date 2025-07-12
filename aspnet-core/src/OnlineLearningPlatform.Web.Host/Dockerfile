FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/OnlineLearningPlatform.Web.Host/OnlineLearningPlatform.Web.Host.csproj", "src/OnlineLearningPlatform.Web.Host/"]
COPY ["src/OnlineLearningPlatform.Web.Core/OnlineLearningPlatform.Web.Core.csproj", "src/OnlineLearningPlatform.Web.Core/"]
COPY ["src/OnlineLearningPlatform.Application/OnlineLearningPlatform.Application.csproj", "src/OnlineLearningPlatform.Application/"]
COPY ["src/OnlineLearningPlatform.Core/OnlineLearningPlatform.Core.csproj", "src/OnlineLearningPlatform.Core/"]
COPY ["src/OnlineLearningPlatform.EntityFrameworkCore/OnlineLearningPlatform.EntityFrameworkCore.csproj", "src/OnlineLearningPlatform.EntityFrameworkCore/"]
WORKDIR "/src/src/OnlineLearningPlatform.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/OnlineLearningPlatform.Web.Host", "src/OnlineLearningPlatform.Web.Host"]
COPY ["src/OnlineLearningPlatform.Web.Core", "src/OnlineLearningPlatform.Web.Core"]
COPY ["src/OnlineLearningPlatform.Application", "src/OnlineLearningPlatform.Application"]
COPY ["src/OnlineLearningPlatform.Core", "src/OnlineLearningPlatform.Core"]
COPY ["src/OnlineLearningPlatform.EntityFrameworkCore", "src/OnlineLearningPlatform.EntityFrameworkCore"]
WORKDIR "/src/src/OnlineLearningPlatform.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "OnlineLearningPlatform.Web.Host.dll"]
