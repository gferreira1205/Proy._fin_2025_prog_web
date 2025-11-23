using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_diciembre_25
{
    abstract class Mensaje
    {
        //Atributos
        private int _idMensaje;
        private DateTime _fechaHora;
        private string _asuntoMensaje;
        private string _cuerpoMensaje;
        private Usuario _emisor;
        private Usuario _receptor;

        //Propiedades
        public int IdMensaje
        {
            get { return _idMensaje; }
            set
            {
                //decido crear esta validación aunque lo vamos a crear nosotros como validación
                //en caso de algún error o ingreso manual
                if (value < 0)
                    throw new ArgumentException("El 'ID del mensaje' debe ser mayor que 0.");
                _idMensaje = value;
            }
        }

        public DateTime FechaHora
        {
            get { return _fechaHora; }
            set
            {
                //decido crear esta validación aunque lo vamos a crear nosotros como validación
                //en caso de algún error o ingreso manual
                if (value > DateTime.Now)
                    throw new ArgumentException("No se permite fecha futura.");

                _fechaHora = value;
            }
        }

        public string AsuntoMensaje
        {
            get { return _asuntoMensaje; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("El 'Asunto' no puede ser vacío.");
                if (value.Length > 50)
                    throw new ArgumentException("El 'Asunto' debe contener como máximo 50 caracteres.");

                _asuntoMensaje = value.Trim();
            }
        }

        public string CuerpoMensaje
        {
            get { return _cuerpoMensaje; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("El 'Cuerpo' no puede ser vacío.");
                if (value.Length > 200)
                    throw new ArgumentException("El 'Cuerpo' debe contener como máximo 200 caracteres.");

                _cuerpoMensaje = value.Trim();
            }
        }

        public Usuario Emisor
        {
            get { return _emisor; }
            set
            {
                if (value == null)
                    throw new ArgumentException("El 'Emisor' no puede ser nulo.");

                _emisor = value;
            }
        }

        public Usuario Receptor
        {
            get { return _receptor; }
            set
            {
                if (value == null)
                    throw new ArgumentException("El 'Receptor' no puede ser nulo.");

                _receptor = value;
            }
        }

        //Constructor
        protected Mensaje(int pidMensaje, DateTime pfechaHora, string pasuntoMensaje, string pcuerpoMensaje,
                          Usuario pemisor, Usuario preceptor)
        {
            IdMensaje = pidMensaje;
            FechaHora = pfechaHora;
            AsuntoMensaje = pasuntoMensaje;
            CuerpoMensaje = pcuerpoMensaje;
            Emisor = pemisor;
            Receptor = preceptor;
    }

        //Métodos
        public virtual string ToStringBase()
        {
            return $"ID: {IdMensaje}, Fecha: {FechaHora}, Asunto: {AsuntoMensaje}, Cuerpo: {CuerpoMensaje}," +
                   $"Emisor: {Emisor.NombreUsuario}, Receptor: {Receptor.NombreUsuario}";
        }
    }
}
