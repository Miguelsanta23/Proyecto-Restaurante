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
    }
}
