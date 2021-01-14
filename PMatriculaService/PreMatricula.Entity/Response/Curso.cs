using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.Response
{
 public  class Curso
  {
    [DbField("cod_curso")]
    public string cod_curso { get; set; }
  }
}
