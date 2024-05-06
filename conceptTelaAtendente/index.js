
//função feita apenas para demonstração de como funcionaria os chats no celular
function entrarChat() {
    document.getElementById('navbar').style.display = 'none'
    document.getElementById('sidebar').style.display = 'none'
    document.getElementById('containerMensagens').style.display = 'none'
    document.getElementById('containerChats').style.display = 'block'
}

function voltarChat() {
    document.getElementById('navbar').style.display = 'block'
    document.getElementById('sidebar').style.display = 'block'
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
        console.log("A largura da tela é menor que 992px. A função não será executada.");
    }
}

// Registre um ouvinte de evento para verificar a largura da tela quando a janela é redimensionada
window.addEventListener('resize', verificarLargura(false));
