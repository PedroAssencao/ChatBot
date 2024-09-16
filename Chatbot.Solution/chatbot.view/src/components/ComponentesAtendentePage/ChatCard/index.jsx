import './style.css';
import image from '../../../img/file.jpg';
import { AtendenteLogado } from '../../../appsettings'
export default function ChatCard(props) {
    const chatDate = props.ChatDate || [];
    const nome = chatDate?.contato?.nome || "Sem Nome";
    const mensagens = chatDate.mensagens || [];
    console.log(chatDate.length > 0)
    console.log(chatDate)
    const ultimaMensagem = mensagens.length > 0
        ? mensagens[mensagens.length - 1].Descricao || 'Aguardando mensagem'
        : 'Aguardando mensagem';

    const ultimaData = mensagens.length > 0
        ? mensagens[mensagens.length - 1].Data || 'Data não disponível'
        : '00:00';

    return (
        <>
            {chatDate.length > 0 ? (
                <div
                    onClick={props.onClick}
                    data-codigo-atendente={AtendenteLogado}
                    data-codigo-chat={chatDate?.codigo}
                    className={props.className}
                    style={{ width: "96%", minHeight: "8vh" }}
                    data-bs-dismiss="offcanvas"
                >
                    <div className="row justify-content-between">
                        <div className="col-3 d-flex align-items-center gap-3">
                            <div>
                                <img className="rounded-circle" style={{ width: "40px" }} src={image} alt="Chat" />
                            </div>
                            <div className="d-flex flex-column">
                                <p className="text-dark text-nowrap m-0">
                                    {nome}
                                </p>
                                {/* Última mensagem enviada */}
                                <p className="text-secondary text-nowrap m-0">
                                    {ultimaMensagem}
                                </p>
                            </div>
                        </div>

                        {/* Data da última mensagem enviada */}
                        <div className="col-2">
                            <p style={{ fontWeight: "bold" }}>
                                {ultimaData}
                            </p>
                        </div>
                    </div>
                </div>
            ) : (
                <div className='d-flex justify-content-center align-items-center'>
                    <strong className='h4 mt-5 text-center' style={{ color: "rgb(38, 58, 109)" }}>
                        Nenhum contato para o estado selecionado foi encontrado.
                    </strong>
                </div>
            )}
        </>

    );
}
