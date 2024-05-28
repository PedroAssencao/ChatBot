import SearchBar from "../../BaseComponents/searchBar"
import StatusAtendimento from "../StatusAtendimento"
import ListaContato from "../ListaContatos/input"
export default function ContainerMensagen(props) {
    return(
        <div class="col bg-light containerMensagens" id="containerMensagens">
            <SearchBar/>
            <StatusAtendimento/>
            <ListaContato/>
        </div>
    )
}