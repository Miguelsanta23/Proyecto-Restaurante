# Proyecto Restaurante

Sistema de Gestion de Restaurante

Sistema de gestion de restaurante desarrollado en C# que utiliza estructuras de datos implementadas desde cero (Listas Enlazadas, Colas y Pilas) sin usar las colecciones nativas de .NET.

Descripcion
Este proyecto es un sistema de consola que permite gestionar restaurantes, clientes, menus y pedidos. Implementa las siguientes estructuras de datos desde cero:

Lista Enlazada: Para gestionar restaurantes, clientes, platos y pedidos
Cola (FIFO): Para gestionar pedidos pendientes de despachar
Pila (LIFO): Para llevar el historial de platos servidos

Caracteristicas Principales

Gestion de Restaurantes
    Crear restaurantes con NIT unico
    Editar informacion del restaurante
    Listar todos los restaurantes registrados
    Validacion de campos obligatorios

Gestion de Clientes
    Crear clientes con cedula unica
    Editar informacion de clientes
    Borrar clientes (validando que no tengan pedidos pendientes)
    Listar todos los clientes
    Validacion de email y celular

Gestion de Platos (Menu)
    Crear platos con codigo unico
    Editar información de platos
    Borrar platos (validando que no esten en pedidos pendientes)
    Listar menu completo
    Validacion de precios

Gestion de Pedidos
    Tomar pedidos de clientes
    Agregar multiples platos con cantidades
    Encolar pedidos (FIFO)
    Despachar pedidos en orden de llegada
    Ver pedidos pendientes y todos los pedidos

Reportes
    Ganancias del dia
    Historial de platos servidos
    Lista completa de pedidos

Tecnologias utilizadas
Lenguaje: C# (.NET 9.0)
Tipo: Aplicación de Consola
IDE: Visual Studio Code

ESTRUCTURA DEL PROYECTO

Proyecto_Restaurante/
│
├── Estructuras/           // Estructuras de datos implementadas desde cero
│   ├── Nodo.cs
│   ├── ListaEnlazada.cs
│   ├── Cola.cs
│   └── Pila.cs
│
├── Modelos/            // Clases de dominio
│   ├── Restaurante.cs
│   ├── Cliente.cs
│   ├── Plato.cs
│   ├── PlatoPedido.cs
│   └── Pedido.cs
│
├── Servicios/            // Logica de negocio
│   ├── ServicioRestaurante.cs
│   ├── ServicioCliente.cs
│   ├── ServicioPlato.cs
│   └── ServicioPedido.cs
│
├── UI/                   // Interfaz de usuario (menus)
│   ├── MenuPrincipal.cs
│   ├── MenuRestaurante.cs
│   ├── MenuCliente.cs
│   ├── MenuPlato.cs
│   ├── MenuPedido.cs
│   └── MenuReportes.cs
│
├── Utilidades/           // Clases auxiliares
│   └── Validaciones.cs
|
├── .gitignore
├── Program.cs            // Punto de entrada
├── Proyecto_Restaurante.csproj
├── Proyecto_Restaurante.sln
└── README.md

![Esctructura del Proyecto](ImagenesReadme/estructura_proyecto1.png)
![Esctructura del Proyecto](ImagenesReadme/estructura_proyecto2.png)

