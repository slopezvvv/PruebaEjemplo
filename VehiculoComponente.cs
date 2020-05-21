using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaEjemplo
{
    abstract class VehiculoComponente
    {
        private double _estado;

        protected VehiculoComponente()
        {
            Estado = 100.0;
        }

        public double Estado { get => _estado; set => _estado = value; }
    }
}
