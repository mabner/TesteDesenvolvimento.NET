$(document).ready(function () {

    function limpa_formulario_cep() {
        // Limpa valores do formulário de cep.
        $("#Endereco_Logradouro").val("");
        $("#Endereco_Bairro").val("");
        $("#Endereco_Localidade").val("");
        $("#Endereco_Uf").val("");
    }

    //Quando o campo cep perde o foco.
    $("#Endereco_Cep").blur(function () {

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#Endereco_Logradouro").val("...");
                $("#Endereco_Bairro").val("...");
                $("#Endereco_Localidade").val("...");
                $("#Endereco_Uf").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (endereco) {

                    if (!("erro" in endereco)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#Endereco_Logradouro").val(endereco.logradouro);
                        $("#Endereco_Bairro").val(endereco.bairro);
                        $("#Endereco_Localidade").val(endereco.localidade);
                        $("#Endereco_Uf").val(endereco.uf);
                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulario_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulario_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formuario_cep();
        }
    });
});