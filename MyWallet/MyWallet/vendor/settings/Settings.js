$(document).ready(function() {
    $("button[id*='set']").click(function () {
        var btn = $(this).attr("id");
        var btnIds = Number(btn.replace(/^\d+/g, ''));

        var TypesViewModel = {};
        var idSelect;

        if (btn.indexOf("Del") >= 0) {

        }

        if (btn.indexOf("Add") >= 0) {
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
            $.post("/settings/add", TypesViewModel,
                function () {
                    $(idSelect).load('/settings/typelist/', { type: TypesViewModel.TypeId });
                });
        }

        if (btn.indexOf("Edit") >= 0) {

        }
        
    });
})