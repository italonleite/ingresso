

var servico = new internalWebService();
//servico.GET(webbase, "usuarios", true, listarUsuarios);
//servico.POST(webbase, "usuarios", true, cadUsuarios);
servico.GET("eventos", '', true, listarEventos);

/*function listarUsuarios(data) {
    var i = 0;
    for (i = 0; i < data.length; i++) {
        $('.Id').append(data[i].Id);
        $('.Nome').append(data[i].Nome);
        $('.Cpf').append(data[i].Cpf);
        $('.Endereco').append(data[i].Endereco);
    }
}*/

function listarEventos(data) {
    var i = 0;
    for (i = 0; i < data.length; i++) {
        var divCard = $('<div/>', { class: 'card' });
        divCard.css('width', '18rem');
        var imgCard = $('<img/>', { src: data[i].Imagem, class: 'card-img-top, rounded' });
        var divCardbody = $('<div/>', { class: 'card-body' });
        var cardH5 = $('<h5/>', { class: 'card-titulo' }).text(data[i].Titulo);
        var cardLocal = $('<p/>', { class: 'card-text' }).text('Local :' + data[i].Local);
        var cardPreco = $('<p/>', { class: 'card-text' }).text('Preco :' + data[i].Preco);
        var hrefCard = $('<a/>', { href: '#', class: 'btn btn-primary'}).text('Comprar');
      
       
        imgCard.appendTo(divCard);
        cardH5.appendTo(divCardbody);
        cardLocal.appendTo(divCardbody);
        cardPreco.appendTo(divCardbody);
        hrefCard.appendTo(divCardbody);
        divCardbody.appendTo(divCard);
        divCard.appendTo($('.listaEventos'));


        
    }
}


//Cadastrar Usuário
function enviar() {

    var novoUsuario = new usuario();
    novoUsuario.nome = $('#nome').val();
    novoUsuario.cpf = $("#cpf").val();
    novoUsuario.sexo = $("input[name='sexo']:checked").val();
    novoUsuario.endereco = $("#endereco").val();
    novoUsuario.login = $("#login").val();
    novoUsuario.senha = $("#senha").val();

    servico.POST("usuarios",novoUsuario, true, resultado);
}

function resultado(data) {
    alert('Usuario cadastrado com sucesso.');
}
function usuario(nome, cpf, sexo, endereco, login, senha) {
    this.nome = nome;
    this.cpf = cpf;
    this.sexo = sexo;
    this.endereco = endereco;
    this.login = login;
    this.senha = senha;

    
}


