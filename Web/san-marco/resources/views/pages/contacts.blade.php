@extends('layout')
@section('content')

<div class="contaoner" style="margin-top: 50px;">
	<div class="row">
		<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">
			<p>Адреса</p>
			<h2><?php $all_rows=DB::select('select * from text_fields');foreach ($all_rows as $row) {if($row->name=='adress'){echo $adress = $row->text;}}?></h2>			
			<p>Телефон</p>
			<h2><?php $all_rows=DB::select('select * from text_fields');foreach ($all_rows as $row) {if($row->name=='phone_number'){echo $phone_number = $row->text;}}?></h2>
			<p>Email</p>
			<h2><?php $all_rows=DB::select('select * from text_fields');foreach ($all_rows as $row) {if($row->name=='email'){echo $email = $row->text;}}?></h2>
		</div>
	</div>
	<div class="row">
		<div class="col-lg-12 col-md-12 text-center">
			<p>Режим роботи</p>
		</div>
	</div>
	<div class="row"  style=" margin: auto; max-width: 450px;">
		<div class="col-lg-2 col-md-2 text-center" style="padding: 0 10px;">
			<p>Пн-Пт</p>
			<p>з 9:00 до 18:00</p>
		</div>
		<div class="col-lg-8 col-md-8 text-center" style="padding: 0 10px;">
			<p>Сб</p>
			<p>працюємо в режимі неповного дня за умови попередньої домовленості</p>
		</div>
		<div class="col-lg-2 col-md-2 text-center" style="padding: 0 10px;">
			<p>Нд</p>
			<p>вихідний</p>
		</div>
	</div>
	<div class="jumbotron text-center" style="height: 650px; margin: 0;padding: 0;">
		<div id="map"></div>
		<script>
			function initMap() {
				var uluru = {lat: 48.462835, lng: 35.036190};
				var map = new google.maps.Map(
					document.getElementById('map'), {zoom: 16, center: uluru});
				var marker = new google.maps.Marker({position: uluru, map: map});
			}
		</script>
	</div>
</div>

@endsection