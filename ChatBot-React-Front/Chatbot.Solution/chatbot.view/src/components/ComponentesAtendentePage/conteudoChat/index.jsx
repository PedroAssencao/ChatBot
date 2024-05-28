import ConversaCard from '../conversaCard'
import MensagemSend from '../MensagenSend'
import '../conteudoChat/style.css'
export default function conteudoChat(props) {
    return (
        <div class="ConteudoChat d-flex flex-column">
            <ConversaCard/>
            <ConversaCard/>
            <ConversaCard/>
            <ConversaCard/>
            <ConversaCard/>
            <MensagemSend/>
        </div>
    )
}