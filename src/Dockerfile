FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app1

COPY CleanArchitecture.sln ./
COPY CleanArchitecture.Api/*.csproj ./CleanArchitecture.Api/
COPY CleanArchitecture.Application/*.csproj ./CleanArchitecture.Application/
COPY CleanArchitecture.Domain/*.csproj ./CleanArchitecture.Domain/
COPY CleanArchitecture.Infrastructure/*.csproj ./CleanArchitecture.Infrastructure/
COPY CleanArchitecture.Persistence/*.csproj ./CleanArchitecture.Persistence/

RUN dotnet restore

COPY . .


WORKDIR /app/

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /src
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "CleanArchitecture.Api.dll"]
