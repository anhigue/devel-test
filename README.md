# DEVEL TEST

## Prerequisites

Make sure you have the following installed on your machine:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [Azure SQL Database](https://azure.microsoft.com/en-us/services/sql-database/)

To execute the project in ASP .NET 8, follow these steps:

## Setup Instructions

1. Clone the repository to your local machine.
2. Open the solution file in Visual Studio or your preferred IDE.
3. Restore the NuGet packages by running the following command in the Package Manager Console:
    ```
    dotnet restore
    ```
4. Build the solution by running the following command:
    ```
    dotnet build
    ```
5. Run the project by executing the following command:
    ```
    dotnet run
    ```

### Setup Database connection

Update the connection string in `appsettings.json` to point to your SQL Server instance:

```JSON
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_user_id;Password=your_password;"
}
```

> **_NOTE:_**  The database must be created before include the connection string on the project.

## Directory Structure

The project directory contains the following directories:

- `Controllers`: This directory contains the controllers for handling HTTP requests and generating responses.
- `Models`: This directory contains the data models used in the project.
- `Views`: This directory contains the views for rendering HTML content.
- `wwwroot`: This directory contains static files such as CSS, JavaScript, and images.

## Additional Directories
In addition to the existing directories, you can also find the following directories in the project:

- `Repository`: This directory contains the classes responsible for interacting with the database or external data sources.
- `Api`: This directory contains the API controllers and related files for handling HTTP requests and returning responses.
- `Dto`: This directory contains the data transfer objects (DTOs) used for transferring data between different layers of the application.
- `Constants`: This directory contains files that define constants or configuration values used throughout the project.

Feel free to explore and modify these directories to suit your project's needs.
