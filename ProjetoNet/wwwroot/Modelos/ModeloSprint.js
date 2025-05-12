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

    static carregarSprint(sprint) {
        const container = document.getElementById("kanbanGridContainer"); // onde o HTML será injetado

        container.innerHTML += `
        <div class="kanban-container scrollbar me-n3">
            <div id="nomeSprintCadastrada">
                <p>${sprint.nome_sprint}</p>
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
                <h5 class="fs-0 mb-0">${titulo} <span class="text-500" style="background-color: red">Adicionar NUMERO de cards</span></h5>
                <div class="dropdown font-sans-serif btn-reveal-trigger">
                    <button class="btn btn-sm btn-reveal py-0 px-2" type="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="fas fa-ellipsis-h"></span>
                    </button>
                    <div class="dropdown-menu dropdown-menu-end py-0">
                        <a class="dropdown-item" href="#!">Add Card</a>
                        <a class="dropdown-item" href="#!">Edit</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item text-danger" href="#!">Remove</a>
                    </div>
                </div>
            </div>
            <div class="kanban-items-container scrollbar">
                <form class="add-card-form mt-3">
                    <textarea class="form-control" data-input="add-card" rows="2" placeholder="Enter a title for this card..."></textarea>
                    <div class="row gx-2 mt-2">
                        <div class="col">
                            <button class="btn btn-primary btn-sm d-block w-100" type="button">Add</button>
                        </div>
                        <div class="col">
                            <button class="btn btn-outline-secondary btn-sm d-block w-100 border-400" type="button" data-btn-form="hide">Cancel</button>
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

        sprints.forEach(sprint => {
            Sprint.carregarSprint(sprint); // carrega cada uma individualmente
        });

    }
}