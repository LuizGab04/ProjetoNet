export class Sprint {
    nome_sprint
    id_sprint
   

    static appUrl = "http://localhost:5176/api/sprint"

    static async cadastrarSprint(sprint) {
        let response = await fetch(`${this.appUrl}/criar`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(sprint),
        });

        return response.json();
    }

    //FUNÇÃO PARA CARREGAR AS SPRINTS NO HTML
    static async carregarSprint(sprint) {
        const container = document.getElementById("kanbanGridContainer"); // onde o HTML será injetado
        container.innerHTML += `
        <div id="sprint-${sprint.id_sprint}" class="kanban-container borderSprint scrollbar me-n3 pt-4" data-id="${sprint.id_sprint}">
            <div class="px-3 d-flex">
                <div id="nomeSprintCadastrada">
                    <p>${sprint.nome_sprint}</p>
                </div>
                <div class="dropdown font-sans-serif btn-reveal-trigger">
                    <button class="btn btn-sm btn-reveal py-0 px-2" type="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <a<i class="bi bi-three-dots-vertical"></i></a>
                    </button>
                    <div class="dropdown-menu dropdown-menu-end py-0">
                        <button id="excluirSprint" class="dropdown-item text-danger btnRemoverSprint">Remove</button>
                    </div>
                </div>
            </div>
            ${this.criarColuna("Backlog do Produto")}
            ${this.criarColuna("Fazendo")}
            ${this.criarColuna("Esperando Teste")}
            ${this.criarColuna("Em Teste")}
            ${this.criarColuna("Concluído")}
        </div>
    `;
    }
    static criarColuna(titulo) {
        return `
        <div class="kanban-column">
            <div class="kanban-column-header">
                <h5 class="fs-0 mb-0">${titulo} <span class="text-500">(0)</span></h5>
            </div>
            <div id="kanbanItemContainer" class="kanban-items-container scrollbar" tabindex="">
                <form class="add-card-form mt-3">
                    <textarea class="form-control input-nome-card" rows="2" placeholder="Insira um nome do Card"></textarea>
                    <div class="row gx-2 mt-2">
                        <div class="col">
                            <button class="btn btn-primary btn-sm d-block w-100 btCadastrarCard" type="button">Adicionar</button>
                        </div>
                        <div class="col">
                            <button class="btn btn-outline-secondary btn-sm d-block w-100 border-400" type="button" data-btn-form="hide">Cancelar</button>
                        </div>
                    </div>
                </form>
            </div>
            <div class="kanban-column-footer">
                <button class="btn btn-link btn-sm d-block w-100 btn-add-card text-decoration-none text-600" type="button">
                    <span class="fas fa-plus me-2"></span>Add another card
                </button>
            </div>
        </div>
    `;
    }

    static async carregarTodasAsSprints() {
        const response = await fetch("http://localhost:5176/api/sprint/mostrarSprints"); // endpoint que retorna TODAS as sprints
        const sprints = await response.json();

        for (const sprint of sprints) {
        await Sprint.carregarSprint(sprint);
    }

    return sprints;

    }

    static async excluirSprint(idSprint) {
        const token = localStorage.getItem("token");

        const response = await fetch(`${this.appUrl}/${idSprint}`, {
            method: "DELETE",
            headers: {
                "Authorization": `Bearer ${token}`
            }
        });

        return response
        console.log(response);
    }
}