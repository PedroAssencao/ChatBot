import ConversaCard from '../conversaCard'
import MensagemSend from '../MensagenSend'
import '../conteudoChat/style.css'
export default function conteudoChat(props) {
    return (
        <>
            <div className="ConteudoChat d-flex flex-column">
                <ConversaCard IsRecaive={false} descricao={"Teste Com Mensagem Enviada"}/>
                <ConversaCard IsRecaive={true} descricao={"Teste Com Mensagem Recebida"}/>
            </div>
            <MensagemSend />
        </>
    )
}