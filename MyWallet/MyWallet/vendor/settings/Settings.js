$(document).ready(function() {
    $("button[id*='add']").click(function () {

        var TypesViewModel = {};
        var idSelect;

        if ($(this).attr("id") === "addRev") {
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

        $.post("/settings/add", TypesViewModel,
            function () {
                $(idSelect).load('/settings/typelist/', { type: TypesViewModel.TypeId });
            });
    });
})