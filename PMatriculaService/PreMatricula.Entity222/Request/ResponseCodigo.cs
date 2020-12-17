using PreMatricula.Entity.Complementos;

namespace PreMatricula.Entity.Request
{
  public class ResponseCodigo
  {
    [DbField("CODIGO")]
    public string CODIGO { get; set; }
  }
}
