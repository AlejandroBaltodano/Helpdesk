using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.LogicaDeNegocios
{
    public class CordinadorDeCasos
    {
        public void AgregarUnCaso(Model.Casos caso)
        {
            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();

            caso.Estado = (int)Estado.Registrado;
            caso.FechaCreacion = (DateTime)DateTime.Now;

            gestorDeCasos.Agregar(caso);

        }

        public Model.Casos ConsultarPorId(int id)
        {
            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();
            return gestorDeCasos.ObtenerCasoPorId(id);


        }

        public void EditarUnCaso(Model.Casos caso)
        {
            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();

            if (caso.Estado==1||caso.Estado==2)
            {
                gestorDeCasos.Actualizar(caso);
            }

        }

        public void EliminarUnCaso(Model.Casos caso) {

            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();

            if (caso.Estado == 1)
            {
                caso.Estado = (int)Estado.Eliminado;
                gestorDeCasos.Eliminar(caso);
            }
        }

        public bool PonerEnProcesoUnCaso(Model.Casos caso,string nombrePersonaResuelve)
        {
            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();
            bool casoExedidoDeTiempo = ValidacionDeTiempo(caso);

            if (caso.Estado == 1)
            {
                if (casoExedidoDeTiempo)
                {

                }
                else {

                if (nombrePersonaResuelve != "" || nombrePersonaResuelve != null)
                {
                    caso.Estado = (int)Estado.EnProceso;
                    caso.FechaInicioProceso = DateTime.Now;
                    caso.NombrePersonaResuelve = nombrePersonaResuelve;

                    gestorDeCasos.EnProceso(caso);
                }
                }
                
            }
            return casoExedidoDeTiempo;
        }

        public bool RechazarUnCaso(Model.Casos caso, string motivoDeRechazo)
        {

            bool seActualizoCorrectamente = false;
            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();

            if (caso.Estado == (int)Estado.Registrado)
            {
                if (motivoDeRechazo != "" || motivoDeRechazo != null)
                {
                    caso.Estado = (int)Estado.Rechazado;
                    caso.MotivoRechazo = motivoDeRechazo;

                    gestorDeCasos.Rechazar(caso);
                    seActualizoCorrectamente = true;
                }

            }
            else
            {
                seActualizoCorrectamente = false;
            }

            return seActualizoCorrectamente;
        }

        public bool TerminarUnCaso(Model.Casos caso, string descripcionResolucion)
        {

            bool seActualizoCorrectamente = false;
            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();

            if (caso.Estado == (int)Estado.EnProceso)
            {
                if (descripcionResolucion != "" || descripcionResolucion != null)
                {
                    caso.Estado = (int)Estado.Terminado;
                    caso.DescripcionResolucion = descripcionResolucion;
                    caso.FechaResolucion = DateTime.Now;

                    gestorDeCasos.Terminar(caso);
                    seActualizoCorrectamente = true;
                }

            }
            else
            {
                seActualizoCorrectamente = false;
            }

            return seActualizoCorrectamente;
        }

        public List<Model.Casos> ObtenerListaPorEstado(int estado)
        {
            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();
            return gestorDeCasos.ObtenerCasosPorEstado(estado);

        }

        public List<Model.Casos> ObtenerListaPorNivelDeCriticidad(string nivelDeCriticidad)
        {
            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();
            return gestorDeCasos.ObtenerCasosPorNivelDeCriticidad(nivelDeCriticidad);

        }

        public bool ValidacionDeTiempo(Model.Casos caso)
        {
            bool tiempoExidedo = false;

            DateTime fechaActual = DateTime.Now;
            DateTime fechaCreacion = caso.FechaCreacion;

            TimeSpan diferencia = fechaActual-fechaCreacion;
          
            if (caso.Nivel == (int)NivelCriticidad.Alto)
            {
                if (diferencia.TotalHours >= 1)
                {
                    tiempoExidedo = true;
                }
            }
            else if (caso.Nivel == (int)NivelCriticidad.Medio)
            {
                if (diferencia.Hours>=4)
                {
                    tiempoExidedo = true;
                }
            }
            else if (caso.Nivel == (int)NivelCriticidad.Bajo)
            {
                if (diferencia.Hours >= 24)
                {
                    tiempoExidedo = true;
                }
            }

            return tiempoExidedo;
        }

        public List<Model.Casos> ObternerListaCasosExedidosDeTiempo()
        {
            HelpDesk.AccesoADatos.GestorDeCasos gestorDeCasos = new HelpDesk.AccesoADatos.GestorDeCasos();

            List<Model.Casos> casos = gestorDeCasos.ObtenerCasosEnEstadoRegistrado();
            List<Model.Casos> casosExedidosDeTiempo = new List<Model.Casos>();

            foreach (var caso in casos)
            {

                if (ValidacionDeTiempo(caso))
                {
                    casosExedidosDeTiempo.Add(caso);
                }
            }

            return casosExedidosDeTiempo;

        }

    }
}
