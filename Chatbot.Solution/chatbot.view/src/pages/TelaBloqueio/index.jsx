import './style.css';
export default function TelaBloqueio(){
        document.querySelector("#bodyFromPageAll").style = "overflow-y: auto;"
    return(
        <div className="col">
        <div className="barra-superior">
          <h1 >ChatBot</h1>
        </div>
  
       
        <div className="conteudo">
          <div class="parte-superior">
          <h2>Bloqueados</h2>
          <button type="button" class="btn btn-success">Adicionar Contato</button>
          </div>
          
          <hr className="linha-horizontal"/>
         

          {/* <div class="card text-center">
                <div class="card-header">
                    <ul class="nav nav-pills card-header-pills">
                        <li class="nav-item">
                        <a class="nav-link active" href="#">Contatos</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="#">Link</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link disabled" aria-disabled="true">Disabled</a>
                      </li>
                    </ul>
                </div>
                  <div class="card-body">
                      <h5 class="card-title">Special title treatment</h5>
                      <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                  </div>
            </div> */}
            <table class="table">
                <thead class="table-success">
                  <tr>

                    <th scope="col">Contato</th>

                    <th scope="col">Bot</th>
                    <th scope="col"></th>
                  </tr>
                </thead>
                <tbody class="table-group">
                  <tr>
                    <td>7999923879</td>
                    <td>DazzleBot</td>
                    <td><svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                   <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5M8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5m3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0"/>
                  </svg></td>
                  </tr>
                  <tr>
                    <td>799938392</td>
                    <td>DazzleBot</td>
                    <td><svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                   <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5M8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5m3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0"/>
                    </svg></td>
                  </tr> 
                </tbody>
             </table>
         </div>
         
          
        </div>
    )
}
