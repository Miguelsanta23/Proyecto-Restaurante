using System;
using Proyecto_Restaurante.Modelos;
using Proyecto_Restaurante.Estructuras;
using Proyecto_Restaurante.Utilidades;

namespace Proyecto_Restaurante.Servicios
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

        // Lista todos los platos del menu
        public void ListarPlatos()
        {
            if (platos.EstaVacia())
            {
                Console.WriteLine("No hay platos en el menu");
                return;
            }

            Console.WriteLine("\n===== MENU DE PLATOS =====");
            Nodo<Plato> actual = platos.Cabeza;
            int contador = 1;

            while (actual != null)
            {
                Plato p = actual.Valor;
                Console.WriteLine("\n" + contador + ". " + p.ToString());
                Console.WriteLine("   Descripción: " + p.Descripcion);
                actual = actual.Siguiente;
                contador++;
            }
        }

        // Edita un plato existente
        public bool EditarPlato(string codigo, string nuevoNombre, string nuevaDescripcion, decimal nuevoPrecio)
        {
            Plato plato = BuscarPorCodigo(codigo);

            if (plato == null)
            {
                Console.WriteLine("Error: No se encontro el plato con ese codigo.");
                return false;
            }

            // Validar campos
            if (!Validaciones.ValidarCampoNoVacio(nuevoNombre) || !Validaciones.ValidarCampoNoVacio(nuevaDescripcion))
            {
                Console.WriteLine("Error: Todos los campos son obligatorios");
                return false;
            }

            if (!Validaciones.ValidarPrecio(nuevoPrecio))
            {
                Console.WriteLine("Error: El precio debe ser mayor a cero");
                return false;
            }

            // Actualizar datos
            plato.Nombre = nuevoNombre;
            plato.Descripcion = nuevaDescripcion;
            plato.Precio = nuevoPrecio;

            Console.WriteLine("Plato actualizado exitosamente");
            return true;
        }

        // Borrar un plato (debe validarse antes que no este en pedidos pendientes)
        public bool BorrarPlato(string codigo)
        {
            Plato plato = BuscarPorCodigo(codigo);

            if (plato == null)
            {
                Console.WriteLine("Error: No se encontro el plato con ese codigo");
                return false;
            }

            // Eliminar el plato de la lista
            bool eliminado = false;
            if (platos.Cabeza != null && platos.Cabeza.Valor.Codigo == codigo)
            {
                platos.EliminarPosicion(0);
                eliminado = true;
            }
            else
            {
                Nodo<Plato> actual = platos.Cabeza;
                int posicion = 0;
                while (actual != null)
                {
                    if (actual.Valor.Codigo == codigo)
                    {
                        platos.EliminarPosicion(posicion);
                        eliminado = true;
                        break;
                    }
                    actual = actual.Siguiente;
                    posicion++;
                }
            }

            if (eliminado)
            {
                Console.WriteLine("Plato eliminado exitosamente");
            }

            return eliminado;
        }
    }
}
