#FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
#WORKDIR /app
#
#COPY *.csproj ./
#RUN dotnet restore
#
#COPY . ./
#RUN dotnet publish -c Release -o out
#
#FROM microsoft/dotnet:2.2-aspnetcore-runtime
#WORKDIR /app
#EXPOSE 80
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "appSimon.dll"]

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80 
#
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["/appSimon.csproj", "./"]
RUN dotnet restore "./appSimon.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "appSimon.csproj" -c Release -o /app 

FROM build AS publish
RUN dotnet publish "appSimon.csproj" -c Release -o /app 

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "appSimon.dll"]