namespace Proyecto_Reastaurante.Estructuras;

/// Representa un nodo generico para estructuras de datos enlazadas
public class Nodo<T>
{
    private T valor;
    private Nodo<T> siguiente;

    /// Representa un nodo genérico para estructuras de datos enlazadas
    public Nodo(T valor)
    {
        this.valor = valor;
        this.siguiente = null;
    }

    /// Obtiene o establece el valor almacenado en el nodo
    public T Valor
    {
        get { return this.valor; }
        set { this.valor = value; }
    }

    /// Obtiene o establece el siguiente nodo en la secuencia
    public Nodo<T> Siguiente
    {
        get { return this.siguiente; }
        set { this.siguiente = value; }
    }
}