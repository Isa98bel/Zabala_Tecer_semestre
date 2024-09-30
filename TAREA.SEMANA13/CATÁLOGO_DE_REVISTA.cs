using System;

// Definición de un nodo en el árbol binario de búsqueda (ABB)
public class Nodo
{
    public string Titulo;  // Título de la revista
    public Nodo Izquierdo; // Hijo izquierdo
    public Nodo Derecho;   // Hijo derecho

    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierdo = null;
        Derecho = null;
    }
}

// Clase que define el catálogo de revistas usando un ABB
public class CatalogoRevistas
{
    private Nodo raiz;

    // Método para insertar un nuevo título en el catálogo
    public void Insertar(string titulo)
    {
        raiz = InsertarRecursivo(raiz, titulo);
    }

    // Método recursivo para insertar un título en el lugar adecuado
    private Nodo InsertarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Nodo(titulo); // Crear un nuevo nodo si es nulo
        }

        // Comparación alfabética para definir el lugar del nuevo nodo
        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);
        }
        else if (string.Compare(titulo, nodo.Titulo) > 0)
        {
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);
        }

        return nodo; // Retornar el nodo actualizado
    }

    // Método de búsqueda iterativa para encontrar un título
    public bool Buscar(string titulo)
    {
        Nodo actual = raiz;

        while (actual != null)
        {
            int comparacion = string.Compare(titulo, actual.Titulo);

            if (comparacion == 0)
            {
                return true; // Título encontrado
            }
            else if (comparacion < 0)
            {
                actual = actual.Izquierdo; // Moverse al subárbol izquierdo
            }
            else
            {
                actual = actual.Derecho; // Moverse al subárbol derecho
            }
        }

        return false; // Título no encontrado
    }
}

// Programa principal que maneja el menú y la interacción con el usuario
public class Program
{
    static void Main(string[] args)
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();

        // Insertar 10 títulos en el catálogo
        catalogo.Insertar("Revista Cientifica A");
        catalogo.Insertar("Revista de Ciencias Naturales B");
        catalogo.Insertar("Revista Tecnologica C");
        catalogo.Insertar("Revista de Salud D");
        catalogo.Insertar("Revista Agricola E");
        catalogo.Insertar("Revista de Educacion F");
        catalogo.Insertar("Revista de Quimica G");
        catalogo.Insertar("Revista de Ingenieria H");
        catalogo.Insertar("Revista de Biologia I");
        catalogo.Insertar("Revista Ambiental J");

        // Menú para buscar títulos
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\nCatálogo de Revistas");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título a buscar: ");
                    string tituloBuscado = Console.ReadLine();

                    if (catalogo.Buscar(tituloBuscado))
                    {
                        Console.WriteLine("Título encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Título no encontrado.");
                    }
                    break;

                case "2":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
