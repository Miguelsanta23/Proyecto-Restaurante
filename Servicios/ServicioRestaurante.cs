using System;
using Proyecto_Restaurante.Modelos;
using Proyecto_Restaurante.Estructuras;
using Proyecto_Restaurante.Utilidades;

namespace Proyecto_Restaurante.Servicios
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
        public bool CrearRestaurante(string nit, string nombre, string duenio, string celular, string direccion)
        {
            // Validar que no hay campos vacios
            if (!Validaciones.ValidarCampoNoVacio(nit) || !Validaciones.ValidarCampoNoVacio(nombre) ||
                !Validaciones.ValidarCampoNoVacio(duenio) || !Validaciones.ValidarCampoNoVacio(direccion))
            {
                Console.WriteLine("Error: Todos los campos son obligatorios");
                return false;
            }

            // Validar celular
            if (!Validaciones.ValidarCelular(celular))
            {
                Console.WriteLine("Error: El celular debe tener 10 dígitos");
                return false;
            }

            // Validar que el NIT no exista
            if (BuscarPorNit(nit) != null)
            {
                Console.WriteLine("Error: Ya existe un restaurante con ese NIT");
                return false;
            }

            // Crear y agregar el restaurante
            Restaurante nuevoRestaurante = new Restaurante(nit, nombre, duenio, celular, direccion);
            restaurantes.Agregar(nuevoRestaurante);
            Console.WriteLine("Restaurante creado exitosamente");
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

        // Lista todos los restaurantes
        public void ListarRestaurantes()
        {
            if (restaurantes.EstaVacia())
            {
                Console.WriteLine("No hay restaurantes registrados.");
                return;
            }

            Console.WriteLine("\n===== LISTA DE RESTAURANTES =====");
            Nodo<Restaurante> actual = restaurantes.Cabeza;
            int contador = 1;

            while (actual != null)
            {
                Restaurante r = actual.Valor;
                Console.WriteLine("\n" + contador + ". " + r.ToString());
                Console.WriteLine("   Celular: " + r.Celular);
                Console.WriteLine("   Direccion: " + r.Direccion);
                actual = actual.Siguiente;
                contador++;
            }
        }

        // Edita un restaurante existente
        public bool EditarRestaurante(string nit, string nuevoNombre, string nuevoDuenio, string nuevoCelular, string nuevaDireccion)
        {
            Restaurante restaurante = BuscarPorNit(nit);

            if (restaurante == null)
            {
                Console.WriteLine("Error: No se encontro el restaurante con ese NIT");
                return false;
            }

            // Validar campos
            if (!Validaciones.ValidarCampoNoVacio(nuevoNombre) || !Validaciones.ValidarCampoNoVacio(nuevoDuenio) ||
                !Validaciones.ValidarCampoNoVacio(nuevaDireccion))
            {
                Console.WriteLine("Error: Todos los campos son obligatorios");
                return false;
            }

            if (!Validaciones.ValidarCelular(nuevoCelular))
            {
                Console.WriteLine("Error: El celular debe tener 10 digitos");
                return false;
            }

            // Actualizar datos
            restaurante.Nombre = nuevoNombre;
            restaurante.Duenio = nuevoDuenio;
            restaurante.Celular = nuevoCelular;
            restaurante.Direccion = nuevaDireccion;

            Console.WriteLine("Restaurante actualizado exitosamente");
            return true;
        }
    }
}
