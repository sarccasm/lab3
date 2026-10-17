# Practice 3: Routing (completed)

ASP.NET Core MVC (.NET 6) implementation of all 12 requirements from https://github.com/ChNU-Classes/Routing.

## Run

Install the .NET 6 SDK (or a compatible SDK with .NET 6 targeting/runtime support). Open a terminal in the project directory:

```bash
dotnet restore
dotnet run
```

Open the local HTTP/HTTPS address printed by `dotnet run`, then visit `/products`.

## Routes

- GET `/products`, `/products/`, `/products/index`, `/items`, `/items/index` : list
- GET `/products/{id}` : details
- GET `/products/create` or `/products/new` : create form
- POST `/products/create` or `/products/new` : create
- GET/POST `/products/edit/{id}` : edit
- GET/POST `/products/delete/{id}` : delete (GET confirms, POST deletes)
- GET `/products?search=lap&category=Electronics&minPrice=10&maxPrice=1500` : filter
- Missing product: HTTP 404 with custom page and back link
- POST `/users/index` : admin user list only with form-body field `parameter=df2323eoT`; otherwise HTTP 401. GET is always HTTP 401.

Test admin using a terminal (replace port):

```bash
curl -i -X POST http://localhost:5000/users/index -d 'parameter=df2323eoT'
curl -i -X POST http://localhost:5000/users/index -d 'parameter=wrong'
```

Admin token is a lab-only demonstration, **not** production-grade authentication.

## Storage

Products and users are stored in memory (no database needed). Edits persist until the application restarts. Form POST actions use antiforgery tokens. For demonstration purposes, the list includes 4 sample products.

## Notes

This is a self-contained completed implementation of the assignment, keeping the original project name and .NET 6 target. It is not a byte-for-byte modification of the upstream repository because the full source archive could not be retrieved in this environment. Build/run could not be verified here because the .NET SDK is unavailable.
