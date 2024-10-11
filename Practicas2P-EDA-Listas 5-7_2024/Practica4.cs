using System;
using System.Collections.Generic;
using System.Linq;
/*
namespace Forms
{
    public class Práctica4
    {
        private LinkedList<Producto> productosCirculares; // Lista enlazada para productos
        private Random random;

        public Práctica4()
        {
            productosCirculares = new LinkedList<Producto>();
            random = new Random();
        }

        // Agrega un producto con nombre y precio aleatorio
        public void AgregarProducto(string nombre)
        {
            if (!string.IsNullOrEmpty(nombre))
                productosCirculares.AddLast(new Producto(nombre, 1, random.Next(10, 100)));
        }

        // Elimina el producto de la lista por nombre
        public void EliminarProducto(string nombre)
        {
            var productoEliminar = productosCirculares.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (productoEliminar != null)
                productosCirculares.Remove(productoEliminar);
        }

        // Devuelve la lista de productos ordenados por nombre
        public List<Producto> ObtenerProductosOrdenados()
        {
            return productosCirculares.OrderBy(p => p.Nombre).ToList();
        }

        // Calcula el costo total de todos los productos en la lista
        public int CalcularCostoTotal()
        {
            return productosCirculares.Sum(p => p.Precio);
        }
    }
}
*/