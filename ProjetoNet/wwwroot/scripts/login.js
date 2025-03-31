function addStyle() {
    const sheet = new CSSStyleSheet();
    sheet.insertRule(`#botoes-login { display: none; }`, 0); 
    document.adoptedStyleSheets = [...document.adoptedStyleSheets, sheet]; 
}

btCadastrar.onclick = () => {
    document.querySelector('h1').innerHTML = "Realize o seu Cadastro"
    document.getElementById("botoes-login").classList.add(addStyle())
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
              <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Confirme sua ssenha</label>
                <input type="password" class="form-control" id="exampleInputPassword1">
             </div>
        </form>
          <div>
            <ul id="form-botoes" style=" list-style: none; display: flex; justify-content: center;">
                <li class="p-3"><button id="btVoltar" class="btn btn-primary">voltar</button></li>
                <li class="p-3"><button type="submit" id="btEnviarCadastro" class="btn btn-secondary">Cadastrar</button></li>
            </ul>
          </div>
    `;

    document.getElementById("btVoltar").onclick = () => {
        window.location.href = "login.html"
    }
    document.getElementById("btEnviarCadastro").onclick = () => {
    }

    
};



btLogin.onclick = () => {
    console.log("ooi")
}

