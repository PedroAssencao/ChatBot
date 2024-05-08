
//função feita apenas para demonstração de como funcionaria os chats no celular
function entrarChat() {
    document.getElementById('navbar').style.display = 'none'
    document.getElementById('sidebar').style.display = 'none'
    document.getElementById('containerMensagens').style.display = 'none'
    document.getElementById('containerChats').style.display = 'flex'
}

function voltarChat() {
    document.getElementById('navbar').style.display = 'block'
    document.getElementById('sidebar').style.display = 'flex'
    document.getElementById('containerMensagens').style.display = 'block'
    document.getElementById('containerChats').style.display = 'none'
}


// Verifique a largura da janela quando a página é carregada e redimensionada
function verificarLargura(bool) {
    // Obtenha a largura atual da janela
    var larguraJanela = window.innerWidth;

    // Verifique se a largura da janela é maior ou igual a 991px
    if (larguraJanela < 992 && bool == true) {
        // Se for maior ou igual a 991px, permita o uso da sua função
        entrarChat()
    } else {
        // Caso contrário, a largura da tela é menor que 991px
        // Neste exemplo, não fazemos nada ou podemos desativar a função

    }
}

// Registre um ouvinte de evento para verificar a largura da tela quando a janela é redimensionada
window.addEventListener('resize', verificarLargura(false));


function VerficarAltura() {
    var larguraJanela = window.innerHeight;
    console.log(larguraJanela);

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

window.addEventListener('resize', VerficarAltura);
VerficarAltura();
