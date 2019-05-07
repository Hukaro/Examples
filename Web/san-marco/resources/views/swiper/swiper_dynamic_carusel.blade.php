<?php $files = scandir($path);?>
<div class="swiper-container main-slider loading">
	<div class="swiper-wrapper">
		<?php $i = 0;for ($a = 2; $a < count($files); $a++):
		$path_to_file= $path.$files[$a];?>
		<div class="swiper-slide">
			<figure class="slide-bgimg" style="background-image:url(<?php echo $path_to_file;?>)">
				<img class="entity-img" src="<?php echo $path_to_file;?>"/>
			</figure>
		</div>
		<?php $i++;endfor;?>
	</div>
	<div class="swiper-button-prev swiper-button-white"></div>
	<div class="swiper-button-next swiper-button-white"></div>
</div>
<div class="swiper-container nav-slider loading">
	<div class="swiper-wrapper" role="navigation">
		<?php $i = 0;for ($a = 2; $a < count($files); $a++):
		$path_to_file= $path.$files[$a];?>
		<div class="swiper-slide">
			<figure class="slide-bgimg" style="background-image:url(<?php echo $path_to_file;?>)">
				<img class="entity-img" src="<?php echo $path_to_file;?>"/>
			</figure>
		</div>
		<?php $i++;endfor;?>
	</div>
</div>