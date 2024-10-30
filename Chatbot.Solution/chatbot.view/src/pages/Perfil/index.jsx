import "./style.css";
import image from "./do-utilizador.png"

export default function perfil() {
    return (
        <div className="col principal">

            <h1 className="Title">Meu Perfil</h1>

            <hr></hr>

            <p className="SubTitle">Dados do Usuario</p>

<div className="imagem">
<img src={image}></img> 
</div>
            
            <div className="row">
                <div className="col principal">

                    <p>Login</p>
                    <div className="input-group flex-nowrap">
                        <input type="text" className="form-control" placeholder="Username" aria-label="Username" aria-describedby="addon-wrapping"></input>
                    </div>
                    <p>Nome</p>
                    <div className="input-group flex-nowrap">
                        <input type="text" className="form-control" placeholder="Username" aria-label="Username" aria-describedby="addon-wrapping"></input>
                    </div>
                    <p>Telefone</p>
                    <div className="input-group flex-nowrap">
                        <input type="text" className="form-control" placeholder="Username" aria-label="Username" aria-describedby="addon-wrapping"></input>
                    </div>
                </div>
                <div className="col principal">

                    <button className="btn btn-primary">Alterar Senha</button>

                    <p>Data de Nascimento</p>
                    <div className="input-group flex-nowrap">
                        <input type="text" className="form-control" placeholder="Username" aria-label="Username" aria-describedby="addon-wrapping"></input>
                    </div>
                    <p>Celular</p>
                    <div className="input-group flex-nowrap">
                        <input type="text" className="form-control" placeholder="Username" aria-label="Username" aria-describedby="addon-wrapping"></input>
                    </div>
                </div>
            </div>


        </div>
    );
}
