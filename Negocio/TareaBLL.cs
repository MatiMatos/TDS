using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class TareaBLL
    {
        BaseDeDatosEntities bde = new BaseDeDatosEntities();

        public void Add(string titulo, string cuerpo, DateTime fechaCreacion, int estado)
        {
            Tarea nueva = new Tarea();
            nueva.Titulo = titulo;
            nueva.Cuerpo = cuerpo;
            nueva.FechaCreacion = fechaCreacion;
            nueva.Estado = estado;
            bde.Tarea.Add(nueva);
            bde.SaveChanges();
        }

        public List<Tarea> GetAll()
        {
            List<Tarea> tarea = new List<Tarea>();
            return bde.Tarea.ToList();
        }
    }
}
