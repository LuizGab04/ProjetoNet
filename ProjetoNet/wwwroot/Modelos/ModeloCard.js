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
        const gridLoad = document.getElementById("kanbanItemContainer")
        gridLoad.innerHTML = `<div class="kanban-item" tabindex="0">
                  <div class="card kanban-item-card hover-actions-trigger">
                    <div class="card-body">
                      <div class="position-relative">
                        <div class="dropdown font-sans-serif">
                          <button class="btn btn-sm btn-falcon-default kanban-item-dropdown-btn hover-actions" type="button" data-boundary="viewport" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><svg class="svg-inline--fa fa-ellipsis-h fa-w-16" data-fa-transform="shrink-2" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="ellipsis-h" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg="" style="transform-origin: 0.5em 0.5em;"><g transform="translate(256 256)"><g transform="translate(0, 0)  scale(0.875, 0.875)  rotate(0 0 0)"><path fill="currentColor" d="M328 256c0 39.8-32.2 72-72 72s-72-32.2-72-72 32.2-72 72-72 72 32.2 72 72zm104-72c-39.8 0-72 32.2-72 72s32.2 72 72 72 72-32.2 72-72-32.2-72-72-72zm-352 0c-39.8 0-72 32.2-72 72s32.2 72 72 72 72-32.2 72-72-32.2-72-72-72z" transform="translate(-256 -256)"></path></g></g></svg><!-- <span class="fas fa-ellipsis-h" data-fa-transform="shrink-2"></span> Font Awesome fontawesome.com --></button>
                          <div class="dropdown-menu dropdown-menu-end py-0"><a class="dropdown-item" href="#!">Add Card</a><a class="dropdown-item" href="#!">Edit</a><a class="dropdown-item" href="#!">Copy link</a>
                            <div class="dropdown-divider"></div><a class="dropdown-item text-danger" href="#!">Remove</a>
                          </div>
                        </div>
                      </div>
                      <p class="mb-0 fw-medium font-sans-serif stretched-link" data-bs-toggle="modal" data-bs-target="#kanban-modal-1">👌 ${nome_card}</p>
                    </div>
                  </div>
                </div>`


    }
}