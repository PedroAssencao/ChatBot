import { useEffect } from 'react';
import Navbar from '../../components/BaseComponents/navbar';
import ContainerMensagen from '../../components/ComponentesAtendentePage/ContainerMensagens';
import ContainerChats from '../../components/ComponentesAtendentePage/ContainerChats';
import { VerficarAltura } from '../../Repository/AtendenteRepository/index'
import OffCanvasBuscaMobile from '../../components/ComponentesAtendentePage/offCanvasBuscaParaMobile';
export default function Atendente(props) {

    useEffect(() => {
        window.addEventListener('resize', VerficarAltura);
        VerficarAltura();
    }, []);

    return (
        <div className="col bg-warning containerPai p-0 container-fluid d-flex flex-column">
            <Navbar />
            <div className='flex-grow-1 d-flex bg-dark p-0'>
                <ContainerMensagen />
                <ContainerChats />
            </div>
        <OffCanvasBuscaMobile/>
        </div>
    );
}
