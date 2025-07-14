# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# انسخ كل ملفات .csproj عشان تعمل restore صح
COPY ./API/API.csproj ./API/
COPY ./Core/Core.csproj ./Core/
COPY ./Services/Services.csproj ./Services/
COPY ./Infrastructure/Infrastructure.csproj ./Infrastructure/
COPY ./Domain/Domain.csproj ./Domain/

# اعمل restore
RUN dotnet restore ./API/API.csproj

# انسخ كل الكود
COPY . .

# ادخل على مشروع API
WORKDIR /src/API

# اعمل build
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
