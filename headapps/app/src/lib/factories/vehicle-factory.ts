import { Vehicle } from "../types/vehicle";
import { v4 as uuid } from "uuid";

/**
 * PATRÓN FACTORY METHOD (versión TypeScript).
 *
 * Mismos conocimientos aplicados al core migrado a Next.js: cada fábrica concreta decide
 * qué modelo crear, y la clase base aplica los valores por defecto (año actual) mediante
 * un paso tipo Builder. Agregar un modelo nuevo = una nueva subclase, sin tocar lo demás.
 */
export abstract class VehicleFactory {
  /** Factory Method: la subclase decide marca/modelo. */
  protected abstract createVehicle(): Pick<Vehicle, "brand" | "model">;

  /** Crea el vehículo completo con id y propiedades por defecto (año actual). */
  build(): Vehicle {
    const base = this.createVehicle();
    return {
      id: uuid(),
      brand: base.brand,
      model: base.model,
      year: new Date().getFullYear(), // año actual por defecto
    };
  }
}

export class MustangFactory extends VehicleFactory {
  protected createVehicle() {
    return { brand: "Ford", model: "Mustang" };
  }
}

export class ExplorerFactory extends VehicleFactory {
  protected createVehicle() {
    return { brand: "Ford", model: "Explorer" };
  }
}

export class EscapeFactory extends VehicleFactory {
  protected createVehicle() {
    return { brand: "Ford", model: "Escape" };
  }
}
