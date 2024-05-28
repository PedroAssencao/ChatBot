import ChatCard from "../ChatCard"
export default function ListaContato(props) {
    return (
        <div class="ListaContatos overflow-y-auto" style="max-height: 63vh;">
            
            <ChatCard className={"mt-4 justify-content-center align-items-center row mx-auto p-2 activeChat"}/>
            <ChatCard className={"mt-4 justify-content-center align-items-center row mx-auto p-2 unactiveChat"}/>
            
            {/* Apenas para Cunho de Espacamento  */}
            <div style="min-height: 10rem;">

            </div>

        </div>
    )
}