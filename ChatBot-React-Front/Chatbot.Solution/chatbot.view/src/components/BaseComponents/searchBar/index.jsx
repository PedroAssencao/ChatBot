import A from '../a'
import Input from '../input/input'
export default function searchBar(props) {
    return (
        <div className="d-flex justify-content-center ms-4 align-items-center" style={{ maxWidth: "90%" }}>
            <Input placeholder={"Buscar por usuário ou telefone"} />
            <A className={"btn b0dea5"} icon={
                <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor"
                    className="bi bi-search" viewBox="0 0 16 16">
                    <path
                        d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0" />
                </svg>
            } />
        </div>

    )
}