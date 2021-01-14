import React, { Component } from 'react';
import './styles/Login.css'

class Login extends Component{
    Comprobar(){
        window.location.href="/menu"      
    }

    render(){

        return(
            <div className="Container-form">
            <div className="formulario">
            <h2>Iniciar sesión</h2>
            <form action="index.html" method="post">
                <input id="Usuario" type="text" placeholder="Usuario" required/>
                <input id="Password" type="password" placeholder="Contraseña" required/>
                <input type="button" value="Iniciar sesion" onClick={this.Comprobar}/>
            </form>
            </div>
            </div>
        )
    }
}

export default Login;