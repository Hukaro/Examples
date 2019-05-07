@extends('layout')

@section('content')
		<div class="container">
			<div class="jumbotron">
				<div class="row">
					<div class="col-md-6">
						<h2 class="text-center">Lorem ipsum dolor.</h2>
						<p class="lead">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quisquam optio dignissimos vero ut, esse laudantium deleniti, ipsam debitis? Ad, saepe, praesentium. Vitae sequi voluptas veritatis necessitatibus nesciunt enim voluptatibus aut doloribus. Totam optio voluptatum deleniti magnam adipisci corporis laboriosam saepe vero nesciunt sequi mollitia, earum iure amet hic debitis facilis.</p>
						<button type="button" class="btn btn-outline-primary btn-lg btn-block">Button</button>
					</div>
					<div class="col-md-6">
						@include('pages.contacts')
					</div>
				</div>
			</div>
			<hr>
				<h1 class="text-center">SKILLS</h1>
			<div class="jumbotron">
				<div class="row">
					<div class="col-md-5">
						<h2 class="text-center">Professional skills</h2>
						<div>
							<p>Lorem ipsum dolor sit amet.</p>
							<div class="progress" style="height: 5px;">
								<div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
						</div>
						<div>
							<p>Lorem ipsum dolor sit amet.</p>
							<div class="progress" style="height: 5px;">
								<div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
						</div>
						<div>
							<p>Lorem ipsum dolor sit amet.</p>
							<div class="progress" style="height: 5px;">
								<div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
						</div>
						<div>
							<p>Lorem ipsum dolor sit amet.</p>
							<div class="progress" style="height: 5px;">
								<div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
						</div>
						<div>
							<p>Lorem ipsum dolor sit amet.</p>
							<div class="progress" style="height: 5px;">
								<div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
							</div>
						</div>
					</div>
					<div class="col-md-2">
						<div class="collapse navbar-collapse" id="collapse-1">
							<div class="vert_line" style="width: 3px;height: 350px;"></div>
						</div>
					</div>
					<div class="col-md-5 text-center">
						<h2>Aditional skills</h2>
						<canvas id="doughnutChart"></canvas>
						<hr>
						<div class="row">
							<div class="col-md-6 text-left">
								<li>Lorem.</li>
								<li>Lorem.</li>
								<li>Lorem.</li>
							</div>
							<div class="col-md-6 text-left">
								<li>Lorem.</li>
								<li>Lorem.</li>
								<li>Lorem.</li>
							</div>
						</div>
					</div>
				</div>
			</div>
			<hr>
			<h1 class="text-center">EDUCATION</h1>
			<div class="row">
				<div class="col-lg-4 col-md-4 col-sm-4 col-xs-6"> 
					<div class="thumbnail">
						<div class="caption">
							<h3>Lorem ipsum dolor.</h3>
							<p><i class="fas fa-university"></i> Lorem ipsum dolor sit amet.</p>
							<p><i class="fas fa-file-alt"></i> Lorem ipsum dolor sit amet, consectetur.</p>
							<hr>
							<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Laborum cumque dolore dolorum, adipisci officia eum.</p>
						</div>
					</div>
				</div>
				<div class="col-lg-4 col-md-4 col-sm-4 col-xs-6"> 
					<div class="thumbnail">
						<div class="caption">
							<h3>Lorem ipsum dolor.</h3>
							<p><i class="fas fa-university"></i> Lorem ipsum dolor sit amet.</p>
							<p><i class="fas fa-file-alt"></i> Lorem ipsum dolor sit amet, consectetur.</p>
							<hr>
							<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Laborum cumque dolore dolorum, adipisci officia eum.</p>
						</div>
					</div>
				</div>
				<div class="col-lg-4 col-md-4 col-sm-4 col-xs-6"> 
					<div class="thumbnail">
						<div class="caption">
							<h3>Lorem ipsum dolor.</h3>
							<p><i class="fas fa-university"></i> Lorem ipsum dolor sit amet.</p>
							<p><i class="fas fa-file-alt"></i> Lorem ipsum dolor sit amet, consectetur.</p>
							<hr>
							<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Laborum cumque dolore dolorum, adipisci officia eum.</p>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
@endsection