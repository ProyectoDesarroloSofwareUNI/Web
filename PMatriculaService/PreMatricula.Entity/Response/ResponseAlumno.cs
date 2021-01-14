using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.Response
{
  public class ResponseAlumno
  {
    [DbField("cod_alumno")]
    public string cod_alumno { get; set; }
  }
}
