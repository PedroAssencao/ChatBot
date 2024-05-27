import './style.css'
import A from '../a'

export default function Navbar() {
    return (
        // navbar
        <div className="col-12 p-4 bg-light" id="navbar">
            <div className="row justify-content-between">

                {/* Header aqui fica o contato e a navbar */}
                <div className="col mt-3" style={{maxWidth: "35rem"}}>
                    <div className="d-flex gap-3">
                        <h1 className="d-block" style={{color: "#263a6d", fontWeight: "bold", fontSize: "2rem"}}>
                            Chatbot
                        </h1>

                        {/* <button className="btn btnAdicionar">
                            <p className="buttonplus">+</p>
                        </button> */}

                    </div>
                </div>

                <A classNameName={"col mt-3 d-flex d-lg-none justify-content-end"} data-bs-toggle={"offcanvas"} href={"#offcanvasExample"} Icon={
                    <svg xmlns="http://www.w3.org/2000/svg" style="color:#182c5f;" width="36" height="36"
                        fill="currentColor" className="bi bi-search" viewBox="0 0 16 16">
                        <path
                            d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0" />
                    </svg>
                } />

                {/* Contato, Ver Como Vai ficar isso aqui depois, acho massa fazer algo como whastapp que so aparece os chat quando clicka aqui */}
                <div className="col mt-3 d-none d-lg-block">
                    <div className="d-flex gap-3">
                        <div className="d-flex align-items-end gap-3">
                            <img className="leadImage rounded-circle" src="~/img/bye-bye-looksmaxxing.webp" />
                            <p style={{fontFamily: "Arial, Helvetica, sans-serif"}}>Pedro Assenção</p>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    )
}