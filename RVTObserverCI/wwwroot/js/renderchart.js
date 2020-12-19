function renderChart(labels, voice) {
    var ctx = document.getElementById('myChart').getContext('2d');
    var renderChart = new Chart(ctx,
        {
            type: 'bar',
            data: {
                labels: ["Green Party", "Red Party", "Blue Party", "Yellow Party", "Rose Party"],
                datasets: [
                    {

                        data: voice,
                        backgroundColor: [
                            'rgba(0,219,15,1)',
                            'rgba(227,0,0, 1)',
                            'rgba(0,4,236, 1)',
                            'rgba(218,231,11, 1)',
                            'rgba(253,0,255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderColor: [
                            'rgba(0,219,15,1)',
                            'rgba(227,0,0, 1)',
                            'rgba(0,4,236, 1)',
                            'rgba(218,231,11, 1)',
                            'rgba(253,0,255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }
                ]
            },
            options: {
                legend: {
                    display: false
                },
                scales: {
                    xAxes: [{
                        gridLines: {
                            display: false
                        }
                    }],
                    yAxes: [
                        {
                            ticks: {
                                display: false,
                            },
                            gridLines: {
                                display: false
                            }

                        }
                    ]
                }
            }
        });
}