var optionsCounter = 0
var MenuCounter = 0
var loopsCount = 0

const data = [
  {
    "codigo": 1,
    "titulo": "Menu Inicial",
    "header": "Empresas Senai",
    "body": "Seja Bem Vindo ao Nosso Robo de Atendimento, Antes de Falar Com Nossos Atendentes Por Favor Resposnda as Perguntas Abaixo Para Sabermos o Seu Problema, Tentaremos Resolver Sem Intervenção Humana Se Possivel!",
    "footer": "Todos direitos reservados",
    "tipo": "PrimeiraMensagem",
    "login": {
      "codigo": 1,
      "codigoWhatsap": "557999411293",
      "usuario": "Master",
      "email": "master.123@123",
      "senha": "c2VuYWkuMTIz",
      "imagem": "img-placeholder",
      "plano": "master"
    },
    "options": [
      {
        "codigo": 1,
        "codigoMenu": 1,
        "titulo": "Financeiro",
        "descricao": "Referente a Financeiro",
        "resposta": "2",
        "tipo": "MensagemDeRespostaInterativa",
        "finalizar": false
      },
      {
        "codigo": 2,
        "codigoMenu": 1,
        "titulo": "Suporte",
        "descricao": "Referente a Suporte",
        "resposta": "3",
        "tipo": "MensagemDeRespostaInterativa",
        "finalizar": false
      },
      {
        "codigo": 13,
        "codigoMenu": 1,
        "titulo": "Historia Senai",
        "descricao": "Historia do Senai Contada Pela IA e Interação Geral Com IA",
        "resposta": "6",
        "tipo": "MensagemPorIA",
        "finalizar": false
      }
    ]
  },
  {
    "codigo": 2,
    "titulo": "Finanças",
    "header": "Empresas Senai",
    "body": "Por Favor Escolha Qual Parte das Finança Voce Esta Tendo Problemas",
    "footer": "Todos direitos reservados",
    "tipo": "MenuBot",
    "login": {
      "codigo": 1,
      "codigoWhatsap": "557999411293",
      "usuario": "Master",
      "email": "master.123@123",
      "senha": "c2VuYWkuMTIz",
      "imagem": "img-placeholder",
      "plano": "master"
    },
    "options": [
      {
        "codigo": 9,
        "codigoMenu": 2,
        "titulo": "Pagamento",
        "descricao": "Dificuldades no Pagamento",
        "resposta": "5",
        "tipo": "MensagemDeRespostaInterativa",
        "finalizar": false
      },
      {
        "codigo": 10,
        "codigoMenu": 2,
        "titulo": "Finalizar",
        "descricao": "Finalizar Atendimento",
        "resposta": "Muito Obrigado Por Interagir",
        "tipo": "MensagemDeResposta",
        "finalizar": true
      }
    ]
  },
  {
    "codigo": 3,
    "titulo": "Suporte",
    "header": "Empresas Senai",
    "body": "Por Favor Escolha Qual Setor de Suporte Que Voce Deseja Ser Atendido",
    "footer": "Todos direitos reservados",
    "tipo": "MenuBot",
    "login": {
      "codigo": 1,
      "codigoWhatsap": "557999411293",
      "usuario": "Master",
      "email": "master.123@123",
      "senha": "c2VuYWkuMTIz",
      "imagem": "img-placeholder",
      "plano": "master"
    },
    "options": [
      {
        "codigo": 11,
        "codigoMenu": 3,
        "titulo": "Dificuldades Sistemas",
        "descricao": "Instabilidade no Geral",
        "resposta": "4",
        "tipo": "MensagemDeRespostaInterativa",
        "finalizar": false
      },
      {
        "codigo": 12,
        "codigoMenu": 3,
        "titulo": "Finalizar",
        "descricao": "Finalizar Atendimento",
        "resposta": "Muito Obrigado Por Interagir Volte Sempre",
        "tipo": "MensagemDeResposta",
        "finalizar": true
      }
    ]
  },
  {
    "codigo": 4,
    "titulo": "Menu de Dificuldades ao Acessar o Sistema",
    "header": "Empresas Senai",
    "body": "Escolha Quais Das Opções Abaixo Descreve Melhor o Seu Problema",
    "footer": "Todos direitos reservados",
    "tipo": "MenuBot",
    "login": {
      "codigo": 1,
      "codigoWhatsap": "557999411293",
      "usuario": "Master",
      "email": "master.123@123",
      "senha": "c2VuYWkuMTIz",
      "imagem": "img-placeholder",
      "plano": "master"
    },
    "options": [
      {
        "codigo": 6,
        "codigoMenu": 4,
        "titulo": "Esquecimento da Senha",
        "descricao": "Esqueci Minha Senha",
        "resposta": "Aqui Esta um Link Para Preencher as informações para o reset da sua senha: (linkExemplo), espero que fique bem.",
        "tipo": "MensagemDeResposta",
        "finalizar": true
      },
      {
        "codigo": 7,
        "codigoMenu": 4,
        "titulo": "Dificuldades Sistemas",
        "descricao": "Instabilidade No Geral",
        "resposta": "Lamentamos se o sistema esta lento hoje, estamos em periodo de manuntenção ja voltaremos ao normal",
        "tipo": "MensagemDeResposta",
        "finalizar": true
      },
      {
        "codigo": 8,
        "codigoMenu": 4,
        "titulo": "Finalizar",
        "descricao": "Finalizar Atendimento",
        "resposta": "Obrigado Por Interagir Volte Sempre",
        "tipo": "MensagemDeResposta",
        "finalizar": true
      }
    ]
  },
  {
    "codigo": 5,
    "titulo": "DificuldadePagar",
    "header": "Empresas Senai",
    "body": "Escolha Quais Das Opções Abaixo Descreve Melhor o Seu Problema de Pagamento",
    "footer": "Todos direitos reservados",
    "tipo": "MenuBot",
    "login": {
      "codigo": 1,
      "codigoWhatsap": "557999411293",
      "usuario": "Master",
      "email": "master.123@123",
      "senha": "c2VuYWkuMTIz",
      "imagem": "img-placeholder",
      "plano": "master"
    },
    "options": [
      {
        "codigo": 3,
        "codigoMenu": 5,
        "titulo": "Pagamento Indisponivel",
        "descricao": "Pagamento Não Disponivel",
        "resposta": "Sua Forma de Pagamento não esta disponivel no sistema? Use esse qrcode para pagar diretamente: (exemploqrcode)",
        "tipo": "MensagemDeResposta",
        "finalizar": true
      },
      {
        "codigo": 4,
        "codigoMenu": 5,
        "titulo": "Pagamento Não Autorizado",
        "descricao": "Pagamento Não Autorizado",
        "resposta": "Sinto Muito Pelo Transtorno se Possivel tente checkar seu saldo para ver se ouve uma transação erronea",
        "tipo": "MensagemDeResposta",
        "finalizar": true
      },
      {
        "codigo": 5,
        "codigoMenu": 5,
        "titulo": "Finalizar",
        "descricao": "Finalizar Atendimento",
        "resposta": "Muito Obrigado Por Interagir",
        "tipo": "MensagemDeResposta",
        "finalizar": true
      }
    ]
  },
  {
    "codigo": 6,
    "titulo": "Menu IA",
    "header": "Empresas Senai",
    "body": "Escolha Quais Das Opções Abaixo e a Sua Vontade Se Tiver Mais Alguma Pergunta Apenas Pergunte!",
    "footer": "Todos direitos reservados",
    "tipo": "MenuDaIA",
    "login": {
      "codigo": 1,
      "codigoWhatsap": "557999411293",
      "usuario": "Master",
      "email": "master.123@123",
      "senha": "c2VuYWkuMTIz",
      "imagem": "img-placeholder",
      "plano": "master"
    },
    "options": [
      {
        "codigo": 14,
        "codigoMenu": 6,
        "titulo": "Sim",
        "descricao": "Voltar ao Fluxo de Atendimento Normal",
        "resposta": "Sim",
        "tipo": "MensagemPorIA",
        "finalizar": false
      },
      {
        "codigo": 15,
        "codigoMenu": 6,
        "titulo": "Finalizar",
        "descricao": "Finalizar o Atendimento",
        "resposta": "Obrigado Por Interagir com O Sistema!",
        "tipo": "MensagemPorIA",
        "finalizar": true
      }
    ]
  }
];

export const SelectTipoHandEvent = (element) => {
  if (element.target.value == "0") {
    document.querySelector('#DepartamentoSelect').style.display = "none"
    document.querySelector("#FinalizarAtendimentoSelect").style.display = "none"
    document.querySelector("#TextareaSelect").style.display = "none"
    document.querySelector('#MultiplaEscolha').style.display = "none"
    document.querySelector('#RedirecionamentoInputsSections').style.display = "none"
  }

  if (element.target.value == "1") {
    document.querySelector('#DepartamentoSelect').style.display = "block"
    document.querySelector("#FinalizarAtendimentoSelect").style.display = "none"
    document.querySelector('#MultiplaEscolha').style.display = "none"
    document.querySelector('#RedirecionamentoInputsSections').style.display = "flex"
    document.querySelector("#TextareaSelect").style.display = "none"
  }

  if (element.target.value == "2") {
    document.querySelector("#FinalizarAtendimentoSelect").style.display = "Flex"
    document.querySelector("#TextareaSelect").style.display = "Flex"
    document.querySelector('#DepartamentoSelect').style.display = "none"
    document.querySelector('#RedirecionamentoInputsSections').style.display = "none"
  }

  if (element.target.value == "3") {
    document.querySelector('#MultiplaEscolha').style.display = "Flex"
    document.querySelector('#DepartamentoSelect').style.display = "none"
    document.querySelector("#FinalizarAtendimentoSelect").style.display = "none"
    document.querySelector('#RedirecionamentoInputsSections').style.display = "none"
    document.querySelector("#TextareaSelect").style.display = "none"
  }
}

// document.querySelector("#SelectTipo").addEventListener("change", (element) => {

//   if (element.target.value == "0") {
//     document.querySelector('#DepartamentoSelect').style.display = "none"
//     document.querySelector("#FinalizarAtendimentoSelect").style.display = "none"
//     document.querySelector("#TextareaSelect").style.display = "none"
//     document.querySelector('#MultiplaEscolha').style.display = "none"
//     document.querySelector('#RedirecionamentoInputsSections').style.display = "none"
//   }

//   if (element.target.value == "1") {
//     document.querySelector('#DepartamentoSelect').style.display = "block"
//     document.querySelector("#FinalizarAtendimentoSelect").style.display = "none"
//     document.querySelector('#MultiplaEscolha').style.display = "none"
//     document.querySelector('#RedirecionamentoInputsSections').style.display = "flex"
//     document.querySelector("#TextareaSelect").style.display = "none"
//   }

//   if (element.target.value == "2") {
//     document.querySelector("#FinalizarAtendimentoSelect").style.display = "Flex"
//     document.querySelector("#TextareaSelect").style.display = "Flex"
//     document.querySelector('#DepartamentoSelect').style.display = "none"
//     document.querySelector('#RedirecionamentoInputsSections').style.display = "none"
//   }

//   if (element.target.value == "3") {
//     document.querySelector('#MultiplaEscolha').style.display = "Flex"
//     document.querySelector('#DepartamentoSelect').style.display = "none"
//     document.querySelector("#FinalizarAtendimentoSelect").style.display = "none"
//     document.querySelector('#RedirecionamentoInputsSections').style.display = "none"
//     document.querySelector("#TextareaSelect").style.display = "none"
//   }

// });

const setMenId = (menId) => {
  localStorage.setItem("MenId", menId)
}

// Funções para simular o backend enquanto não integra com a página principal
const getMenuPorId = (codigo) => data.filter(x => x.codigo == codigo)[0];
const getMenuPorTipo = (Tipo) => data.filter(x => x.tipo == Tipo)[0];

// Função para gerar o HTML dos menus em cascata
const gerarMenuHtml = (menu, nivel = 0) => {
  MenuCounter = MenuCounter + 20
  let marginClass = `marginClasses-${nivel}`;
  let menuHtml = `
        <div class="col-12 p-0 mt-4 ${marginClass}">
            <div class="bg-light p-4 rounded-0 border border-dark border-2 menu" id="Menu${menu.codigo}">
                <strong class="h6 text-dark">${menu.titulo}</strong>
                <div class="dropdown">
                    <button class="btn text-dark border-0" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
                        <svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-arrow-right-circle" viewBox="0 0 16 16">
                            <path fill-rule="evenodd" d="M1 8a7 7 0 1 0 14 0A7 7 0 0 0 1 8m15 0A8 8 0 1 1 0 8a8 8 0 0 1 16 0M4.5 7.5a.5.5 0 0 0 0 1h5.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5z"/>
                        </svg>
                    </button>
                    <ul class="dropdown-menu dropdown-menu-start dropdownMargin" aria-labelledby="dropdownMenuButton">
                        <li><a data-bs-toggle="modal" data-bs-target="#exampleModal" onclick="setMenId(${menu.codigo})" class="dropdown-item" href="#">Adicionar Opção</a></li>
                        <li><a class="dropdown-item" href="#">Atualizar Opção</a></li>
                        <li><a data-bs-toggle="modal" data-bs-target="#exampleModal2" class="dropdown-item border-top-5 border-dark" href="#">Excluir</a></li>
                    </ul>
                </div>
            </div>
        </div>
    `;

  menu.options.forEach((option) => {
    optionsCounter = optionsCounter + 10
    //<strong class="h6 text-dark">sou uma option de ${menu.titulo} | ${option.titulo}</strong>
    var optionNivel = nivel + 1;
    let optionMarginClass = `marginClasses-${optionNivel}`;

    let TipoACriacao = ``
    if (option.tipo == "MensagemDeRespostaInterativa" || option.tipo == "MensagemPorIA") {
      TipoACriacao = `<li><a data-bs-toggle="modal" data-bs-target="#exampleModal" onclick="setMenId(${option.resposta})" class="dropdown-item" href="#">Adicionar Opção</a></li>`
    }
    else {
      TipoACriacao = `<li><a data-bs-toggle="modal" data-bs-target="#exampleModal" onclick="setMenId(${option.codigoMenu})" class="dropdown-item" href="#">Adicionar Opção</a></li>`
    }


    menuHtml += `
        <div class="col-12 p-0 mt-4 ${optionMarginClass}">
            <div class="bg-light p-4 rounded-0 border border-dark border-2 menu" id="option${option.codigo}">
                
                <strong class="h6 text-dark">${option.titulo}</strong>
                <div class="dropdown">
                    <button class="btn text-dark border-0" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
                        <svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-arrow-right-circle" viewBox="0 0 16 16">
                            <path fill-rule="evenodd" d="M1 8a7 7 0 1 0 14 0A7 7 0 0 0 1 8m15 0A8 8 0 1 1 0 8a8 8 0 0 1 16 0M4.5 7.5a.5.5 0 0 0 0 1h5.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5z"/>
                        </svg>
                    </button>
                    <ul class="dropdown-menu dropdown-menu-start dropdownMargin" aria-labelledby="dropdownMenuButton">
                        ${TipoACriacao}
                        <li><a class="dropdown-item" href="#">Atualizar Opção</a></li>
                        <li><a data-bs-toggle="modal" data-bs-target="#exampleModal2" class="dropdown-item border-top-5 border-dark" href="#">Excluir</a></li>
                    </ul>
                </div>
            </div>
        </div>
        `;

    // Se a opção tiver um submenu, gera o HTML recursivamente
    if (option.tipo == "MensagemDeRespostaInterativa" || option.tipo == "MensagemPorIA") {
      const subMenu = getMenuPorId(parseInt(option.resposta));
      if (subMenu) {
        menuHtml += gerarMenuHtml(subMenu, optionNivel + 1);
      }
    }
  });

  return menuHtml;
};
 
export const resetarAndStartPlumbJS = () => {
  jsPlumb.deleteEveryConnection();
  jsPlumb.deleteEveryEndpoint();
  jsPlumb.reset();
  data.forEach(element => {
    conectarMenus(element);
  });
  jsPlumb.repaintEverything();
};


const conectarMenus = (menu) => {
  menu.options.forEach(option => {

    jsPlumb.connect({
      source: `Menu${option.codigoMenu}`,
      target: `option${option.codigo}`,
      anchors: ["BottomLeft", "Left"],
      connector: ["Flowchart"],
      paintStyle: { stroke: "#000", strokeWidth: 2 },
      endpoint: "Blank",
      overlays: [
        ["Arrow", { width: 1, length: 1, location: 1 }]
      ]
    });

    if (loopsCount == 0) {
      jsPlumb.connect({
        source: `CreateMenu`,
        target: `Menu${getMenuPorTipo("PrimeiraMensagem").codigo}`.trim(),
        anchors: ["BottomLeft", "Left"],
        connector: ["Flowchart"],
        paintStyle: { stroke: "#000", strokeWidth: 2 },
        endpoint: "Blank",
        overlays: [
          ["Arrow", { width: 1, length: 1, location: 1 }]
        ]
      });
      loopsCount = loopsCount + 1
    }

    if (option.tipo == "MensagemDeRespostaInterativa" || option.tipo == "MensagemPorIA") {
      jsPlumb.connect({
        source: `option${option.codigo}`,
        target: `Menu${option.resposta}`,
        anchors: ["BottomLeft", "Left"],
        connector: ["Flowchart"],
        paintStyle: { stroke: "#000", strokeWidth: 2 },
        endpoint: "Blank",
        overlays: [
          ["Arrow", { width: 1, length: 1, location: 1 }]
        ]
      });
    }

  });
};

export const Iniciar = () => {
  console.log("Carregou")
  jsPlumb.deleteEveryConnection();
  jsPlumb.repaintEverything();
  const MenuInicial = getMenuPorTipo("PrimeiraMensagem");
  const menuHtml = gerarMenuHtml(MenuInicial);
  document.querySelector("#LinhaMenuPrincipal").innerHTML = `<div class="col-12 p-0">
            <button class="btn buttonAdicionarFromHome" id="CreateMenu"><strong>Adicionar Menu</strong></button>
        </div>
        ` + menuHtml;
  resetarAndStartPlumbJS()
}

// jsPlumb.ready(function () {
//   Iniciar()
// });

 export const AdicionarEmDados = () => {
  var selectValue = document.querySelector("#SelectTipo").value
  //Lembrar que como os id e 1,1 ele vao se preencher suave nao precisa ficar com dor de cabeca sobre isso

  if (selectValue == "1") {
    const newOption = {
      "codigo": optionsCounter,
      "codigoMenu": parseInt(localStorage.getItem("MenId")),
      "titulo": document.querySelector("#TituloOpcaoMenuInputRedirecionamento").value,
      "descricao": document.querySelector("#DescricaoMenuInputRedirecionamento").value,
      "resposta": document.querySelector("#selectDepartamento").id,
      "tipo": "RedirecinamentoHumano",
      "finalizar": document.querySelector("#FinalizarChecked").checked
    }

    getMenuPorId(parseInt(localStorage.getItem("MenId"))).options.push(newOption)
    Iniciar()
  }

  if (selectValue == "2") {
    const newOption = {
      "codigo": optionsCounter,
      "codigoMenu": parseInt(localStorage.getItem("MenId")),
      "titulo": document.querySelector("#TituloSimplesInput").value,
      "descricao": document.querySelector("#DescricaoSimplesInput").value,
      "resposta": document.querySelector("#textAreaContent").value,
      "tipo": "MensagemDeResposta",
      "finalizar": document.querySelector("#FinalizarChecked").checked
    }
    Iniciar()
  }

  if (selectValue == "3") {

    const NewMenu = {
      "codigo": MenuCounter,
      "titulo": document.querySelector("#TituloMenuInput").value,
      "header": document.querySelector("#cabecalhoMenuInput").value,
      "body": document.querySelector("#corpoMenuInput").value,
      "footer": document.querySelector("#rodapeMenuInput").value,
      "tipo": "MenuBot",
      "login": {
        "codigo": 1,
        "codigoWhatsap": "557999411293",
        "usuario": "Master",
        "email": "master.123@123",
        "senha": "c2VuYWkuMTIz",
        "imagem": "img-placeholder",
        "plano": "master"
      },
      "options": []
    }

    const newOption = {
      "codigo": optionsCounter,
      "codigoMenu": parseInt(localStorage.getItem("MenId")),
      "titulo": document.querySelector("#TituloOpcaoMenuInput").value,
      "descricao": document.querySelector("#DescricaoMenuInput").value,
      "resposta": NewMenu.codigo.toString(),
      "tipo": "MensagemDeRespostaInterativa",
      "finalizar": document.querySelector("#FinalizarChecked").checked
    }

    data.push(NewMenu)
    getMenuPorId(localStorage.getItem("MenId")).options.push(newOption)
    Iniciar()
  }

}

