# Stage 1: Build
# We use the SDK image to compile the code
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the .csproj files first (for better caching)
COPY ["src/Arcademy.API/Arcademy.API.csproj", "src/Arcademy.API/"]
COPY ["src/Arcademy.Application/Arcademy.Application.csproj", "src/Arcademy.Application/"]
COPY ["src/Arcademy.Domain/Arcademy.Domain.csproj", "src/Arcademy.Domain/"]
COPY ["src/Arcademy.Infrastructure/Arcademy.Infrastructure.csproj", "src/Arcademy.Infrastructure/"]

# Restore dependencies
RUN dotnet restore "src/Arcademy.API/Arcademy.API.csproj"

# Copy the rest of the code
COPY . .

# Build and Publish (Release mode)
WORKDIR "/src/src/Arcademy.API"
RUN dotnet build "Arcademy.API.csproj" -c Release -o /app/build
RUN dotnet publish "Arcademy.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
# We use the ASP.NET Core Runtime image (much smaller, no SDK tools)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Arcademy.API.dll"]