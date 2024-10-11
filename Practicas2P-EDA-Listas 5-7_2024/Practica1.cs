using System;
using System.Collections.Generic;
/*
namespace Forms
{
    public class Práctica1
    {
        private LinkedList<Producto> productos; // Lista para almacenar productos
        private int productosRetirados; // Contador de productos retirados
        private Random random;
        private int productoId;

        public Práctica1()
        {
            productos = new LinkedList<Producto>();
            random = new Random();
            productosRetirados = 0;
            productoId = 1;
        }

        // Agrega un nuevo producto con nombre, cantidad y precio aleatorios
        public void AgregarProducto()
        {
            string nombre = "Producto" + productoId++;
            int cantidad = random.Next(1, 100);
            int precio = random.Next(10, 500);
            productos.AddLast(new Producto(nombre, cantidad, precio));
        }

        // Retira el producto seleccionado de la lista
        public void RetirarProducto(Producto productoSeleccionado)
        {
            if (productoSeleccionado != null)
            {
                productos.Remove(productoSeleccionado); // Elimina de la lista
                productosRetirados++; // Incrementa retirados
            }
        }

        // Devuelve la lista de productos actuales
        public List<Producto> ObtenerProductos()
        {
            return new List<Producto>(productos);
        }

        // Devuelve el número total de productos retirados
        public int ObtenerTotalProductosRetirados()
        {
            return productosRetirados;
        }
    }
}
*/