
//função feita apenas para demonstração de como funcionaria os chats no celular
function entrarChat() {
    document.getElementById('navbar').style.display = 'none'
    document.getElementById('sidebar').style.display = 'none'
    document.getElementById('containerMensagens').style.display = 'none'
    document.getElementById('containerChats').style.display = 'flex'
}

window.onload = function() {
    var element = document.querySelector(".ConteudoChat");
    element.scrollTop = element.scrollHeight;
};

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




function aumentarMargin() {
    var larguraJanela = window.innerHeight;
    console.log(larguraJanela)
    if(larguraJanela > 900){
        var containerMensagens = document.getElementById("pai");
        containerMensagens.style.marginLeft = '5.8rem'; // Ajuste o valor conforme necessário
    }
}

function diminuirMargin() {
    var larguraJanela = window.innerHeight;
    if(larguraJanela > 600){
        console.log(larguraJanela)
        var containerMensagens = document.getElementById("pai");
        containerMensagens.style.marginLeft = '0';
    }
}

function pesquisar(){
    var contato = document.getElementById("inputContatos").value;
    console.log(contato)
    var listacontatos = document.getElementById("ListaContatos");
    const itens = document.querySelectorAll(".itemcontato");
    document.getElementById("ListaContatos").innerHTML = ""
    console.log(itens)
    
    itens.forEach(element => {
        console.log(element)
        var titulo = element.querySelector(".titulo").innerHTML;
        console.log(titulo)


        if (titulo.includes(contato)) {
            document.getElementById("ListaContatos").innerHTML += element.innerHTML
        }
        else{
            console.log("nao tem nenhume que inclui sua pesquisa")
        }
    });

   

    contato.includes(contato); // retorna false
}