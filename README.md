# Sistema de Inventario de Ferretería - Cliente Web

Cliente web ASP.NET Core MVC que consume servicios SOAP para la gestión de inventario de una ferretería.

## Descripción

Aplicación web desarrollada en ASP.NET Core 8.0 que proporciona una interfaz de usuario para gestionar el inventario de artículos de ferretería mediante la comunicación con un servicio web SOAP.

## Características

- **Búsqueda de artículos**: Consulta artículos por código
- **Registro de artículos**: Creación de nuevos artículos en el inventario
- **Autenticación de usuarios**: Sistema de login con ASP.NET Identity
- **Interfaz web responsive**: Vistas MVC con Razor

## Tecnologías Utilizadas

- **.NET 8.0**: Framework principal
- **ASP.NET Core MVC**: Patrón arquitectónico
- **ASP.NET Identity**: Sistema de autenticación y autorización
- **Entity Framework Core**: ORM para acceso a datos
- **SQL Server**: Base de datos (LocalDB para desarrollo)
- **SOAP/WCF**: Comunicación con servicios web
- **Bootstrap**: Framework CSS para la interfaz

## Estructura del Proyecto

```
inventario_ferreteria_cliente/
├── Controllers/
│   ├── ArticulosController.cs    # Controlador para operaciones de artículos
│   └── HomeController.cs         # Controlador principal
├── Models/
│   ├── ArticuloViewModel.cs      # Modelo de vista para artículos
│   └── ErrorViewModel.cs         # Modelo para manejo de errores
├── Views/
│   ├── Articulos/
│   │   ├── Index.cshtml         # Vista principal
│   │   ├── Buscar.cshtml        # Vista de búsqueda
│   │   ├── Crear.cshtml         # Formulario de creación
│   │   ├── Detalles.cshtml      # Detalles del artículo
│   │   └── Resultado.cshtml     # Vista de resultados
│   └── Home/
├── Data/
│   ├── ApplicationDbContext.cs   # Contexto de base de datos
│   └── Migrations/              # Migraciones de EF Core
├── Connected Services/
│   └── ServicioArticuloReference/ # Referencia al servicio SOAP
├── wwwroot/                      # Archivos estáticos
└── Program.cs                    # Punto de entrada de la aplicación
```

## Requisitos Previos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server o SQL Server Express (LocalDB)
- Visual Studio 2022 o superior (recomendado)
- Acceso al servicio SOAP de inventario

## Configuración

### 1. Clonar el repositorio

```bash
git clone <url-del-repositorio>
cd inventario_ferreteria_cliente
```

### 2. Configurar la cadena de conexión

Editar el archivo [appsettings.json](appsettings.json) para configurar la conexión a la base de datos:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-inventario_ferreteria_cliente;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 3. Configurar el endpoint del servicio SOAP

En [Controllers/ArticuloController.cs:19](Controllers/ArticuloController.cs#L19), ajustar la URL del servicio:

```csharp
_client = new ServicioArticulosClient(binding, new EndpointAddress("http://tu-servidor:puerto/Service.svc"));
```

### 4. Aplicar migraciones de base de datos

```bash
dotnet ef database update
```

### 5. Ejecutar la aplicación

```bash
dotnet run
```

La aplicación estará disponible en `https://localhost:5001` o `http://localhost:5000`.

## Uso

### Búsqueda de artículos

1. Navegar a **Artículos > Buscar**
2. Ingresar el código del artículo
3. Ver los detalles del artículo encontrado

### Crear nuevo artículo

1. Navegar a **Artículos > Crear**
2. Completar el formulario con los datos:
   - Código
   - Nombre
   - Categoría
   - Precio de compra
   - Precio de venta
   - Stock
   - Proveedor
   - Stock mínimo (opcional)
3. Enviar el formulario

## Modelo de Datos

### ArticuloViewModel

| Campo | Tipo | Descripción |
|-------|------|-------------|
| Codigo | string | Código único del artículo |
| Nombre | string | Nombre del artículo |
| Categoria | string | Categoría del producto |
| Preciocompra | decimal | Precio de compra |
| Precioventa | decimal | Precio de venta |
| Stock | int | Cantidad en inventario |
| Proveedor | string | Nombre del proveedor |
| Stockminimo | int? | Stock mínimo requerido |

## Servicios SOAP Consumidos

El cliente consume los siguientes métodos del servicio SOAP:

- `ConsultarArticuloPorCodigoSoap(string codigo)`: Busca un artículo por su código
- `InsertarArticuloSoap(Articulo articulo)`: Registra un nuevo artículo

## Dependencias NuGet

- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore (8.0.21)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (8.0.21)
- Microsoft.AspNetCore.Identity.UI (8.0.21)
- Microsoft.EntityFrameworkCore.SqlServer (8.0.21)
- Microsoft.EntityFrameworkCore.Tools (8.0.21)
- System.ServiceModel.Http (8.*)
- System.ServiceModel.NetTcp (8.*)
- System.ServiceModel.Primitives (8.*)

## Desarrollo

### Compilar el proyecto

```bash
dotnet build
```

### Ejecutar en modo desarrollo

```bash
dotnet watch run
```

### Crear migración nueva

```bash
dotnet ef migrations add NombreMigracion
```

## Solución de Problemas

### Error de conexión al servicio SOAP

Verificar que:
- El servicio SOAP esté en ejecución
- La URL del endpoint sea correcta
- No haya restricciones de firewall

### Error de base de datos

```bash
dotnet ef database drop
dotnet ef database update
```

## Licencia

Este proyecto es parte de un sistema académico/empresarial de gestión de inventario.

## Contacto

Para más información sobre el proyecto, consultar la documentación del servicio SOAP asociado.
