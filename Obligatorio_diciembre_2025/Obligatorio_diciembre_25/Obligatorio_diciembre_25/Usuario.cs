using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_diciembre_25
{
    class Usuario
    {
        //Atributos
        private string _nombreUsuario;
        private string _nombreCompleto;
        private DateTime _fechaNacimiento;
        private string _telefono;

        //Propiedades
        //Decido y valido que el nombre de usuario contenga al menos 3 caracteres
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El 'Nombre de Usuario' no puede ser vacío.");
                if (value.Length < 3)
                {
                    throw new ArgumentException("El 'Nombre de Usuario' debe contener al menos 3 caracteres.");
                }

                _nombreUsuario = value.Trim();
            }

        }
        public string NombreCompleto
        {
            get { return _nombreCompleto; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El 'Nombre Completo' no puede ser vacío.");

                _nombreCompleto = value.Trim();
            }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("La fecha de nacimiento no puede ser en el futuro.");

                // Validación razonable de edad: menor de 120 años
                int edad = CalcularEdad(value, DateTime.Now);
                if (edad > 120)
                    throw new ArgumentException("Error, no se permiten edades > 120.");

                _fechaNacimiento = value.Date;
            }
        }

        //Decido validar que el teléfono esté entre 5 y 20 digitos. Si bien el número más extenso existente
        //es de 15, dejo un rango mayor.
        public string Telefono
        {
            get { return _telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El 'Número de teléfono' no puede ser vacío.");
                if (value.Length < 5 || value.Length > 20)
                    throw new ArgumentException("El teléfono debe tener entre 5 y 20 caracteres.");

                _telefono = value.Trim();

            }
        }
        //Constructor
        public Usuario(string pnombreUsuario, string pnombreCompleto, DateTime pfechaNacimiento, string ptelefono )
        {
            NombreUsuario = pnombreUsuario;
            NombreCompleto = pnombreCompleto;
            FechaNacimiento = pfechaNacimiento;
            Telefono = ptelefono;
        }

        //Métodos
        //Método auxiliar privado para calcular edad
        private static int CalcularEdad(DateTime nacimiento, DateTime referencia)
        {
            int edad = referencia.Year - nacimiento.Year;
            //Con el siguiente if, valido si no debo restar 1 a la cuenta de años.
            if (referencia.Month < nacimiento.Month || (referencia.Month == nacimiento.Month && referencia.Day < nacimiento.Day))
                edad--;
            return edad;
        }

        //Método para mostrar datos
        public override string ToString()
        {
            return $"Usuario: {NombreUsuario}, Nombre Completo: {NombreCompleto}, Fecha Nacimiento: {FechaNacimiento.ToShortDateString()}, Teléfono: {Telefono}";
        }
    }
}
