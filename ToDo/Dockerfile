FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env

WORKDIR /app

EXPOSE 80

COPY . ./

RUN dotnet restore
RUN dotnet publish ./ToDo.API/ToDo.API.csproj -c Release -o ./ToDo.API/build --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime

WORKDIR /app

COPY --from=build-env /app/ToDo.API/build ./

ENTRYPOINT ["dotnet", "ToDo.API.dll"]
