import React, { Component } from 'react';
import { BrowserRouter as Router, Switch ,Route, Link } from 'react-router-dom';
import './styles/Menu.css'
import Datos from './Datos'
import Horario from './Horario'
import Prematricula from './Prematricula'
import Cursosdisp from './Cursosdisp'


class Menu extends Component{
    Desplegar(){
            document.querySelector(".nav-menu").classList.toggle("show");
    }
    Cerrar(){
            window.location.href="/"
    }
    render(){
        return(
            <Router>
                <div id="fondo1">
                    <div id="Nombre">
                        <strong>PRE-MATRICULA</strong>
                    </div>
                    <div className="menu-btn" id="Menu" onClick={this.Desplegar}>Men&uacute;</div>
                    <div className="container">
                        <nav className="nav-main">
                            <ul className="nav-menu">
                                <Link to= "/menu/datos" className= "nav-apartado" >
                                    <li>Datos Personales</li>
                                </Link>
                                <Link to= "/menu/horario" className= "nav-apartado" >
                                    <li>Horario</li>
                                </Link>
                                <Link to= "/menu/cursosdisponibles" className= "nav-apartado" >
                                    <li>Cursos Disponibles</li>
                                </Link>
                                <Link to= "/menu/prematricula" className= "nav-apartado" >
                                    <li>Pre-Matr&iacute;cula</li>
                                </Link>
                                <li onClick={this.Cerrar}>Cerrar Sesi&oacute;n</li>
                            </ul>
                        </nav>
                    </div>
                <Switch>
                  <Route path="/menu/datos" > <Datos /></Route>
                  <Route path="/menu/horario" > <Horario /></Route>
                  <Route path="/menu/cursosdisponibles"><Cursosdisp /></Route>
                  <Route path="/menu/prematricula"><Prematricula /></Route>
                </Switch>
                </div>
            </Router>
        )
    }
}
export default Menu;
