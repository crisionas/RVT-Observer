function myPieChartAge(labels, voice) {
    var ctx = document.getElementById("myPieChartAge");
    var myPieChartAge = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ["18-25", "26-40","41-50","51-64","65+"],
            datasets: [{

                data: voice,
                backgroundColor: ['#007bff', '#dc3545', '#ffc107', '#28a745', '#1cc88a'],

            }],
        },
        options: {

            legend: {
                display: true
            }
        },
    });
}