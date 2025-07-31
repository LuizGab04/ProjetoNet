import { Usuario } from "../Modelos/ModeloUsuario.js"
class funcoesGerais {
   
    static async informacoesUsuario() {
        await Usuario.pegarFoto()
        const nome = localStorage.getItem("nome_usuario")
        document.getElementById("nomeUsuario").innerHTML = `<p class="fw-bold">Ola, ${nome}!</p>`
    }

    static validacaoToken() {
        const token = localStorage.getItem("token");

        if (!token) {
            window.location.href = "login.html";
            return
        }
    }
}

export { funcoesGerais };