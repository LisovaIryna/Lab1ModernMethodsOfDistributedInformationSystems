fetch('/BallDown/GetChartDataAndTimeResult')
    .then(response => response.json())
    .then(data => {
        console.log(data);
        var context = document.getElementById('chart').getContext('2d');

        //Chart without animation
        var chart = new Chart(context, {
            type: 'line',
            data: {
                labels: data.labels,
                datasets: [
                    {
                        label: 'Пряма гора',
                        data: data.straightLinePoints,
                        borderColor: 'rgba(143, 196, 144, 1)',
                        fill: false,
                        pointRadius: 0
                    },
                    {
                        label: 'Параболічна гора',
                        data: data.parabolaPoints,
                        borderColor: 'rgba(196, 143, 195, 1)',
                        fill: false,
                        pointRadius: 0
                    }
                ]
            },
            options: {
                animation: false,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });

        let ballRadius = 10;
        let timeStraightLine = data.time.timeStraightLine;
        let timeParabola = data.time.timeParabola;

        //Animation of balls falling down
        function animateBalls() {
            const startTime = performance.now();

            document.getElementById('timeDisplayStraightLine').innerHTML = `Час спуску з прямої гори: ${timeStraightLine} с`;
            document.getElementById('timeDisplayParabola').innerHTML = `Час спуску з параболічної гори: ${timeParabola} с`;
            document.querySelector('.result').classList.remove('hidden');
            document.querySelector('.note').classList.remove('hidden');

            function animate(currentTime) {
                const elapsed = (currentTime - startTime) / 1000 / 7;

                let straightLineFraction = Math.min(elapsed / timeStraightLine, 1);
                let parabolaFraction = Math.min(elapsed / timeParabola, 1);

                let straightLineBallPosition = data.straightLinePoints[data.straightLinePoints.length - Math.floor(straightLineFraction * data.straightLinePoints.length)];
                let parabolaBallPosition = data.parabolaPoints[data.parabolaPoints.length - Math.floor(parabolaFraction * data.parabolaPoints.length)];

                chart.update();

                drawBall(chart, (1 - straightLineFraction) * 100, straightLineBallPosition, 'rgba(143, 196, 144, 1)');
                drawBall(chart, (1 - parabolaFraction) * 100, parabolaBallPosition, 'rgba(196, 143, 195, 1)');

                if (straightLineFraction < 1 || parabolaFraction < 1)
                    requestAnimationFrame(animate);
            }
            requestAnimationFrame(animate);
        }

        //Drawing balls
        function drawBall(chart, x, y, color) {
            var context = chart.ctx;

            var xPosition = chart.scales.x.getPixelForValue(x);
            var yPosition = chart.scales.y.getPixelForValue(y);

            if (xPosition >= chart.chartArea.left && xPosition <= chart.chartArea.right
                && yPosition >= chart.chartArea.top && yPosition <= chart.chartArea.bottom) {
                context.beginPath();
                context.arc(xPosition, yPosition, ballRadius, 0, 2 * Math.PI);
                context.fillStyle = color;
                context.fill();
                context.closePath();
            }
        }

        //Action when button has been clicked
        document.getElementById('startButton').addEventListener('click', function () {
            animateBalls();
        });
    });