using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_diciembre_25
{
    class TipoMensaje
    {
        //Atributos
        private string _codigoTipoMensaje;
        private string _nombreTipoMensaje;

        //Propiedades
        public string CodigoTipoMensaje
        {
            get { return _codigoTipoMensaje; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El 'Código' no puede ser vacío.");
                if (value.Length != 3)
                    throw new ArgumentException("El 'Código' debe ser de 3 caraceres.");

                _codigoTipoMensaje = value.Trim().ToUpper();
            }
        }

        public string NombreTipoMensaje
        {
            get { return _nombreTipoMensaje; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El 'Nombre' no puede ser vacío.");

                _nombreTipoMensaje = value.Trim();
            }
        }

        //Constructor
        public TipoMensaje(string pcodigoTipoMensaje, string pnombreTipoMensaje)
        {
            CodigoTipoMensaje = pcodigoTipoMensaje;
            NombreTipoMensaje = pnombreTipoMensaje;
        }

        //Métodos
        public override string ToString()
        {
            return $"Código: {CodigoTipoMensaje}, Nombre: {NombreTipoMensaje}";
        }
    }
}
