<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>San Marco</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.5.13/css/mdb.min.css">
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Swiper/4.5.0/css/swiper.css">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Swiper/4.5.0/css/swiper.min.css">



	<link rel="stylesheet" href="css/album.css">
	<link rel="stylesheet" href="css/swiper.css">
	<link rel="stylesheet" href="css/gallery.css">
</head>
<body>
	<div id="wrap">
		@include('layouts.nav')
		@yield('content')
		@include('layouts.footer')


		<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
		<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
		<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.4/umd/popper.min.js"></script>

		<script src="https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.5.13/js/mdb.min.js"></script>
		<script src="https://cdnjs.cloudflare.com/ajax/libs/Swiper/4.5.0/js/swiper.js"></script>
		<script src="https://cdnjs.cloudflare.com/ajax/libs/Swiper/4.5.0/js/swiper.min.js"></script>
		<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAIl4PmR6XA9fbuQTM2bgAkev1imKUedn8&callback=initMap"></script>
		<script>
			$('ul.nav li.dropdown').hover(
				function(){$(this).find('.dropdown-menu').stop(true, true).delay(150).fadeIn(150);},
				function(){$(this).find('.dropdown-menu').stop(true, true).delay(150).fadeOut(150);});
		</script>
		<script type="text/javascript" src="js/swiper.js"></script>
		<script type="text/javascript" src="js/gallery.js"></script>
</body>
</html>