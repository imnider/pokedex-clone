# Backend
Realicé dos versiones para el Backend, una con almacenamiento en Caché y otra con conexión a Base de Datos SqlServer.
## Conexión con Base de Datos
La base de datos utilizada fue creada para SqlServer.
### Scaffolding
```bash
dotnet ef dbcontext scaffold "Server=localhost,1433;User=sa;Password=Admin1234@;Database=PokedexClone;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --project PokedexClone.Domain --startup-project PokedexClone.WebApp --context-dir Database/SqlServer/Context --output-dir Database/SqlServer/Entities --no-build --force`
```