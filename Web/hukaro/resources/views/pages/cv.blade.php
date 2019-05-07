@extends('layout')

@section('content')
<div class="container">
	<div class="jumbotron" id="my_cv">
		<div class="row" id="cv_header_row">
			<div class="col-md-8">
				<div class="row">
					<div class="col-md-6">
						<img src="http://dummyimage.com/250x300/4d494d/686a82.gif&text=placeholder+image" alt="placeholder+image" id="my_img">
					</div>
					<div class="col-md-6">
						<h1>OLEH ZINIUK</h1>
					</div>
				</div>
				
			</div>
			<div class="col-md-4 text-right" id="text_right_to_left">
				<p>Dnipro, Ukraine<i class="fas fa-home"></i></p>
				<p>+38(096) 536-73-90<i class="fas fa-phone"></i></p>
				<p>oleh.ziniuk@gmail.com<i class="fas fa-envelope"></i></p>
				<p>Lorem ipsum dolor sit.<i class="fas fa-link"></i></p>
			</div>
		</div>
		<hr>
		<div class="row" style="font-size: 18px;">
			<div class="col-md-12">
				<h2><i class="fas fa-wrench"></i>	SKILLS</h2>
				<dd>	
					<div class="row">
						<div class="col-md-6">
							<li>C/C#</li>
							<li>Java</li>
							<li>HTML, PHP, JavaScript, CSS</li>
						</div>			
						<div class="col-md-6">
							<li>Quick learning, adaptability, flexibility</li>
							<li>Fluent English, native Ukrainian and Russian, studing Polish</li>
						</div>		
					</div>		
				</dd>
				<hr>
				<h2><i class="fas fa-toolbox"></i>	EXPERIENCE</h2>
				<dd>			
					<p><b><mark>Frelance programmer | </mark></b>Philip Morris Europe SA</p>
					<h3>JUN 2015 - JUL 2015</h3>
					<p>Writing code for a mobile puzzle app.</p>
					<p><b><mark>Frelance programmer</mark></b></p>
					<h3>JUL 2015 - JUL 2016</h3>
					<p>Creating a remake of Lucon Fight Club (pretty olg flash game)</p>
					<p><b><mark>Intern | </mark></b>Apriorit</p>
					<h3>NOV 2018 - NOW</h3>
					<p>Studying tools and techniques for writing technical documentation. Writing technical documentation.</p>
					<a href="javascript:genPDF()">Lorem ipsum.</a>
				</dd>
				<hr>
				<h2><i class="fas fa-graduation-cap"></i>	EDUCATION</h2>
				<dd>			
					<h3>SEP 2012 - JUL 2016</h3>
					<p><b><mark>Bachelor’s degree | </mark></b>Oles Honhcar Dnipro Narional University</p>
					<p>Theoretical and practical knowledge in software architecture and development.</p>
					<h3>SEP 2016 - JUN 2018</h3>
					<p><b><mark>Master’s degree | </mark></b>Polish-Japanese Academy of Information Technology</p>
					<p>In-depth constructing the understanding of an IT product, major mechanisms and ways to acess its prigress. Learning newest IT technologies.</p>
				</dd>
				<hr>
				<h2><i class="fas fa-bars"></i>	SUMMARY</h2>
				<dd>
					<p>Creative and energetic graduate Oles Honchar Dnipro National University with Bachelor’s Degree in Computer Engineering bringing the passion for challenging tasks and knowledge. Reliable and friendly engineer able to complete tasks efficiently and work collaboratively in team environment.</p>
				</dd>
			</div>
		</div>
	</div>
</div>
@endsection