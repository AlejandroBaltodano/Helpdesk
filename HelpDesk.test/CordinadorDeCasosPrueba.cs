using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HelpDesk.test
{
    [TestClass]
    public class CordinadorDeCasosPrueba
    {
        LogicaDeNegocios.CordinadorDeCasos cordinador = new LogicaDeNegocios.CordinadorDeCasos();

        [TestMethod]
        public void DebeAgregarUnCaso()
        {
            Model.Casos elNuevoCaso = new Model.Casos();

            elNuevoCaso.DescripcionProblema = "Robo a supermercado";
            elNuevoCaso.Nivel = (int)LogicaDeNegocios.NivelCriticidad.Bajo;
            elNuevoCaso.NombreContacto = "Alexander";
            elNuevoCaso.TelefonoContacto = "88888888";
            elNuevoCaso.ProvinciaContacto = (int)LogicaDeNegocios.ProvinciaContacto.Guanacaste;
            elNuevoCaso.DireccionContacto = "Barrio Moracia, Liberia";

            cordinador.AgregarUnCaso(elNuevoCaso);
        }

        [TestMethod]
        public void DebeEditarUnCaso()
        {
            Model.Casos caso = new Model.Casos();

            caso = cordinador.ConsultarPorId(4);

            caso.DescripcionProblema = "Robo a supermercado a mano armada";
            caso.NombreContacto = "Cristian";
            
            cordinador.EditarUnCaso(caso);

        }
        [TestMethod]
        public void DebeEditarSoloAlgunosCamposDelCaso()
        {
            Model.Casos caso = new Model.Casos();

            caso = cordinador.ConsultarPorId(4);

            caso.ObservacionesResolucion = "Adios";

            cordinador.EditarUnCaso(caso);

        }
        [TestMethod]
        public void DebeEliminarUnCaso()
        {
            Model.Casos caso = new Model.Casos();

            caso = cordinador.ConsultarPorId(4);

            cordinador.EliminarUnCaso(caso);

        }
        [TestMethod]
        public void DebePonerEnProcesoUnCaso()
        {
            Model.Casos caso = new Model.Casos();
            caso = cordinador.ConsultarPorId(3);
            bool estadoDeValidacion = cordinador.PonerEnProcesoUnCaso(caso, "Lic.Ramirez");
            Model.Casos caso2 = cordinador.ConsultarPorId(3);

            Assert.AreEqual(caso.NombrePersonaResuelve, caso2.NombrePersonaResuelve);
        }
        [TestMethod]
        public void DebeRechazarUnCaso()
        {
            Model.Casos caso = new Model.Casos();

            caso = cordinador.ConsultarPorId(5);

            cordinador.RechazarUnCaso(caso, "Papeles Incompletos");

        }
        [TestMethod]
        public void DebeTerminarUnCaso()
        {
            Model.Casos caso = new Model.Casos();

            caso = cordinador.ConsultarPorId(5);

            cordinador.TerminarUnCaso(caso, "Complimiento de la Pena");

            Model.Casos caso2 = cordinador.ConsultarPorId(5);

            Assert.AreEqual(null, caso2.DescripcionResolucion);

            caso = cordinador.ConsultarPorId(3);
            cordinador.TerminarUnCaso(caso, "Complimiento de la Pena");
        }
        [TestMethod]
        public void DebeObtenerCasosPorEstado()
        {
            List<Model.Casos> coleccionDeCasos = cordinador.ObtenerListaPorEstado((int)LogicaDeNegocios.Estado.Terminado);

            Assert.AreEqual(1, coleccionDeCasos.Count);
        }
        [TestMethod]
        public void DebeObtenerCasosPorNivelDeCriticidad()
        {
            List<Model.Casos> coleccionDeCasos = cordinador.ObtenerListaPorNivelDeCriticidad((int)LogicaDeNegocios.NivelCriticidad.Bajo);

            Assert.AreEqual(2, coleccionDeCasos.Count);
        }
        [TestMethod]
        public void DebeComprovarTiempoDeExpiracion()
        {
            Model.Casos caso = cordinador.ConsultarPorId(4);

            bool expiroElTiempo = cordinador.ValidacionDeTiempo(caso);

           Assert.AreEqual(true, expiroElTiempo);
        }

        [TestMethod]
        public void DebeObtenerCasosExedidosDeTiempo()
        {
            List<Model.Casos> coleccionDeCasosExedidosDeTiempo = cordinador.ObternerListaCasosExedidosDeTiempo();


            Assert.AreEqual(2, coleccionDeCasosExedidosDeTiempo.Count);
        }

        [TestMethod]
        public void DebeVereficarSiElCasosSeExedidoDeTiempo()
        {
            Model.Casos caso = new Model.Casos();

            caso = cordinador.ConsultarPorId(7);

            bool condicionDeValidacionSiExpiroElTiempo = cordinador.PonerEnProcesoUnCaso(caso, "Lic.Rodriguez Rojas");


            Assert.AreEqual(true,condicionDeValidacionSiExpiroElTiempo);
        }
    }
}
