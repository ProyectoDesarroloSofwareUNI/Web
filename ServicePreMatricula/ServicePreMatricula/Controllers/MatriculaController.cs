using System;
using Newtonsoft.Json;
using PreMatricula.Entity.Request;
using PreMatricula.Entity.Response;
using PreMatricula.Entity.Complementos;
using System.Web.Http;
using System.Collections.Generic;
using PreMatricula.Entity.DTO;

namespace ServicePreMatricula.Controllers
{
    public class MatriculaController : ApiController
    {

    [HttpPost]
    [Route("api/Matricula/logear")]
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
    [Route("api/Matricula/OptenerCursos")]
    public ResponseCursos OptenerCursos(ResponseCodigo usuario)
    {
      try
      {
        List<ResponseCursosDTO> resul = new List<ResponseCursosDTO>();
        resul = new DataAccess().ExecuteSqlProcedure<ResponseCursosDTO, ResponseCodigo>("OPTENER_CURSOS_ALUMNO", usuario);

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
