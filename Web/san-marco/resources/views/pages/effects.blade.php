@extends('layout')
@section('content')
<div class="container text-center">
	<?php $_path=$path;$_texts=DB::select('select * from effect_text');?>
	<?php $folders = scandir($path)?>
	<?php for ($folder = 2; $folder < count($folders); $folder++):?>
		<div class="row">
		<?php $name="carusel$folder"?>
		<?php $path = $_path.$folders[$folder].'/'?>
		<?php $files = scandir($path); $base_name = basename($path)?>
		<h2 style="color:#FF0000;"><?php foreach ($_texts as $text) {if($text->text == $base_name){$needed_text=$text->title;}} echo $needed_text?></h2>
		<hr class="my_hr" style="width: 20%;">
		<p><?php foreach ($_texts as $text) {if($text->text == $folders[$folder]){$needed_text=$text->some_text;}}echo $needed_text?></p>
		<hr class="my_hr" style="width: 10%;">
		@include ('layouts/dynamic_carusel')	
		<div class="row" style="height: 100px;">
			<?php for ($i=0; $i < 4; $i++):?>
			<?php if($i==0){
				$icon = "img/icons/surface.png";
				$head ="Тип поверхні";
				$key = "surface_type";}
			elseif ($i==1){
				$icon = "img/icons/drop.png";
				$head ="Розбавлення";
				$key = "dilution";}
			elseif ($i==2){
				$icon = "img/icons/layers.png";
				$head ="Витрати матеріалу";
				$key = "consumption";}
			else{
				$icon = "img/icons/aim.png";
				$head ="Застосування";
				$key = "application";}
			?>
			<div class="col-lg-3 col-md-3 col-sm-3 col-xs-6" style="height: 100%">
				<div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 effect_icons">
					<img src="<?php echo $icon?>"; style="height: 40px">
				</div>
				<div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 effect_text">
					<h4 style="margin-left:5px;"><?php echo $head;?></h4>
					<h5 style="margin-left:5px;"><?php foreach ($_texts as $text) {if($text->text == $folders[$folder]){$needed_text=$text->$key;}} echo $needed_text?></h5>
				</div>
			</div>
			<?php endfor?>
		</div>
		<hr class="my_hr" style="width: 100%;">
		</div>
	<?php endfor;?>
</div>
@endsection