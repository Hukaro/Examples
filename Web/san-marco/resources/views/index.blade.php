@extends('layout')

@section('content')
<div class="container text-center">
	<div class="container" id ="my_carousel">
		<?php $files = scandir($path);
		$name="carusel"?>
		@include ('layouts/dynamic_carusel')
	</div>
	<div class="row">
		<?php for ($a = 0; $a < 4; $a++):?>
		<div class="col-lg-3 col-md-3 col-sm-3 col-xs-6"> 
			<a href="#" class="thumbnail">
				<img class="img-thumbnail" src="http://dummyimage.com/400x400/4d494d/686a82.gif&text=placeholder+image">
			</a>
		</div>
		<?php endfor;?>
	</div>
	<div class="row">
		<div class="col-lg-4 col-md-4 col-sm-4 col-xs-6"> 
			<div class="thumbnail text-center" id="contact_icons">
				<p>Телефонуйте</p>
				<span class="glyphicon glyphicon-earphone" id="glyphicon_icons"></span>
				<p><?php $all_rows=DB::select('select * from text_fields');foreach ($all_rows as $row) {if($row->name=='phone_number'){echo $phone_number = $row->text;}}?></p>
			</div>
		</div>
		<div class="col-lg-4 col-md-4 col-sm-4 col-xs-6"> 
			<a class="thumbnail text-center" id="contact_icons">
				<p>Пишіть</p>
				<span class="glyphicon glyphicon-envelope" id="glyphicon_icons"></span>
				<p><?php $all_rows=DB::select('select * from text_fields');foreach ($all_rows as $row) {if($row->name=='email'){echo $email = $row->text;}}?></p>
			</a>
		</div>
		<div class="col-lg-4 col-md-4 col-sm-4 col-xs-12"> 
			<a class="thumbnail text-center" id="contact_icons">
				<p>Карта проїзду</p>
				<span class="glyphicon glyphicon-map-marker" id="glyphicon_icons"></span>
				<p><?php $all_rows=DB::select('select * from text_fields');foreach ($all_rows as $row) {if($row->name=='adress'){echo $adress = $row->text;}}?></p>
			</a>
		</div>	
	</div>
	<div class="container text-center">
		<div class="jumbotron">
			<h1 class="display-4">San Marco – надійний партнер Ваших проектів!</h1>
			<p class="lead">Продукція італійського заводу San Marco має сильні конкурентні переваги та швидко набирає популярності в Україні. А все завдяки унікальному поєднанню трьох складових успіху: висока якість екологічних матеріалів, найбільший асортимент продукції від економ до преміум класу та продуманий сервіс для кожного клієнта. Завітайте до фірмового салону Сан Марко у Дніпрі!</p>
			<button type="button" class="btn btn-outline-danger btn-lg btn-block">Детальніше</button>
		</div>
	</div>
</div>
@endsection