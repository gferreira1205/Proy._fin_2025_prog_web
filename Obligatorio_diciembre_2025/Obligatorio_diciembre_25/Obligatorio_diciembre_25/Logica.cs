using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_diciembre_25
{
    class Logica
    {
        //Atributos 
        private List<Usuario> _usuarios;
        private List<TipoMensaje> _tiposMensajes;
        private List<Mensaje> _mensajes;

        //Constructor
        public Logica()
        {
            _usuarios = new List<Usuario>();
            _tiposMensajes = new List<TipoMensaje>();
            _mensajes = new List<Mensaje>();
        }

        //Métodos
        private int ObtenerSiguienteId()
        {
            int mayor = 0;

            foreach (Mensaje m in _mensajes)
            {
                if (m.IdMensaje > mayor)
                    mayor = m.IdMensaje;
            }

            return mayor + 1;
        }

        // AltaUsuario
        public void AltaUsuario(Usuario u)
        {
            if (u == null)
                throw new ArgumentException("El usuario no puede ser nulo.");

            string nombreBuscado = u.NombreUsuario.Trim().ToLower();

            foreach (Usuario usu in _usuarios)
            {
                if (usu.NombreUsuario.Trim().ToLower() == nombreBuscado)
                    throw new Exception("Ya existe un usuario con ese nombre.");
            }

            _usuarios.Add(u);
        }

        // BuscarUsuario
        public Usuario BuscarUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                return null;

            string buscado = nombreUsuario.Trim().ToLower();

            foreach (Usuario u in _usuarios)
            {
                if (u.NombreUsuario.Trim().ToLower() == buscado)
                    return u;
            }

            return null;
        }

        // AltaTipoMensaje
        public void AltaTipoMensaje(TipoMensaje t)
        {
            if (t == null)
                throw new ArgumentException("El tipo no puede ser nulo.");

            foreach (TipoMensaje tipo in _tiposMensajes)
            {
                if (tipo.CodigoTipoMensaje == t.CodigoTipoMensaje)
                    throw new Exception("Ya existe un tipo de mensaje con ese código.");
            }

            _tiposMensajes.Add(t);
        }

        // BuscarTipo
        public TipoMensaje BuscarTipo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            string buscado = codigo.Trim().ToUpper();

            foreach (TipoMensaje t in _tiposMensajes)
            {
                if (t.CodigoTipoMensaje == buscado)
                    return t;
            }
            return null;
        }

        // AltaMensajePrivado
        public void AltaMensajePrivado(MensajePrivado priv)
        {
            if (priv == null)
                throw new ArgumentException("El mensaje no puede ser nulo.");

            priv.IdMensaje = ObtenerSiguienteId();
            priv.FechaHora = DateTime.Now;

            _mensajes.Add(priv);
        }

        // AltaMensajeComun
        public void AltaMensajeComun(MensajeComun m)
        {
            if (m == null)
                throw new ArgumentException("El mensaje no puede ser nulo.");

            m.IdMensaje = ObtenerSiguienteId();
            m.FechaHora = DateTime.Now;

            _mensajes.Add(m);
        }

        // ListarMensajesPorEmisor
        public List<Mensaje> ListarMensajesPorEmisor(Usuario u)
        {
            List<Mensaje> listaMensEmi = new List<Mensaje>();

            foreach (Mensaje m in _mensajes)
            {
                if (m.Emisor.NombreUsuario == u.NombreUsuario)
                    listaMensEmi.Add(m);
            }

            return listaMensEmi;
        }

        // ListarMensajesComunesPorTipo
        public List<MensajeComun> ListarMensajesComunesPorTipo(TipoMensaje t)
        {
            List<MensajeComun> listaMensTipo = new List<MensajeComun>();

            foreach (Mensaje m in _mensajes)
            {
                if (m is MensajeComun comun)
                {
                    if (comun.Tipo.CodigoTipoMensaje == t.CodigoTipoMensaje)
                        listaMensTipo.Add(comun);
                }
            }

            return listaMensTipo;
        }

    }
}
