export function VerficarAltura() {
    var larguraJanela = window.innerHeight;
    
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
