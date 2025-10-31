namespace Proyecto_Reastaurante.Estructuras;

using System;

/// Implementación de una lista enlazada genérica
public class ListaEnlazada<T>
{
    private Nodo<T> cabeza;
    private Nodo<T> ultimo;
    private int cantidad = 0;

    /// Obtiene el primer nodo de la lista
    public Nodo<T> Cabeza
    {
        get { return this.cabeza; }
    }

    /// Obtiene el ultimo nodo de la lista
    public Nodo<T> Ultimo
    {
        get { return this.ultimo; }
    }

    /// Obtiene la cantidad de elementos en la lista
    public int Cantidad
    {
        get { return this.cantidad; }
    }

    /// Agrega un nuevo elemento al final de la lista
    public void Agregar(T valor)
    {
        cantidad++;
        if (cabeza == null)
        {
            cabeza = new Nodo<T>(valor);
            ultimo = cabeza;
            return;
        }

        Nodo<T> actual = cabeza;
        while (actual.Siguiente != null)
        {
            actual = actual.Siguiente;
        }
        actual.Siguiente = new Nodo<T>(valor);
        ultimo = actual.Siguiente;
    }

    /// Imprime todos los elementos de la lista
    public void Imprimir()
    {
        Nodo<T> actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
    }
    public void Revertir()
    {
        Nodo<T> previo = null;
        Nodo<T> actual = cabeza;
        Nodo<T> siguiente = null;
        while (actual != null)
        {
            siguiente = actual.Siguiente;
            actual.Siguiente = previo;
            previo = actual;
            actual = siguiente;
        }
        cabeza = previo;
    }

    /// Elimina un elemento de la lista en una posición específica
    public void EliminarPosicion(int posicion)
    {
        if (cabeza == null || posicion < 0)
        {
            return;
        }

        if (posicion == 0)
        {
            cabeza = cabeza.Siguiente;
            cantidad--;
            return;
        }

        Nodo<T> actual = cabeza;
        int contador = 0;

        while (actual.Siguiente != null && contador < posicion - 1)
        {
            actual = actual.Siguiente;
            contador++;
        }

        if (actual.Siguiente == null)
        {
            return;
        }

        actual.Siguiente = actual.Siguiente.Siguiente;
        cantidad--;


        if (actual.Siguiente == null)
        {
            ultimo = actual;
        }
    }

    /// Busca un elemento en la lista usando un criterio de comparación
    public T Buscar(Func<T, bool> criterio)
    {
        Nodo<T> actual = cabeza;
        while (actual != null)
        {
            if (criterio(actual.Valor))
            {
                return actual.Valor;
            }
            actual = actual.Siguiente;
        }
        return default(T);
    }

   

    /// Elimina un elemento que cumple con un criterio específico
    public bool Eliminar(Func<T, bool> criterio)
    {
        if (cabeza == null)
        {
            return false;
        }

        // Si el elemento a eliminar es la cabeza
        if (criterio(cabeza.Valor))
        {
            cabeza = cabeza.Siguiente;
            cantidad--;
            if (cabeza == null)
            {
                ultimo = null;
            }
            return true;
        }

        Nodo<T> actual = cabeza;
        while (actual.Siguiente != null)
        {
            if (criterio(actual.Siguiente.Valor))
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                cantidad--;
                if (actual.Siguiente == null)
                {
                    ultimo = actual;
                }
                return true;
            }
            actual = actual.Siguiente;
        }

        return false;
    }

    /// Obtiene un elemento en una posición específica
    public T ObtenerPorPosicion(int posicion)
    {
        if (posicion < 0 || posicion >= cantidad)
        {
            return default(T);
        }

        Nodo<T> actual = cabeza;
        int contador = 0;

        while (actual != null && contador < posicion)
        {
            actual = actual.Siguiente;
            contador++;
        }

        return actual != null ? actual.Valor : default(T);
    }

    /// Verifica si la lista esta vacia
    public bool EstaVacia()
    {
        return cantidad == 0;
    }

    /// Limpia todos los elementos de la lista
    public void Limpiar()
    {
        cabeza = null;
        ultimo = null;
        cantidad = 0;
    }


    public int Contar()
    {
        int contador = 0;
        Nodo<T> actual = cabeza;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }
    public int ContarElementos()
    {
        int contador = 0;
        if (cabeza != null)
            contador = 1;

        Nodo<T> actual = cabeza;
        while (actual.Siguiente != null)
        {
            actual = actual.Siguiente;
            contador++;
        }
        return contador;
    }
    public void InsertarEnPosicion(T valor, int posicion)
    {
        if (posicion < 0)
        {
            throw new ArgumentOutOfRangeException("La posición no puede ser negativa.");
        }

        Nodo<T> nuevoNodo = new Nodo<T>(valor);

        if (posicion == 0)
        {
            nuevoNodo.Siguiente = cabeza;
            cabeza = nuevoNodo;
            return;
        }

        Nodo<T> actual = cabeza;
        int contador = 0;
        while (actual != null && contador < posicion - 1)
        {
            actual = actual.Siguiente;
            contador++;
        }

        if (actual == null)
        {
            throw new ArgumentOutOfRangeException("La posición excede el tamaño de la lista.");
        }

        nuevoNodo.Siguiente = actual.Siguiente;
        actual.Siguiente = nuevoNodo;
    }


    /*public void Eliminar(Persona valor) {
        
        if (cabeza == null) 
        {
            return; 
        }

        cantidad--;

        if (cabeza.Valor.Cedula == valor.Cedula) 
        {
            cabeza = cabeza.Siguiente;
            return;
        }

        Nodo actual = cabeza;
        while (actual.Siguiente != null) 
        {
            if (actual.Siguiente.Valor.Cedula == valor.Cedula)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                return;
            }
            actual = actual.Siguiente;
        }
        
    }*/

    /*public void EliminarDuplicados() 
    {
        if (cabeza == null) {
            return;
        }
        Nodo<T> actual = cabeza;
        while (actual != null) {
            Nodo<T> comparador = actual;
            while (comparador.Siguiente != null) 
            {
                if (actual.Valor == comparador.Siguiente.Valor) 
                {
                    comparador.Siguiente = comparador.Siguiente.Siguiente;
                } else {
                    comparador = comparador.Siguiente;
                }
            }
            actual = actual.Siguiente;
        }
    }*/

    /*public int ContarRepetidos(Persona valor)
    {
        int contador = 0;
        Nodo<T> actual = cabeza;
        while(actual.Siguiente != null)
        {
            if(actual.Valor == valor)
                contador++;
            actual = actual.Siguiente;
        }
        if(actual.Valor == valor)
                contador++;
        return contador;
    }*/

}