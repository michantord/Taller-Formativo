"use server";

import { VehicleService } from "@/lib/services/vehicle";
import { ExplorerFactory } from "@/lib/factories/vehicle-factory";
import { revalidatePath } from "next/cache";

export async function addExplorer() {
  const service = new VehicleService();

  // Factory Method: crea el Explorer con su año actual por defecto.
  service.add(new ExplorerFactory().build());

  // BUG ORIGINAL DEL BOTÓN:
  // El server action guardaba el vehículo pero la página nunca se volvía a renderizar
  // con los datos nuevos (y el reload manual del cliente corría ANTES de terminar el
  // action). revalidatePath invalida el cache del server component "/", de modo que la
  // lista de vehículos se vuelve a obtener y el auto recién agregado aparece.
  revalidatePath("/");
}
