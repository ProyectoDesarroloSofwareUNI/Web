import React from 'react'
import {Button,Modal,ModalHeader,ModalBody,ModalFooter} from 'reactstrap';
import './styles/Tablas.css'


const Prematricula = () => {
    var pre = [{
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
    }];
    class Filas extends React.Component{
        state={
            abierto:false,
        }
    
        abrirModal=()=>{
            this.setState({abierto: this.state.abierto});
        }
        
      render(){
        var l = [];
        for(var i = 0; i < pre.length; i++){
          var m =
            <tr>
              <td>{pre[i]["cod_curso"]}</td>
              <td>{pre[i]["cod_especialidad"]}</td>
              <td>{pre[i]["nombre_cursos"]}</td>
              <td>{pre[i]["ciclo"]}</td>
              <td>{pre[i]["creditos"]}</td>
              <td><Button type="button" onClick={this.abrirModal}>Si</Button></td>
            </tr>;
          l.push(m);
        }
        <Modal isOpen={this.state.abierto}>
            <ModalHeader>Header</ModalHeader>
            <ModalBody>Body</ModalBody>
            <ModalFooter>Footer</ModalFooter>
        </Modal>
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
          <h1>Matricula de Cursos</h1>
          <p>Seleccionar los cursos a cual desea matricularse:</p>
          <h4><u>Normas</u></h4>
          <div id="Normas">
            <p>No superar el numero de creditos permitidos</p>
            <p>No sera posible dejar cursos de un ciclo inferior</p>
            <p>No generar un cruce de horarios</p>
          </div>
          <br/>
          <p>
             <b>Creditos permitidos: 18</b> 
          </p>
          <br/>
          <br/>
          <table className="table table-striped" border="2px" align="center" >
            <thead>
              <tr>
                <th>Cód.Curso</th>
                <th>Cód.Especialidad</th>
                <th>Curso</th>
                <th>Ciclo</th>
                <th>Creditos</th>
                <th>Selecciona</th>
              </tr>
            </thead>
            <Cuerpo />
          </table>
        </div>
    )
}

export default Prematricula