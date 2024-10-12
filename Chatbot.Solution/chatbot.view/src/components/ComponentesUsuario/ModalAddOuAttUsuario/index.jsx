import Input from '../../BaseComponents/input'
import './style.css'
export default function ModalAddOuAttUsuario(props) {
    return (
        <div className="modal fade" id="staticBackdrop" data-bs-keyboard="false" tabIndex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div className="modal-dialog modal-dialog-centered">
                <div className="modal-content">
                    <div className="modal-header">
                        <h1 className="modal-title fs-5" id="staticBackdropLabel">{props.title}</h1>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body modalUsuarioBody">
                        {props.descricao}
                        <Input id={"NomeUsuarioInputUsuarios"} placeholder={"Nome Usuario"}/>
                        <Input id={"SenhaInputUsuarios"} placeholder={"Senha"}/>
                        <Input id={"EmailInputUsuarios"} placeholder={"Email"}/>
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" onClick={props.onClick} className="btn btn-primary">Salvar</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

