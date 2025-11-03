using System;

namespace Proyecto_Reastaurante.Utilidades
{
    // Clase que contiene metodos de validación para diferentes campos
    public class Validaciones
    {
        // Valida que una cadena no este vacia o solo contenga espacios
        public static bool ValidarCampoNoVacio(string campo)
        {
            if (campo == null || campo.Trim() == "")
            {
                return false;
            }
            return true;
        }

        // Valida que un celular tenga 10 digitos
        public static bool ValidarCelular(string celular)
        {
            if (celular == null || celular.Length != 10)
            {
                return false;
            }

            // Verificar que todos los caracteres sean numeros
            for (int i = 0; i < celular.Length; i++)
            {
                if (celular[i] < '0' || celular[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        // Valida que un email tenga formato basico valido
        public static bool ValidarEmail(string email)
        {
            if (email == null || email.Trim() == "")
            {
                return false;
            }

            // Buscar el simbolo @
            int posicionArroba = -1;
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    posicionArroba = i;
                    break;
                }
            }

            // Debe tener @ y no puede estar al inicio ni al final
            if (posicionArroba <= 0 || posicionArroba >= email.Length - 1)
            {
                return false;
            }

            // Debe tener al menos un punto despues del @
            bool tienePuntoDespuesArroba = false;
            for (int i = posicionArroba + 1; i < email.Length; i++)
            {
                if (email[i] == '.')
                {
                    tienePuntoDespuesArroba = true;
                    break;
                }
            }

            return tienePuntoDespuesArroba;
        }

        // Valida que un precio sea mayor a cero
        public static bool ValidarPrecio(decimal precio)
        {
            return precio > 0;
        }

        // Valida que una cantidad sea mayor a cero
        public static bool ValidarCantidad(int cantidad)
        {
            return cantidad > 0;
        }

        // Lee un numero entero desde consola con validacion
        public static int LeerEntero(string mensaje)
        {
            int numero;
            bool valido = false;

            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                // Intentar convertir a entero
                valido = int.TryParse(entrada, out numero);

                if (!valido)
                {
                    Console.WriteLine("Error: Debe ingresar un numero entero valido.");
                }

            } while (!valido);

            return numero;
        }

        // Lee un numero decimal desde consola con validacion
        public static decimal LeerDecimal(string mensaje)
        {
            decimal numero;
            bool valido = false;

            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                // Intentar convertir a decimal
                valido = decimal.TryParse(entrada, out numero);

                if (!valido)
                {
                    Console.WriteLine("Error: Debe ingresar un numero decimal valido.");
                }

            } while (!valido);

            return numero;
        }

        // Pausa la ejecucion hasta que el usuario presione una tecla
        public static void PausarConsola()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Limpia la consola
        public static void LimpiarConsola()
        {
            Console.Clear();
        }
    }
}
