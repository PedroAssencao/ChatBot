import { useEffect } from 'react'
import Image from './DazzleBot.png'
import './style.css'
import { urlBase } from '../../appsettings'

export default function Registro() {

    //function para tirar a mensagem de error quando o input e acionado
    const hideError = () => {

        document.getElementById('errorLogin').style.display = 'none';
        document.getElementById('errorCadastro').style.display = 'none';
        document.getElementById('errorCadastroSenha').style.display = 'none';

    }

    useEffect(() => {

        var inputSenhaCadastro = document.getElementById("inputSenhaCadastrar")

        //function para enviar dados para efeturar login
        document.getElementById('buttonEntrar').addEventListener('click', async () => {
            const url = "http://localhost:5058/api/v1/Login/login/logar";
        
            // Captura os valores dos inputs
            const email = document.getElementById('inputEmailLogar').value;
            const senha = document.getElementById('inputSenhaLogar').value;

            // Dados a serem enviados no corpo da requisição
            const data = {
                Email: email,
                Senha: senha,
            };
        
            // Configurações da requisição
            const options = {
                method: 'POST', // Método HTTP POST
                headers: {
                    'Content-Type': 'application/json', // Tipo de conteúdo JSON
                },
                body: JSON.stringify(data), // Converte o objeto JavaScript em JSON
            };
        
            try {
                // Faz a requisição e aguarda a resposta
                const response = await fetch(url, options);
                if (response.ok) {
                    // Redireciona para a página desejada
                    location.replace(location.origin);
                } else {
                    // Exibe a mensagem de erro no front-end
                    document.getElementById('errorLogin').style.display = "block";
                }
            } catch (error) {
                console.error('Ocorreu um erro:', error);
            }
        });
        


        //function para enviar dados para cadastro
        document.getElementById('buttonCadastrar').addEventListener('click', () => {
            if (inputSenhaCadastro.value.length > 6) {
                const url = urlBase + '/v1/login/Cadastrar';

                // Dados a serem enviados no corpo da requisição
                const data = {
                    logUser: document.getElementById('inputNomeCadastrar').value,
                    logEmail: document.getElementById('inputEmailCadastrar').value,
                    logSenha: document.getElementById('inputSenhaCadastrar').value,
                };

                // Configurações da requisição
                const options = {
                    method: 'POST', // Método HTTP POST
                    headers: {
                        'Content-Type': 'application/json' // Tipo de conteúdo JSON
                    },
                    credentials: 'include',
                    body: JSON.stringify(data) // Converte o objeto JavaScript em JSON
                };

                // Realiza a requisição usando fetch
                fetch(url, options)
                    .then(response => {
                        if (response.ok) {
                            location.replace(location.origin) //Redireciona Para a Tela Desejada
                        } else {
                            document.getElementById('errorCadastro').style.display = "block"
                            throw new Error('Erro ao enviar os dados.'); // Lança um erro se a requisição falhar
                        }

                    })
                    // .then(data => {
                    //     console.log('Resposta do servidor:', data);
                    //     location.reload()

                    // })
                    .catch(error => {
                        console.error('Ocorreu um erro:', error);

                    });
            }
            else {
                document.getElementById('errorCadastroSenha').style.display = 'block';
            }

        })

        // Coloque todo o seu código JavaScript dentro desta função de efeito
        var btnSignin = document.querySelector("#signin");
        var btnSignup = document.querySelector("#signup");
        var body = document.querySelector("body");

        btnSignin.addEventListener("click", function () {
            body.className = "sign-in-js";
        });

        btnSignup.addEventListener("click", function () {
            body.className = "sign-up-js";
        });

        // Retorne uma função de limpeza para remover os event listeners quando o componente for desmontado
        return () => {
            btnSignin.removeEventListener("click", () => {
                body.className = "sign-in-js";
            });
            btnSignup.removeEventListener("click", () => {
                body.className = "sign-up-js";
            });
        };
    }, []); // O segundo argumento vazio [] garante que este efeito seja executado apenas uma vez após a montagem do componente

    return (
        <>
            <div className="container container-fluid">
                <div className="content first-content">
                    <div className="first-column">
                        <h2 className="title title-primary">Seja bem vindo!</h2>
                        <p className="description description-primary">pra continuar conectado</p>
                        <p className="description description-primary">realizar login com informações pessoais</p>
                        <button id="signin" className="btnFromLogin btn-primaryFromLogin">sign in</button>
                    </div>
                    <div className="second-column">
                        <img className="imagem" src={Image} />
                        <h2 className="title title-second">criar conta</h2>
                        <p className="description description-second">ou usar email para entrar:</p>
                        <div className="form" >


                            <p id="errorCadastro" style={{ display: 'none', color: 'red' }}>Usuario ou Email Repetido Verifique e Tente Criar Novamente</p>

                            <p id="errorCadastroSenha" style={{ display: 'none', color: 'red' }}>Senha Menor do que 8 Caracteres</p>

                            <label className="label-input">
                                <i className="far fa-user icon-modify"></i>
                                <input id="inputNomeCadastrar" onKeyDown={hideError} type="text" placeholder="Nome" />
                            </label>

                            <label className="label-input">
                                <i className="far fa-envelope icon-modify"></i>
                                <input id="inputEmailCadastrar" onKeyDown={hideError} type="email" placeholder="Email" />
                            </label>

                            <label className="label-input">
                                <i className="fas fa-lock icon-modify"></i>
                                <input id="inputSenhaCadastrar" onKeyDown={hideError} type="password" minLength={"8"} placeholder="Senha" />
                            </label>


                            <button id="buttonCadastrar" className="btnFromLogin btn-second">entrar</button>

                        </div>
                    </div>
                </div>
                <div className="content second-content">
                    <div className="first-column">
                        <h2 className="title title-primary">ola, amigo!</h2>
                        <p className="description description-primary">coloque detalhes pessoais</p>
                        <p className="description description-primary">comece uma jornada com nós</p>
                        <button id="signup" className="btnFromLogin btn-primaryFromLogin">entrar</button>
                    </div>
                    <div className="second-column">
                        <img className="imagem" src={Image} />
                        <h2 className="title title-second">entrar com o developer</h2>
                        <p className="description description-second">ou use sua conta com email:</p>
                        <div className="form">
                            <p id="errorLogin" style={{ display: 'none', color: 'red' }} >Usuario Não Encontrado Verifique o Usuario ou a Senha</p>
                            <label className="label-input">
                                <i className="far fa-envelope icon-modify"></i>
                                <input id="inputEmailLogar" onKeyDown={hideError} type="email" placeholder="Email" />
                            </label>

                            <label className="label-input">
                                <i className="fas fa-lock icon-modify"></i>
                                <input id="inputSenhaLogar" onKeyDown={hideError} type="password" placeholder="Senha" />
                            </label>

                            <a className="password" href="#">Esqueceu sua senha?</a>
                            <button id="buttonEntrar" className="btnFromLogin btn-second">entrar</button>
                        </div>
                    </div>
                </div>
            </div>
            <script src="./js/logar/app.js">


            </script>

        </>
    )

}