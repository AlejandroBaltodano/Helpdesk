using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.LogicaDeNegocios
{
    public enum Estado
    {
        Registrado = 1,
        EnProceso = 2,
        Terminado = 3,
        Rechazado = 4,
        Eliminado = 5,
    }
    public enum NivelCriticidad
    {
        Bajo = 1,
        Medio = 2,
        Alto = 3,
    }

    public enum ProvinciaContacto
    {
        San_Jose = 1,
        Alajuela = 2,
        Cartago = 3,
        Heredia = 4,
        Guanacaste = 5,
        Puntarenas = 6,
        Limon = 7,
    }
}
