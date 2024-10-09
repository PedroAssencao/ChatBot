import { AtendenteLogado } from "../../appsettings";
export default function Home() {
    AtendenteLogado().then(result => {
        console.log(result); // Aqui você tem o valor da Promise resolvida
    });
    return (
        <div className="col">
            <h1>Home</h1>
        </div>
    );
}
