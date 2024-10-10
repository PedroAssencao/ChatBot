import React, { useState } from 'react';
import './style.css';

export default function push(){

    document.querySelector("#bodyFromPageAll").style = "overflow-y: auto;";
    return(
        <div className="col">
             <div className='push'>
                 <h1>Push</h1>
                <button type="button" className="btn btn-success">Comprar créditos</button>
             </div>
            
             <div className="botoes">
                 <button type="button" className="btn btn-success">Histórico de Eventos</button>
                 <button type="button" className="btn btn-success">Adicionar evento</button>
             </div>
        </div>
    )
}

