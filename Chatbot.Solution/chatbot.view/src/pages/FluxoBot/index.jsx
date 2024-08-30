import './style.css';
import { Iniciar, AdicionarEmDados, resetarAndStartPlumbJS } from '../../Repository/FluxoBoxRepository/index'
import { useEffect } from 'react';

export default function FluxoBot() {

  useEffect(() => {
    jsPlumb.ready(Iniciar)
    window.addEventListener('resize', resetarAndStartPlumbJS);
  }, []);

  document.querySelector("#bodyFromPageAll").style = "overflow-y: auto;"

  return (
    <div className='col'>
      <div className="container-fluid border-bottom border-secondary border-2 mt-5">
        <h2 className="h2 TituloForFluxoBot">Dazzle Bot</h2>
      </div>
      <div className="row container-fluid flex-column flex-md-row p-0 mt-3 gap-5" style={{ marginLeft: "1px" }}>
        <div className="col-12 col-md-2 p-0 bg-light containerInicio">
          <div className='header p-2'>
            <h4 className='text-danger'>OFFLINE</h4>
          </div>
          <div className='w-100 p-2'>
            <h6 className='d-flex jusitfy-content-center align-items-center gap-2 textColorForFluxoBot'>
              <svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" className="bi bi-journal-bookmark-fill text-dark" viewBox="0 0 16 16">
                <path fillRule="evenodd" d="M6 1h6v7a.5.5 0 0 1-.757.429L9 7.083 6.757 8.43A.5.5 0 0 1 6 8z" />
                <path d="M3 0h10a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2v-1h1v1a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v1H1V2a2 2 0 0 1 2-2" />
                <path d="M1 5v-.5a.5.5 0 0 1 1 0V5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1zm0 3v-.5a.5.5 0 0 1 1 0V8h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1zm0 3v-.5a.5.5 0 0 1 1 0v.5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1z" />
              </svg>
              Inicial
            </h6>
          </div>
          <div className='w-100 p-2'>
            <h6 className='d-flex jusitfy-content-center align-items-center gap-2 textColorForFluxoBot'>
              <svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" className="bi bi-journal-plus text-dark" viewBox="0 0 16 16">
                <path fillRule="evenodd" d="M8 5.5a.5.5 0 0 1 .5.5v1.5H10a.5.5 0 0 1 0 1H8.5V10a.5.5 0 0 1-1 0V8.5H6a.5.5 0 0 1 0-1h1.5V6a.5.5 0 0 1 .5-.5" />
                <path d="M3 0h10a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2v-1h1v1a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v1H1V2a2 2 0 0 1 2-2" />
                <path d="M1 5v-.5a.5.5 0 0 1 1 0V5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1zm0 3v-.5a.5.5 0 0 1 1 0V8h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1zm0 3v-.5a.5.5 0 0 1 1 0v.5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1z" />
              </svg>
              Menus
            </h6>
          </div>
        </div>
        <div className="col p-0 bg-warning ContainerInfos">

          <div className='header p-2'>
            <div className='ms-3'>
              <button className='btn btnColorForFluxoBot d-flex gap-3'>Ligar
                <div className="form-check form-switch ">
                  <input className="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                </div>
              </button>
            </div>
            <div className='me-3'>
              <button className='btn btnColorForFluxoBot'>Salvar</button>
            </div>
          </div>

          <div className="container-fluid overflow-x-hidden" id='ParentContainerToRender'>
            <div className="row p-3">
              {/* Linha do Primeiro Menu */}
              <div className="col-12 p-0" id="LinhaMenuPrincipal" style={{ marginLeft: "2rem" }}>

              </div>
            </div>
          </div>

          {/* Modals
                    Modal Para Adição de Opção no Menu */}
          <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div className="modal-dialog modal-dialog-centered modal-xl">
              <div className="modal-content">
                <div className="modal-body">

                  <div className="d-flex gap-3 mt-3 justify-content-between">
                    <div className="containerTipo">
                      <label className="mb-2"><strong>Tipo</strong></label>
                      {/* Puxar Aqui Do Codigo Todos os Tipo Para Inserção */}
                      <select onChange={(e) => SelectTipoHandEvent(e)} className="form-select" id="SelectTipo">
                        <option value="0" defaultValue={true}>Selecione um Tipo</option>
                        <option value="1">Redirecionamento</option>
                        <option value="2">Mensagem Simples</option>
                        <option value="3">Mensagem de Multipla Escolhas</option>
                      </select>
                    </div>

                    <div className="containerTipo" style={{ display: "none" }} id="DepartamentoSelect">
                      <label className="mb-2"><strong>Departamento destinado ao Redirecionamento</strong></label>
                      {/* Puxar Aqui Do Codigo Todos os Departamentos Para Inserção
                                            Lembrar que id vai ser o id do departamento selecionado em questao */}
                      <select id="selectDepartamento" className="form-select">
                        <option defaultValue={true}>Selecione um Departamento</option>
                        <option id="1" value="1">Suporte</option>
                        <option id="2" value="2">Financeiro</option>
                        <option id="3" value="3">Técnico</option>
                      </select>
                    </div>

                  </div>

                  {/* Menu Simples para opcao de Redirecionamento Departamento */}
                  <div className="row mt-4" style={{ display: "none" }} id="RedirecionamentoInputsSections">
                    <div className="col-6 mb-3">
                      <label className="mb-2"><strong>Titulo da Opção</strong></label>
                      <input id="TituloOpcaoMenuInputRedirecionamento" placeholder="Obrigatorio"
                        className="form-control" />
                    </div>
                    <div className="col-6 mb-3">
                      <label className="mb-2"><strong>Descrição</strong></label>
                      <input id="DescricaoMenuInputRedirecionamento" placeholder="Opcional"
                        className="form-control" />
                    </div>
                  </div>

                  <div className="gap-3 justify-content-between mt-4" style={{ display: "none" }}
                    id="FinalizarAtendimentoSelect">
                    <div className="form-check">
                      <input className="form-check-input" type="checkbox" value="" id="FinalizarChecked" />
                      <label className="form-check-label" htmlFor="flexCheckDefault">
                        Finalizar atendimento ápos a resposta?
                      </label>
                    </div>
                  </div>

                  {/* Caso A mensagem Seja do Tipo de Resposta Simples */}
                  <div className="gap-3 justify-content-between mt-4 flex-column" style={{ display: "none" }}
                    id="TextareaSelect">
                    <div className="row">
                      <div className="col-6 mb-3">
                        <label className="mb-2"><strong>Titulo</strong></label>
                        <input id="TituloSimplesInput" placeholder="Obrigatorio" className="form-control" />
                      </div>
                      <div className="col-6 mb-3">
                        <label className="mb-2"><strong>Descricao</strong></label>
                        <input id="DescricaoSimplesInput" placeholder="Obrigatorio" className="form-control" />
                      </div>
                    </div>
                    <div className="w-100">
                      <label className="mb-2"><strong>Resposta</strong></label>
                      <textarea style={{ minHeight: "10rem", resize: "none" }} id="textAreaContent"
                        className="form-control"></textarea>
                    </div>
                  </div>

                  {/* Caso A mensagem Seja do Tipo de Multiplas Escolhas */}
                  <div className="row mt-4" style={{ display: "none" }} id="MultiplaEscolha">
                    <div className="col-6 mb-3">
                      <label className="mb-2"><strong>Titulo da Opção</strong></label>
                      <input id="TituloOpcaoMenuInput" placeholder="Obrigatorio" className="form-control" />
                    </div>
                    <div className="col-6 mb-3">
                      <label className="mb-2"><strong>Descrição</strong></label>
                      <input id="DescricaoMenuInput" placeholder="Opcional" className="form-control" />
                    </div>
                    <div className="col-6 mb-3">
                      <label className="mb-2"><strong>Titulo do Menu</strong></label>
                      <input id="TituloMenuInput" placeholder="Obrigatorio" className="form-control" />
                    </div>
                    <div className="col-6 mb-3">
                      <label className="mb-2"><strong>Cabeçalho</strong></label>
                      <input id="cabecalhoMenuInput" placeholder="Opcional" className="form-control" />
                    </div>
                    <div className="col-6 mb-3">
                      <label className="mb-2"><strong>Corpo</strong></label>
                      <input id="corpoMenuInput" placeholder="Obrigatorio" className="form-control" />
                    </div>
                    <div className="col-6 mb-3">
                      <label className="mb-2"><strong>rodapé</strong></label>
                      <input id="rodapeMenuInput" placeholder="Opcional" className="form-control" />
                    </div>
                  </div>


                </div>
                <div className="modal-footer border-top-0">
                  <button type="button" className="btn buttonCancelarFromHome" data-bs-dismiss="modal">Cancelar</button>
                  <button type="button" className="btn buttonSalvarFromHome" onClick={() => AdicionarEmDados}>Salvar</button>
                </div>
              </div>
            </div>
          </div>

          {/* Modal Para Exclusão de Opção no Menu */}
          <div className="modal fade" id="exampleModal2" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div className="modal-dialog modal-dialog-centered">
              <div className="modal-content">
                <div className="modal-body">
                  <div className="d-flex gap-3 mt-3 justify-content-between">
                    <h6 className="h6" id="ExclusaoHeader"><strong>Você Realmente Deseja a Exclusão do Item: $Inserir o
                      Nome Dinamicamente Aqui?</strong></h6>
                  </div>
                </div>
                <div className="modal-footer border-top-0">
                  <button type="button" className="btn buttonCancelarFromHome" data-bs-dismiss="modal">Cancelar</button>
                  <button type="button" className="btn buttonDeletarFromHome">Excluir</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      {/* existe apenas para dar espaçamento na tela de celulares pequenos */}
      <div className='col mt-5' style={{ visibility: "hidden" }}>

      </div>
    </div>
  )
}