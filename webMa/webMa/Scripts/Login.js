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
        window.location.replace("Home/About.cshtml");  
      }
      else
        alert("Contraseña Incorecta");
    }
  }).done(function (data) {
    $('#value1').text(data);
  }).fail(function (jqXHR, textStatus, errorThrown) {
    $('#value1').text(jqXHR.responseText || textStatus);
  });
}
