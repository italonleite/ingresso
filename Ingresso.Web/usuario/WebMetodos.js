
var webbase = "https://ingressoapi.azurewebsites.net/v1/";


function Header (A, B, C, D) {
    this.A = A;
    this.B = B;
    this.C = C;
    this.D = D;
};
var header = new Header(undefined, undefined, undefined, undefined);
function setHeader() {

}
function internalWebService() {
    this.GET = function (URL, Data, Async, Function) {
        if (Async == undefined) Async = false;

        $.ajax({
            type: "GET",
            url: webbase + URL + "/" + Data,
            contentType: 'json',
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
            url: webbase + URL,
            data: JSON.stringify(Data),
            headers: setHeader(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processData: true,
            async: Async,
            success: function (Data, status, jqXHR) {
                if (Function != undefined) Function(Data, status, jqXHR);
                dataReturn = Data;
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

      this.POST = function (URL, Data, Async, Function) {
        this.service.POST(URL, Data, Async, Function);
    }

  
}