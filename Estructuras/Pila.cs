namespace Proyecto_Restaurante.Estructuras;

using System;

/// Implementación de una pila generica (LIFO - Last In First Out)
public class Pila<T>
{
    private Nodo<T> cima;
    private int tamano;

    /// Obtiene el tamaño actual de la pila
    public int Tamano
    {
        get { return this.tamano; }
    }

    /// Se agrega en elemento a la cima de la pila

    public void AgregarElemento(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);

        if (cima == null)
        {
            cima = nuevoNodo;
        }
        else
        {
            nuevoNodo.Siguiente = cima;
            cima = nuevoNodo;
        }
        tamano++;
    }

    /// Agrega un elemento a la cima de la pila 
    public void Apilar(T valor)
    {
        AgregarElemento(valor);
    }

    /// Se elimina el ultimo elemento agregado a la pila
    public void EliminarElemento()
    {
        if (cima != null)
        {
            tamano--;
            cima = cima.Siguiente;
        }
    }

    /// Se Imprime la pila de arriba a abajo
    public void ImprimirPila()
    {
        Nodo<T> nodoActual = cima;
        while (nodoActual != null)
        {
            Console.WriteLine(nodoActual.Valor + " ");
            nodoActual = nodoActual.Siguiente;
        }
        Console.WriteLine();
    }

    /// Imprime la pila 
    public void Imprimir()
    {
        ImprimirPila();
    }

    /// Se imprime la pila de abajo a arriba
    public void ImprimirAlReves()
    {
        Pila<T> pilaAuxiliar = new Pila<T>();

        while (cima != null)
        {
            pilaAuxiliar.AgregarElemento(cima.Valor);
            EliminarElemento();
        }

        pilaAuxiliar.ImprimirPila();
    }

    /// Verifica si la pila esta vacia
    public bool EstaVacia()
    {
        return tamano == 0;
    }
}