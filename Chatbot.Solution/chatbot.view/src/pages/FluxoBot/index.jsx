import './style.css';
import { Iniciar, resetarAndStartPlumbJS, fetchNewDatas } from '../../Repository/FluxoBoxRepository/index'
import { useEffect } from 'react';
import BaseModal from '../../components/BaseComponents/BaseModal'
import HeaderControlFluxobot from '../../components/ComponentesFluxoBot/HeaderControlFluxoBot';
import ModalDeAdicaoFluxoBot from '../../components/ComponentesFluxoBot/ModalDeAdicaoFluxobot';
import SidebarControlFluxoBot from '../../components/ComponentesFluxoBot/SideBarControlFluxoBot';

export default function FluxoBot() {

  useEffect(() => {
    const initialize = async () => {
      const result = await fetchNewDatas();
      if (result) {
        jsPlumb.ready(Iniciar);
        window.addEventListener('resize', resetarAndStartPlumbJS);
      }
    };

    initialize();

    return () => {
      window.removeEventListener('resize', resetarAndStartPlumbJS);
    };
  }, []);

  document.querySelector("#bodyFromPageAll").style = "overflow-y: auto;"

  return (
    <div className='col'>
      <div className="container-fluid border-bottom border-secondary border-2 mt-5">
        <h2 className="h2 TituloForFluxoBot">Dazzle Bot</h2>
      </div>

      <div className="row container-fluid flex-column flex-md-row p-0 mt-3 gap-5" style={{ marginLeft: "1px" }}>
        <div className="col-12 col-md-2 p-0 bg-light containerInicio">
          <SidebarControlFluxoBot />
        </div>

        <div className="col p-0 bg-warning ContainerInfos">

          <HeaderControlFluxobot />

          <div className="container-fluid overflow-x-hidden" id='ParentContainerToRender'>
            <div className="row p-3">
              {/* Linha do Primeiro Menu */}
              <div className="col-12 p-0" id="LinhaMenuPrincipal" style={{ marginLeft: "2rem" }}>

              </div>
            </div>
          </div>

          <ModalDeAdicaoFluxoBot />

          <BaseModal
            id="exampleModal2"
            HasHeader={false}
            ModalSize={null}
            Description="Você Realmente Deseja a Exclusão do Item: $Inserir o Nome Dinamicamente Aqui?"
            ButtonClassName="btn buttonDeletarFromModal"
            ButtonDescription="Excluir"
            ButtonOnclick={() => console.log('Excluir clicado')} />

        </div>

      </div>

      {/* existe apenas para dar espaçamento na tela de celulares pequenos */}
      <div className='col mt-5' style={{ visibility: "hidden" }}></div>

    </div>
  )
}