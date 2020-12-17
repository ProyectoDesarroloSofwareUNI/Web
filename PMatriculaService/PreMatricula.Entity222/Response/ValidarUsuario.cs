using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreMatricula.Entity.Response
{
  public class ValidarUsuario : ResponseBase
  {
    public bool Exist_usuario { get; set; }
  }
}
