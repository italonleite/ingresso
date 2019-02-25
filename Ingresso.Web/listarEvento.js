document.querySelector("#eventos").addEventListener('click', function () { 
    obterdados();
})
function obterdados() { 
    let url = 'https://ingressoapi.azurewebsites.net/v1/eventos';
    const api = new XMLHttpRequest();
    api.open('GET', url, true);
    api.send();
    api.onreadystatechange = function () { 
        if (this.status == 200 && this.readyState == 4) { 
            let dados = JSON.parse(this.responseText);
            console.log(dados);
            let resultado = document.querySelector("#resultado");
            resultado.innerHTML = '';
            for (let item of dados) { 
                resultado.innerHTML += `
                <div class="card mb-4 shadow-sm" >
                <img src="http://lorempixel.com/357/225">
                <div class="card-body" >
                  <p class="card-text" style="text-align: left;" id="Titulo">Evento: ${item.Titulo}</p>
                  <p class="card-text" style="text-align: left;">Local: ${item.Local}</p>
                  <p class="card-text" style="text-align: left;">Preço: ${item.Preco}</p>
                  <div class="comprar justify-content-between">
                    <div class="btn-group">
                    <a href="usuario/index.html"><button type="button"  class="btn btn-sm btn-outline-secondary" id="btComprar">Comprar</button></a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
               `;
            }
        }
    }
}