		if(document.getElementById("doughnutChart")){
		var ctxD = document.getElementById("doughnutChart").getContext('2d');
		var myLineChart = new Chart(ctxD, {
			type: 'doughnut',
			data: {
				labels: ["English", "Creativity", "Teamwork"],
				datasets: [{
					data: [85, 80, 80],
					backgroundColor: ["#F7464A", "#46BFBD", "#FDB45C"],
					hoverBackgroundColor: ["#FF5A5E", "#5AD3D1", "#FFC870"]
				}]
			},
			options: {
				responsive: true
			}
		});};