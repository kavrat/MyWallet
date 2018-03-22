$(document).ready(function () {
    $(".table").on("click", "button[id^='set']", function () {
        var btn = $(this).attr("id");
        var btnIds = btn.replace(/^\D+/g, '');

        var TypesViewModel = {};
        var idSelect;

        if (btn.indexOf("Del") >= 0) {
            idSelect = deleteFunc(btnIds, idSelect);
        }

        if (btn.indexOf("Add") >= 0) {
            idSelect = addFunc(btn, TypesViewModel, idSelect);

        }

        if (btn.indexOf("Edit") >= 0) {
            var temp = $(this).closest('tr');
            editRow(temp);
        }
    });

});

function addFunc(btn, TypesViewModel, idSelect) {
    if (btn.indexOf("Rev") >= 0) {
        TypesViewModel.Name = $("#revName").val();
        TypesViewModel.TypeId = 1;
        idSelect = "#revData";
        $("#revName").val(null);
    }
    else {
        TypesViewModel.Name = $("#expName").val();
        TypesViewModel.TypeId = 2;
        idSelect = "#expData";
        $("#expName").val(null);
    }
    $.post("/settings/add", TypesViewModel, function () {
        $(idSelect).load('/settings/typelist/', { type: TypesViewModel.TypeId });
    });
    return idSelect;
}

function deleteFunc(btnIds, idSelect) {
    var idType = Number(btnIds.charAt(0));
    var idDel = Number(btnIds.substr(1));
    if (idType === 1) {
        idSelect = "#revData";
    }
    else {
        idSelect = "#expData";
    }
    $.post("/settings/delete/", { index: idDel }, function () {
        $(idSelect).load("settings/typelist/", { type: idType });
    });
    return idSelect;
}

function editRow(row) {
    $('td:first-child', row).each(function () {
        $(this).html('<input type="text" value="' + $(this).html() + '" />');
    });
    $('td:nth-child(2)', row).each(function () {
        $(this).html('<button id="setSave"class="btn btn-primary" type="button">Save</button>');
    });

}
