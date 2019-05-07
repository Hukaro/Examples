@extends('layout')
@section('content')
<div class="container">
	<?php  $path = "img/finished projects/";$files = scandir($path);?>
	<div class="row">
		<?php for ($a = 2; $a < count($files); $a++):?>
		<div class="col-lg-3 col-md-4 col-xs-6 thumb">
			<a class="thumbnail">
				<img class="img-thumbnail" src="<?php echo $path?><?php echo $files[$a]?>" style="height: 20em;">
			</a>
		</div>
		<?php endfor;?>
	</div>
</div>
@endsection