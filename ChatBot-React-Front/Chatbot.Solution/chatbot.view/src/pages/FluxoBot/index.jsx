import './style.css';
export default function FluxoBot() {
    return (
        <div className='col'>
            <div className="container-fluid border-bottom border-dark border-4 mt-5">
                <h2 className="h2">Dazzle Bot</h2>
            </div>
            <div className="row container-fluid p-0 mt-3 gap-5" style={{ marginLeft: "1px" }}>
                <div className="col-2 p-0 bg-dark containerInicio">
                    <div className='header'>
                        <h3 className='h3 text-danger'>OFFLINE</h3>
                    </div>
                </div>
                <div className="col p-5 bg-warning ContainerInfos">
                    <div className='header '>

                    </div>
                </div>
            </div>
        </div>
    )
}