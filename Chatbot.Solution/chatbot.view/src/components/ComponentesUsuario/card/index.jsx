import image from "../card/do-utilizador.png"
import image2 from "../card/chave.png"
import image3 from "../card/verificado.png"
import './style.css'
export default function card() {
    return (

        <div className="card">
            <div className="cardBody">
                <div>

                    <img src={image3}></img>
                    <div className="cardInfo">
                        <p className="Number">0</p>
                        <p>Ativo(s)</p>
                    </div>
                </div>
                <div className="cardIcon">
                    <img src={image}></img>

                    <p className="Name">Antony</p>
                    <p className="Type">Atendente</p>
                    <div>
                        <p className="Number">0</p>
                        <p>Ativo(s)</p>
                    </div>
                </div>
                <div className="cardTotal">

                    <img src={image2}></img>
                    <div className="cardInfo">
                        <p className="Number">0</p>
                        <p>Ativo(s)</p>
                    </div>
                </div>
            </div>

        </div>
    )
}

