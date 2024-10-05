import { useEffect, useState, useRef } from 'react';
import LoadScreen from '../../components/BaseComponents/loadingScreen';
import Navbar from '../../components/BaseComponents/navbar';
import ContainerMensagen from '../../components/ComponentesAtendentePage/ContainerMensagens';
import ContainerChats from '../../components/ComponentesAtendentePage/ContainerChats';
import { VerficarAltura, FetchChatsData, FiltrarDataPorStatus } from '../../Repository/AtendenteRepository/index'
import OffCanvasBuscaMobile from '../../components/ComponentesAtendentePage/offCanvasBuscaParaMobile';
import { urlBase, UsuarioLogadoId } from '../../appsettings'
export default function Atendente() {

    const [ChatsDate, setChatsDate] = useState([]);
    const [IsDataLoad, SetLoadDate] = useState(false);
    const [StatusActive, setStatusActive] = useState("Ativo");
    const [IsChatActive, setChatActive] = useState({ chatActiveStatus: "Desativado" });
    const [connectionDateChild, setconnectionDateChild] = useState()
    const [ChatDatesFiltered, setChatDatesFiltered] = useState([])
    // Cria um useRef para armazenar o valor mais recente do estado
    const isChatActiveRef = useRef(IsChatActive);

    // Atualiza o valor do useRef sempre que o estado IsChatActive mudar
    useEffect(() => {
        isChatActiveRef.current = IsChatActive;
    }, [IsChatActive]);

    function showNotification(title, options) {
        // Verifica se a API de Notificações é suportada
        if (!("Notification" in window)) {
            console.log("Este navegador não suporta notificações.");
            return;
        }

        // Solicita permissão para enviar notificações
        Notification.requestPermission().then(permission => {
            if (permission === "granted") {
                // Cria e exibe a notificação
                const notification = new Notification(title, options);

                // Adiciona um evento para quando a notificação é clicada se necessario executar uma ação posteriormente
                notification.onclick = () => {
                    console.log("Notificação clicada!");
                };
            } else if (permission === "denied") {
                console.log("Permissão de notificações negada.");
            }
        });
    }

    useEffect(() => {
        window.addEventListener('resize', VerficarAltura);

        const fetchdata = (firstConnection) => {
            const connection = new signalR.HubConnectionBuilder()
                .withUrl(`http://localhost:5058/api/chatHub?logId=${UsuarioLogadoId}`)
                .build();

            setconnectionDateChild(connection);

            connection.on("ReceiveChats", (element) => {
                setChatsDate(prevChatsDate => {
                    const index = prevChatsDate.findIndex(chat => chat.codigo === element.codigo);

                    if (index !== -1) {
                        const updatedChats = [...prevChatsDate];
                        updatedChats[index] = element;
                        return updatedChats;
                    } else {
                        return [...prevChatsDate, element];
                    }
                });

                const mensagens = element.mensagens || [];
                const IsLeadMessage = mensagens.length > 0 ? mensagens[mensagens.length - 1].contato : false;

                if (firstConnection === false && IsLeadMessage && isChatActiveRef.current.Codigo !== element.codigo &&
                    element?.atendimento?.estadoAtendimento == "HUMANO" && element?.atendimento?.atendente
                    && element?.atendimento?.atendente.estadoAtendente) {
                    const ultimaMensagem = mensagens.length > 0
                        ? mensagens[mensagens.length - 1].descricao
                        : 'Aguardando mensagem';

                    showNotification("Nova Mensagem", {
                        body: ultimaMensagem,
                    });
                }
            });

            connection.on("CompleteLoading", () => {
                SetLoadDate(true);
                firstConnection = false;
            });

            connection.start().catch(err => console.error(err.toString()));
        };

        fetchdata(true);
        VerficarAltura();
    }, []);

    const handleDataFromChild = (data) => {
        setStatusActive(data);
    };

    const handleChatInFromChild = (data) => {
        setChatActive(data)
    }

    const SetChatDatesFromChild = (data) => {
        setChatsDate(data)
    }

    const BuscarContato = (query) => {
        if (query == "" || query == null || query == '') {
            return setChatDatesFiltered([])
        }
        const resultado = ChatsDate.filter((chat) => {
            return chat.contato.nome.toLowerCase().includes(query.toLowerCase()) ||
                chat.contato.codigoWhatsapp.toLowerCase().includes(query.toLowerCase());
        });
        setChatDatesFiltered(resultado)
    }

    document.querySelector("#bodyFromPageAll").style.overflowX = "hidden"

    return (
        <div className="col bg-warning containerPai p-0 container-fluid d-flex flex-column">
            {IsDataLoad ? <>
                <Navbar chatActiveStatus={IsChatActive} ChatDates={ChatsDate} />
                <div className='flex-grow-1 d-flex bg-dark p-0'>
                    <ContainerMensagen searchbarFunction={BuscarContato} SetChatDatesFromChild={SetChatDatesFromChild} chatActiveStatus={IsChatActive} StatusActive={StatusActive} setChatActive={handleChatInFromChild} StatusFuncion={handleDataFromChild} ContatosDate={ChatDatesFiltered.length > 0  ? ChatDatesFiltered : FiltrarDataPorStatus(StatusActive, ChatsDate)} />
                    <ContainerChats connectionDateChild={connectionDateChild} ChatDates={ChatsDate} chatActiveStatus={IsChatActive} />
                </div>
                <OffCanvasBuscaMobile searchbarFunction={BuscarContato} SetChatDatesFromChild={SetChatDatesFromChild} chatActiveStatus={IsChatActive} StatusActive={StatusActive} setChatActive={handleChatInFromChild} StatusFuncion={handleDataFromChild} ContatosDate={ChatDatesFiltered.length > 0 ? ChatDatesFiltered : ChatsDate} />
            </> : <LoadScreen />}
        </div>
    );
}
