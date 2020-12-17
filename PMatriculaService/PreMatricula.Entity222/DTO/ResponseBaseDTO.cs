using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.DTO
{
  public class ResponseBaseDTO
  {

    public bool Error { get; set; }
    public int? CodigoError { get; set; }
    public string MensajeError { get; set; }
    public string MensajeDetalle { get; set; }
  }
}
