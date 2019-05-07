@extends('layout')
@section('content')
<div class="container">
	<div class="row">
		<?php $max_panes=3; for ($i=0; $i < $max_panes; $i++):?>
		<?php if ($max_panes%2!=0 && $i==$max_panes-1):?>
		<div class="col-lg-12 col-md-12 col-xs-12 thumb">
			<?php $id_num = "fuckMylife"?>
		<?php else:?>
		<div class="col-lg-6 col-md-6 col-xs-12 thumb">
			<?php $id_num = "IamOk"?>
		<?php endif;?>
			<a class="thumbnail text-center" href="#">
				<img class="img-thumbnail" src="http://dummyimage.com/400x400/4d494d/686a82.gif&text=placeholder+image" id="<?php echo $id_num?>">
				<h3>Lorem ipsum dolor.</h3>
			</a>
			<p class="text-center" style="margin:5px 25px;">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Harum molestias fugit sint deserunt voluptatem, voluptas asperiores dolorem aspernatur, nesciunt dolorum architecto. Nesciunt possimus blanditiis impedit, voluptatem deleniti distinctio sunt eius! Numquam laboriosam, quia laborum? Nulla veritatis dolores optio, quas beatae!</p>
		</div>
		<?php endfor?>
	</div>
</div>
@endsection