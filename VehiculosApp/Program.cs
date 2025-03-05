using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculosApp.Modelos;

namespace VehiculosApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 
            Vehiculo vehiculo1 = new Automovil("Nissan", "Frontier", 2010, 2);
            Vehiculo vehiculo2 = new Motocicleta("Yamaha","YMT-03", 2015);

            // Mostrar el detalle de cada objetos
            Console.WriteLine(vehiculo1.MostrarDetalles());
            Console.WriteLine(new string('-', 10));
            Console.WriteLine(vehiculo2.MostrarDetalles());

            Console.ReadLine();
        }
    }
}
