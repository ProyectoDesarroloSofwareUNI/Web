import React from 'react'

const Cursosdisp = () => {
    var cd = [ {
            "cod_curso": "CM1B2",
            "cod_especialidad": "N1",
            "nombre_cursos": "Algebra lineal I",
            "ciclo": 2,
            "creditos": 5
        },
        {
            "cod_curso": "CM1H2",
            "cod_especialidad": "N1",
            "nombre_cursos": "Cálculo de Probabilidades",
            "ciclo": 2,
            "creditos": 3
        },
        {
            "cod_curso": "CC211",
            "cod_especialidad": "N1",
            "nombre_cursos": "Programación Orientada a Objetos",
            "ciclo": 3,
            "creditos": 4
        },
        {
            "cod_curso": "CC221",
            "cod_especialidad": "N1",
            "nombre_cursos": "Arquitectura de Computadores",
            "ciclo": 3,
            "creditos": 4
        },
        {
            "cod_curso": "CM2A1",
            "cod_especialidad": "N1",
            "nombre_cursos": "Cálculo Diferencial e Integral Avanzado",
            "ciclo": 3,
            "creditos": 7
        },
        {
            "cod_curso": "CM2H1",
            "cod_especialidad": "N1",
            "nombre_cursos": "Matemática Discreta",
            "ciclo": 3,
            "creditos": 4
        },
        {
            "cod_curso": "CQ221",
            "cod_especialidad": "N1",
            "nombre_cursos": "Introducción a la Electricidad y Magnetismo",
            "ciclo": 4,
            "creditos": 5
        }];
    class Filas extends React.Component{
      render(){
        var l = [];
        for(var i = 0; i < cd.length; i++){
          var s =
            <tr>
              <td>{cd[i]["cod_curso"]}</td>
              <td>{cd[i]["cod_especialidad"]}</td>
              <td>{cd[i]["nombre_cursos"]}</td>
              <td>{cd[i]["ciclo"]}</td>
              <td>{cd[i]["creditos"]}</td>
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
          <h2>Cursos Disponibles</h2>
          <br/>
          <table className="tabla">
            <thead>
              <tr>
                <th>Código</th>
                <th>Especialidad</th>
                <th>Nombre</th>
                <th>Ciclo</th>
                <th>Créditos</th>
              </tr>
            </thead>
            <Cuerpo />
          </table>
        </div>
    )
}

export default Cursosdisp
