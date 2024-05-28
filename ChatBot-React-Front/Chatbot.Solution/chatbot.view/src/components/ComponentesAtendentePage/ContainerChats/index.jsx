import conteudoChat from "../conteudoChat"
export default function ContainerChats(props) {
    return (
        <div class="col p-0 d-lg-flex containerChat" id="containerChats"
            style="display: none; flex-direction: column; background-color: #EBEFF9;">
            <conteudoChat/>
        </div>
    )
}