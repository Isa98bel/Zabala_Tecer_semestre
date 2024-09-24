// Implementación de un Árbol Binario de Búsqueda bajo buenas prácticas

using System;



public class NodoArbol

{

    public int Dato;

    public NodoArbol Izquierda, Derecha;



    public NodoArbol(int valor)

    {

        Dato = valor;

        Izquierda = Derecha = null;

    }

}



public class ArbolBusquedaBinaria

{

    public NodoArbol Raiz;



    // Método para agregar un valor al árbol

    public void Agregar(int valor)

    {

        Raiz = AgregarRecursivo(Raiz, valor);

    }



    private NodoArbol AgregarRecursivo(NodoArbol nodoActual, int valor)

    {

        if (nodoActual == null)

        {

            return new NodoArbol(valor);

        }



        if (valor < nodoActual.Dato)

            nodoActual.Izquierda = AgregarRecursivo(nodoActual.Izquierda, valor);

        else if (valor > nodoActual.Dato)

            nodoActual.Derecha = AgregarRecursivo(nodoActual.Derecha, valor);



        return nodoActual;

    }



    // Método para eliminar un nodo del árbol

    public NodoArbol Eliminar(NodoArbol nodoActual, int valor)

    {

        if (nodoActual == null) return null;



        if (valor < nodoActual.Dato)

            nodoActual.Izquierda = Eliminar(nodoActual.Izquierda, valor);

        else if (valor > nodoActual.Dato)

            nodoActual.Derecha = Eliminar(nodoActual.Derecha, valor);

        else

        {

            if (nodoActual.Izquierda == null)

                return nodoActual.Derecha;

            if (nodoActual.Derecha == null)

                return nodoActual.Izquierda;



            nodoActual.Dato = ObtenerMinimo(nodoActual.Derecha);

            nodoActual.Derecha = Eliminar(nodoActual.Derecha, nodoActual.Dato);

        }



        return nodoActual;

    }



    private int ObtenerMinimo(NodoArbol nodo)

    {

        int min = nodo.Dato;

        while (nodo.Izquierda != null)

        {

            min = nodo.Izquierda.Dato;

            nodo = nodo.Izquierda;

        }

        return min;

    }



    // Método para buscar un nodo

    public NodoArbol Buscar(NodoArbol nodoActual, int valor)

    {

        if (nodoActual == null || nodoActual.Dato == valor)

            return nodoActual;



        if (valor < nodoActual.Dato)

            return Buscar(nodoActual.Izquierda, valor);



        return Buscar(nodoActual.Derecha, valor);

    }



    // Método para recorrer el árbol en inorden

    public void RecorridoInOrden(NodoArbol nodoActual)

    {

        if (nodoActual != null)

        {

            RecorridoInOrden(nodoActual.Izquierda);

            Console.Write(nodoActual.Dato + " ");

            RecorridoInOrden(nodoActual.Derecha);

        }

    }

}



class ProgramaPrincipal

{

    // El método Main debe ser estático para ser el punto de entrada

    static void Main(string[] args) 

    {

        ArbolBusquedaBinaria arbol = new ArbolBusquedaBinaria();



        Console.WriteLine("Bienvenido al sistema de Árbol Binario");



        bool continuar = true;

        while (continuar)

        {

            Console.WriteLine("\n--- Menú ---");

            Console.WriteLine("1. Agregar valor");

            Console.WriteLine("2. Eliminar valor");

            Console.WriteLine("3. Buscar valor");

            Console.WriteLine("4. Mostrar recorrido Inorden");

            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());



            switch (opcion)

            {

                case 1:

                    Console.Write("Ingrese el valor a agregar: ");

                    int valorAgregar = int.Parse(Console.ReadLine());

                    arbol.Agregar(valorAgregar);

                    Console.WriteLine("Valor agregado.");

                    break;

                case 2:

                    Console.Write("Ingrese el valor a eliminar: ");

                    int valorEliminar = int.Parse(Console.ReadLine());

                    arbol.Raiz = arbol.Eliminar(arbol.Raiz, valorEliminar);

                    Console.WriteLine("Valor eliminado.");

                    break;

                case 3:

                    Console.Write("Ingrese el valor a buscar: ");

                    int valorBuscar = int.Parse(Console.ReadLine());

                    NodoArbol nodoEncontrado = arbol.Buscar(arbol.Raiz, valorBuscar);

                    if (nodoEncontrado != null)

                        Console.WriteLine("Valor encontrado: " + nodoEncontrado.Dato);

                    else

                        Console.WriteLine("Valor no encontrado.");

                    break;

                case 4:

                    Console.WriteLine("Recorrido Inorden:");

                    arbol.RecorridoInOrden(arbol.Raiz);

                    Console.WriteLine();

                    break;

                case 5:

                    continuar = false;

                    Console.WriteLine("Saliendo...");

                    break;

                default:

                    Console.WriteLine("Opción no válida. Intente nuevamente.");

                    break;

            }

        }

    }

}
