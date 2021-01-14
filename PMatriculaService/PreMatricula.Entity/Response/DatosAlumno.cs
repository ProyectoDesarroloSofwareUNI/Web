using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.Response
{
  public class DatosAlumno: ResponseBase
  {
    [DbField("nombre")]
    public string nombre { get; set; }
    [DbField("apellido_paterno")]
    public string apellido_paterno { get; set; }
    [DbField("apellido_materno")]
    public string apellido_materno { get; set; }
    [DbField("cod_Especialidad")]
    public string cod_Especialidad { get; set; }
    [DbField("ciclo_relativo")]
    public int ciclo_relativo { get; set; }
    [DbField("creditos")]
    public int creditos { get; set; }

  }
}
