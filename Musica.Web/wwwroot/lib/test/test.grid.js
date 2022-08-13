var baseDirectory = "";
var gridName = "";
var urlDelete = "";
var detail = ""
var autoBindGrid = true;
var isActive = false;
var textDelete = "";

function buttonsTemplate(id, description, active, showEdit, showDelete) {
    description = description.replace('"', '01234567890');
    if (showEdit == null) showEdit = true;
    if (showDelete == null) showDelete = true;
    var html = "";
    active = active == null ? true : active;
    if (active) {
        html = '<div class="list-icons">';
        if (showEdit) html += "<a href='" + baseDirectory + "/Edit" + detail + "?id=" + id + "' class='list-icons-item'><i class='fa fa-edit' title='Editar'></i></a>";
        if (showDelete) html += "<a href='#' onclick='deleteGridElementModal(\"" + id + "\",\"" + description + "\"" + ")'  class='list-icons-item'> <i class='fa fa-trash' title='" + (isActive ? 'Inactivar' : 'Eliminar') + "'></i></a>";
        html += "</div >";
    } else {
        html = '<div class="list-icons">';
        html += "<a href='" + baseDirectory + "/Edit" + detail + "?id=" + id + "' class='list-icons-item'><i class='fa fa-eye' title='" + (detail === "" ? isActive ? 'Detalle' : 'Ver' : 'Ver') + "'></i></a>";
        if (detail === "") {
            html += "<a href='#' onclick='unDeleteGridElement(\"" + id + "\")'  class='list-icons-item'> <i class='fa fa-undo' title='" + (isActive ? 'Reactivar' : 'Deshacer eliminado') + "'></i></a>";
        }
        html += "</div >";
    }
    return html;
}

function NumericTemplate(field) {
    return "<span style='float:right;'>" + kendo.toString(field, "n2") + "</span>";
}

//Export functionality
$('#btnExport').click(function () {
    var grid = $("#" + gridName).data("kendoGrid");
    grid.saveAsExcel();
});

$('#btnExportPDF').click(function () {
    var grid = $("#" + gridName).data("kendoGrid");
    grid.saveAsPDF();
});

$(document).ready(function () {

    if (gridName != "") {
        var grid = $("#" + gridName).data("kendoGrid");
        isActive = grid.columns.some(c => c.field == "Active");
    }

    var divConfirmModalWindow = '<div class="modal fade" id="deleteConfirmModal" tabindex="-1" role="dialog" aria-labelledby="deleteConfirmModal" data-backdrop="static" data-keyboard="false">'
        + '<div class="modal-dialog" role="document">'
        + '<div class="modal-content">'
        + '<div class="modal-header">'
        + '<h4 class="modal-title">Confirmar</h4>'
        + '</div>'
        + '<div id="deleteConfirmContentModal">'
        + '<div class="container-fluid">'
        + '<div class="modal-body">'
        + '<div class="text-center">'
        + '<i style="vertical-align: middle" class="fa fa-exclamation-triangle fa-5x  text-warning"></i>'
        + '</div>'
        + '<div class="text-center">'
        + '<p  style="vertical-align: middle" class="pt-3 pb-3 TestConfirmWindowMessage">¿Desea ' + (textDelete != "" ? textDelete : (isActive ? 'inactivar' : 'eliminar')) + ' el elemento <b id="DeleteElement"></b>?</p>'
        + '</div>'
        + '<div class="text-center clearfix">'
        + '<button type="button" class="btn btn-theme-bordered btnConfirmModalNo" data-dismiss="modal"><i class="glyphicon glyphicon-remove"></i> No</button><span style="visibility: hidden;">spa</span>'
        + '<button type="button" onclick="confirmDeleteGridElementModal()" class="btn btn-theme btnConfirmModalYes"><span class="glyphicon glyphicon-ok"></span> Sí</button>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>';



    var divConfirmModalWindowCompositeKey = '<div class="modal fade" id="deleteConfirmModalCompositeKey" tabindex="-1" role="dialog" aria-labelledby="deleteConfirmModal" data-backdrop="static" data-keyboard="false">'
        + '<div class="modal-dialog" role="document">'
        + '<div class="modal-content">'
        + '<div class="modal-header">'
        + '<h4 class="modal-title">Confirm</h4>'
        + '</div>'
        + '<div id="deleteConfirmContentModal">'
        + '<div class="container-fluid">'
        + '<div class="modal-body">'
        + '<div class="text-center">'
        + '<i style="vertical-align: middle" class="fa fa-exclamation-triangle fa-5x  text-warning"></i>'
        + '</div>'
        + '<div class="text-center">'
        + '<p style="vertical-align: middle" class="TestConfirmWindowMessage">> >Are you sure you want to delete the element <b id="DeleteElementCompositeKey"></b>?</p>'
        + '</div>'
        + '<div class="text-center clearfix">'
        + '<button type="button" class="btn btn-theme-bordered btnConfirmModalNo" data-dismiss="modal"><i class="glyphicon glyphicon-remove"></i> No</button><span style="visibility: hidden;">spa</span>'
        + ' <button type="button" onclick="confirmDeleteGridElementCompositeKeyModal()" class="btn btn-theme btnConfirmWindowYes"><span class="glyphicon glyphicon-ok"></span> Yes</button>'
        + '<span class="spacer20">'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>';

    var divActivateConfirmModalWindow = '<div class="modal fade" id="activateConfirmModal" tabindex="-1" role="dialog" aria-labelledby="activateConfirmModal" data-backdrop="static" data-keyboard="false">'
        + '<div class="modal-dialog" role="document">'
        + '<div class="modal-content">'
        + '<div class="modal-header">'
        + '<h4 class="modal-title">Confirm</h4>'
        + '</div>'
        + '<div id="deleteConfirmContentModal">'
        + '<div class="container-fluid">'
        + '<div class="modal-body">'
        + '<div class="text-center">'
        + '<i style="vertical-align: middle" class="fa fa-exclamation-triangle fa-5x  text-warning"></i>'
        + '</div>'
        + '<div class="text-center">'
        + '<p style="vertical-align: middle" class="TestConfirmWindowMessage"> Are you sure you want to activate the element <b id="ActivateElement"></b> versión : <b id="ActivateVersionElement"></b>?</p>'
        + '</div>'
        + '<div class="text-center clearfix">'
        + '<button type="button" class="btn btn-theme-bordered btnConfirmModalNo" data-dismiss="modal"><i class="glyphicon glyphicon-remove"></i> No</button><span style="visibility: hidden;">spa</span>'
        + '<button type="button" onclick="confirmActivateGridElementModal()" class="btn btn-theme btnConfirmModalYes"><span class="glyphicon glyphicon-ok"></span> Yes</button>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>';

    var divDismissConfirmModalWindow = '<div class="modal fade" id="dismissConfirmModal" tabindex="-1" role="dialog" aria-labelledby="dismissConfirmModal" data-backdrop="static" data-keyboard="false">'
        + '<div class="modal-dialog" role="document">'
        + '<div class="modal-content">'
        + '<div class="modal-header">'
        + '<h4 class="modal-title">Confirm</h4>'
        + '</div>'
        + '<div id="deleteConfirmContentModal">'
        + '<div class="container-fluid">'
        + '<div class="modal-body">'
        + '<div class="text-center">'
        + '<i style="vertical-align: middle" class="fa fa-exclamation-triangle fa-5x  text-warning"></i>'
        + '</div>'
        + '<div class="text-center">'
        + '<p style="vertical-align: middle" class="TestConfirmWindowMessage"> Are you sure you want to delete the element <b id="DismissElement"></b> versión : <b id="DismissVersionElement"></b>?</p>'
        + '</div>'
        + '<div class="text-center clearfix">'
        + '<button type="button" class="btn btn-theme-bordered btnConfirmModalNo" data-dismiss="modal"><i class="glyphicon glyphicon-remove"></i> No</button><span style="visibility: hidden;">spa</span>'
        + '<button type="button" onclick="confirmDismissGridElementModal()" class="btn btn-theme btnConfirmModalYes"><span class="glyphicon glyphicon-ok"></span> Yes</button>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>'
        + '</div>';



    $('body').append(divConfirmModalWindow);

    $('body').append(divConfirmModalWindowCompositeKey);

    $('body').append(divActivateConfirmModalWindow);

    $('body').append(divDismissConfirmModalWindow);

    var win = $("#deleteConfirmWindow").kendoWindow({
        modal: true,
        title: "Confirmar",
        visible: false,
        width: "500px"
    }).data("kendoWindow");

    $("#btnShowDeleted").bind("click", btnShowDeleted_OnClick);
    $("#btnHideDeleted").bind("click", btnHideDeleted_OnClick);

    // Condición para evitar auto-bind en Grids que no lo requieran
    // Por Default: true
    if (autoBindGrid) {
        autoBindGridFunction();
    }
});

function autoBindGridFunction() {
    if (gridName != "") {
        var grid = $("#" + gridName).data("kendoGrid");
        grid.bind("dataBound", grid_dataBound);
        grid.dataSource.fetch();
        $("#" + gridName).data("kendoGrid").dataSource.read();
    }
}

function btnShowDeleted_OnClick() {
    $("#btnShowDeleted").hide();
    $("#btnHideDeleted").show();

    showDeleted = true;
    if (autoBindGrid) {
        var grid = $("#" + gridName).data("kendoGrid");
        grid.dataSource.read();
    } else {
        autoBindGridFunction();
    }
}

function btnHideDeleted_OnClick() {
    $("#btnShowDeleted").show();
    $("#btnHideDeleted").hide();

    showDeleted = false;
    if (autoBindGrid) {
        var grid = $("#" + gridName).data("kendoGrid");
        grid.dataSource.read();
    } else {
        autoBindGridFunction();
    }
}

function grid_dataBound(e) {
    var items = e.sender.items();
    items.each(function (index) {
        var grid = $("#" + gridName).data("kendoGrid");
        var dataItem = grid.dataItem(this);
        if (dataItem.Active !== true && dataItem.Active !== undefined) {
            this.className += " row-deleted";
        }

    })
}

var gridElementId = null;

function deleteGridElementModal(id, name) {
    name = name.replace('01234567890', '"');
    name = name.replace("~l~", "'");

    gridElementId = id;
    $("#deleteConfirmModal").modal("show");
    $('#DeleteElement').text(name);
}


var firstElementId = null;
var secondElementId = null;
function deleteGridElementCompositeKeyModal(firstId, secondId, name) {
    firstElementId = firstId;
    secondElementId = secondId;

    $("#deleteConfirmModalCompositeKey").modal("show");
    $('#DeleteElementCompositeKey').text(name);
}


function confirmDeleteGridElementModal() {

    if (gridElementId != null) {
        $.ajax({
            type: "POST",
            url: baseDirectory + "/delete" + detail,
            data: {
                Id: gridElementId
            },
            headers: {
                RequestVerificationToken:
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success: function (data) {
                $("#deleteConfirmModal").modal("hide");
                if (autoBindGrid) {
                    $("#" + gridName).data("kendoGrid").dataSource.read();
                } else {
                    autoBindGridFunction();
                }
            }
        });
    }

}


function confirmDeleteGridElementCompositeKeyModal() {

    if (firstElementId != null && secondElementId != null) {
        $.ajax({
            type: "POST",
            url: baseDirectory + "/delete" + detail,
            data: {
                firstId: firstElementId,
                secondId: secondElementId
            },
            headers: {
                RequestVerificationToken:
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success: function (data) {
                $("#deleteConfirmModalCompositeKey").modal("hide");
                if (autoBindGrid) {
                    $("#" + gridNameCompositeKey).data("kendoGrid").dataSource.read();
                } else {
                    autoBindGridFunction();
                }
            }
        });
    }

}

function cancelDeleteGridElementModal() {
    $('#deleteConfirmModal').modal("hide");
}

function cancelDeleteGridElement() {
    var win = $("#deleteConfirmWindow").data("kendoWindow");
    win.close();
}


function unDeleteGridElement(gridElementId) {
    if (gridElementId != null) {
        $.ajax({
            type: "POST",
            url: baseDirectory + "/delete" + detail + "?handler=Undelete",
            data: {
                Id: gridElementId
            },
            headers: {
                RequestVerificationToken:
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success: function (data) {
                $("#deleteConfirmModal").modal("hide");
                if (autoBindGrid) {
                    $("#" + gridName).data("kendoGrid").dataSource.read();
                } else {
                    autoBindGridFunction();
                }
            }
        });
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

function templateCheck(valor) {
    if (valor) {
        return "<p class='text-center' style='margin-bottom:0px'><i class='fa fa-check-square'></i></p>";
    }
    return "<p class='text-center' style='margin-bottom:0px'><i class='fa fa-square'></i></p>";
}

function NumericTemplate(field) {
    return "<span style='float:right;'>" + kendo.toString(field, "n2") + "</span>";
}


/* State saving/load for index pages functionality.
 */
var options = {
    gridName: "",
    filtersStateSelector: ".grid-filter:not('.k-widget'):not([name$='_input'])",
};

var ignoreHashChange = false;
var isLoadingState = true;

function initializeGrid(e) {
    options = $.extend({}, options, e);

    var grid = $("#" + options.gridName).data("kendoGrid");


    window.onhashchange = function () {
        if (!ignoreHashChange)
            loadState(options.gridName);
        ignoreHashChange = false;
    };

    window.onload = function () {
        loadState(options.gridName);
    };
}

function dataBoundGrid(gridName) {
    if (!isLoadingState) {
        saveState(gridName);
    }
    isLoadingState = false;
}

function loadState(gridName) {

    var grid = $('#' + gridName).data('kendoGrid');
    if (grid) {

        grid.unbind("dataBound");

        var encodedState = getState();

        if (encodedState.length > 0) {

            var hashState = $.base64.decode(decodeURIComponent(encodedState.substring(1)));

            var commands = hashState.split("&");
            var values = [];

            for (i = 0; i < commands.length; i++) {
                var command = commands[i].split("=");
                values[command[0]] = command[1];
            }

            loadFiltersState(values);
            loadGridState(grid, values);
        }
        grid.dataSource.read();

        grid.bind("dataBound", function () {
            dataBoundGrid(options.gridName);
        });
    }
}

/*
 * Get state from URL Hash
 * */
function getState() {
    var encodedState = window.location.hash;
    return encodedState;
}

var datePicker;
function loadFiltersState(values) {

    for (var key in values) {
        if (key == ! "" || key == !undefined) {
            if (values.hasOwnProperty(key)) {
                if (!isSpecialFilter(key)) {

                    var input = $("#" + key);
                    var filterValue = values[key];

                    if (input) {
                        var combo = input.data("kendoComboBox");
                        var dropdownlist = input.data("kendoDropDownList");
                        var numeric = input.data("kendoNumericTextBox");
                        datePicker = input.data("kendoDatePicker");

                        if (combo) {
                            if (combo.value() != values[key]) {
                                combo.value('');
                                combo.value(filterValue);
                            }
                        }
                        else if (numeric) {
                            if (numeric.value() != filterValue) {
                                numeric.value(filterValue);
                            }

                        }
                        else if (dropdownlist) {
                            if (dropdownlist.value() != filterValue) {
                                dropdownlist.value('');
                                dropdownlist.dataSource.data({});
                                dropdownlist.value(filterValue);
                            }
                        }
                        else if (datePicker) {
                            var d = new Date(filterValue);
                            if (d) {
                                if (formatDate(datePicker.value()) != filterValue) {
                                    d.setDate(d.getDate() + 1);
                                    datePicker.value(d);
                                }
                            }
                            else {
                                datePicker.value(new Date());
                            }
                        }
                        else {
                            var type = input.attr("type");
                            if (type == "checkbox") {
                                if (filterValue == "true")
                                    input[0].checked = true;
                                else
                                    input[0].checked = false;
                            } else {
                                if (input.val() != filterValue) {
                                    input.val(filterValue);
                                }
                            }
                        }
                    }
                }
            }
        }
    }


}

function loadGridState(grid, values) {
    var page = values["page"] ? values["page"] : 1;
    var sort = values["sorts"] ? values["sorts"] : "";
    var filter = values["filters"] ? values["filters"] : "";

    if (grid.dataSource.page() != page)
        grid.dataSource._page = page;

    if (sort.length > 0) {
        if (JSON.stringify(grid.dataSource.sort()) != sort)
            grid.dataSource._sort = JSON.parse(sort);
    }
    else {
        if (grid.dataSource.sort() && grid.dataSource.sort().length && grid.dataSource.sort().length > 0)
            delete grid.dataSource._sort;
    }

    if (filter.length > 0) {
        if (JSON.stringify(grid.dataSource.filter()) != filter)
            grid.dataSource._filter = JSON.parse(filter);
    }
    else {
        if (grid.dataSource.filter())
            delete grid.dataSource._filter;
    }
}

function saveState(gridName) {
    var filtersState = getFiltersState();
    var gridState = getGridState(gridName);

    var state = $.extend({}, gridState, filtersState);

    var stateHashed = encodeState(state);
    if (window.location.hash != stateHashed) {
        ignoreHashChange = true;
        window.location.hash = stateHashed;
    }
}

function getFiltersState() {

    var filters = $(options.filtersStateSelector);

    var arrayOfFilters = [];
    var id = "";
    $.each(filters, function (index, value) {
        var input = null;
        id = '#' + value.id;
        input = $('#' + value.id);
        if (input) {
            if (input[0].dataset.role == "combobox")
                arrayOfFilters[value.id] = input.val();
            if (input[0].className == "check-box")
                arrayOfFilters[value.id] = input[0].checked;
            else if (input.data("kendoDatePicker")) {
                if (datePicker != undefined)
                    arrayOfFilters[value.id] = formatDate(datePicker.value());
            }
            else
                arrayOfFilters[value.id] = input.val();
        }
    });
    return arrayOfFilters;
}

function getGridState(gridName) {
    var grid = $("#" + gridName).data("kendoGrid");

    var gridState = [];

    gridState["sorts"] = JSON.stringify(getValueForParam(grid.dataSource.sort()));
    gridState["filters"] = JSON.stringify(grid.dataSource.filter());
    gridState["page"] = grid.dataSource.page();

    return gridState;
}

function encodeState(arrayOfFilters) {
    var hash = "";
    var i = 0;
    for (key in arrayOfFilters) {
        if (i != 0) {
            hash = hash + "&";
        }
        hash = hash + key + "=" + arrayOfFilters[key];
        i++;
    }

    hash = encodeURIComponent($.base64.encode(hash));

    return "#" + hash;
}

function isSpecialFilter(filterName) {
    return $.inArray(filterName, ["sorts", "page", "filters"]) >= 0;
}

function getValueForParam(e) {
    if (e) {
        if (e.length && e.length > 0)
            return e;
        else
            return undefined;
    }
    return undefined;
}

function redirectToView(url) {
    url = url.replace('returnUrl=~returnUrl~', 'returnUrl=' + encodeURIComponent(document.location.pathname + document.location.search + window.location.hash));
    window.location = url;
}

function openToView(url) {
    url = url.replace('returnUrl=~returnUrl~', 'returnUrl=' + encodeURIComponent(document.location.pathname + document.location.search + window.location.hash));
    window.open(url);
}
