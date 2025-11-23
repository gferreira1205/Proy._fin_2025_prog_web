using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_diciembre_25
{
    class MensajePrivado : Mensaje
    {
        //Atributos
        private DateTime _fechaCaducidad;

        //Propiedades
        public DateTime FechaCaducidad
        {
            get { return _fechaCaducidad; }
            set 
            {
                if (value <= FechaHora)
                    throw new ArgumentException("La 'Fecha de caducidad' debe ser posterior a la fecha del mensaje.");

                _fechaCaducidad = value;
            }
        }
        //Constructor
        public MensajePrivado(int pidMensaje, DateTime pfechaHora, string pasuntoMensaje, string pcuerpoMensaje,
                              Usuario pemisor, Usuario preceptor, DateTime pfechaCaducidad)
            : base(pidMensaje, pfechaHora, pasuntoMensaje, pcuerpoMensaje, pemisor, preceptor)
        {
            FechaCaducidad = pfechaCaducidad;
        }

        // Métodos
        public override string ToString()
        {
            // usamos base.ToStringBase() para no repetir lo común
            return $"{base.ToStringBase()}, Fecha de caducidad: {FechaCaducidad:yyyy-MM-dd}";
        }
    }

   
}
