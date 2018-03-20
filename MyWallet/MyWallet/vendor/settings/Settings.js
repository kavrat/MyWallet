$(document).ready(function () {
    $(".table").on("click", "button[id^='set']", function () {
        var btn = $(this).attr("id");
        var btnIds = btn.replace(/^\D+/g, '');

        var TypesViewModel = {};
        var idSelect;

        if (btn.indexOf("Del") >= 0) {
            var idType = Number(btnIds.charAt(0));
            var idDel = Number(btnIds.substr(1));

            if (idType === 1) {
                idSelect = "#revData";
            }
            else {
                idSelect = "#expData";
            }

            $.post("/settings/delete/", { index: idDel },
                function () {
                    $(idSelect).load("settings/typelist/", { type: idType });
                });
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
        //idSelect = null;
    });
})