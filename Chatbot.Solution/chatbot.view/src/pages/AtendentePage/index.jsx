import { useEffect, useState } from 'react';
import LoadScreen from '../../components/BaseComponents/loadingScreen';
import Navbar from '../../components/BaseComponents/navbar';
import ContainerMensagen from '../../components/ComponentesAtendentePage/ContainerMensagens';
import ContainerChats from '../../components/ComponentesAtendentePage/ContainerChats';
import { VerficarAltura, FetchChatsData, FiltrarDataPorStatus } from '../../Repository/AtendenteRepository/index'
import OffCanvasBuscaMobile from '../../components/ComponentesAtendentePage/offCanvasBuscaParaMobile';
export default function Atendente() {

    const [ChatsDate, setChatsDate] = useState([]);
    const [IsDataLoad, SetLoadDate] = useState(false);
    const [StatusActive, setStatusActive] = useState("Ativo");
    useEffect(() => {
        window.addEventListener('resize', VerficarAltura);
        const fetchData = async () => {
            const data = await FetchChatsData();
            setChatsDate(data);
            SetLoadDate(true)
        };
        fetchData();
        VerficarAltura();
    }, []);

    const handleDataFromChild = (data) => {
        setStatusActive(data);
    };

    document.querySelector("#bodyFromPageAll").style.overflowX = "hidden"

    return (
        <div className="col bg-warning containerPai p-0 container-fluid d-flex flex-column">
            {IsDataLoad ? <>
                <Navbar />
                <div className='flex-grow-1 d-flex bg-dark p-0'>
                    {IsDataLoad ? <ContainerMensagen StatusActive={StatusActive} StatusFuncion={handleDataFromChild} ContatosDate={FiltrarDataPorStatus(StatusActive, ChatsDate)} /> : null}
                    <ContainerChats />
                </div>
                <OffCanvasBuscaMobile />
            </> : <LoadScreen />}
        </div>
    );
}
