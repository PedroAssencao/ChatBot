import "./style.css";
import image from "../Usuario/do-utilizador.png"
import image2 from "../Usuario/chave.png"
import image3 from "../Usuario/verificado.png"

export default function usuario() {
  return (
    <div className="col">
      <div className="Header">
      <h1 className="Title">Usuario</h1>
      <button className="btn btn-primary">Adicionar Usuario   	&nbsp;
      <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-plus-circle" viewBox="0 0 16 16">
  <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
  <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4"/>
</svg>
      </button>
      </div>

      <hr></hr>
      <div class="container-fluid text-center">
        <div class="row row-cols-1 row-cols-sm-2 row-cols-md-4">
          <div class="col">
            <div className="card">
              <div className="cardBody">
                <div>
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-1-circle-fill"
                    viewBox="0 0 16 16"
                  >
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M9.283 4.002H7.971L6.072 5.385v1.271l1.834-1.318h.065V12h1.312z" />
                  </svg> */}
                   <img src={image3}></img>
                  <div className="cardInfo">
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
                <div className="cardIcon">
                  <img src={image}></img>
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="100"
                    height="100"
                    fill="currentColor"
                    class="bi bi-person-circle"
                    viewBox="0 0 16 16"
                  >
                    <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                    <path
                      fill-rule="evenodd"
                      d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1"
                    />
                  </svg> */}
                  <p className="Name">Antony</p>
                  <p className="Type">Atendente</p>
                  <div>
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
                <div className="cardTotal">
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-1-circle-fill"
                    viewBox="0 0 16 16"
                  >
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M9.283 4.002H7.971L6.072 5.385v1.271l1.834-1.318h.065V12h1.312z" />
                  </svg> */}
                   <img src={image2}></img>
                  <div className="cardInfo">
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
              </div>
             
            </div>
          </div>
        
          <div class="col">
            <div className="card">
              <div className="cardBody">
                <div>
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-1-circle-fill"
                    viewBox="0 0 16 16"
                  >
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M9.283 4.002H7.971L6.072 5.385v1.271l1.834-1.318h.065V12h1.312z" />
                  </svg> */}
                   <img src={image3}></img>
                  <div className="cardInfo">
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
                <div className="cardIcon">
                  <img src={image}></img>
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="100"
                    height="100"
                    fill="currentColor"
                    class="bi bi-person-circle"
                    viewBox="0 0 16 16"
                  >
                    <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                    <path
                      fill-rule="evenodd"
                      d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1"
                    />
                  </svg> */}
                  <p className="Name">Antony</p>
                  <p className="Type">Atendente</p>
                  <div>
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
                <div className="cardTotal">
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-1-circle-fill"
                    viewBox="0 0 16 16"
                  >
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M9.283 4.002H7.971L6.072 5.385v1.271l1.834-1.318h.065V12h1.312z" />
                  </svg> */}
                   <img src={image2}></img>
                  <div className="cardInfo">
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
              </div>
             
            </div>
          </div>

          <div class="col">
            <div className="card">
              <div className="cardBody">
                <div>
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-1-circle-fill"
                    viewBox="0 0 16 16"
                  >
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M9.283 4.002H7.971L6.072 5.385v1.271l1.834-1.318h.065V12h1.312z" />
                  </svg> */}
                   <img src={image3}></img>
                  <div className="cardInfo">
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
                <div className="cardIcon">
                  <img src={image}></img>
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="100"
                    height="100"
                    fill="currentColor"
                    class="bi bi-person-circle"
                    viewBox="0 0 16 16"
                  >
                    <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                    <path
                      fill-rule="evenodd"
                      d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1"
                    />
                  </svg> */}
                  <p className="Name">Antony</p>
                  <p className="Type">Atendente</p>
                  <div>
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
                <div className="cardTotal">
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-1-circle-fill"
                    viewBox="0 0 16 16"
                  >
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M9.283 4.002H7.971L6.072 5.385v1.271l1.834-1.318h.065V12h1.312z" />
                  </svg> */}
                   <img src={image2}></img>
                  <div className="cardInfo">
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
              </div>
             
            </div>
          </div>

          <div class="col">
            <div className="card">
              <div className="cardBody">
                <div>
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-1-circle-fill"
                    viewBox="0 0 16 16"
                  >
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M9.283 4.002H7.971L6.072 5.385v1.271l1.834-1.318h.065V12h1.312z" />
                  </svg> */}
                   <img src={image3}></img>
                  <div className="cardInfo">
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
                <div className="cardIcon">
                  <img src={image}></img>
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="100"
                    height="100"
                    fill="currentColor"
                    class="bi bi-person-circle"
                    viewBox="0 0 16 16"
                  >
                    <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                    <path
                      fill-rule="evenodd"
                      d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1"
                    />
                  </svg> */}
                  <p className="Name">Antony</p>
                  <p className="Type">Atendente</p>
                  <div>
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
                <div className="cardTotal">
                  {/* <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    class="bi bi-1-circle-fill"
                    viewBox="0 0 16 16"
                  >
                    <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M9.283 4.002H7.971L6.072 5.385v1.271l1.834-1.318h.065V12h1.312z" />
                  </svg> */}
                   <img src={image2}></img>
                  <div className="cardInfo">
                  <p className="Number">0</p>
                  <p>Ativo(s)</p>
                </div>
                </div>
              </div>
             
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
