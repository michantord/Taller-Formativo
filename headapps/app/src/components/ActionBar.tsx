"use client";

import { addExplorer } from "@/actions/add-explorer";

export const ActionBar = () => {
  return (
    <div className="mb-4 flex w-full justify-end">
      {/*
        BUG ORIGINAL: el onSubmit hacía e.currentTarget.reset() y window.location.reload(),
        lo que recargaba la página ANTES de que el server action terminara de guardar
        (condición de carrera) y el vehículo nunca aparecía.

        FIX: dejamos que el server action `addExplorer` haga su trabajo y llame a
        revalidatePath("/"). Next.js re-renderiza el server component con la lista
        actualizada automáticamente. Ya no hace falta el reload manual.
      */}
      <form action={addExplorer}>
        <button
          type="submit"
          className="rounded bg-blue-500 px-4 py-2 font-semibold text-white hover:bg-blue-600"
        >
          Add Explorer
        </button>
      </form>
    </div>
  );
};
