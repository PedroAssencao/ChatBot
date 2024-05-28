import Navbar from '../../components/BaseComponents/navbar'
import ContainerMensagen from '../../components/ComponentesAtendentePage/ContainerMensagens'
import ContainerChats from '../../components/ComponentesAtendentePage/ContainerChats'
export default function Atendente(props) {
    return (
        <div className="col bg-warning containerPai p-0 container-fluid d-flex flex-column">
            <Navbar />
            <ContainerMensagen/>
            <ContainerChats/>
        </div>
    )
}