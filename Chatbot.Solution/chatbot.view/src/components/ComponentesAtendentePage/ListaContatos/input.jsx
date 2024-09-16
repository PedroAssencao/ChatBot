import ChatCard from "../ChatCard"
import { entrarChat } from '../../../Repository/AtendenteRepository'
export default function ListaContato(props) {
    return (
        <div className="ListaContatos overflow-y-auto" style={{ maxHeight: "63vh" }}>

            {props.date.map(x => (
                <ChatCard
                    key={x.codigo}
                    ChatDate={x}
                    onClick={entrarChat}
                    className={"mt-4 justify-content-center align-items-center row mx-auto p-2 unactiveChat"}
                />
            ))}

            {/* <ChatCard onClick={entrarChat} className={"mt-4 justify-content-center align-items-center row mx-auto p-2 activeChat"}/> */}

            {/* Apenas para Cunho de Espacamento  */}
            <div style={{ minHeight: "10rem" }}>

            </div>

        </div>
    )
}