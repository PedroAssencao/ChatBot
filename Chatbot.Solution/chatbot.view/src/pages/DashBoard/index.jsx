import './style.css';
import Mensagem from '../../components/ComponentesDashBoard/Mensagem';

export default function DashBoard(){
    return(
        <div className="col">
            <div className='Header'>
            <h1>DashBoard</h1>
            <p>11/08/2024 - 16/08/2024</p>
            </div>
        
            <hr></hr>
            <p>Novidades</p>
            <Mensagem/>
        </div>
    )
}
