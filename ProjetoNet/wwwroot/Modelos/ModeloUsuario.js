export class Usuario {
    nome_usuario
    email_usuario
    senha_usuario


    static appUrl = "http://localhost:5176/api/usuario"

    static async listarUsuarios() {
        let response = await fetch(this.appUrl);
        return response.json();
    }

    static async buscarUsuario(id) {
        let response = await fetch(`${this.appUrl}/${id}`);
        return response.json();
    }
    static async cadastrarUsuario(usuario) {
        let response = await fetch(this.appUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(usuario),
        });

        return response.json();
    }
    static async validacaoEmail(usuario) {
        let response = await fetch(this.appUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(usuario),
        });

        console.log(response)
        return response.json();
    }

    static async loginUsuario(UsuarioLogin) {
        let response = await fetch(this.appUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(UsuarioLogin),
        });

    }
}