import './style.css'
export default function ChatCard(props) {
    return (
        <div className={props.className}
            style={{width: "96%"}} data-bs-dismiss="offcanvas">
            <div className="row">
                <div className="col-3">
                    <div className="d-flex">
                        <img className="leadImage rounded-circle" src="./img/file.jpg" />
                    </div>
                </div>
                <div className="col">
                    <div className="d-flex flex-column">
                        {/* Inserir o Nome do Contato */}
                        <p className="text-dark">
                            Pedro Assenção
                        </p>
                        {/* Ultima mensagem enviada */}
                        <p className="text-secondary">
                            Você: como posso ajudar?
                        </p>

                    </div>
                </div>
                {/* data da Ultima mensagem enviada */}
                <div className="col-2">
                    <p style={{fontWeight: "bold"}}>
                        10:35
                    </p>
                </div>
            </div>
        </div>
    )
}