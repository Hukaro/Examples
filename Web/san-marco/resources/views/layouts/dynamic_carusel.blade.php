<div id="<?php echo $name?>" class="carousel slide" data-ride="carousel">
	<ol class="carousel-indicators">
		<?php $i = 0;for ($a = 2; $a < count($files); $a++):?>
			<li data-target="#<?php echo $name?>" data-slide-to="<?php echo $i?>" class="<?php echo $i==0?'active':'';?>"></li>
		<?php $i++;endfor;?>
	</ol>
	<div class="carousel-inner">
		<?php $i = 0;for ($a = 2; $a < count($files); $a++):
		$path_to_file= $path . $files[$a];?>
		<div class="item <?php echo $i==0?'active':'';?>">
			<img src="<?php echo $path_to_file;?>" id="caruser_fixer">
		</div>
		<?php $i++;endfor;?>
	</div>
	<a class="left carousel-control" href="#<?php echo $name?>" data-slide="prev">
		<span class="glyphicon glyphicon-chevron-left"></span>
		<span class="sr-only">Previous</span>
	</a>
	<a class="right carousel-control" href="#<?php echo $name?>" data-slide="next">
		<span class="glyphicon glyphicon-chevron-right"></span>
		<span class="sr-only">Next</span>
	</a>
</div>