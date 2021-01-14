using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.DTO
{
  public class ResponseCursosDictadosDTO
  {
    [DbField("cod_curso")]
    public string cod_curso { get; set; }
    [DbField("seccion")]
    public string seccion { get; set; }
    [DbField("nombre_curso")]
    public string nombre_curso { get; set; }
    [DbField("aula")]
    public string aula { get; set; }
    [DbField("nombre_profesor")]
    public string nombre_profesor { get; set; }
    [DbField("hora_inicio")]
    public double hora_inicio { get; set; }
    [DbField("hora_fin")]
    public double hora_fin { get; set; }
    [DbField("tipo_clase")]
    public string tipo_clase { get; set; }
    [DbField("dia_clase")]
    public double dia_clase { get; set; }
  }
}
