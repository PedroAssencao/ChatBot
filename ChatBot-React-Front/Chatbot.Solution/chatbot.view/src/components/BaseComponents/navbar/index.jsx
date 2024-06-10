import './style.css'
import A from '../a'
import image from '../../../img/file.jpg'
import { voltarChat } from '../../../Repository/AtendenteRepository'
export default function Navbar(props) {
    return (
        // navbar

        //colocar os ifs para atender condições de renderização aqui depois
        <div className="col-12 p-4 bg-light" id="navbar">
            <div className="row justify-content-between">

                {/* Header aqui fica o contato e a navbar */}
                <div id='TituloNavbar' className="col mt-3" style={{ maxWidth: "35rem" }}>
                    <div className="d-flex gap-3">
                        <h1 className="d-block" style={{ color: "#263a6d", fontWeight: "bold", fontSize: "2rem" }}>
                            Chatbot
                        </h1>

                        {/* <button className="btn btnAdicionar">
                            <p className="buttonplus">+</p>
                        </button> */}

                    </div>
                </div>


                <div id='NavbarSearch' className='col mt-3'>
                    <A className={"col d-flex d-lg-none justify-content-end align-items-center"} bootsrapAction={"offcanvas"} href={"#offcanvasExample"} icon={
                        <svg xmlns="http://www.w3.org/2000/svg" style={{ color: "#182c5f", display: "flex" }} width="36" height="36"
                            fill="currentColor" className="bi bi-search" viewBox="0 0 16 16">
                            <path
                                d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0" />
                        </svg>
                    } />
                </div>


                {/* Contato, Ver Como Vai ficar isso aqui depois, acho massa fazer algo como whastapp que so aparece os chat quando clicka aqui */}
                <div className="col mt-3 d-lg-block" style={{ display: "none" }} id='setarVoltar'>
                    <div className="p-3 d-lg-none" onClick={voltarChat}>
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20"
                            fill="currentColor" className="bi bi-arrow-left" viewBox="0 0 16 16">
                            <path fillRule="evenodd"
                                d="M15 8a.5.5 0 0 0-.5-.5H2.707l3.147-3.146a.5.5 0 1 0-.708-.708l-4 4a.5.5 0 0 0 0 .708l4 4a.5.5 0 0 0 .708-.708L2.707 8.5H14.5A.5.5 0 0 0 15 8" />
                        </svg>
                    </div>
                    <div className="d-flex gap-3">
                        <div className="d-flex align-items-end gap-3">
                            <img src={image} className="leadImage rounded-circle" />
                            <p style={{ fontFamily: "Arial, Helvetica, sans-serif" }}>Pedro Assenção</p>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    )
}