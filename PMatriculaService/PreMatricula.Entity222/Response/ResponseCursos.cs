using PreMatricula.Entity.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreMatricula.Entity.DTO;

namespace PreMatricula.Entity.Response
{
  public class ResponseCursos : ResponseBase
  {
    public List<ResponseCursosDTO> Result { get; set; }

    public ResponseCursos()
    {
      Result = new List<ResponseCursosDTO>();
    }
  }
}
