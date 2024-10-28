import { urlBase, UsuarioLogado } from "../../appsettings"
import { dataMock } from "./MockDatesForTestFluxoBot"
var optionsCounter = 0
var MenuCounter = 0
var loopsCount = 0
let data = []

export const fetchNewDatas = async () => {
  try {
    var UsuarioLogadoId = await UsuarioLogado()
    console.log(UsuarioLogadoId)
    const response = await fetch(`${urlBase}/v1/Menus/Menus/GetAllMenusByLogId/${UsuarioLogadoId.usuarioLogadoId}`);
    const responseJson = await response.json();
    console.log(responseJson)
    data = responseJson;
    if (data.length > 0) {
      return true; 
    }else{
      return false
    }
  } catch (error) {
    console.error(error);
    //deixar isso aqui apenas no ambiente de teste 
    //data = dataMock;    
    return false;
  }
}

const AdicionarNovaOpcao = async (element) => {
  try {
    const response = await fetch(`${urlBase}/v1/Option/Option/Create`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(element),
    });

    if (!response.ok) {
      throw new Error(`Erro na requisição: ${response.status}`);
    }

    const Model = await response.json();
    return Model
  } catch (error) {
    console.error('Erro ao adicionar nova opção:', error);
    return false
  }
};

const AdicionarNovoMenu = async (element) => {
  try {
    const response = await fetch(`${urlBase}/v1/Menus/Menus/Create`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(element),
    });

    if (!response.ok) {
      throw new Error(`Erro na requisição: ${response.status}`);
    }

    const Model = await response.json();
    return Model
  } catch (error) {
    console.error('Erro ao adicionar nova opção:', error);
    return false
  }
}

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
                        <li>
                          <a data-bs-toggle="modal" data-bs-target="#exampleModal" 
                            onclick="localStorage.setItem('MenId', ${menu.codigo})" 
                            class="dropdown-item" href="#">
                            Adicionar Opção
                          </a>
                        </li>
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

    if (option.tipo == 3 || option.tipo == 4) {
      TipoACriacao = `
        <li>
          <a data-bs-toggle="modal" data-bs-target="#exampleModal" 
            onclick="localStorage.setItem('MenId', ${option.codigoMenu})" 
            class="dropdown-item" href="#">
            Adicionar Opção Ao Menu: ${getMenuPorId(option.codigoMenu).titulo}
          </a>
        </li>`
    }
    else {
      TipoACriacao = `
        <li>
          <a data-bs-toggle="modal" data-bs-target="#exampleModal" 
            onclick="localStorage.setItem('MenId', ${option.resposta})" 
            class="dropdown-item" href="#">
            Adicionar Opção Como Resposta
          </a>
        </li>`
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
    if (option.tipo == 3 || option.tipo == 4) {
      const subMenu = getMenuPorId(parseInt(option.resposta));
      if (subMenu) {
        menuHtml += gerarMenuHtml(subMenu, optionNivel + 1);
      }
    }
  });

  return menuHtml;
};

export const resetarAndStartPlumbJS = () => {
  //esse esquema com console.log so serve para desativar as mensagens que o plumbjs fica setando
  const originalLog = console.log;
  console.log = function () { };
  jsPlumb.deleteEveryConnection();
  jsPlumb.deleteEveryEndpoint();
  jsPlumb.reset();
  data.forEach(element => {
    conectarMenus(element);
  });
  jsPlumb.repaintEverything();
  console.log = originalLog;
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
        ["Arrow", { width: 10, length: 10, location: 1 }]
      ]
    });

    // if (loopsCount == 0) {
    jsPlumb.connect({
      source: `CreateMenu`,
      target: `Menu${getMenuPorTipo(1).codigo}`.trim(),
      anchors: ["BottomLeft", "Left"],
      connector: ["Flowchart"],
      paintStyle: { stroke: "#000", strokeWidth: 2 },
      endpoint: "Blank",
      overlays: [
        ["Arrow", { width: 10, length: 10, location: 1 }]
      ]
    });
    // loopsCount = loopsCount + 1
    // }

    if (option.tipo == 3 || option.tipo == 4) {
      jsPlumb.connect({
        source: `option${option.codigo}`,
        target: `Menu${option.resposta}`,
        anchors: ["BottomLeft", "Left"],
        connector: ["Flowchart"],
        paintStyle: { stroke: "#000", strokeWidth: 2 },
        endpoint: "Blank",
        overlays: [
          ["Arrow", { width: 10, length: 10, location: 1 }]
        ]
      });
    }

  });
};

export const Iniciar = () => {
  jsPlumb.deleteEveryConnection();
  jsPlumb.repaintEverything();
  const MenuInicial = getMenuPorTipo(1);
  const menuHtml = gerarMenuHtml(MenuInicial);
  document.querySelector("#LinhaMenuPrincipal").innerHTML = `<div class="col-12 p-0">
            <button class="btn buttonAdicionarFromHome btnHoverClass" data-bs-toggle="modal" data-bs-target="#exampleModal" onclick="localStorage.setItem('MenId', ${getMenuPorTipo(1).codigo})" id="CreateMenu"><strong>Adicionar Menu</strong></button>
        </div>
        ` + menuHtml;
  resetarAndStartPlumbJS()
}

// jsPlumb.ready(function () {
//   Iniciar()
// });

export const AdicionarEmDados = async (e) => {
  console.log(e)
  e.target.disabled = true
  e.target.innerHtml = "Loading..."
  var selectValue = document.querySelector("#SelectTipo").value
  //Lembrar que como os id e 1,1 ele vao se preencher suave nao precisa ficar com dor de cabeca sobre isso
  // Ajustando o horário para o fuso horário de Brasília (UTC-3)
  const now = new Date();
  const HorarioDeBrasilia = new Date(now.setHours(now.getUTCHours() - 3))

  if (selectValue == "1") {

    var UsuarioLogadoIdResult = await UsuarioLogado()
    var UsuarioLogadoId = parseInt(UsuarioLogadoIdResult.usuarioLogadoId)
    console.log("Id Usuario logado")
    console.log(UsuarioLogadoId)
    //esquema para deixar fixo para teste 

    // const newOption = {
    //   "codigo": optionsCounter,
    //   "codigoMenu": parseInt(localStorage.getItem("MenId")),
    //   "titulo": document.querySelector("#TituloOpcaoMenuInputRedirecionamento").value,
    //   "descricao": document.querySelector("#DescricaoMenuInputRedirecionamento").value,
    //   "resposta": document.querySelector("#selectDepartamento").id,
    //   "tipo": 6,
    //   "finalizar": document.querySelector("#FinalizarChecked").checked
    // }

    const newOption = {
      "CodigoLogin": UsuarioLogadoId,
      "codigoMenu": parseInt(localStorage.getItem("MenId")),
      "titulo": document.querySelector("#TituloOpcaoMenuInputRedirecionamento").value,
      "data": HorarioDeBrasilia,
      "descricao": document.querySelector("#DescricaoMenuInputRedirecionamento").value,
      "resposta": document.querySelector("#selectDepartamento").options[document.querySelector("#selectDepartamento").selectedIndex].id,
      "tipo": 6,
      "finalizar": document.querySelector("#FinalizarChecked").checked
    }

    let optionResponse = await AdicionarNovaOpcao(newOption)

    if (optionResponse) {
      getMenuPorId(parseInt(localStorage.getItem("MenId"))).options.push(newOption)
      Iniciar()
    }

  }

  if (selectValue == "2") {

    // const newOption = {
    //   "codigo": optionsCounter,
    //   "codigoMenu": parseInt(localStorage.getItem("MenId")),
    //   "titulo": document.querySelector("#TituloSimplesInput").value,
    //   "descricao": document.querySelector("#DescricaoSimplesInput").value,
    //   "resposta": document.querySelector("#textAreaContent").value,
    //   "tipo": 1,
    //   "finalizar": document.querySelector("#FinalizarChecked").checked
    // }

    const newOption = {
      "CodigoLogin": UsuarioLogadoId,
      "codigoMenu": parseInt(localStorage.getItem("MenId")),
      "titulo": document.querySelector("#TituloSimplesInput").value,
      "data": HorarioDeBrasilia,
      "descricao": document.querySelector("#DescricaoSimplesInput").value,
      "resposta": document.querySelector("#textAreaContent").value,
      "tipo": 1,
      "finalizar": document.querySelector("#FinalizarChecked").checked
    }

    let optionResponse = await AdicionarNovaOpcao(newOption)

    if (optionResponse) {
      getMenuPorId(parseInt(localStorage.getItem("MenId"))).options.push(newOption)
      Iniciar()
    }

    return
  }

  if (selectValue == "3") {

    // const NewMenu = {
    //   "codigo": MenuCounter,
    //   "titulo": document.querySelector("#TituloMenuInput").value,
    //   "header": document.querySelector("#cabecalhoMenuInput").value,
    //   "body": document.querySelector("#corpoMenuInput").value,
    //   "footer": document.querySelector("#rodapeMenuInput").value,
    //   "tipo": 2,
    //   "CodigoLogin": UsuarioLogadoId,
    //   "options": []
    // }

    const NewMenu = {
      "titulo": document.querySelector("#TituloMenuInput").value,
      "header": document.querySelector("#cabecalhoMenuInput").value,
      "body": document.querySelector("#corpoMenuInput").value,
      "footer": document.querySelector("#rodapeMenuInput").value,
      "tipo": 2,
      "CodigoLogin": UsuarioLogadoId,
      "options": []
    }

    // const newOption = {
    //   "codigo": optionsCounter,
    //   "CodigoLogin": UsuarioLogadoId,
    //   "codigoMenu": parseInt(localStorage.getItem("MenId")),
    //   "data": HorarioDeBrasilia,
    //   "titulo": document.querySelector("#TituloOpcaoMenuInput").value,
    //   "descricao": document.querySelector("#DescricaoMenuInput").value,
    //   "resposta": NewMenu.codigo.toString(),
    //   "tipo": 3,
    //   "finalizar": document.querySelector("#FinalizarChecked").checked
    // }

    let MenuResponse = await AdicionarNovoMenu(NewMenu)

    const newOption = {
      "CodigoLogin": UsuarioLogadoId,
      "codigoMenu": parseInt(localStorage.getItem("MenId")),
      "data": HorarioDeBrasilia,
      "titulo": document.querySelector("#TituloOpcaoMenuInput").value,
      "descricao": document.querySelector("#DescricaoMenuInput").value,
      "resposta": MenuResponse.codigo.toString(),
      "tipo": 3,
      "finalizar": document.querySelector("#FinalizarChecked").checked
    }

    if (MenuResponse) {
      let optionResponse = await AdicionarNovaOpcao(newOption)

      if (optionResponse) {
        data.push(MenuResponse)
        getMenuPorId(localStorage.getItem("MenId")).options.push(optionResponse)
        Iniciar()
      }

    }

    e.target.disabled = false
    e.target.innerHtml = "Salvar"
  }

}

