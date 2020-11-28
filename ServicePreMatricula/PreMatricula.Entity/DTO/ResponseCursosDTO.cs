using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.DTO
{
  public class ResponseCursosDTO
  {
    [DbField("cod_curso")]
    public string cod_curso { get; set; }
    [DbField("cod_especialidad")]
    public string cod_especialidad { get; set; }
    [DbField("nombre_cursos")]
    public string nombre_cursos { get; set; }
    [DbField("ciclo")]
    public int ciclo { get; set; }
    [DbField("creditos")]
    public int creditos { get; set; }
  }
}
