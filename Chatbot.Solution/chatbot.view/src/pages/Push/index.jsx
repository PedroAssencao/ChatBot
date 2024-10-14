import React, { useState } from 'react';
import './style.css';

export default function push(){

    document.querySelector("#bodyFromPageAll").style = "overflow-y: auto;";
    return(
        <div className="col">
            <div className="barra-superior">
                <h1>DazzleBot</h1>
            </div>
            <div className='conteudo'>
                        <div className='parte-superior'>
                            <h1>Push</h1>
                                <button type="button" className="btn btn-success" style={{height:'3rem'}}>Comprar créditos</button>
                        </div>
                        <hr className="linha-horizontal" />
                        
                        <div className="botoes" style={{display:'flex',justifyContent:'flex-end', margin:'2rem'}}>
                            <button type="button" className="btn btn-success" style={{marginRight:'2rem'}}>Histórico de Eventos</button>
                            <button type="button" className="btn btn-success">Adicionar evento</button>
                        </div>

                        <div className="cartoes" style={{display:'flex', justifyContent:'space-around'}}>
                                <div className="card" style={{width:'25rem'}}>
                                        <div className="card-body">

                                                <svg xmlns="http://www.w3.org/2000/svg" width="70" height="70" fill="currentColor" class="bi bi-send-check" viewBox="0 0 16 16">
                                                    <path d="M15.964.686a.5.5 0 0 0-.65-.65L.767 5.855a.75.75 0 0 0-.124 1.329l4.995 3.178 1.531 2.406a.5.5 0 0 0 .844-.536L6.637 10.07l7.494-7.494-1.895 4.738a.5.5 0 1 0 .928.372zm-2.54 1.183L5.93 9.363 1.591 6.602z"/>
                                                    <path d="M16 12.5a3.5 3.5 0 1 1-7 0 3.5 3.5 0 0 1 7 0m-1.993-1.679a.5.5 0 0 0-.686.172l-1.17 1.95-.547-.547a.5.5 0 0 0-.708.708l.774.773a.75.75 0 0 0 1.174-.144l1.335-2.226a.5.5 0 0 0-.172-.686"/>
                                                </svg>

                                                <div>
                                                        <h5 className="card-title">Mensagens Enviadas</h5>
                                                        <h6 className="card-subtitle mb-2 text-body-secondary">0</h6>
                                                </div>

                                                <div className="info">
                                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-info-circle" viewBox="0 0 16 16">
                                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
                                                        <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0"/>
                                                        </svg>
                                                </div>
                                        </div>
                                </div>
                        </div>
            </div>
            

        </div>
    )
}

