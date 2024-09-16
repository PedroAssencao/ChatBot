import SearchBar from "../../BaseComponents/searchBar"
import { useState } from 'react';
import StatusAtendimento from "../StatusAtendimento"
import ListaContato from "../ListaContatos/input"
import '../ContainerMensagens/style.css'
export default function ContainerMensagen(props) {
    return (
        <div className="col bg-light containerMensagens border-end border-1 border-dark" id="containerMensagens">
            <SearchBar />
            <StatusAtendimento SetStatusActive={props.StatusFuncion} />
            <ListaContato date={props.ContatosDate} />
        </div>
    )
}