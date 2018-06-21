$.ajax({
    url: "/home/GetWeeklyExpanses/",
    type: "GET",
    success: onSuccess,
    error: onErrorCall

});

function onSuccess(result) {
    var expenseValues = [];
    var expenseNames = [];
    var bgColors = ["rgba(240, 155, 127, 0.5)", "rgba(240, 127, 155, 0.5)", "rgba(127, 155, 240, 0.5)", "rgba(128, 223, 255, 0.5)", "rgba(217, 109, 155, 0.5)", "rgba(96, 88, 155, 0.5)"];
    var borderColors = ["rgba(240, 155, 127, 1)", "rgba(240, 127, 155, 1)", "rgba(127, 155, 240, 1)", "rgba(128, 223, 255, 1)", "rgba(217, 109, 155, 1)", "rgba(96, 88, 155, 1)"];

    for (var i = 0; i < result.length; i++) {
        expenseValues.push(result[i].Value);
        expenseNames.push(result[i].Name);
    }

    var ctx = $("#PieChart")[0].getContext('2d');
    var myChart = new Chart(ctx,
        {
            type: 'pie',
            data: {
                labels: expenseNames,
                datasets: [
                    {
                        data: expenseValues,
                        backgroundColor: bgColors,
                        borderColor: borderColors
                    }
                ],
            }
            //options: {
            //    animation.animateRotate: true,
            //    animation.animateScale: false,

            //}
        });
}

function onErrorCall(response) {
    alert('error');
}