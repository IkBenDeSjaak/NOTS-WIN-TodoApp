# TodoApp

## Projecten
- `TodoClient` (WPF App with MVVM, data binding and command binding)
- `TodoBackend` (API with ASP.Net Core)

## Run Locally

- Clone the project
```bash
  git clone https://github.com/IkBenDeSjaak/NOTS-WIN-TodoApp.git
```
- Open the solution in Visual Studio

### Database

- Create a MariaDB database with the name `TodoApp`

### TodoBackend

- Change the code in `Program.cs` so that the connectionString and the serverVersion corresponds with your database
- Open a terminal and navigate to `/TodoApp/TodoBackend`
- Install EF Core tools
```bash
  dotnet tool install --global dotnet-ef
```
- Create the database tables
```bash
  dotnet ef database update
```
- Optional: seed the database with the file `Seed/seed.sql`
- Start TodoBackend without debugging

### TodoClient

- Start TodoClient
