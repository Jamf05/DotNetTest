# DotNetTest

This guide details the steps to set up and run a .NET 6.0 application. The project relies on SQL Server, which is containerized using Docker.

## Prerequisites

- Docker

## Database Setup

1. Pull the SQL Server 2022 image:

    ```bash
    docker pull mcr.microsoft.com/mssql/server:2022-latest
    ```

2. Start the SQL Server instance in a Docker container:

    ```bash
    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=123456As" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest
    ```

3. Connect to the SQL Server instance created in the container and create a new database called `DevLab`.

4. Execute the provided SQL script named `script.sql` to generate the initial tables for the `DevLab` database.

## Running the .NET 6.0 Project

1. Open the solution in your preferred .NET IDE.

2. Update the connection string in the project to match your SQL Server credentials and the database name (DevLab).

    ```plaintext
        Connection String Example:
        Server=localhost;Database=DevLab;User Id=SA;Password=123456As;Encrypt=False;
    ```

3. Build and run the project.

## Notes

- Ensure that the SQL Server container is running before executing the .NET application.
- Modify the connection strings within the project to suit your SQL Server setup.

For further assistance or inquiries, please contact jorgemogotocoro05@gmail.com.