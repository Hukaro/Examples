<nav class="navbar">
	<div class="navbar-header navbar-default navbar-fixed-top">
		<div class="container container-fluid" id="header_сontainer">
			<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#collapse-1" aria-expanded="false">
				<span class="icon-bar top-bar"></span>
				<span class="icon-bar middle-bar"></span>
				<span class="icon-bar bottom-bar"></span>
			</button>
			<div class="nav navbar-nav navbar-center">
				<a href="/" class="navbar-brand"><img id="brand_image" src="svg/logo.svg" alt="San Marco Logo"></a>
			</div>	
			<div class="collapse navbar-collapse" id="collapse-1">
				<ul class="nav navbar-nav navbar-left">
					<li class="nav-item"><a href="test">TEST</a></li>
					<li class="nav-item"><a href="company">Компанія</a></li>
					<li class="nav-item"><a href="gallery">Галерея</a></li>
					<li class="nav-item dropdown">
						<a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Матеріали<span class="caret"></span></a>
						<ul class="dropdown-menu" id="left_dropdown">
							<li class="nav-item"><a href="">Водорозчинні фарби</a></li>
							<li class="nav-item"><a href="">Декоративні покриття</a></li>
							<li class="nav-item"><a href="">Оздоблення фасадів</a></li>
							<li class="nav-item"><a href="">Грунтовки</a></li>
							<li class="nav-item"><a href="">Лаки та воски</a></li>
							<li class="nav-item"><a href="">Спеціальні продукти</a></li>
							<li class="nav-item"><a href="">Інструменти</a></li>
						</ul>
					</li>
				</ul>
				<ul class="nav navbar-nav navbar-right">
					<li class="nav-item dropdown">
						<a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Ефекти<span class="caret"></span></a>
						<?php $path = "img/effects/";
						$files = scandir($path);
						if(count($files)!=null):?>
							<ul class="dropdown-menu">
								<?php for ($i=2; $i < count($files); $i++):?>
									<li class="nav-item"><a href="<?php echo $files[$i]?>"><?php $texts=DB::select('select * from replacer');foreach ($texts as $text) {if($text->origin==$files[$i]){echo $text->replace;}}?></a></li>
								<?php endfor;?>
							</ul>
						<?php endif;?>
					</li>
					<li class="nav-item dropdown">
						<a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Корисне<span class="caret"></span></a>
						<ul class="dropdown-menu">
							<li class="nav-item"><a href="examples">Реалізовані проєкти</a></li>
							<li class="nav-item"><a href="">Another action</a></li>
							<li class="nav-item"><a href="">Something else here</a></li>
							<li role="separator" class="divider"></li>
							<li class="nav-item"><a href="">Separated link</a></li>
							<li role="separator" class="divider"></li>
							<li class="nav-item"><a href="">Test</a></li>
						</ul>
					</li>
					<li class="nav-item"><a href="contacts">Контакти</a></li>
				</ul>
			</div>
		</div>
	</div>
</nav>
<main>