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

    static async mostrarCards(id_sprint) {
        const resposta = await fetch(`${this.appUrl}/${id_sprint}`); // ou seu endpoint
        const cards = await resposta.json();

        if (cards.length === 0) {
            console.log('Nao há cards')
            return
        }

        for (let cont = 0; cont < 5; cont++) {
            const sprintContainer = document.querySelector(`#sprint-${cards[0].sprint_responsavel} .kanban-column[column-index="${cont}"] .kanban-items-container`);

            if (sprintContainer) {
                const array = cards.filter(x => x.coluna_responsavel === cont)
                const htmlCards = array.map(card => {
                    return `<div class="kanban-item sortable-item-wrapper">
                    <div class="card sortable-item kanban-item-card hover-actions-trigger">
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
                                ${card.nome_card}
                            </p>
                        </div>
                    </div>
                </div>`
                }).join('')

                sprintContainer.innerHTML = htmlCards
            }
            else console.warn(`Sprint ${card.sprint_responsavel} não encontrada no DOM.`);
        }

    }
}