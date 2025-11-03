using System;
using Proyecto_Reastaurante.Modelos;
using Proyecto_Reastaurante.Estructuras;
using Proyecto_Reastaurante.Utilidades;

namespace Proyecto_Reastaurante.Servicios
{
    // Servicio para gestionar restaurantes
    public class ServicioRestaurante
    {
        private ListaEnlazada<Restaurante> restaurantes;

        // Constructor que inicializa el servicio
        public ServicioRestaurante()
        {
            restaurantes = new ListaEnlazada<Restaurante>();
        }

        // Obtiene la lista de restaurantes
        public ListaEnlazada<Restaurante> ObtenerRestaurantes()
        {
            return restaurantes;
        }

        // Crea un nuevo restaurante
        public bool CrearRestaurante(string nit, string nombre, string dueno, string celular, string direccion)
        {
            // Validar que no hay campos vacios
            if (!Validaciones.ValidarCampoNoVacio(nit) || !Validaciones.ValidarCampoNoVacio(nombre) ||
                !Validaciones.ValidarCampoNoVacio(dueno) || !Validaciones.ValidarCampoNoVacio(direccion))
            {
                Console.WriteLine("Error: Todos los campos son obligatorios.");
                return false;
            }

            // Validar celular
            if (!Validaciones.ValidarCelular(celular))
            {
                Console.WriteLine("Error: El celular debe tener 10 dígitos.");
                return false;
            }

            // Validar que el NIT no exista
            if (BuscarPorNit(nit) != null)
            {
                Console.WriteLine("Error: Ya existe un restaurante con ese NIT.");
                return false;
            }

            // Crear y agregar el restaurante
            Restaurante nuevoRestaurante = new Restaurante(nit, nombre, dueno, celular, direccion);
            restaurantes.Agregar(nuevoRestaurante);
            Console.WriteLine("Restaurante creado exitosamente.");
            return true;
        }

        // Busca un restaurante por su NIT
        public Restaurante BuscarPorNit(string nit)
        {
            Nodo<Restaurante> actual = restaurantes.Cabeza;
            while (actual != null)
            {
                if (actual.Valor.Nit == nit)
                {
                    return actual.Valor;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
    }
}

