using System;
using Proyecto_Reastaurante.Modelos;
using Proyecto_Reastaurante.Estructuras;
using Proyecto_Reastaurante.Utilidades;

namespace SistemaRestaurante.Servicios
{
    // Servicio para gestionar platos del menu
    public class ServicioPlato
    {
        private ListaEnlazada<Plato> platos;

        // Constructor que inicializa el servicio
        public ServicioPlato()
        {
            platos = new ListaEnlazada<Plato>();
        }

        // Obtiene la lista de platos
        public ListaEnlazada<Plato> ObtenerPlatos()
        {
            return platos;
        }

        // Crea un nuevo plato
        public bool CrearPlato(string codigo, string nombre, string descripcion, decimal precio)
        {
            // Validar campos
            if (!Validaciones.ValidarCampoNoVacio(codigo) || !Validaciones.ValidarCampoNoVacio(nombre) ||
                !Validaciones.ValidarCampoNoVacio(descripcion))
            {
                Console.WriteLine("Error: Todos los campos son obligatorios");
                return false;
            }

            if (!Validaciones.ValidarPrecio(precio))
            {
                Console.WriteLine("Error: El precio debe ser mayor a cero");
                return false;
            }

            // Validar que el codigo no exista
            if (BuscarPorCodigo(codigo) != null)
            {
                Console.WriteLine("Error: Ya existe un plato con ese codigo");
                return false;
            }

            // Crear y agregar el plato
            Plato nuevoPlato = new Plato(codigo, nombre, descripcion, precio);
            platos.Agregar(nuevoPlato);
            Console.WriteLine("Plato creado exitosamente");
            return true;
        }

        // Busca un plato por su codigo
        public Plato BuscarPorCodigo(string codigo)
        {
            Nodo<Plato> actual = platos.Cabeza;
            while (actual != null)
            {
                if (actual.Valor.Codigo == codigo)
                {
                    return actual.Valor;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
    }
}
