import React from 'react'
import './styles/Tablas.css'

const Horario = () => {
    var hor = [{
        "cod_curso": "BFI01",
        "seccion": "A",
        "nombre_curso": "FÍSICA I",
        "aula": "zoom25",
        "nombre_profesor": "M. BROCCA",
        "hora_inicio": 10.0,
        "hora_fin": 12.0,
        "tipo_clase": "T",
        "dia_clase": 1.0
    },
    {
        "cod_curso": "BFI01",
        "seccion": "A",
        "nombre_curso": "FÍSICA I",
        "aula": "zoom70",
        "nombre_profesor": "M. BROCCA",
        "hora_inicio": 10.0,
        "hora_fin": 12.0,
        "tipo_clase": "T",
        "dia_clase": 3.0
    },
    {
        "cod_curso": "BFI01",
        "seccion": "A",
        "nombre_curso": "FÍSICA I",
        "aula": "zoom25",
        "nombre_profesor": "R. SALAZAR",
        "hora_inicio": 8.0,
        "hora_fin": 10.0,
        "tipo_clase": "P",
        "dia_clase": 5.0
    },
    {
        "cod_curso": "BFI01",
        "seccion": "A",
        "nombre_curso": "FÍSICA I",
        "aula": "zoom163",
        "nombre_profesor": "A. CABALLERO",
        "hora_inicio": 13.0,
        "hora_fin": 15.0,
        "tipo_clase": "L",
        "dia_clase": 5.0
    },
    {
        "cod_curso": "BFI01",
        "seccion": "B",
        "nombre_curso": "FÍSICA I",
        "aula": "zoom25",
        "nombre_profesor": "M. BROCCA",
        "hora_inicio": 14.0,
        "hora_fin": 16.0,
        "tipo_clase": "T",
        "dia_clase": 1.0
    },
    {
        "cod_curso": "BFI01",
        "seccion": "B",
        "nombre_curso": "FÍSICA I",
        "aula": "zoom160",
        "nombre_profesor": "M. BROCCA",
        "hora_inicio": 14.0,
        "hora_fin": 16.0,
        "tipo_clase": "T",
        "dia_clase": 3.0
    },
    {
        "cod_curso": "BFI01",
        "seccion": "B",
        "nombre_curso": "FÍSICA I",
        "aula": "zoom69",
        "nombre_profesor": "R. SALAZAR",
        "hora_inicio": 8.0,
        "hora_fin": 10.0,
        "tipo_clase": "P",
        "dia_clase": 5.0
    },
    {
        "cod_curso": "BFI01",
        "seccion": "B",
        "nombre_curso": "FÍSICA I",
        "aula": "meet05",
        "nombre_profesor": "A. CABALLERO",
        "hora_inicio": 8.0,
        "hora_fin": 10.0,
        "tipo_clase": "L",
        "dia_clase": 5.0
    }];
    class Filas extends React.Component{
      render(){
        var l = [];
        for(var i = 0; i < hor.length; i++){
          var s =
            <tr>
              <td>{hor[i]["cod_curso"]}</td>
              <td>{hor[i]["nombre_curso"]}</td>
              <td>{hor[i]["tipo_clase"]}</td>
              <td>{hor[i]["seccion"]}</td>
              <td>{hor[i]["aula"]}</td>
              <td>{hor[i]["nombre_profesor"]}</td>
              <td>{hor[i]["hora_inicio"]} {hor[i]["hora_fin"]}</td>
              <td>{hor[i]["dia_clase"]}</td>
            </tr>;
          l.push(s);
        }
        return(
          l
        )
      }
    }
    class Cuerpo extends React.Component{
      render(){
        return(
          <tbody>
            <Filas />
          </tbody>
        )
      }
    }

    return (
        <div className="cont-tabla">
          <h2>Horarios</h2>
          <br/>
          <table className="tabla">
            <thead>
              <tr>
                <th>Código</th>
                <th>Nombre</th>
                <th>Tipo</th>
                <th>Sección</th>
                <th>Aula</th>
                <th>Profesor</th>
                <th>Hora</th>
                <th>Día</th>
              </tr>
            </thead>
            <Cuerpo />
          </table>
        </div>
    )
}

export default Horario
