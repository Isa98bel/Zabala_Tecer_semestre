using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // El Gobierno Nacional a través de su Ministerio de Salud requiere algunos datos sobre la campaña de vacunación.

        // Crear conjunto ficticio de 500 ciudadanos (1-500)
        HashSet<int> ciudadanos = new HashSet<int>(Enumerable.Range(1, 500));

        // Crear conjunto ficticio de 75 ciudadanos vacunados con Pfizer (101-175)
        HashSet<int> pfizer = new HashSet<int>(Enumerable.Range(101, 75));

        // Crear conjunto ficticio de 75 ciudadanos vacunados con AstraZeneca (151-225)
        HashSet<int> astrazeneca = new HashSet<int>(Enumerable.Range(151, 75));

        // Listado de ciudadanos que no se han vacunado
        HashSet<int> no_vacunados = new HashSet<int>(ciudadanos);
        no_vacunados.ExceptWith(pfizer);
        no_vacunados.ExceptWith(astrazeneca);

        // Listado de ciudadanos que han recibido las dos vacunas
        HashSet<int> ambas_vacunas = new HashSet<int>(pfizer);
        ambas_vacunas.IntersectWith(astrazeneca);

        // Listado de ciudadanos que solamente han recibido la vacuna de Pfizer
        HashSet<int> solo_pfizer = new HashSet<int>(pfizer);
        solo_pfizer.ExceptWith(astrazeneca);

        // Listado de ciudadanos que solamente han recibido la vacuna de AstraZeneca
        HashSet<int> solo_astrazeneca = new HashSet<int>(astrazeneca);
        solo_astrazeneca.ExceptWith(pfizer);

        // Guardar los resultados en un archivo
        using (StreamWriter outfile = new StreamWriter("reporte_vacunacion_covid.txt"))
        {
            outfile.WriteLine("Ciudadanos que no se han vacunado:");
            outfile.WriteLine(string.Join(" ", no_vacunados));

            outfile.WriteLine("\n\nCiudadanos que han recibido ambas vacunas:");
            outfile.WriteLine(string.Join(" ", ambas_vacunas));

            outfile.WriteLine("\n\nCiudadanos que solo han recibido la vacuna de Pfizer:");
            outfile.WriteLine(string.Join(" ", solo_pfizer));

            outfile.WriteLine("\n\nCiudadanos que solo han recibido la vacuna de AstraZeneca:");
            outfile.WriteLine(string.Join(" ", solo_astrazeneca));
        }

        Console.WriteLine("Reporte generado en 'reporte_vacunacion_covid.txt'");
    }
}
