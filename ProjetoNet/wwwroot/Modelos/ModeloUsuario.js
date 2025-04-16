export class Usuario {
    nome_usuario
    email_usuario
    senha_usuario
    foto_perfil

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
        let response = await fetch(`${this.appUrl}/criar`, {
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


        return response.json()
        console.log("Token criado", response);
    }

    static async uploadFoto(formData) {
        const token = localStorage.getItem("token");

        const response = await fetch(`${this.appUrl}/foto`, {
            method: "POST",
            headers: {
                "Authorization": `Bearer ${token}`
            },
            body: formData
        });

        const resultado = await response.json();
        console.log("Resposta da API:", resultado);
    }
}

    

