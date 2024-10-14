import Input from '../../BaseComponents/input'
import Select from '../../BaseComponents/select'
import './style.css'
export default function ModalAddOuAttUsuario(props) {
    console.log("Nome Usuario Aqui")
    console.log(props.nomeUsuario)
    return (
        <div className="modal fade" id="staticBackdrop" data-bs-keyboard="false" tabIndex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div className="modal-dialog modal-dialog-centered modal-lg">
                <div className="modal-content">
                    <div className="modal-header">
                        <h1 className="modal-title fs-5" id="staticBackdropLabel">{props.title}</h1>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body modalUsuarioBody">
                        <strong className='w-100 d-flex justify-content-start h6'>
                            {props.descricao}
                        </strong>
                        <div className='row gap-2'>
                            <div className='widthRowUsuarioModal'>
                                <Input value={props.nomeUsuariov} id={"NomeUsuarioInputUsuarios"} placeholder={"Nome Usuario"} />
                            </div>
                            <div className='widthRowUsuarioModal'>
                                <Select
                                    onChange={props.SetDepartamentoAtivoId}
                                    id={"SelectDepartamentoUsuarioModal"}
                                    placeholder={"Departamentos"}
                                    optionsList={props.optionsList}
                                />
                            </div>
                            <div className='widthRowUsuarioModal'>
                                <Input value={props.senhaUsuario} id={"SenhaInputUsuarios"} placeholder={"Senha"} />
                            </div>
                            <div className='widthRowUsuarioModal'>
                                <Input value={props.emailUsuario} id={"EmailInputUsuarios"} placeholder={"Email"} />
                            </div>
                        </div>
                    </div>
                    <div className="modal-footer">
                        <button type="button" onClick={props.onClick} className="btn btn-primary">Salvar</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

