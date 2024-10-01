import { useEffect, useState } from 'react';
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
    const [IsChatActive, setChatActive] = useState({chatActiveStatus: "Desativado"});
    const [connectionDateChild, setconnectionDateChild] = useState()
    useEffect(() => {
        window.addEventListener('resize', VerficarAltura);

        /*const fetchData = async () => {
            const data = await FetchChatsData();
            // console.log("dados que chegam na pagina do componente inicial")
            // console.log(data)
            setChatsDate(data);
            SetLoadDate(true)
        };*/

        const fetchdata = () => {
            const connection = new signalR.HubConnectionBuilder()
                .withUrl(`http://localhost:5058/api/chatHub?logId=${UsuarioLogadoId}`)
                .build();
            
                setconnectionDateChild(connection)
            
                connection.on("ReceiveChats", (element) => {
                console.log("mensagen recebida")
                console.log(element)
               
                setChatsDate(prevChatsDate => {
                    // Procura o índice do elemento com o mesmo 'codigo'
                    const index = prevChatsDate.findIndex(chat => chat.codigo === element.codigo);

                    if (index !== -1) {
                        // Se o elemento já existe, substitui por uma nova cópia do array com o item atualizado
                        const updatedChats = [...prevChatsDate];  // Cria uma cópia do array atual
                        updatedChats[index] = element;            // Substitui o elemento no índice encontrado
                        return updatedChats;
                    } else {
                        // Se não existe, adiciona o novo elemento ao final do array
                        return [...prevChatsDate, element];
                    }
                });

                
            });

            connection.on("CompleteLoading", () => {
                SetLoadDate(true);
            });

            connection.start().catch(err => console.error(err.toString()));
        }
        fetchdata();
        VerficarAltura();
    }, []);

    const handleDataFromChild = (data) => {
        setStatusActive(data);
    };

    const handleChatInFromChild = (data) => {
        setChatActive(data)
    }

    document.querySelector("#bodyFromPageAll").style.overflowX = "hidden"

    return (
        <div className="col bg-warning containerPai p-0 container-fluid d-flex flex-column">
            {IsDataLoad ? <>
                <Navbar chatActiveStatus={IsChatActive}/>
                <div className='flex-grow-1 d-flex bg-dark p-0'>
                    <ContainerMensagen StatusActive={StatusActive} setChatActive={handleChatInFromChild} StatusFuncion={handleDataFromChild} ContatosDate={FiltrarDataPorStatus(StatusActive, ChatsDate)} />
                    <ContainerChats connectionDateChild={connectionDateChild} ChatDates={ChatsDate} chatActiveStatus={IsChatActive} />
                </div>
                <OffCanvasBuscaMobile />
            </> : <LoadScreen />}
        </div>
    );
}
