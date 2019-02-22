
var webbase = "https://ingressoapi.azurewebsites.net/v1/";

function internalWebService() {
    this.GET = function (URL, Data, Async, Function) {
        if (Async == undefined) Async = false;

        $.ajax({
            type: "GET",
            url: webbase + URL + "/" + Data,
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            dataType: 'json',
            headers: setHeader(),
            async: Async,
            success: function (data, status, jqXHR) {
                if (Function != undefined) Function(data, status, jqXHR);
                return data;
            },
            error: function (xhr, erro) {
                if (Function != undefined) Function(false, xhr, erro);
                return false;
            }
        });
    }

    this.POST = function (URL, Data, Async, Function) {
        if (Async == undefined) Async = false;
        var dataReturn;
        $.ajax({
            type: "POST",
            url: webbase + URL + "/" + Data,
            data: JSON.stringify(Data),
            headers: setHeader(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processData: true,
            async: Async,
            success: function (data, status, jqXHR) {
                if (Function != undefined) Function(data, status, jqXHR);
                dataReturn = data;
            },
            error: function (xhr) {
                if (Function != undefined) Function('', 'failed', jqXHR);
                dataReturn = false;
                //return false;
            }
        });
        return dataReturn;
    }

    
}
function WebService(servico) {
    this.service = new internalWebService(servico);

    this.GET = function (URL, Data, Async, Function) {
        this.service.GET(URL, Data, Async, Function);
    }

    this.POST = function (URL, Data, Async, Function) {
        this.service.POST(URL, Data, Async, Function);
    }

   
}