# Taller Formativo — Principios SOLID y Patrones de Diseño

Tarea 12 — Aplicación de mejores prácticas, principios SOLID y patrones de diseño sobre el aplicativo de automóviles de *Codificando Con Patrones Cía. Ltda.*

## Enlaces

- **Repositorio (GitHub):** https://github.com/michantord/Taller-Formativo
- **Video de evidencia (YouTube):** _(pendiente — agregar link aquí)_

## ¿Qué se implementó?

| Requerimiento | Solución |
|---------------|----------|
| Botón de agregar vehículos no funcionaba (bug de QA) | Corrección del ciclo de vida en Inyección de Dependencias: `AddTransient` → **`AddSingleton`** |
| Probar sin base de datos | Patrón **Repository** (implementación en memoria + `DBVehicleRepository` para el futuro) |
| Año actual + 20 propiedades por defecto (próximo sprint) | Patrón **Builder** + diccionario de propiedades flexible |
| Nuevos modelos (Ford Escape rojo) | Patrón **Factory Method** |
| Botón en la migración a Next.js | `revalidatePath` en el Server Action + Factory Method en TypeScript |

## Estructura

- `DesignPatterns/` — Backend MVC en ASP.NET Core (.NET 8)
- `headapps/app/` — Migración del core a Next.js 16 / React 19
- `docs/` — Documento técnico (`Documento-Tecnico.pdf`) y guion del video (`Guion-Video.md`)

## Cómo ejecutar

**Backend .NET**
```bash
cd DesignPatterns
DOTNET_ROLL_FORWARD=Major dotnet run
# Abrir la URL que muestre la consola (p. ej. https://localhost:5001)
```
> `DOTNET_ROLL_FORWARD=Major` permite correr el proyecto `net8.0` usando el runtime .NET 9 instalado.

**Frontend Next.js**
```bash
cd headapps/app
npm install
npm run dev
# Abrir http://localhost:3000
```

## Patrones aplicados

- **Repository + Inyección de Dependencias**
- **Builder**
- **Factory Method**

El detalle técnico, los diagramas UML y la justificación están en `docs/Documento-Tecnico.pdf`.
