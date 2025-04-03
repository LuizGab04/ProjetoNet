export class Usuario {
    nome_usuario
    email_usuario
    senha_usuario


    static appUrl = "http://localhost:5176/api/controller"

    static async listarUsuarios() {
        let response = await fetch(this.appUrl);
        return response.json();
    }

    static async buscarUsuario(id) {
        let response = await fetch(`${this.appUrl}/${id}`);
        return response.json();
    }
    static async cadastrarUsuario(usuario) {
        try {
            let response = await fetch(this.appUrl, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(usuario),
            });

            let data = await response.json().catch(() => null);
            return data || { mensagem: "Nenhum conteúdo retornado" };
        } catch (error) {
            Swal.fire({
                icon: "error",
                title: "Oops...",
                text: "Something went wrong!",
                footer: '<a href="#">Why do I have this issue?</a>'
            });
        }
    }
    static async validacaoEmail(usuario) {
        let response = await fetch(this.appUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(usuario),
        });
        return response.json();
    }
}