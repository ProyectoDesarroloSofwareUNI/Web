using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.Response
{
  public class HorarioCurso
  {
    [DbField("cod_curso")]
    public string cod_curso { get; set; }
    [DbField("hora_inicio")]
    public string hora_inicio { get; set; }
    [DbField("hora_fin")]
    public string hora_fin { get; set; }
    [DbField("dia_clase")]
    public int dia_clase { get; set; }
    [DbField("tipo_clase")]
    public string tipo_clase { get; set; }
  }
}
