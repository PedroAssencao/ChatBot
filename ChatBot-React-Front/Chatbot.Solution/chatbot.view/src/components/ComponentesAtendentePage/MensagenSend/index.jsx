import '../MensagenSend/style.css'
export default function MensagemSend(props) {
    return (
        <div class="flex-grow-1">

            <div class="d-flex gap-3 mensagens mt-3 justify-content-center align-items-center">

                <div class="inputMensagen w-100" style="max-width: 90%;">
                    <input class="form-control p-3 rounded-4" style="background-color: #c7cfe4;"
                        placeholder="Mensagem" />
                </div>

                <a class="btn p-3 rounded-4 " style="background-color: #6276A842;">
                    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor"
                        class="bi bi-send" viewBox="0 0 16 16">
                        <path
                            d="M15.854.146a.5.5 0 0 1 .11.54l-5.819 14.547a.75.75 0 0 1-1.329.124l-3.178-4.995L.643 7.184a.75.75 0 0 1 .124-1.33L15.314.037a.5.5 0 0 1 .54.11ZM6.636 10.07l2.761 4.338L14.13 2.576zm6.787-8.201L1.591 6.602l4.339 2.76z" />
                    </svg>
                </a>

            </div>
        </div>
    )
}