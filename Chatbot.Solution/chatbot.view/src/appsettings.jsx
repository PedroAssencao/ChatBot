export const urlBase = "http://localhost:5058/api"
export const AtendenteLogado = () => {
    fetch(urlBase+'/v1/Login/login/GetClaimsInfo', {
        credentials: 'include'
    });
}
export const UsuarioLogadoId = 1 
