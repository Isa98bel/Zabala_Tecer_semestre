using System;
using System.Collections.Generic;

namespace TraductorBasico
{
    class Program
    {
        // Diccionario Inglés-Español
        static Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            { "time", "tiempo" },
            { "person", "persona" },
            { "year", "año" },
            { "way", "camino/forma" },
            { "day", "día" },
            { "thing", "cosa" },
            { "man", "hombre" },
            { "world", "mundo" },
            { "life", "vida" },
            { "hand", "mano" },
            { "part", "parte" },
            { "child", "niño/a" },
            { "eye", "ojo" },
            { "woman", "mujer" },
            { "place", "lugar" },
            { "work", "trabajo" },
            { "week", "semana" },
            { "case", "caso" },
            { "point", "punto/tema" },
            { "government", "gobierno" },
            { "company", "empresa/compañía" }
        };

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                // Mostrar menú
                Console.WriteLine("MENU");
                Console.WriteLine("=======================================================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Ingresar más palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        TraducirFrase();
                        break;
                    case 2:
                        AgregarPalabra();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                        break;
                }

            } while (opcion != 0);
        }

        static void TraducirFrase()
        {
            Console.Write("Ingrese la frase: ");
            string frase = Console.ReadLine().ToLower();
            string[] palabras = frase.Split(' ');

            Console.Write("Su frase traducida es: ");
            foreach (var palabra in palabras)
            {
                if (diccionario.ContainsKey(palabra))
                {
                    Console.Write(diccionario[palabra] + " ");
                }
                else
                {
                    Console.Write(palabra + " ");
                }
            }
            Console.WriteLine();
        }

        static void AgregarPalabra()
        {
            Console.Write("Ingrese la palabra en inglés: ");
            string palabraIngles = Console.ReadLine().ToLower();

            Console.Write("Ingrese la traducción en español: ");
            string palabraEspanol = Console.ReadLine().ToLower();

            if (!diccionario.ContainsKey(palabraIngles))
            {
                diccionario.Add(palabraIngles, palabraEspanol);
                Console.WriteLine("Palabra agregada exitosamente.");
            }
            else
            {
                Console.WriteLine("La palabra ya existe en el diccionario.");
            }
        }
    }
}
