$.ajax({
    url: "/home/getmonthly/",
    type: "GET",
    success: onSuccess,
    error: onErrorCall

});
function onSuccess(result) {
    var expenses = [];
    var revenues = [];
    var months = [];

    for (var i = 0; i < result.length; i++) {
        expenses.push(result[i].MonthExpense);
        revenues.push(result[i].MonthRevenue);
        months.push(result[i].Month);
    }

    var ctx = $("#BarChart")[0].getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: months,
            datasets: [{
                label: 'revenues',
                data: revenues,
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            },
            {
                label: 'expenses',
                data: expenses,
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            }]

        },
        options: {
            barValueSpacing: 20,
            scales: {
                yAxes: [{
                    ticks: {
                        min: 0
                    }
                }]
            }
        }
    });
}

function onErrorCall(response) {
    alert('error');
}

