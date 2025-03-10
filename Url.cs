using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace navegadorWeb
{
    internal class Url
    {
       /* public string direccionUrl { get; set; }
        public DateTime fechaAcceso { get; set; }
        public int contadorVisitas { get; set; }*/


        string direccionUrl;
        DateTime fechaAcceso;
        int contadorVisitas;

        public string DireccionUrl { get => direccionUrl; set => direccionUrl = value; }
        public DateTime FechaAcceso { get => fechaAcceso; set => fechaAcceso = value; }
        public int ContadorVisitas { get => contadorVisitas; set => contadorVisitas = value; }
    }
}
