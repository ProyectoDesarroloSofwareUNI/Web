using System;
using Newtonsoft.Json;
using PreMatricula.Entity.Request;
using PreMatricula.Entity.Response;
using PreMatricula.Entity.Complementos;
using System.Web.Http;
using System.Collections.Generic;
using PreMatricula.Entity.DTO;
using System.Web.Http.Cors;
using PMatriculaService.App_Start;
namespace PMatriculaService.Controllers
{
  [MyCorsPolicy]
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
    [Route("api/Matricula/datosAlumno")]
    public DatosAlumno datosAlumno(UsuarioLogeo usuario)
    {
      try
      {
        ValidarUsuario usuarioValidar = new ValidarUsuario();
        DatosAlumno resulFail = new DatosAlumno();
        usuarioValidar = logear(usuario);
        if (usuarioValidar.Exist_usuario) {
          DatosAlumno resul = new DatosAlumno();
          ResponseAlumno alumno = new ResponseAlumno();
          alumno.cod_alumno = usuario.CODIGO;
          resul = new DataAccess().ExecuteSqlProcedureSingle<DatosAlumno, ResponseAlumno>("OBTENER_DATOS_ALUMNO", alumno);

          return resul;
        }
        else
        {
       
          return resulFail;
        }

      }
      catch (Exception ex)
      {
        var response = new DatosAlumno();
        
        return response;
        //var _responseJson = JsonConvert.SerializeObject(response);
        //return Json(_responseJson);
      }

    }


    [HttpPost]
    [Route("api/Matricula/obtenerCursosDictados")]
    public ResponseCursosDictados obtenerCursosDictados(UsuarioLogeo usuario)
    {
      try
      {
        ValidarUsuario usuarioValidar = new ValidarUsuario();
        ResponseCursosDictados resulFail = new ResponseCursosDictados();
        usuarioValidar = logear(usuario);
        if (usuarioValidar.Exist_usuario)
        {

          List<ResponseCursosDictadosDTO> resul = new List<ResponseCursosDictadosDTO>();
          resul = new DataAccess().ExecuteSqlProcedure<ResponseCursosDictadosDTO, UsuarioLogeo>("OBTENER_CURSOS_DICTADOS", null);

          var resposne = new ResponseCursosDictados()
          {
            Result = resul
          };

          return resposne;
        }
        else
        {
          return resulFail;

        }
      }
      catch (Exception ex)
      {
        var response = new ResponseCursosDictados();

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
          Result = resul
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



    [HttpPost]
    [Route("api/Matricula/PreMatricular")]
    public ResponsePreMatricula PreMatricular(CursosPreMatricula Cursos)
    {
      try
      {
      
        List<HorarioCurso> listadoCursos = new List<HorarioCurso>();
        //Optenemos el Horario de lso cursos de Laboratorio 
        foreach (var cod in Cursos.cod_cuso )
        {
          Curso cod_curso = new Curso();
          HorarioCurso resul = new HorarioCurso();
          cod_curso.cod_curso = cod;
          resul = new DataAccess().ExecuteSqlProcedureSingle<HorarioCurso, Curso>("OBTENER_HORA_DIA_CURSO",cod_curso);
          if(resul.tipo_clase=="L")
          listadoCursos.Add(resul);
        }
        //Validamos quen  exista cruse en Laboratorio
        foreach (var fila in listadoCursos)
        {
            foreach(var fila_v in listadoCursos)
            {
                if(fila.dia_clase==fila_v.dia_clase)
                    {
                    if (Convert.ToInt32(fila.hora_inicio) >= Convert.ToInt32(fila_v.hora_inicio) && Convert.ToInt32(fila.hora_inicio)<= Convert.ToInt32(fila_v.hora_fin))
                      {
                        var response = new ResponsePreMatricula()
                             {
                                  respuesta = false,
                                  RespuestaServicio =null
                             };
                              return response;
                       }
                    if(Convert.ToInt32(fila.hora_fin) > Convert.ToInt32(fila_v.hora_inicio) && Convert.ToInt32(fila.hora_fin) <= Convert.ToInt32(fila_v.hora_fin))
                      {
                            var response = new ResponsePreMatricula()
                            {
                              respuesta = false,
                              RespuestaServicio = null
                            };
                            return response;

                       }

                   }

            }
        };
        //Aqui se Ralisa la  Pre Matricula si no hay cruses
        foreach (var cod in Cursos.cod_cuso) 
        {
        var  resul = new DataAccess().ExecuteSqlProcedureSingle<HorarioCurso, MatriculaCurso>("OBTENER_HORA_DIA_CURSO",new MatriculaCurso
          {
            cod_alumno=Cursos.cod_alumno,
            cod_curso=cod
          });
          
        }
        var response_v = new ResponsePreMatricula()
        {
          respuesta = true,
          RespuestaServicio = null
        };
        return response_v;

      }
      catch (Exception ex)
      {
        var response = new ResponsePreMatricula()
        {
          respuesta = false,
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
