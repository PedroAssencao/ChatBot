import './style.css'
import image from '../../../img/file.jpg'
export default function ChatCard(props) {
    return (
        <div className={props.className}
            style={{ width: "96%", minHeight: "8vh" }} data-bs-dismiss="offcanvas">
            <div className="row justify-content-between">
                <div className="col-3 d-flex align-items-center gap-3">
                    <div>
                        <img className="rounded-circle" style={{ width: "40px" }} src={image} />
                    </div>
                    <div className="d-flex flex-column">
                        <p className="text-dark text-nowrap m-0">
                            Pedro Assenção
                        </p>
                        {/* Ultima mensagem enviada */}
                        <p className="text-secondary text-nowrap m-0">
                            Você: como posso ajudar?
                        </p>
                    </div>
                </div>

                {/* data da Ultima mensagem enviada */}
                <div className="col-2">
                    <p style={{ fontWeight: "bold" }}>
                        10:35
                    </p>
                </div>
            </div>
        </div>
    )
}