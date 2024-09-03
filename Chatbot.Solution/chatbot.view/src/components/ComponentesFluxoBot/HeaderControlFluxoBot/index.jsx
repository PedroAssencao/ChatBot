import './style.css'
import ButtonBase from '../../BaseComponents/button'
export default function HeaderControlFluxobot(props) {
    return (
        <div className='headerControlFluxoBot p-2'>
            <div className='ms-3'>
                <button className='btn btnColorForFluxoBot d-flex gap-3'>Ligar
                    <div className="form-check form-switch ">
                        <input className="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                    </div>
                </button>
            </div>
            <div className='me-3'>
                <ButtonBase
                    className="btn btnColorForFluxoBot"
                    Description="Salvar"
                />
            </div>
        </div>
    )
}