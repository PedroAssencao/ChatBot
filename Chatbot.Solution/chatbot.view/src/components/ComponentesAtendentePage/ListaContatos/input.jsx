import ChatCard from "../ChatCard"
import { voltarChat, entrarChat } from '../../../Repository/AtendenteRepository'
export default function ListaContato(props) {
    return (
        <div className="ListaContatos overflow-y-auto" style={{maxHeight: "63vh"}}>
            
            <ChatCard onClick={entrarChat} className={"mt-4 justify-content-center align-items-center row mx-auto p-2 activeChat"}/>
            <ChatCard onClick={entrarChat} className={"mt-4 justify-content-center align-items-center row mx-auto p-2 unactiveChat"}/>
            
            {/* Apenas para Cunho de Espacamento  */}
            <div style={{minHeight: "10rem"}}>

            </div>

        </div>
    )
}