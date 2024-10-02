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
    // try {
    //     const response = await fetch(urlBase + "/v1/Chat/chats/Get/BuscarTodosOsChatsPorLogId/" + UsuarioLogadoId);
    //     const data = await response.json();     
    //     return data;
    // } catch (error) {
    //     console.error('Error fetching contacts:', error);
    // }

    /*const connection = new signalR.HubConnectionBuilder()
        .withUrl(`http://localhost:5058/api/chatHub?logId=${UsuarioLogadoId}`)
        .build();

    connection.on("ReceiveChats", (element) => {
        console.log(element)
        // const index = data.findIndex(item => item.codigo === element.codigo);

        // if (index !== -1) {
        //     // Substitui o objeto existente pelo novo
        //     data[index] = element;
        // } else {
        //     // Adiciona o novo elemento se não houver um com o mesmo código
        //     data.push(element);
        // }

        return element
    });

    connection.start().catch(err => console.error(err.toString()));
*/
};

export const FiltrarDataPorStatus = (status,data) => {
    const statusNormalizado = status.trim().toLowerCase();
    if (statusNormalizado == "ativo") {
        return data.filter(x =>
            x?.atendente != null &&
            x?.atendimento?.estadoAtendimento?.trim().toLowerCase() == "humano"
        );
        return []
    }

    if (statusNormalizado == "esperando") {
        return data.filter(x =>
            x?.atendente == null ||
            x?.atendimento?.estadoAtendimento?.trim().toLowerCase() != "humano"
        );
        return []
    }
};

export function entrarChat() {
    var larguraJanela = window.innerWidth;

    if (larguraJanela < 992) {
        document.getElementById('TituloNavbar').style.display = 'none'
        document.getElementById('setarVoltar').style.display = 'flex'
        document.querySelector('#NavbarSearch').style.display = 'none'
        document.getElementById('sidebar').style.display = 'none'
        document.getElementById('containerMensagens').style.display = 'none'
        document.getElementById('containerChats').style.display = 'flex'
    }

    if (larguraJanela > 992) {
        //se quiser fazer uma alteração no codigo ao entrar o chat pc entrar aqui
    }
}

export function voltarChat() {
    document.getElementById('TituloNavbar').style.display = 'block'
    document.getElementById('setarVoltar').style.display = 'none'
    document.querySelector('#NavbarSearch').style.display = 'block'
    document.getElementById('sidebar').style.display = 'flex'
    document.getElementById('containerMensagens').style.display = 'block'
    document.getElementById('containerChats').style.display = 'none'
}
