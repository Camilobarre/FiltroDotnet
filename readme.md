# Hotel Reservation API

Este proyecto es una API RESTful para gestionar las reservas de un hotel. Utiliza .NET Core con autenticación JWT y una base de datos MySQL.

## Características

- **Gestión de huéspedes**: Crear, actualizar, eliminar y buscar huéspedes.
- **Gestión de habitaciones**: Crear, actualizar, eliminar y listar habitaciones.
- **Gestión de tipos de habitación**: Crear, actualizar, eliminar y listar tipos de habitación.
- **Gestión de reservas**: Crear, actualizar y eliminar reservas.
- **Autenticación JWT**: Sistema de autenticación basado en roles con tokens JWT.
- **Swagger**: Documentación interactiva para probar la API.

## Requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- [MySQL](https://www.mysql.com/downloads/)
- Archivo `.env` con las siguientes variables:

```bash
DB_HOST = bxsrlhhfo0yqfkif6lgc-mysql.services.clever-cloud.com
DB_NAME = bxsrlhhfo0yqfkif6lgc
DB_PORT = 3306
DB_USERNAME = uiwbeizmv8i1aiot
DB_PASSWORD = BIS2vjUkucLiihvP0rYt

JWT_KEY = a25821d8-841a-11ef-84d4-cecd028ee826
JWT_ISSUER = http://localhost:5084
JWT_AUDIENCE = public
JWT_EXPIRES_IN = 3