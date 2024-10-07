import { AtendenteLogado } from "../../appsettings";
export default function Home() {
    console.log(AtendenteLogado())
    return (
        <div className="col">
            <h1>Home</h1>
        </div>
    );
}
