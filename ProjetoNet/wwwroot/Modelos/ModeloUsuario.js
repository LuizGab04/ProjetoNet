export class Usuario {
    id_usuario
    nome_usuario
    email_usuario

    static appUrl = "http://localhost:5176/api/usuarios"

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

            if (!response.ok) {
                throw new Error(`Erro na requisição: ${response.status}`);
            }

            let data = await response.json().catch(() => null);
            return data || { mensagem: "Nenhum conteúdo retornado" };
        } catch (error) {
            console.error("Erro ao ir para o back usuário:", error);
            alert("Erro ao cadastrar usuário!");
        }
    }
}