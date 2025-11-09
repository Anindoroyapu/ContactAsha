# Use the official .NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application files
COPY . ./

# Build the application in Release mode
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory for the runtime
WORKDIR /app

# Copy the build output to the runtime container
COPY --from=build /app/out .

# Copy .env file to the runtime container
COPY .env .
COPY .conf.* .

# Expose the port that your application runs on
EXPOSE 5050
# Set the entry point for the application
ENTRYPOINT ["dotnet", "BikiranWebAPI.dll"]
