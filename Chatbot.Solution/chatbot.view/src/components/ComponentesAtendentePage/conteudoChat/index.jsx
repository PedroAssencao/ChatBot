import ConversaCard from '../conversaCard'
import MensagemSend from '../MensagenSend'
import '../conteudoChat/style.css'
export default function conteudoChat(props) {
    return (
        <>
        {props.chatActiveStatus == "Desativado" ? (
            <div className='d-flex justify-content-center align-items-center w-100 h-100'>
                <strong className='h5' style={{ color: "rgb(38, 58, 109)" }}>
                    Entre em algum Chat, As suas conversas irão aparecer aqui!
                </strong>
            </div>
        ) : (
            <div className="ConteudoChat d-flex flex-column">
                <ConversaCard IsRecaive={false} descricao={"Teste Com Mensagem Enviada"} />
                <ConversaCard IsRecaive={true} descricao={"Teste Com Mensagem Recebida"} />
                <MensagemSend />
            </div>
        )}
    </>
    
    )
}