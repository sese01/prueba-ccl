# Proyecto: Prueba Técnica CCL

## Descripción
Este proyecto está compuesto por un backend desarrollado en **.NET Core** y un frontend en **Angular**. Su objetivo es [describir brevemente la funcionalidad principal del proyecto].

## Tecnologías Utilizadas
- **Backend:** .NET Core
- **Frontend:** Angular
- **Base de datos:** [Indicar base de datos utilizada]
- **CI/CD:** GitHub Actions

## Estructura del Proyecto
```
[Raíz del proyecto]
│── BackEnd/
│   ├── Data/                # Configuración de la base de datos y modelos
│   ├── PruebaTecnicaCCL/    # Proyecto principal del backend
│   ├── Services/            # Servicios y DTOs
│── FrontEnd/
│   ├── src/app/            # Componentes principales
│   ├── src/core/           # Módulos y servicios centrales
│   ├── src/public/         # Componentes públicos como el login
│── .github/                # Configuración de flujos de trabajo de GitHub Actions
│── README.md
```

## Instalación y Configuración

### Backend
1. Navega a la carpeta `BackEnd/PruebaTecnicaCCL/`.
2. Configura el archivo `appsettings.json` con las credenciales necesarias.
3. Restaura las dependencias:
   ```sh
   dotnet restore
   ```
4. Ejecuta el proyecto:
   ```sh
   dotnet run
   ```

### Frontend
1. Navega a la carpeta `FrontEnd/`.
2. Instala las dependencias:
   ```sh
   npm install
   ```
3. Ejecuta el proyecto:
   ```sh
   ng serve --open
   ```

## Contribuciones
1. Haz un fork del repositorio.
2. Crea una rama para tu cambio (`git checkout -b feature/nueva-caracteristica`).
3. Realiza tus cambios y haz commit (`git commit -m 'Añadir nueva característica'`).
4. Sube la rama (`git push origin feature/nueva-caracteristica`).
5. Crea un Pull Request en GitHub.

## Autor
- **Sebastian Gomez** - [Tu perfil de GitHub](https://github.com/sese01)

## Licencia
Este proyecto está bajo la licencia [Nombre de la licencia].

