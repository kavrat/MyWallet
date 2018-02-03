$(document).ready(function() {
    $("#addRev").click(function () {

        var TypesViewModel = {};
        TypesViewModel.Name = $("#revName").val();
        TypesViewModel.TypeId = 1;

        $.post("/settings/add", TypesViewModel,
            function () {
                $("#revData").load('/settings/typelist/', {type: '1'});
                console.log("in load func");
            }
            );
    })
})