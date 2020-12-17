using PreMatricula.Entity.Complementos;

namespace PreMatricula.Entity.Request
{
  public class UsuarioLogeo
  {
    [DbField("CODIGO")]
    public string CODIGO { get; set; }
    [DbField("CLAVE")]
    public string CLAVE { get; set; }
  }
}
