function genPDF(){
			var doc = new jsPDF();

			doc.fromHTML($('#my_cv').get(0),20,20,{
				'with':500});

			doc.save('test.pdf');
		}