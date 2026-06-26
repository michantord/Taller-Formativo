# Guion del Video de Evidencia

**Duración objetivo:** 5–8 minutos
**Objetivo:** demostrar que el taller se completó localmente, explicando los problemas, los patrones aplicados y mostrando la solución funcionando.

> Consejo: graba pantalla + micrófono. Ten abierto el editor (VS Code/Visual Studio) y un navegador. Cierra notificaciones.

---

## 0. Presentación (0:00 – 0:30)

> "Hola, soy [tu nombre]. En este video presento la Tarea 12 del taller formativo de patrones de diseño y principios SOLID para el aplicativo de automóviles de Codificando Con Patrones. Voy a mostrar los problemas que identifiqué, los patrones que apliqué y la solución funcionando, tanto en el backend .NET como en la migración a Next.js."

---

## 1. El problema reportado por QA (0:30 – 1:30)

- Abre `DesignPatterns/Infraestructure/DependencyInjection/ServicesConfiguration.cs`.

> "El equipo de QA reportó que agregar vehículos no funcionaba. La causa raíz estaba aquí: el repositorio se registraba como `AddTransient`. Transient crea una instancia nueva del repositorio en cada request. Como `MyVehiclesRepository` guarda los autos en una lista en memoria, cada request empezaba con una lista vacía y los vehículos agregados se perdían."

- Señala el cambio a `AddSingleton`.

> "La solución es registrarlo como Singleton: así la lista en memoria vive durante toda la aplicación. Esto respeta el patrón Repository y el principio de Inversión de Dependencias: el controlador depende de la interfaz `IVehicleRepository`, no de una implementación concreta."

---

## 2. Probar sin base de datos (1:30 – 2:15)

- Muestra `IVehicleRepository`, `MyVehiclesRepository` y `DBVehicleRepository`.

> "El equipo de base de datos dijo que el esquema aún no está listo. Gracias al patrón Repository tenemos dos implementaciones: una en memoria, que usamos ahora para probar, y `DBVehicleRepository`, que se implementará cuando la base esté lista. El día de mañana solo cambio una línea en la configuración de dependencias y el resto del código no se entera."

---

## 3. Builder: año actual + propiedades por defecto (2:15 – 3:30)

- Abre `Patterns/Builders/VehicleBuilder.cs` y `Models/Vehicle.cs`.

> "El negocio pidió agregar el año actual y 20 propiedades por defecto que llegarán el próximo sprint. En lugar de inflar el constructor o agregar 20 propiedades fijas a la clase, apliqué el patrón Builder con una interfaz fluida y un diccionario de propiedades flexible."

> "Así, cuando lleguen las 20 propiedades definitivas, solo agrego líneas `WithProperty` en `WithDefaultProperties`. No toco la clase Vehicle, ni el controlador, ni el repositorio. Esto cumple el principio Abierto/Cerrado y minimiza los cambios del próximo sprint."

---

## 4. Factory Method: nuevos modelos (3:30 – 4:30)

- Abre la carpeta `Patterns/Factories/`.

> "El arquitecto previó que se agregarán más modelos. Apliqué Factory Method: una clase abstracta `VehicleFactory` y una fábrica concreta por modelo. Para agregar el nuevo modelo Ford Escape rojo, que pedía la consigna, solo creé `EscapeFactory`, sin modificar ninguna fábrica existente."

- Abre `HomeController.cs` y muestra `AddMustang`, `AddExplorer`, `AddEscape`.

> "El controlador ahora combina los dos patrones: la fábrica decide qué modelo crear y el Builder le aplica el año y las propiedades por defecto."

---

## 5. Demo en vivo — .NET (4:30 – 5:45)

- En terminal:
```bash
cd DesignPatterns
dotnet run
```
- Abre el navegador en la URL que muestre la consola.

> "Ejecuto la aplicación. Hago clic en Add Mustang... y ahora sí aparece en la tabla, con su año. Agrego Explorer... y el nuevo Escape. Antes esto no se mostraba; ahora persiste correctamente gracias al Singleton."

- (Opcional) Muestra Start Engine / Llenar tanque para evidenciar que el resto sigue funcionando.

---

## 6. Demo en vivo — Next.js (5:45 – 7:00)

- Abre `actions/add-explorer.ts`, `components/ActionBar.tsx` y `lib/factories/vehicle-factory.ts`.

> "El mismo conocimiento lo apliqué al core migrado a Next.js. El botón fallaba por dos motivos: el server action no revalidaba la página y el cliente recargaba antes de que el action terminara, una condición de carrera. La solución fue llamar `revalidatePath` en el server action y quitar el reload manual. Además reusé un Factory Method en TypeScript."

- En terminal:
```bash
cd headapps/app
npm install
npm run dev
```
- Abre http://localhost:3000 y haz clic en **Add Explorer**.

> "Hago clic en Add Explorer y el vehículo aparece de inmediato en el listado, con su año actual. El botón quedó arreglado."

---

## 7. Cierre (7:00 – 7:30)

> "En resumen: corregí el ciclo de vida del repositorio (DI/Singleton), reforcé el patrón Repository para probar sin base de datos, apliqué Builder para las propiedades por defecto minimizando cambios futuros, y Factory Method para extender modelos. Apliqué los mismos principios en .NET y en Next.js. Todo el código está comentado y subido a mi repositorio de GitHub. Gracias."

---

## Checklist antes de subir el video

- [ ] Se ve el problema original explicado (Transient → Singleton).
- [ ] Se explican los 3 patrones: Repository, Builder, Factory Method.
- [ ] Se muestra el nuevo modelo Escape (rojo, Ford).
- [ ] Demo .NET funcionando (vehículos visibles con año).
- [ ] Demo Next.js funcionando (botón Add Explorer).
- [ ] Se menciona el repositorio de GitHub.
