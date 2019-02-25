var servico = new internalWebService();
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
