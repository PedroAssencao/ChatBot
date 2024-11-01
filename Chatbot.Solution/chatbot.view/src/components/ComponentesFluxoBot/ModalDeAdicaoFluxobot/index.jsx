import './style.css';
import { AdicionarEmDados, SelectTipoHandEvent } from '../../../Repository/FluxoBoxRepository'
import { urlBase, UsuarioLogado } from "../../../appsettings";
import { useEffect, useState } from "react";
import Select from '../../BaseComponents/select';
import ButtonBase from '../../BaseComponents/button';
export default function ModalDeAdicaoFluxoBot(props) {
    const [resultDep, setResultDep] = useState(null);
    const [DepartamentoAtivoId, setDepartamentoAtivoId] = useState(0);
    const [IdUsuarioLogado, setIdUsuarioLogado] = useState(0)
    const fetchData = async (param) => {

        let url = `${urlBase}/v1/Departamaneto/Departamento/BuscarTodosDepartamentoPorLogId?id=${param}`;

        try {
            const response = await fetch(url);

            if (!response.ok) {
                throw new Error('Erro na requisição');
            }

            const data = await response.json();
            var listTratada = []
            data.map(x => {
                listTratada.push({
                    id: x.codigo,
                    descricao: x.nomeDepartamento,
                    value: x.codigo
                })
            })
            setResultDep(listTratada);
            console.log("Aqui esta a lista tratada")
            console.log(listTratada)
            setDepartamentoAtivoId(listTratada[0].id)
            // setIsLoading(false)
        } catch (error) {
            console.log(error)
        }
    };

    const DepartamentoUsuario = 0;

    const selecionarDepartamentoAtivoNoSelect = (param) => {
        try {
            const selectElement = document.querySelector("#SelectDepartamentoUsuarioModal");
            if (selectElement && param) {
                selectElement.value = param;
            } else {
                selectElement.value = 1;
            }
        } catch (error) {

        }
    };

    useEffect(() => {
        selecionarDepartamentoAtivoNoSelect(DepartamentoUsuario);
    }, [DepartamentoUsuario]);


    useEffect(() => {
        UsuarioLogado().then(result => {
            if (result.usuarioLogadoId == null) {
                location.replace(location.origin + "/login");
            } else {
                fetchData(result.usuarioLogadoId);
                setIdUsuarioLogado(result.usuarioLogadoId)
            }
        });
    }, []);
    return (
        <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div className="modal-dialog modal-dialog-centered modal-xl">
                <div className="modal-content">
                    <div className="modal-body">
                        <div className="row mt-3 justify-content-between">
                            <div className="containerTipo col-6">
                                <label className="mb-2"><strong>Tipo</strong></label>
                                {/* Puxar Aqui Do Codigo Todos os Tipo Para Inserção */}
                                <select onChange={(e) => SelectTipoHandEvent(e)} className="form-select" id="SelectTipo">
                                    <option value="0" defaultValue={true}>Selecione um Tipo</option>
                                    <option value="1">Redirecionamento</option>
                                    <option value="2">Mensagem Simples</option>
                                    <option value="3">Mensagem de Multipla Escolhas</option>
                                </select>
                            </div>

                            <div className="containerTipo col-6" style={{ display: "none" }} id="DepartamentoSelect">
                                <label className="mb-2"><strong>Departamento</strong></label>
                                {/* Puxar Aqui Do Codigo Todos os Departamentos Para Inserção
                                            Lembrar que id vai ser o id do departamento selecionado em questao */}
                                {resultDep != null &&
                                    <Select
                                        // onChange={props.SetDepartamentoAtivoId}
                                        id={"selectDepartamento"}
                                        className={"DepartamentoModalAddFluxoBot form-select p-3"}
                                        placeholder={"Departamentos"}
                                        optionsList={resultDep}
                                    />
                                }
                                {/* <select id="selectDepartamento" className="form-select">
                                    <option defaultValue={true}>Selecione um Departamento</option>
                                    <option id="1" value="1">Suporte</option>
                                    <option id="2" value="2">Financeiro</option>
                                    <option id="3" value="3">Técnico</option>
                                </select> */}
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
                        <ButtonBase
                            AtributoPersonalizado={{ 'data-bs-dismiss': "modal" }}
                            className="btn buttonCancelarFromModal"
                            Description="Cancelar"
                        />
                        <ButtonBase
                            AtributoPersonalizado={{ 'data-bs-dismiss': "modal" }}
                            className={"btn buttonSalvarFromHome"}
                            Description={"Salvar"}
                            onClick={AdicionarEmDados}
                        />
                    </div>
                </div>
            </div>
        </div>

    )
}