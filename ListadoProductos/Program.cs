// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text.Json;

namespace ListadoProductos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string nombreJson = "productos.json";

            var rnd = new Random();

            var listaProductos = new List<Producto>();

            int cant = rnd.Next(1, 16);
            Console.WriteLine($"\nCantidad de productos: {cant}");

            CreacionProductos(listaProductos, cant);

            string lista = Serializacion(listaProductos);

            EscribirArchivo(nombreJson, lista);

            string texto = File.ReadAllText(nombreJson);

            var info = JsonSerializer.Deserialize<List<Producto>>(texto);

            MostrarProductos(info);
        }

        private static void MostrarProductos(List<Producto>? info)
        {
            Console.WriteLine("\nMuestra de productos:");
            foreach (var item in info)
            {
                Console.WriteLine($"\nNombre del producto: {item.Nombre}");
                Console.WriteLine($"Fecha de vencimiento: {item.FechaVencimiento}");
                Console.WriteLine($"Precio: ${item.Precio}");
                Console.WriteLine($"Tamaño: {item.Tamanio}");
            }
        }

        private static void EscribirArchivo(string nombreJson, string lista)
        {
            Console.WriteLine("\nEscribiendo archivo Json...");
            var escribir = new StreamWriter(File.Open(nombreJson, FileMode.Create));
            escribir.WriteLine(lista);
            escribir.Close();
            Console.WriteLine("Escritura exitosa");
        }

        private static string Serializacion(List<Producto> listaProductos)
        {
            Console.WriteLine("\nSerializando...");
            string lista = JsonSerializer.Serialize(listaProductos);
            Console.WriteLine("Serialización exitosa");
            return lista;
        }

        private static void CreacionProductos(List<Producto> listaProductos, int cant)
        {
            for (int i = 0; i < cant; i++)
            {
                var produ = new Producto();
                listaProductos.Add(produ);
            }
        }
    }
}