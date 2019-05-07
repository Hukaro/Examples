<?php $files = scandir($path);?>
<div class="swiper-container main-slider loading">
	<div class="swiper-wrapper">
		<?php $i = 0;for ($a = 2; $a < count($files); $a++):
		$path_to_file= $path.$files[$a];?>
		<div class="swiper-slide">
			<figure class="slide-bgimg" style="background-image:url(<?php echo $path_to_file;?>)">
				<img class="entity-img" src="<?php echo $path_to_file;?>"/>
			</figure>
			<div class="content">				
				<p class="title"><?php foreach ($_texts as $text) {if($text->text == $base_name){$needed_text=$text->title;}} echo $needed_text?></p>
				<span class="caption <?php echo $class?>"><?php foreach ($_texts as $text) {if($text->text == $folders[$folder]){$needed_text=$text->some_text;}}echo $needed_text?></span>
				<?php for ($z=0; $z < 4; $z++):
					if($z==0)
					{
						$icon = "img/icons/surface.png";
						$head = "Тип поверхні";
						$key = "surface_type";
					}
					elseif ($z==1)
					{
						$icon = "img/icons/drop.png";
						$head = "Розбавлення";
						$key =  "dilution";
					}
					elseif ($z==2)
					{
						$icon = "img/icons/layers.png";
						$head = "Витрати матеріалу";
						$key = "consumption";
					}
					else
					{
						$icon = "img/icons/aim.png";
						$head = "Застосування";
						$key = "application";
					}
					?>
					<div class="caption col-lg-3 col-md-3 col-sm-3 col-xs-6" style="height: 100%">
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