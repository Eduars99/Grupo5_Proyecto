using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_Database
{
    class ClassRegistro
    {
        TiendaEntities db = new TiendaEntities();
        public void InsertarDatos(int UserID, string password, string name, string lastname, string DNI, string email,
           string phone, string role)

        {
            Usuario NewRegistro = new Usuario()
            {
                User_ID = UserID,
                Password = password,
                National_ID = DNI,
                Nombre = name,
                Apellido = lastname,
                //Gender = gender,
                Email = email,
                Phone = phone,
                Role = role

            };
            db.Usuarios.Add(NewRegistro);
            db.SaveChanges(); //insert into... values...
        }

        public List<Usuario> ObtenerUsuario(int user)
        {
            var Query = from username in db.Usuarios
                        where username.User_ID == user
                        select username;
            return Query.ToList();
        }

        public List<Usuario> ObtenerLogin(int user, string contrasena)
        {
            var Query = from username in db.Usuarios
                        where username.User_ID == user && username.Password == contrasena
                        select username;
            return Query.ToList();
        }

    }
}
