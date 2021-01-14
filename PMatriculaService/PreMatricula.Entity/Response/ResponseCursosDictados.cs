using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreMatricula.Entity.DTO;
namespace PreMatricula.Entity.Response
{
  public class ResponseCursosDictados : ResponseBase
  {


    public List<ResponseCursosDictadosDTO> Result { get; set; }

    public ResponseCursosDictados()
    {
      Result = new List<ResponseCursosDictadosDTO>();
    }
  }

}
