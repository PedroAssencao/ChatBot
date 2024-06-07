import ChatCard from "../ChatCard"
export default function ListaContato(props) {
    return (
        <div className="ListaContatos overflow-y-auto" style={{maxHeight: "63vh"}}>
            
            <ChatCard className={"mt-4 justify-content-center align-items-center row mx-auto p-2 activeChat"}/>
            <ChatCard className={"mt-4 justify-content-center align-items-center row mx-auto p-2 unactiveChat"}/>
            
            {/* Apenas para Cunho de Espacamento  */}
            <div style={{minHeight: "10rem"}}>

            </div>

        </div>
    )
}