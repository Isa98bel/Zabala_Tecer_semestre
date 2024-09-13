using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> catalogo = new List<string>
        {
            "Revista de Tecnología",
            "Revista de Ciencia",
            "Revista de Historia",
            "Revista de Salud",
            "Revista de Deporte",
            "Revista de Arte",
            "Revista de Literatura",
            "Revista de Viajes",
            "Revista de Política",
            "Revista de Economía"
        };

        Console.WriteLine("Catálogo de Revistas:");
        for (int i = 0; i < catalogo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {catalogo[i]}");
        }

        Console.WriteLine("\nMenú:");
        Console.WriteLine("1. Buscar un título (búsqueda iterativa)");
        Console.WriteLine("2. Buscar un título (búsqueda recursiva)");
        Console.WriteLine("0. Salir");

        while (true)
        {
            Console.Write("\nSelecciona una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "0")
            {
                break;
            }

            Console.Write("Ingresa el título a buscar: ");
            string tituloBuscado = Console.ReadLine();

            if (opcion == "1")
            {
                bool encontrado = BuscarIterativo(catalogo, tituloBuscado);
                Console.WriteLine(encontrado ? "Título encontrado." : "Título no encontrado.");
            }
            else if (opcion == "2")
            {
                bool encontrado = BuscarRecursivo(catalogo, tituloBuscado, 0);
                Console.WriteLine(encontrado ? "Título encontrado." : "Título no encontrado.");
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }
    }

    static bool BuscarIterativo(List<string> catalogo, string tituloBuscado)
    {
        foreach (var titulo in catalogo)
        {
            if (titulo.Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    static bool BuscarRecursivo(List<string> catalogo, string tituloBuscado, int index)
    {
        if (index >= catalogo.Count)
        {
            return false;
        }
        if (catalogo[index].Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return BuscarRecursivo(catalogo, tituloBuscado, index + 1);
    }
}
