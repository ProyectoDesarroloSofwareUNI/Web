using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.Response
{
  public class ResponseConsultaUsuario
  {
    [DbField("RESULT")]
    public Boolean RESULT { get; set; }
  }
}
