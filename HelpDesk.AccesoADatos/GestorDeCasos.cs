using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.AccesoADatos
{
   public class GestorDeCasos
    {
        public void Agregar(Model.Casos elNuevoCaso)
        {

            var db = new Context();
            db.Casos.Add(elNuevoCaso);
            db.Entry(elNuevoCaso).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public void Actualizar(Model.Casos elCaso)
        {

            var db = new Context();
            var valorBd = ObtenerCasoPorId(elCaso.Id);

            valorBd.DescripcionProblema = elCaso.DescripcionProblema;
            valorBd.Nivel = elCaso.Nivel;
            valorBd.Estado = elCaso.Estado;
            valorBd.ObservacionesResolucion = elCaso.ObservacionesResolucion;
            valorBd.NombreContacto = elCaso.NombreContacto;
            valorBd.TelefonoContacto = elCaso.TelefonoContacto;
            valorBd.DireccionContacto = elCaso.DireccionContacto;
            valorBd.ProvinciaContacto = elCaso.ProvinciaContacto;

            valorBd.FechaResolucion = null;
            valorBd.ObservacionesResolucion = null;
            valorBd.FechaInicioProceso = null;
            valorBd.NombrePersonaResuelve = null;
            valorBd.MotivoRechazo = null;
            valorBd.DescripcionResolucion = null;

            db.Entry(valorBd).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public Model.Casos ObtenerCasoPorId(int Id)
        {
            var db = new Context();
            var resultado = db.Casos.Find(Id);

            return resultado;
        }

        public void Eliminar(Model.Casos elCaso)
        {
            var db = new Context();
            var valorBd = ObtenerCasoPorId(elCaso.Id);

            valorBd = elCaso;
            

            db.Entry(valorBd).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public void EnProceso(Model.Casos elCaso)
        {
            var db = new Context();
            var valorBd = ObtenerCasoPorId(elCaso.Id);

            valorBd = elCaso;

            db.Entry(valorBd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Rechazar(Model.Casos elCaso)
        {
            var db = new Context();
            var valorBd = ObtenerCasoPorId(elCaso.Id);

            valorBd = elCaso;

            db.Entry(valorBd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Terminar(Model.Casos elCaso)
        {
            var db = new Context();
            var valorBd = ObtenerCasoPorId(elCaso.Id);

            valorBd = elCaso;

            db.Entry(valorBd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public List<Model.Casos> ObtenerTodosLosCasos()
        {
            var db = new Context();
            var resultado = db.Casos.ToList();
            return resultado;

        }

        public List<Model.Casos> ObtenerCasosPorEstado(int estado)
        {
            var db = new Context();
            var resultado = from busqueda in db.Casos
                            where busqueda.Estado.Equals(estado)
                            select busqueda;
            return resultado.ToList();

        }


        public List<Model.Casos> ObtenerCasosPorNivelDeCriticidad(string nivelDeCriticidad)
        {
            var db = new Context();
            var resultado = from busqueda in db.Casos
                            where busqueda.Nivel.Equals(nivelDeCriticidad)
                            select busqueda;
            return resultado.ToList();

        }

        public List<Model.Casos> ObtenerCasosEnEstadoRegistrado()
        {
            var db = new Context();
            var resultado = from busqueda in db.Casos
                            where busqueda.Estado.Equals(1)
                            select busqueda;
            return resultado.ToList();

        }


    }
}
