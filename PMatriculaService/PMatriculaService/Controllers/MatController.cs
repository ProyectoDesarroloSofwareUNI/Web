using System;
using Newtonsoft.Json;
using PreMatricula.Entity.Request;
using PreMatricula.Entity.Response;
using PreMatricula.Entity.Complementos;
using System.Web.Http;
using System.Collections.Generic;
using PreMatricula.Entity.DTO;
using System.Web.Http.Cors;
namespace PMatriculaService.Controllers
{
  [EnableCors(origins: "http://localhost:2923/Home/index.html", headers: "*", methods: "*")]
  public class MatController : ApiController
  {

    [HttpPost]
    [Route("api/Mat/logear")]
    public ValidarUsuario logear(UsuarioLogeo usuario)
    {
      try
      {
        ResponseConsultaUsuario resul = new ResponseConsultaUsuario();
        resul = new DataAccess().ExecuteSqlProcedureSingle<ResponseConsultaUsuario, UsuarioLogeo>("LOGUEAR", usuario);
        bool response = resul.RESULT;
        var resposne = new ValidarUsuario()
        {
          Exist_usuario = response,
          RespuestaServicio = null
        };
        //var responseJson = JsonConvert.SerializeObject(resposne);
        //return Json(responseJson);
        return resposne;
      }
      catch (Exception ex)
      {
        var response = new ValidarUsuario()
        {
          Exist_usuario = false,
          RespuestaServicio =
          {
            Error=true,
            MensajeError=ex.Message,
            CodigoError=ex.HResult,
            MensajeDetalle=ex.Source
          }
        };
        return response;
        //var _responseJson = JsonConvert.SerializeObject(response);
        //return Json(_responseJson);
      }

    }


    [HttpPost]
    [Route("api/Mat/OptenerCursos")]
    public ResponseCursos OptenerCursos(ResponseCodigo usuario)
    {
      try
      {
        List<ResponseCursosDTO> resul = new List<ResponseCursosDTO>();
        resul = new DataAccess().ExecuteSqlProcedure<ResponseCursosDTO, ResponseCodigo>("OPTENER_CURSOS_ALUMNO", usuario);
        var valor = usuario.CODIGO.Substring(1, 1);
        var valor2= usuario.CODIGO.Substring(0, 1);
        if ((usuario.CODIGO).Length != 11 || (Convert.ToInt32(usuario.CODIGO.Substring(0, 1)) != 1 && Convert.ToInt32(usuario.CODIGO.Substring(0, 1)) != 2) || Convert.ToInt32(usuario.CODIGO.Substring(1, 1)) != 0)
        {
          var valor3 = "entro";
        }
        var resposne = new ResponseCursos()
        {
          Result = resul,
          RespuestaServicio = null
        };
        return resposne;
      }
      catch (Exception ex)
      {
        var response = new ResponseCursos()
        {
          Result = null,
          RespuestaServicio =
          {
            Error=true,
            MensajeError=ex.Message,
            CodigoError=ex.HResult,
            MensajeDetalle=ex.Source
          }
        };
        return response;
      }

    }


  }
}
