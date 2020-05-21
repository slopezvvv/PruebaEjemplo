using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace PruebaEjemplo
{
    class Program
    {
        private static readonly string username = "admin";
        private static readonly string pass = "123";
        private static int exitCode = 0;
        private static readonly ArrayList _motocicletas = new ArrayList(); // persistencia

        static void Main(string[] args)
        {
            const int intentosMaximos = 3;
            int intentosRealizados = 0;
            while (true)
            {
                intentosRealizados++;
                // Pedimos el username
                Console.WriteLine("Ingrese el nombre de usuario:");
                string tmpUsername = Console.ReadLine();

                // Pedimos la contraseña
                Console.WriteLine("Ingrese la contraseña:");
                string tmpPass = Console.ReadLine();

                // Hacemos la llamada al método Login para saber si es un usuario válido
                if (Login(tmpUsername, tmpPass))
                    IniciarMenuPrincipal();
                else
                {
                    Console.WriteLine("El usuario y/o la contraseña son incorrectos. Intentelo de nuevo.");
                    if (intentosRealizados >= intentosMaximos) Environment.Exit(exitCode);
                    break;
                }
            }
        }

        private static bool Login(string username, string pass)
        {
            return Program.username == username && Program.pass == pass;
        }

        private static void IniciarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido a mi app de motocicletas, elija una opcion:");
                Console.WriteLine("1. Ingresar motocicleta.");
                Console.WriteLine("2. Listar motocicletas.");
                Console.WriteLine("3. Salir.");
                

                int opcion;
                string input = Console.ReadLine();
                if (int.TryParse(input, out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingrese numero de motor:");
                            string idMotor = Console.ReadLine();

                            Console.WriteLine("Ingrese el tipo de motor:");
                            Console.WriteLine("1. Cuatro tiempos.");
                            Console.WriteLine("2. Dos tiempos.");

                            TipoMotor tipoMotor = Console.ReadLine() == "2" ?
                                TipoMotor.DOS_TIEMPOS : TipoMotor.CUATRO_TIEMPOS;

                            Console.WriteLine("Ingrese la cilindrada:");
                            int cilindrada = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese el año:");
                            int ano = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese la marca:");
                            string marca = Console.ReadLine();

                            Console.WriteLine("Ingrese el kilometraje:");
                            int kilometraje = int.Parse(Console.ReadLine());

                            Motocicleta motocicleta = new Motocicleta(idMotor, tipoMotor, cilindrada,
                                                                      marca, ano, kilometraje);
                            _motocicletas.Add(motocicleta);
                            break;

                        case 2:
                            // Listar los vehiculos
                            if (_motocicletas.Count > 0)
                                foreach (Motocicleta tmpMotocicleta in _motocicletas)
                                {
                                    Console.WriteLine("ID del motor: " + tmpMotocicleta.Motor.Id);
                                    Console.WriteLine("Tipo del motor: " + tmpMotocicleta.Motor.TipoMotor);
                                    Console.WriteLine("Cilindrada: " + tmpMotocicleta.Motor.Cilindrada);
                                    Console.WriteLine("Estado del motor: " + tmpMotocicleta.Motor.Estado + "%");
                                    Console.WriteLine("Marca: " + tmpMotocicleta.Marca);
                                    Console.WriteLine("Año: " + tmpMotocicleta.Ano);
                                    Console.WriteLine("Kilometraje: " + tmpMotocicleta.Kilometraje);
                                    Console.WriteLine("______________________________________________");
                                    Console.WriteLine(string.Empty);
                                }
                            else
                                Console.WriteLine("No hay motocicletas registradas.");
                            Console.WriteLine("* Presione cualquier tecla para continuar *");
                            Console.ReadLine();
                            break;

                        case 3:
                            // Salir del programa
                            if (exitCode == 0)
                                Console.WriteLine("La aplicación finalizó correctamente.");
                            else
                                Console.WriteLine("Hubo errores al finalizar el programa.");
                            Environment.Exit(exitCode); // Equivalencia en java: System.exit(0);
                            break;

                        default:
                            break;
                    }
                }
                else Console.WriteLine("Opcion no valida");
            }
        }
    }
}
