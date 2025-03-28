const link = document.createElement("link")
link.rel = "stylesheet"
link.href = "assets/css/theme-rtl.css" // Caminho do CSS
document.head.appendChild(link);

btCadastrar.onclick = () => {
    document.getElementById("form-botoes").classList.add("nenhum")
    document.getElementById("form-container").innerHTML = `
        <form>
            <div class="mb-3">
                <label for="inputNome" class="form-label">Nome Completo</label>
                <input type="text" class="form-control" id="inputNome">
            </div>
             <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Endereço de e-mail</label>
                <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
             </div>
             <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Senha</label>
                <input type="password" class="form-control" id="exampleInputPassword1">
             </div>
        </form>
          <div>
            <ul id="form-botoes" style=" list-style: none; display: flex; align-content: center;">
                <li class="p-3"><button id="btLogin" class="btn btn-primary">Login</button></li>
                <li class="p-3"><button id="btCadastrar" class="btn btn-secondary">Cadastro</button></li>
            </ul>
          </div>
    `;
};