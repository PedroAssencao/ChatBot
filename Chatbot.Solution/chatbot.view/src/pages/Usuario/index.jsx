import "./style.css";
import Card from '../../components/ComponentesUsuario/card';
import { urlBase, UsuarioLogado } from "../../appsettings";
import { useEffect, useState } from "react";
import LoadScreen from "../../components/BaseComponents/loadingScreen";
export default function usuario() {

  const [result, setResult] = useState(null);
  const [IsLoading, setIsLoading] = useState(true)
  const fetchData = async (param) => {
    const url = `${urlBase}/v1/Atendente/Atendente/BuscarTodosAtendentePorLogId?id=${param}`;

    try {
      const response = await fetch(url);

      if (!response.ok) {
        throw new Error('Erro na requisição');
      }

      const data = await response.json();
      console.log(data)
      setResult(data);
      setIsLoading(false)
    } catch (error) {
      console.log(error)
    }
  };

  useEffect(() => {
    UsuarioLogado().then(result => {
      if (result.usuarioLogadoId == null) {
        location.replace(location.origin + "/login");
      } else {
        fetchData(result.usuarioLogadoId);
      }
    });
  }, []);


  return (
    <>
      {IsLoading ? (
        <LoadScreen />
      ) : (
        <div className="col">
          <div className="Header">
            <h1 className="Title">Usuario</h1>
            <button className="btn btn-primary">Adicionar Usuario &nbsp;
              <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" className="bi bi-plus-circle" viewBox="0 0 16 16">
                <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4" />
              </svg>
            </button>
          </div>

          <hr />

          <div className="container-fluid text-center">
            <div className="row justify-content-center align-items-center ">

              {result.map(x => (
                <div className="col Widthteste" key={x.atendente.codigo}>
                  <Card date={x} />
                </div>
              ))}

            </div>
          </div>
        </div>
      )}

    </>

  );
}
