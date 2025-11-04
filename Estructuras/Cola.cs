namespace Proyecto_Restaurante.Estructuras;

using System;

/// Implementacion de una cola generica (FIFO - First In First Out)
public class Cola<T>
{
    private Nodo<T> cabeza;
    private Nodo<T> cola;
    private int tamano;

    /// Constructor que inicializa una cola vacia
    public Cola()
    {
        cabeza = null;
        cola = null;
        tamano = 0;
    }

    /// Agrega un elemento al final de la cola
    public void Agregar(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);
        if (EstaVacia())
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else
        {
            cola.Siguiente = nuevoNodo;
            cola = nuevoNodo;
        }
        tamano++;
    }

    /// Elimina y retorna el primer elemento de la cola
    public T Desencolar()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("La cola está vacia");
        }
        
        T valor = cabeza.Valor;
        cabeza = cabeza.Siguiente;
        tamano--;
        
        if (cabeza == null)
        {
            cola = null;
        }
        
        return valor;
    }

    /// Obtiene el primer elemento de la cola sin eliminarlo
    public T Primero()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("La cola está vacía.");
        }
        return cabeza.Valor;
    }

    /// Obtiene el tamaño actual de la cola
    public int Tamano()
    {
        return tamano;
    }

    /// Verifica si la cola esta vacia
    public bool EstaVacia()
    {
        return tamano == 0;
    }

    /// Imprime todos los elementos de la cola
    public void Imprimir()
    {
        if (EstaVacia())
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }

        Nodo<T> actual = cabeza;

        Console.Write("Cola: ");
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }

    /// Limpia todos los elementos de la cola
    public void Limpiar()
    {
        cabeza = null;
        cola = null;
        tamano = 0;
    }

    /*public void EliminarRepetidos()
    {
        Nodo<T> actual = cabeza;

        while (actual != null)
        {
            Nodo<T> siguiente = actual.Siguiente;
            Nodo<T> aux = actual;

            while (siguiente != null)
            {
                if (Equals(actual.Valor, siguiente.Valor))
                {
                    aux.Siguiente = siguiente.Siguiente;
                    tamano--;
                }
                else
                {
                    aux = siguiente;
                }
                siguiente = siguiente.Siguiente;
            }
            actual = actual.Siguiente;
        }
    }*/

}