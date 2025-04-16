# OneStore

## Project Setup Guide (ASP.NET Web API + MSSQL)

### Prerequisites

Before running the project, ensure you have the following installed:

- [.NET 8.0 or later](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

---

### 1. Clone the Repository

```sh
git clone https://github.com/razenxc/OneStore
cd OneStore
```

---

### 2. Configure the appsetings.json

#### I. Configure the Database Connection

Open `appsettings.json` and update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
}
```

**Replace:**

- `YOUR_SERVER` → Your SQL Server instance (e.g., `ALEXEY-DESKTOP\SQLEXPRESS`)
- `YOUR_DATABASE` → Your database name (e.g., `OneStore`)

#### II. Configure JWT

Open `appsettings.json` and update theese strings:

```json
"Jwt": {
    "Issuer": "http://localhost:5043",
    "Audience": "http://localhost:5043",
    "SigningKey": "YourLongLongLongSecretKeyab89bbdc8911f2acdfb148495080238bca11fe3cfc0f5c30e68c3b73e266295428da984d7179828e6a4ccc7b623dd042"
},
```

---

#### III. Configure Api Settings

Open `appsettings.json` and update the admin account login:

```json
"ApiSettings": {
    "AdminUsername": "Admin",
    "AdminPassword": "Admin"
}
```

### 3. Apply Migrations

Run the following commands to apply database migrations:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

If Entity Framework Core tools are not installed, install them with:

```sh
dotnet tool install --global dotnet-ef
```

---

### 4. Run the Project

Start the application with:

```sh
dotnet run
```

By default, the API will be available at:

```
http://localhost:5043
https://localhost:7215
```

---

### 5. Test API Endpoints

You can test the API using **Postman**, **Swagger**, or **cURL**.

#### Open Swagger UI:

```
https://localhost:7215/swagger/index.html
```

#### Example cURL Request:

```sh
curl -X 'GET' \
  'https://localhost:7215/api/product' \
  -H 'accept: */*'
```

---

### 6. Build and Publish

To publish the project, use:

```sh
dotnet publish -c Release -o out
```

Deploy the `out` folder to your hosting environment.
