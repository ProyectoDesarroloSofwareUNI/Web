import React from 'react'

const Datos = () => {
    var dp = {
      "nombre": "PEDRO MARIANO ",
      "apellido_paterno": "UGARTE",
      "apellido_materno": "PRADO",
      "cod_Especialidad": "N1",
      "ciclo_relativo": 6,
      "creditos": 27
    };
    return (
        <div className="dps">
            <h1>DATOS PERSONALES</h1>
            <hr/>
            <div>
              Nombre: {dp["nombre"]}<br/>
              Apellido Paterno: {dp["apellido_paterno"]}<br/>
              Apellido Materno: {dp["apellido_materno"]}<br/>
              Código de especialidad: {dp["cod_Especialidad"]}<br/>
              Ciclo relativo: {dp["ciclo_relativo"]}<br/>
              Créditos: {dp["creditos"]}
            </div>
        </div>
    )
}

export default Datos
