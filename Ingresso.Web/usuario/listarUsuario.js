document.querySelector("#usuarios").addEventListener('click', function () { 
    obterdados();
})
function obterdados() { 
    let url = 'https://ingressoapi.azurewebsites.net/v1/usuarios';
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
                <tr>
                <td>${item.Nome}</td>
                <td>${item.Cpf}</td>
                <td>${item.Sexo}</td>
                <td>${item.Endereco}</td>
                <td>${item.Login}</td>
              </tr>
               `;
            }
        }
    }
}
