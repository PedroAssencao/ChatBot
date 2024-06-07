import SearchBar from "../../BaseComponents/searchBar"
import StatusAtendimento from "../StatusAtendimento"
import ListaContato from "../ListaContatos/input"
import '../ContainerMensagens/style.css'
export default function ContainerMensagen(props) {
    return(
        <div className="col bg-light containerMensagens" id="containerMensagens">
            <SearchBar/>
            <StatusAtendimento/>
            <ListaContato/>
        </div>
    )
}