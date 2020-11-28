using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.Request
{
  public class ResponseCodigo
  {
    [DbField("CODIGO")]
    public string CODIGO { get; set; }
  }
}
