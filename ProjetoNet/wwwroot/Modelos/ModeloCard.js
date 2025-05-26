export class Card {
    id_card
    descricao
    nome_card
    sprint_responsavel

    static appUrl = "http://localhost:5176/api/card"

    static async cadastrarCard(card) {
        const resposta = await fetch(`${this.appUrl}/criarCard`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(card)
        });

        return await resposta.json();
    }

    static cardGrid(card) {
        const sprintContainer = document.querySelector(`#sprint-${card.sprint_responsavel} .kanbanItemContainer`);

        if (!sprintContainer) {
            console.warn(`Sprint ${card.sprint_responsavel} não encontrada no DOM.`);
            return;
        }

        const cardHtml = `
        <div class="kanban-item" tabindex="0">
            <div class="card kanban-item-card hover-actions-trigger">
                <div class="card-body">
                    <div class="position-relative">
                        <div class="dropdown font-sans-serif">
                            <button class="btn btn-sm btn-falcon-default kanban-item-dropdown-btn hover-actions" type="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fas fa-ellipsis-h"></i>
                            </button>
                            <div class="dropdown-menu dropdown-menu-end py-0">
                                <a class="dropdown-item" href="#!">Add Card</a>
                                <a class="dropdown-item" href="#!">Edit</a>
                                <a class="dropdown-item" href="#!">Copy link</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item text-danger" href="#!">Remove</a>
                            </div>
                        </div>
                    </div>
                    <p class="mb-0 fw-medium font-sans-serif stretched-link">
                        👌 ${card.nome_card}
                    </p>
                </div>
            </div>
        </div>
    `;

        sprintContainer.innerHTML += cardHtml;
    }

    static async mostrarCards() {
        const resposta = await fetch("http://localhost:5176/api/card/listarCards"); // ou seu endpoint
        const cards = await resposta.json();

        cards.forEach(card => {
            Card.cardGrid(card);
        });
        
    console.log(card)
    }
}