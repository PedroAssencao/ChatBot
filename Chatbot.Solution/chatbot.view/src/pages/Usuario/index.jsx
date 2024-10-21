import "./style.css";
import Card from '../../components/ComponentesUsuario/card';

export default function usuario() {
  return (
    <div className="col">
      <div className="Header">
      <h1 className="Title">Usuario</h1>
      <button className="btn btn-primary BlueButton">Adicionar Usuario   	&nbsp;
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
           <Card></Card>
          </div>
        
          <div class="col">
          <Card></Card>
          </div>

          <div class="col">
          <Card></Card>
           </div>

           <div class="col">
           <Card></Card>
           </div>
         
        </div>
      </div>
    </div>
  );
}
