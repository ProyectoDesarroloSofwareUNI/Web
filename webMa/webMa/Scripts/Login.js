// TODO: Replace with the URL of your WebService app
var serviceUrl = 'http://localhost:10471/api/Matricula/logear';

function sendRequest() {
  var usuario = $('#Usuario').val();
  var clave = $('#Password').val();
  var Validar;
  console.log(usuario);
  console.log(clave);
  $.ajax({
    type: 'POST',
    url: serviceUrl,
    data: {
      'CODIGO': usuario,
      'CLAVE': clave
    },
    success: function (respuesta) {
      console.log(respuesta);
      Validar = respuesta;
      console.log(Validar.Exist_usuario)
      if (Validar.Exist_usuario == true)
      {
        window.location.replace("http://localhost:2923/Home/Menu");  
      }
      else
        window.location.replace("http://localhost:2923/Home/Menu");  
    }
  }).done(function (data) {
    window.location.replace("http://localhost:2923/Home/Menu");  
  }).fail(function (jqXHR, textStatus, errorThrown) {
    window.location.replace("http://localhost:2923/Home/Menu");  
  });
}
