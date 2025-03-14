﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiculosApp.DAL;
using VehiculosApp.Modelos;

namespace VehiculosApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// 
            //Vehiculo vehiculo1 = new Automovil("Nissan", "Frontier", 2010, 2);
            //Vehiculo vehiculo2 = new Motocicleta("Yamaha","YMT-03", 2015);

            //// Mostrar el detalle de cada objetos
            //Console.WriteLine(vehiculo1.MostrarDetalles());
            //Console.WriteLine(new string('-', 10));
            //Console.WriteLine(vehiculo2.MostrarDetalles());

            bool activado = true;

            do
            {
                Console.WriteLine("Bienvenido a la Consesionaria de Vehículos El Salvador");
                Separador();
                Console.WriteLine("Seleccione una opción: ");
                Separador();
                Console.WriteLine("1. Insertar un vehiculo\n2. Mostrar los vehiculos almacenados\n3. Actualizar vehiculos\n0. Salir");
                Separador();

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("Gracias por visitarnos, lo esperamos pronto");
                        activado = false;
                        break;
                    case 1:
                        InsertarVehiculo();
                        break;
                    case 2:
                        MostrarVehiculos();
                        break;
                    case 3:
                        ActualizarVehiculos();
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta vuelve a intentarlo");
                        break;
                }
                Separador();

            } while (activado);

            Console.ReadLine();
        }

        private static void ActualizarVehiculos()
        {
            Separador();
            Console.WriteLine("Digite el \"Codigo\" del vehiculo a actualizar:");
            MostrarVehiculos();

            int id = int.Parse(Console.ReadLine());

            if (id > 0)
            {
                InsertarVehiculo(id, true);
            }
            else
            {
                Console.WriteLine("El id ingresado es incorrecto");
            }
        }

        private static void MostrarVehiculos()
        {
            VehiculosDAL vehiculoDAL = new VehiculosDAL();

            List<Vehiculo> vehiculos = vehiculoDAL.ObtenerVehiculos();
            Separador();
            foreach (Vehiculo vehiculo in vehiculos)
            {
                Console.WriteLine(vehiculo.MostrarDetalles());
                Separador();
            }
        }

        private static void InsertarVehiculo(int id = 0, bool esActualizacion = false)
        {
            VehiculosDAL vehiculoDAL = new VehiculosDAL();

            Console.Write("Escribe la Marca: ");
            string marca = Console.ReadLine();

            Console.Write("Escribe el Modelo: ");
            string modelo = Console.ReadLine();

            Console.Write("Digital el Año: ");
            int año = int.Parse(Console.ReadLine());

            Console.Write("Elige el Tipo de Vehículo (Automovil/Motocicleta): ");
            string tipo = Console.ReadLine();

            if (tipo.Equals("Automovil"))
            {
                Console.Write("Digital el N° de Puertas: ");
                int puertas = int.Parse(Console.ReadLine());

                if (id > 0 && esActualizacion)
                {
                    vehiculoDAL.ActualizarVehiculo(id, marca, modelo, año, puertas, tipo);
                }
                else
                {
                    vehiculoDAL.GuardarVehiculo(marca, modelo, año, tipo, puertas);
                }                
            }
            else
            {
                if (id > 0 && esActualizacion)
                {
                    vehiculoDAL.ActualizarVehiculo(id, marca, modelo, año, 0, tipo);
                }
                else
                {
                    vehiculoDAL.GuardarVehiculo(marca, modelo, año, tipo);
                }
            }          

        }

        static void Separador()
        {
            Console.WriteLine(new string('-', 20));
        }
    }
}
