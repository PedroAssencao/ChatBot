import ChatCard from "../ChatCard"
import SearchBar from "../../BaseComponents/searchBar"
export default function offCanvasBuscaMobile(props) {
    return (
        // Off Canvas para Busca em mobile mode
        <div className="offcanvas offcanvas-end w-100" tabIndex="-1" id="offcanvasExample"
            aria-labelledby="offcanvasExampleLabel">
            <div className="offcanvas-header">
                <h1 className="offcanvas-title" id="offcanvasExampleLabel">Buscar</h1>
                <button type="button" className="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
            </div>

            <div className="offcanvas-body">

                <SearchBar />
                
                {/* Fazer o contato buscado aparecer aqui e puxar a lista de contatos para aqui tambem */}

                {/* exemplo de Chat Ativado */}
                <ChatCard className={"container-fluid mt-4 d-flex justify-content-center align-items-center"} />

                {/* exemplo de Chat desativado */}
                <ChatCard className={"mt-4 justify-content-center align-items-center row mx-auto p-2 bg-light unactiveChat"} />
            </div>
        </div>
    )
}