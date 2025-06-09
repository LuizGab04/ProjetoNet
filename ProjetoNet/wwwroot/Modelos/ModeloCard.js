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

    static async atualizarCard(card) {
        const resposta = await fetch(`${this.appUrl}/atualizarCard`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(card)
        });

        return await resposta.json();
    }

    static async excluirCard(id_card) {
        const resposta = await fetch(`${this.appUrl}/excluirCard/${id_card}`, {
            method: "DELETE"
        });
        return await resposta.json();
    }

    static async mostrarCards(id_sprint) {
        const resposta = await fetch(`${this.appUrl}/${id_sprint}`);
        const cards = await resposta.json();

        if (!cards || cards.length === 0) {
            console.log(`Não há cards para a sprint ${id_sprint}`);
           
            for (let cont = 0; cont < 5; cont++) {
                const sprintContainer = document.querySelector(
                    `#sprint-${id_sprint} .kanban-column[column-index="${cont}"] .kanban-items-container`
                );
                if (sprintContainer) sprintContainer.innerHTML = "";
            }
            return;
        }

        
        for (let cont = 0; cont < 5; cont++) {
            const sprintContainer = document.querySelector(
                `#sprint-${id_sprint} .kanban-column[column-index="${cont}"] .kanban-items-container`
            );

            if (sprintContainer) {
                // Filtra os cards da coluna atual
                const array = cards.filter(card => card.coluna_responsavel === cont);
                const htmlCards = array.map(card => `
                <div class="kanban-item sortable-item-wrapper">
                    <div class="card sortable-item kanban-item-card hover-actions-trigger">
                        <div class="card-body">
                            <div class="position-relative">
                                <div class="dropdown font-sans-serif">
                                    <button class="btn btn-sm btn-falcon-default kanban-item-dropdown-btn hover-actions" type="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="fas fa-ellipsis-h"></i>
                                    </button>
                                    <div class="dropdown-menu dropdown-menu-end py-0">
                                        <a class="dropdown-item text-danger" href="#!">Excluir</a>
                                    </div>
                                </div>
                            </div>
                            <p class="mb-0 fw-medium font-sans-serif stretched-link">
                                ${card.nome_card}
                            </p>
                        </div>
                    </div>
                </div>
            `).join('');

                // Atualiza a coluna da sprint com os cards
                sprintContainer.innerHTML = "";
                sprintContainer.insertAdjacentHTML("beforeend", htmlCards);
            } else {
                console.warn(`Sprint ${id_sprint} não encontrada no DOM.`);
            }
        }
    }
}