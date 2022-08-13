/** EJEMPLOS DE USO:
        
        Types:
        info, warning, error

        MESSAGES Modal:
        showMessageModal(message); -- Por default: type = info;
        showMessageModal(message, type);//***

        CONFIRM Modal:
        showConfirmModal(message, callbackFunctionName); -- Por default: type = info;
        showConfirmModal(message, callbackFunctionName, type);

**/
var win;
var detailId;
var detail = ""

var divInfoMessageboxModal = '<div class="modal fade TestMessageModal" id="infoBoxModal" tabindex="-1" role="dialog" aria-labelledby="infoBoxModal" data-backdrop="static" data-keyboard="false">'
    + '<div class="modal-dialog" role="document">'
    + '<div class="modal-content">'
    + '<div class="modal-header">'
    + '<h4 class="modal-title"> </h4>'
    + '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true"><i class="fa fa-times"></i></span></button>'
    + '</div>'
    + '<div class="modal-body">'
    + '<div class="container-fluid">'
    + '<div class="text-center">'
    + '<i style="vertical-align: middle" class="fa fa-info-circle fa-5x text-info"></i>'
    + '</div>'
    + '<div class="text-center">'
    + '<p style="vertical-align: middle" class="TestMessageModalMessage"></p>'
    + '</div>'
    + '<div class="text-center clearfix">'
    + '<button type="button" onclick="onClickTestMessageModalButtonOk()" class="btn btn-success btnConfirmModalYes"><span class="glyphicon glyphicon-ok"></span> Aceptar</button>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>';

var divErrorMessageboxModal = '<div class="modal fade TestMessageModal" id="errorBoxModal" tabindex="-1" role="dialog" aria-labelledby="errorBoxModal" data-backdrop="static" data-keyboard="false">'
    + '<div class="modal-dialog" role="document">'
    + '<div class="modal-content">'
    + '<div class="modal-header">'
    + '<h4 class="modal-title"> </h4>'
    + '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true"><i class="fa fa-times"></i></span></button>'
    + '</div>'
    + '<div class="modal-body">'
    + '<div class="container-fluid">'
    + '<div class="text-center">'
    + '<i style="vertical-align: middle" class="fa fa-ban fa-5x text-danger"></i>'
    + '</div>'
    + '<div class="text-center">'
    + '<p style="vertical-align: middle" class="TestMessageModalMessage"></p>'
    + '</div>'
    + '<div class="text-center clearfix">'
    + '<button type="button" onclick="onClickTestMessageModalButtonOk()" class="btn btn-success btnConfirmModalYes"><span class="glyphicon glyphicon-ok"></span> Aceptar</button>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>';

var divWarningMessageboxModal = '<div class="modal fade TestMessageModal" id="warningBoxModal" tabindex="-1" role="dialog" aria-labelledby="warningBoxModal" data-backdrop="static" data-keyboard="false">'
    + '<div class="modal-dialog" role="document">'
    + '<div class="modal-content">'
    + '<div class="modal-header">'
    + '<h4 class="modal-title"> </h4>'
    + '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true"><i class="fa fa-times"></i></span></button>'
    + '</div>'
    + '<div class="modal-body">'
    + '<div class="container-fluid">'
    + '<div class="text-center">'
    + '<i style="vertical-align: middle" class="fa fa-exclamation-triangle fa-5x  text-warning"></i>'
    + '</div>'
    + '<div class="text-center">'
    + '<p style="vertical-align: middle" class="TestMessageModalMessage"></p>'
    + '</div>'
    + '<div class="text-center clearfix">'
    + '<button type="button" onclick="onClickTestMessageModalButtonOk()" class="btn btn-success btnConfirmModalYes"><span class="glyphicon glyphicon-ok"></span> Aceptar</button>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>';

var divInfoConfirmMessageBoxModal = '<div class="modal fade TestMessageModal" id="infoConfirmMessageBoxModal" tabindex="-1" role="dialog" aria-labelledby="infoConfirmMessageBoxModal" data-backdrop="static" data-keyboard="false">'
    + '<div class="modal-dialog" role="document">'
    + '<div class="modal-content">'
    + '<div class="modal-header">'
    + '<h4 class="modal-title">Confirmar</h4>'
    + '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true"><i class="fa fa-times"></i></span></button>'
    + '</div>'
    + '<div class="modal-body">'
    + '<div class="container-fluid">'
    + '<div class="text-center">'
    + '<i style="vertical-align: middle" class="fa fa-info-circle fa-5x text-info"></i>'
    + '</div>'
    + '<div class="text-center">'
    + '<p style="vertical-align: middle" class="TestConfirmModalMessage"></p>'
    + '</div>'
    + '<div class="text-center clearfix">'
    + '<button class="text-center btn btn-theme-bordered btnConfirmModalNo" onclick="onClickTestConfirmModalButtonNo()"><span class="glyphicon glyphicon-remove"></span> No</button><span style="visibility: hidden;">s</span>'
    + '<button type="button" onclick="onClickTestConfirmModalButtonYes()" class="btn btn-theme btnConfirmModalYes"><span class="glyphicon glyphicon-ok"></span> Si</button><span style="visibility: hidden;">s</span>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>';

var divWarningConfirmMessageBoxModal = '<div class="modal fade TestMessageModal" id="warningConfirmMessageBoxModal" tabindex="-1" role="dialog" aria-labelledby="warningConfirmMessageBoxModal" data-backdrop="static" data-keyboard="false">'
    + '<div class="modal-dialog" role="document">'
    + '<div class="modal-content">'
    + '<div class="modal-header">'
    + '<h4 class="modal-title">Confirmar</h4>'
    + '<button type="button" class="close" data-dismiss="modal" aria-label="Close" id="closeModal"><span aria-hidden="true"><i class="fa fa-times"></i></span></button>'
    + '</div>'
    + '<div class="modal-body">'
    + '<div class="container-fluid">'
    + '<div class="text-center">'
    + '<i style="vertical-align: middle" class="fa fa-exclamation-triangle fa-5x  text-warning"></i>'
    + '</div>'
    + '<div class="text-center">'
    + '<p style="vertical-align: middle" class="TestConfirmModalMessage"></p>'
    + '</div>'
    + '<div class="text-center clearfix">'
    + '<button class="text-center btn btn-theme-bordered btnConfirmModalNo" onclick="onClickTestConfirmModalButtonNo()"><span class="glyphicon glyphicon-remove"></span> No</button><span style="visibility: hidden;">s</span>'
    + '<button type="button" onclick="onClickTestConfirmModalButtonYes()" class="btn btn-theme btnConfirmModalYes"><span class="glyphicon glyphicon-ok"></span> Si</button><span style="visibility: hidden;">s</span>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>'
    + '</div>';

$(document).ready(function () {

    var form = $(".card form").attr("id");
    if (form != undefined) {
        var model = form.replace("Form", "_Active");
        var input = $("#" + model);

        $("#btnGoBack").bind("click", function () {
            //if (input.val() === "True") {
            //    showConfirmModal("¿Desea salir sin guardar?", "redirect", "warning");
            //} else {
            redirect();
            //}
        });


        if (input.val() === "False") {
            $("#" + form + " :input").prop("disabled", true);
            $("input[type=submit]").prop("hidden", true);
        }
    }

    /*
    Info MessageBox Modal
    */

    $('body').append(divInfoMessageboxModal);
    $('body').append(divErrorMessageboxModal);
    $('body').append(divWarningMessageboxModal);

    $('body').append(divInfoConfirmMessageBoxModal);
    $('body').append(divWarningConfirmMessageBoxModal);

    var calculatedWidth = "";
    if (window.screen.availWidth < 600) {
        calculatedWidth = window.screen.availWidth + "px";
    } else {
        calculatedWidth = 600 + "px";
    }


});

(function ($) {
    $.fn.currencyInput = function () {
        this.each(function () {
            var wrapper = $("<div class='currency-input' />");
            $(this).wrap(wrapper);
            $(this).before("<span class='currency-symbol'>$</span>");
            $(this).change(function () {
                var min = parseFloat($(this).attr("min"));
                var max = parseFloat($(this).attr("max"));
                var value = this.valueAsNumber;
                if (value < min)
                    value = min;
                else if (value > max)
                    value = max;
                $(this).val(value.toFixed(2));
            });
        });
    };
})(jQuery);

function showMessageModal(message, type, callbackFunctionName) {
    /**
    **  Los tipos definidos son:
    **      - info
    **      - warning 
    **      - error
    **/

    if ((message) && (type) && (callbackFunctionName)) {
        if (type == 'info') {

            modal = $("#infoBoxModal");
            $("#infoBoxModal .TestMessageModalMessage").html(message);
            $("#infoBoxModal .btnConfirmModalYes").attr("onclick", "onClickTestConfirmModalButtonYes('" + callbackFunctionName + "')");
            modal.modal("show");

            return false;
        }
        if (type == 'warning') {

            modal = $("#warningBoxModal");

            $("#warningBoxModal .TestMessageModalMessage").html(message);
            $("#warningBoxModal .btnConfirmModalYes").attr("onclick", "onClickTestConfirmModalButtonYes('" + callbackFunctionName + "')");
            modal.modal("show");

            return false;
        }
        if (type == 'error') {

            modal = $("#errorBoxModal");
            $("#errorBoxModal .TestMessageModalMessage").html(message);
            $("#errorBoxModal .btnConfirmModalYes").attr("onclick", "onClickTestConfirmModalButtonYes('" + callbackFunctionName + "')");
            modal.modal("show");

            return false;
        }
    }

    if ((message) && (type)) {
        if (type == 'info') {

            modal = $("#infoBoxModal");
            $("#infoBoxModal .TestMessageModalMessage").html(message);
            modal.modal("show");

            return false;
        }
        if (type == 'warning') {

            modal = $("#warningBoxModal");

            $("#warningBoxModal .TestMessageModalMessage").html(message);
            modal.modal("show");

            return false;
        }
        if (type == 'error') {

            modal = $("#errorBoxModal");
            $("#errorBoxModal .TestMessageModalMessage").html(message);
            modal.modal("show");

            return false;
        }
    }

    if ((message)) {
        modal = $("#infoBoxModal");
        $("#infoBoxModal .TestMessageModalMessage").html(message);
        modal.modal("show");

        return false;
    }
}

function onClickTestMessageModalButtonOk() {
    modal.modal("hide");
}

function onClickTestConfirmModalButtonYes(callbackFunctionName) {
    eval(callbackFunctionName + '()');
    modal.modal("hide");
    return false;
}

function onClickTestConfirmModalButtonNo() {
    modal.modal("hide");
}

function showConfirmModal(message, callbackFunctionName, type) {
    if ((message) && (callbackFunctionName) && (type)) {
        if (type == 'info') {
            modal = $("#infoConfirmMessageBoxModal");
            $("#infoConfirmMessageBoxModal .TestConfirmModalMessage").html(message.replace(/\n/g, "<br/>"));
            $("#infoConfirmMessageBoxModal .btnConfirmModalYes").attr("onclick", "onClickTestConfirmModalButtonYes('" + callbackFunctionName + "')");
            modal.modal("show");

            return false;
        }
        if (type == 'warning') {
            modal = $("#warningConfirmMessageBoxModal");
            $("#warningConfirmMessageBoxModal .TestConfirmModalMessage").html(message.replace(/\n/g, "<br/>"));
            $("#warningConfirmMessageBoxModal .btnConfirmModalYes").attr("onclick", "onClickTestConfirmModalButtonYes('" + callbackFunctionName + "')");
            modal.modal("show");

            return false;
        }
    }
    if ((message) && (callbackFunctionName)) {
        modal = $("#infoConfirmMessageBoxModal");
        $("#infoConfirmMessageBoxModal .TestConfirmModalMessage").html(message.replace(/\n/g, "<br/>"));
        $("#infoConfirmMessageBoxModal .btnConfirmModalYes").attr("onclick", "onClickTestConfirmModalButtonYes('" + callbackFunctionName + "')");
        modal.modal("show");

        return false;
    }
}

function dataFunction(e) {
    var filterValue = '';
    if (e.filter != undefined && e.filter.filters[0]) {
        filterValue = e.filter.filters[0].value;
    }
    return {
        __RequestVerificationToken: kendo.antiForgeryTokens().__RequestVerificationToken,
        text: filterValue
    };
}

function redirect() {
    window.location = detailId == null ? "./Index" : "../Edit?id=" + detailId;
}