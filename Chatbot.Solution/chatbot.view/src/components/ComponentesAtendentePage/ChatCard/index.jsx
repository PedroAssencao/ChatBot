import './style.css';
import image from '../../../img/file.jpg';
export default function ChatCard(props) {
    const chatDate = props.ChatDate || [];
    const nome = chatDate?.contato?.nome
        ? (chatDate.contato.nome.length > 31
            ? chatDate.contato.nome.substring(0, 29) + '...'
            : chatDate.contato.nome)
        : "Sem Nome";
    const mensagens = chatDate.mensagens || [];
    const ultimaMensagem = mensagens.length > 0
        ? (mensagens[mensagens.length - 1].descricao.length > 5
            ? mensagens[mensagens.length - 1].descricao.substring(0, 28) + '...'
            : mensagens[mensagens.length - 1].descricao)
        : 'Aguardando mensagem';

    const ultimaData = mensagens.length > 0
        ? new Date(mensagens[mensagens.length - 1].data).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
        : '00:00';

    const messagerSender = mensagens.length > 0 && mensagens[mensagens.length - 1].contato == null ? "Você: " : "Cliente: "

    let qtdMensagensNaoLidas = 0

    if (props?.chatActiveStatus?.Codigo != chatDate?.codigo) {
        if (mensagens.length > 0) {
            mensagens.forEach((element) => {
                if (element.statusDaMensagen != "read" && element.contato) {
                    qtdMensagensNaoLidas++
                }
            });
        }
    }



    return (
        <>
            <div
                onClick={props.onClick}
                // data-codigo-atendente={AtendenteLogado}
                // data-codigo-chat={chatDate?.codigo}
                className={props.className}
                style={{ width: "96%", minHeight: "8vh" }}

            >
                <div className="row justify-content-between">
                    <div className="col-3 d-flex align-items-center gap-3">
                        <div>
                            <img className="rounded-circle" style={{ width: "40px" }} src={image} alt="Chat" />
                        </div>
                        <div className="d-flex flex-column">
                            {/* Nome do Cliente */}
                            <p className="text-dark text-nowrap m-0">
                                {nome}
                            </p>
                            {/* Última mensagem enviada */}
                            <p className="text-secondary text-nowrap m-0">
                                {messagerSender}{ultimaMensagem}
                            </p>
                        </div>
                    </div>

                    {/* Data da última mensagem enviada */}
                    <div className="col-2">
                        <p style={{ fontWeight: "bold" }}>
                            {ultimaData}
                        </p>
                        {qtdMensagensNaoLidas > 0 ? (
                            <p className='rounded-circle d-flex justify-content-center align-items-center' style={{ backgroundColor: "rgb(176, 222, 165)", maxWidth: "2rem", minHeight: "2rem" }}>
                                {qtdMensagensNaoLidas}
                            </p>
                        ) : null}

                    </div>
                </div>
            </div>

        </>

    );
}
