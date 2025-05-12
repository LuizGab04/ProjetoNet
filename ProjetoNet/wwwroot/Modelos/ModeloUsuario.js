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

        const data = await response.json();
        const base64 = data.fotoBytes;

        localStorage.setItem("foto_perfil", base64)
    }

    static async pegarFoto() {
        const token = localStorage.getItem("token");

        const response = await fetch(`${this.appUrl}/fotoPerfil`, {
            method: "GET",
            headers: {
                "Authorization": `Bearer ${token}`
            }
        });
 
        if (response.status === 204) {
            document.getElementById("fotoUsuario").innerHTML = `
            <img class="rounded-circle" src="assets/img/team/avatar.png" />
        `;
            return;
        }

        if (!response.ok) {
            console.error("Erro ao buscar a foto:", response.status);
            return;
        }

        const data = await response.json();
        const base64 = data.fotoBytes;

        localStorage.setItem("foto_perfil", base64);

        document.getElementById("fotoUsuario").innerHTML = `
        <img class="rounded-circle" src="data:image/jpeg;base64,${base64}" />
    `;
    }
}



