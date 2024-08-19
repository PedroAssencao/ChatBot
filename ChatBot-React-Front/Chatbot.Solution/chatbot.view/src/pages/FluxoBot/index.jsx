import './style.css';
export default function FluxoBot() {

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
                            <svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-journal-bookmark-fill text-dark" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M6 1h6v7a.5.5 0 0 1-.757.429L9 7.083 6.757 8.43A.5.5 0 0 1 6 8z" />
                                <path d="M3 0h10a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2v-1h1v1a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v1H1V2a2 2 0 0 1 2-2" />
                                <path d="M1 5v-.5a.5.5 0 0 1 1 0V5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1zm0 3v-.5a.5.5 0 0 1 1 0V8h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1zm0 3v-.5a.5.5 0 0 1 1 0v.5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1z" />
                            </svg>
                            Inicial
                        </h6>
                    </div>
                    <div className='w-100 p-2'>
                        <h6 className='d-flex jusitfy-content-center align-items-center gap-2 textColorForFluxoBot'>
                            <svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-journal-plus text-dark" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M8 5.5a.5.5 0 0 1 .5.5v1.5H10a.5.5 0 0 1 0 1H8.5V10a.5.5 0 0 1-1 0V8.5H6a.5.5 0 0 1 0-1h1.5V6a.5.5 0 0 1 .5-.5" />
                                <path d="M3 0h10a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2v-1h1v1a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v1H1V2a2 2 0 0 1 2-2" />
                                <path d="M1 5v-.5a.5.5 0 0 1 1 0V5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1zm0 3v-.5a.5.5 0 0 1 1 0V8h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1zm0 3v-.5a.5.5 0 0 1 1 0v.5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1z" />
                            </svg>
                            Menus
                        </h6>
                    </div>
                </div>
                <div className="col p-0 bg-warning ContainerInfos" >

                    <div className='header p-2'>
                        <div className='ms-3'>
                            <button className='btn btnColorForFluxoBot d-flex gap-3'>Ligar
                                <div class="form-check form-switch ">
                                    <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                                </div>
                            </button>
                        </div>
                        <div className='me-3'>
                            <button className='btn btnColorForFluxoBot'>Salvar</button>
                        </div>
                    </div>

                    <div className='d-flex flex-column w-100 h-100 bg-warning overflow-x-auto'>

                        {/* div para caso o cliente não tenha nenhum menu */}
                        {/* <div className='p-5 d-flex flex-column justify-content-center align-items-center'>
                            <h6 className='textColorForFluxoBot'>Adicione um menu e começe a montar seu fluxo!</h6>
                            <div>
                                <button className='btn btnColorForFluxoBot'>Adicionar Menu</button>
                            </div>
                        </div> */}

                        <div className='w-100 bg-light p-2 d-flex flex-column gap-2 flex-row' style={{ flexWrap: "nowrap" }}>

                            <div className='offset-1 row p-0 gap-2' style={{ flexWrap: "nowrap" }}>
                                <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                    <h6>Titulo do Menu</h6>
                                    <button className='btn btnColorForFluxoBot'>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                            <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                        </svg>
                                    </button>
                                </div>
                            </div>

                            <div className='offset-3 row p-0 gap-2 flex-column ' style={{ flexWrap: "nowrap" }}>

                                <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                    <h6>Titulo do Menu</h6>
                                    <button className='btn btnColorForFluxoBot'>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                            <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                        </svg>
                                    </button>
                                </div>

                                <div className='offset-1 p-0'>

                                    <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                        <h6>Titulo do Menu</h6>
                                        <button className='btn btnColorForFluxoBot'>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                            </svg>
                                        </button>
                                    </div>

                                    <div className='offset-2 mt-3'>
                                        <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                            <h6>Titulo do Menu</h6>
                                            <button className='btn btnColorForFluxoBot'>
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                    <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                    <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                                </svg>
                                            </button>
                                        </div>
                                        <div className='offset-3 mt-3'>
                                            <div className='col mt-3 p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                                <h6>Titulo do Menu</h6>
                                                <button className='btn btnColorForFluxoBot'>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                        <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                                    </svg>
                                                </button>
                                            </div>
                                            <div className='col mt-3 p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                                <h6>Titulo do Menu</h6>
                                                <button className='btn btnColorForFluxoBot'>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                        <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                                    </svg>
                                                </button>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                    <h6>Titulo do Menu</h6>
                                    <button className='btn btnColorForFluxoBot'>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                            <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                        </svg>
                                    </button>
                                </div>

                                <div className='offset-1 p-0'>

                                    <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                        <h6>Titulo do Menu</h6>
                                        <button className='btn btnColorForFluxoBot'>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                            </svg>
                                        </button>
                                    </div>

                                    <div className='offset-2 mt-3'>
                                        <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                            <h6>Titulo do Menu</h6>
                                            <button className='btn btnColorForFluxoBot'>
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                    <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                    <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                                </svg>
                                            </button>
                                        </div>
                                        <div className='offset-3 mt-3'>
                                            <div className='col mt-3 p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                                <h6>Titulo do Menu</h6>
                                                <button className='btn btnColorForFluxoBot'>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                        <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                                    </svg>
                                                </button>
                                            </div>
                                            <div className='col mt-3 p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                                <h6>Titulo do Menu</h6>
                                                <button className='btn btnColorForFluxoBot'>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                        <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                                    </svg>
                                                </button>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                    <h6>Titulo do Menu</h6>
                                    <button className='btn btnColorForFluxoBot'>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                            <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                        </svg>
                                    </button>
                                </div>


                                <div className='offset-1 p-0'>

                                    <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                        <h6>Titulo do Menu</h6>
                                        <button className='btn btnColorForFluxoBot'>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                            </svg>
                                        </button>
                                    </div>

                                    <div className='offset-2 mt-3'>
                                        <div className='col p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                            <h6>Titulo do Menu</h6>
                                            <button className='btn btnColorForFluxoBot'>
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                    <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                    <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                                </svg>
                                            </button>
                                        </div>
                                        <div className='offset-3 mt-3'>
                                            <div className='col mt-3 p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                                <h6>Titulo do Menu</h6>
                                                <button className='btn btnColorForFluxoBot'>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                        <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                                    </svg>
                                                </button>
                                            </div>
                                            <div className='col mt-3 p-5 bg-light menuContainerForFluxoBot border rounded-3 border-dark' style={{ maxWidth: "30rem", minWidth: "30rem" }}>
                                                <h6>Titulo do Menu</h6>
                                                <button className='btn btnColorForFluxoBot'>
                                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-skip-end-circle" viewBox="0 0 16 16">
                                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                                        <path d="M6.271 5.055a.5.5 0 0 1 .52.038L9.5 7.028V5.5a.5.5 0 0 1 1 0v5a.5.5 0 0 1-1 0V8.972l-2.71 1.935A.5.5 0 0 1 6 10.5v-5a.5.5 0 0 1 .271-.445" />
                                                    </svg>
                                                </button>
                                            </div>
                                        </div>
                                    </div>

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