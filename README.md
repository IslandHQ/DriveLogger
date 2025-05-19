# DriveLogger

A logging solution for tracking drive operations and system events.

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)

## Getting Started

1. Clone the repository:
```bash
git clone https://github.com/IslandHQ/DriveLogger.git
```

2. Restore dependencies:
```bash
cd DriveLogger
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

4. Run the application:
```bash
dotnet run --project DriveLogger.csproj
```

## Usage

Instructions on how to use the DriveLogger application.

1. **Start the application** using the command:
```bash
dotnet run --project DriveLogger.csproj
```
   - This will compile and run the project if not already built.

2. **Access the application** via your browser at `http://localhost:5000` (or the appropriate port if configured differently).

3. **Use the provided features** to monitor drive operations:
   - Real-time logs are displayed in the web interface.
   - Filter logs by severity (info, warning, error).
   - Export logs as CSV or JSON.

4. **Configuration**:
   - Modify `appsettings.json` for logging thresholds and output formats.
   - Set environment variables like `LOG_LEVEL=Debug` for detailed logging.

5. **Build and Test**:
   ```bash
   dotnet build
   dotnet test
   ```

## Project Structure

- `DriveLogger.csproj` - Main project file
- `Program.cs` - Entry point of the application
- `Properties/` - Configuration files

## Features
- Real-time drive operation monitoring
- Detailed logging of system events
- Configurable log output formats

## Contributing
1. Fork the repository
2. Create your feature branch (`git checkout -b feature/new-feature`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/new-feature`)
5. Open a pull request

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.