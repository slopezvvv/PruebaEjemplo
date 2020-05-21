using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaEjemplo
{
    class Motocicleta : Vehiculo
    {
        private string _marca;
        private int _ano;
        private int _kilometraje;

        public Motocicleta(string idMotor, TipoMotor tipoMotor, int cilindrada,
                           string marca, int ano, int kilometraje) : base(idMotor, tipoMotor, cilindrada)
        {
            Marca = marca;
            Ano = ano;
            Kilometraje = kilometraje;
        }

        public string Marca { get => _marca; set => _marca = value; }
        public int Ano { get => _ano; set => _ano = value; }
        public int Kilometraje { get => _kilometraje; set => _kilometraje = value; }
    }
}
