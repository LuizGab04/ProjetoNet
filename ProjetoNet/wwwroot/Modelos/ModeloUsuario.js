export class Usuario {
    nome_usuario
    email_usuario
    senha_usuario


    static appUrl = "http://localhost:5176/api/usuario"

    static async cadastrarUsuario(usuario) {
        let response = await fetch(`${this.appUrl}/criar`, {
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

        return response.json();
    }

    static async loginUsuario(usuario) {
        let response = await fetch(`${this.appUrl}/login`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(usuario),
        });
        return response.json();
    }
}