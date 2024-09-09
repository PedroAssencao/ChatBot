import './style.css';
export default function TelaBloqueio(){
        document.querySelector("#bodyFromPageAll").style = "overflow-y: auto;"
    return(
        <div className="App">
        {/* Barra superior */}
        <div className="barra-superior">
          <h1>ChatBot</h1>
        </div>
  
        {/* Conteúdo principal */}
        <div className="conteudo">
          <h2>Bloqueados</h2>
          <hr className="linha-horizontal" />
        </div>
      </div>
    )
}
