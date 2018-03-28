$.ajax({
    url: "/home/getmonthly/",
    type: "GET",
    success: onSuccess,
    error: onErrorCall

});
function onSuccess(result) {
    var ctx = $("#BarChart")[0].getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: "something",
            datasets: [{
                label: 'revenues',
                data: result.Revenues,
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            },
            {
                label: 'expenses',
                data: result.Expenses,
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

