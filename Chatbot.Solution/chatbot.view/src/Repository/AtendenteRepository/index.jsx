import { urlBase, UsuarioLogadoId } from '../../appsettings'

export function VerficarAltura() {
    var larguraJanela = window.innerHeight;

    if (document.querySelector(".ConteudoChat") != null) {
        if (larguraJanela < 559) {
            document.querySelector('.ConteudoChat').style.maxHeight = "65vh";
            document.querySelector('.ConteudoChat').style.height = "65vh";
        } else if (larguraJanela < 670) {
            document.querySelector('.ConteudoChat').style.maxHeight = "67vh";
            document.querySelector('.ConteudoChat').style.height = "67vh";
        } else if (larguraJanela < 768) {
            document.querySelector('.ConteudoChat').style.maxHeight = "70vh";
            document.querySelector('.ConteudoChat').style.height = "70vh";
        } else if (larguraJanela < 874) {
            document.querySelector('.ConteudoChat').style.maxHeight = "74vh";
            document.querySelector('.ConteudoChat').style.height = "74vh";
        } else {
            document.querySelector('.ConteudoChat').style.maxHeight = "77vh";
            document.querySelector('.ConteudoChat').style.height = "77vh";
        }
    }
}

export const FetchChatsData = async () => {
    try {
        const response = await fetch(urlBase + "/v1/Chat/chats/Get/BuscarTodosOsChatsPorLogId/" + UsuarioLogadoId);
        const data = await response.json();
        console.log("Lista De Chats Aqui")
        console.log(data)
        return data;
    } catch (error) {
        console.error('Error fetching contacts:', error);
    }
};

export const FiltrarDataPorStatus = (status, data) => {
    const statusNormalizado = status.trim().toLowerCase();
    if (statusNormalizado == "ativo") {
        return data.filter(x =>
            x?.atendimento?.atendente != null &&
            x?.estadoAtendimento?.trim().toLowerCase() == "humano"
        );
    }

    if (statusNormalizado == "esperando") {
        return data.filter(x =>
            x?.atendimento?.atendente == null ||
            x?.estadoAtendimento?.trim().toLowerCase() != "humano"
        );
    }


    return [];
};


export function entrarChat() {
    document.getElementById('TituloNavbar').style.display = 'none'
    document.getElementById('setarVoltar').style.display = 'flex'
    document.querySelector('#NavbarSearch').style.display = 'none'
    document.getElementById('sidebar').style.display = 'none'
    document.getElementById('containerMensagens').style.display = 'none'
    document.getElementById('containerChats').style.display = 'flex'
}

export function voltarChat() {
    document.getElementById('TituloNavbar').style.display = 'block'
    document.getElementById('setarVoltar').style.display = 'none'
    document.querySelector('#NavbarSearch').style.display = 'block'
    document.getElementById('sidebar').style.display = 'flex'
    document.getElementById('containerMensagens').style.display = 'block'
    document.getElementById('containerChats').style.display = 'none'
}
