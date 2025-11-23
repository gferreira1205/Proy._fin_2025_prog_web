using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_diciembre_25
{
    class MensajeComun : Mensaje
    {
        // Atributo propio
        private TipoMensaje _tipo;

        // Propiedad
        public TipoMensaje Tipo
        {
            get { return _tipo; }
            set
            {
                if (value == null)
                    throw new ArgumentException("El 'Tipo de Mensaje' no puede ser nulo.");

                _tipo = value;
            }
        }

        // Constructor: recibe lo base + el tipo.
        public MensajeComun(int pidMensaje, DateTime pfechaHora, string pasuntoMensaje,
                            string pcuerpoMensaje, Usuario pemisor, Usuario preceptor,
                            TipoMensaje ptipoMensaje)
            : base(pidMensaje, pfechaHora, pasuntoMensaje, pcuerpoMensaje, pemisor, preceptor)
        {
            Tipo = ptipoMensaje;
        }

        // ToString mejorado
        public override string ToString()
        {
            return $"{ToStringBase()}, Tipo: {Tipo.CodigoTipoMensaje} - {Tipo.NombreTipoMensaje}";
        }
    }
}
