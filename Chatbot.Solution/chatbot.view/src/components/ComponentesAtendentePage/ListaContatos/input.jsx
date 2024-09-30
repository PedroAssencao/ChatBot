import React, { useEffect, useState } from 'react';
import ChatCard from "../ChatCard";
import SmallLoadScreen from '../../BaseComponents/smallLoading';
import { entrarChat } from '../../../Repository/AtendenteRepository';
import { AtendenteLogado } from '../../../appsettings';

export default function ListaContato(props) {
    const [mensagemVazia, setMensagemVazia] = useState(false);
    const [IsLoading, SetLoading] = useState(true)
    useEffect(() => {
        SetLoading(true)
        if (props.date.length <= 0) {
            SetLoading(false);
            setMensagemVazia(true);
        } else {
            SetLoading(false);
            setMensagemVazia(false);
        }
    }, [props.date]);

    return (
        <div className="ListaContatos overflow-y-auto overflow-x-hidden" style={{ maxHeight: "63vh" }}>
            {/* Percorrer a lista de chats para exibir dependendo do status */}
            {props.date.map(x => (
                <ChatCard
                    key={x.codigo}
                    ChatDate={x}
                    onClick={() => {
                        entrarChat();
                        props.setChatActive({
                            Codigo: x.codigo,
                            AtendenteLogado: AtendenteLogado,
                            chatActiveStatus: "Ativado",
                        });
                    }}
                    className={"mt-4 justify-content-center align-items-center row mx-auto p-2 unactiveChat"}
                />
            ))}
            {/* Se Nenhum Chat For Reenderizado exibir a mensagem de error */}
            {mensagemVazia && (
                <div className='d-flex justify-content-center align-items-center'>
                    <strong className='h4 mt-5 text-center' style={{ color: "rgb(38, 58, 109)" }}>
                        Nenhum contato para o estado selecionado foi encontrado.
                    </strong>
                </div>
            )}
            {/* Deixar um loading se ainda não tiver reenderizado toda a lista de chats */}
            {IsLoading && (
                <SmallLoadScreen />
            )}
            {/* Apenas para cunho de espaçamento */}
            <div style={{ minHeight: "10rem" }}></div>
        </div>
    );
}
