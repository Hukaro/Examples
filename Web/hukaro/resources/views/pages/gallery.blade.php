@extends('layout')

@section('content')
<div class="container">
	<div class="jumbotron">
		<div class="row">
			<?php for ($a = 0; $a < 9; $a++):?>
			<div class="col-lg-4 col-md-4 col-sm-4 col-xs-6">
				<a class="thumbnail text-center" href="" id="my_thumbnail">
					<img src="http://dummyimage.com/100x250/4d494d/686a82.gif&text=placeholder+image" alt="placeholder+image" id="my_img">
				</a>
			</div>
			<?php endfor;?>
		</div>
	</div>
</div>
@endsection