import ConversaCard from '../conversaCard'
import MensagemSend from '../MensagenSend'
import '../conteudoChat/style.css'
export default function conteudoChat(props) {
    return (
        <>
            {props.chatActiveStatus.chatActiveStatus == "Desativado" ? (
                <div className='d-flex justify-content-center align-items-center w-100 h-100'>
                    <strong className='h5' style={{ color: "rgb(38, 58, 109)" }}>
                        Entre em algum Chat, As suas conversas irão aparecer aqui!
                    </strong>
                </div>
            ) : (
                <div className="ConteudoChat d-flex flex-column">
                    {props.ChatDates && props.ChatDates.map((x) => (
                        x.mensagens && x.mensagens.map((element) => (
                            <ConversaCard
                                key={element.codigo}
                                IsRecaive={element.contato != null}
                                descricao={element.descricao}
                            />
                        ))
                    ))}
                    {/* <ConversaCard IsRecaive={true} descricao={"Teste Com Mensagem Recebida"} /> */}
                    <MensagemSend />
                </div>
            )}
        </>

    )
}