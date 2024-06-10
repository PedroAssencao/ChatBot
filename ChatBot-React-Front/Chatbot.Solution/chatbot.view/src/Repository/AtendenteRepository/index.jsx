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