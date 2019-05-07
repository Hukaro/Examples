<?php $files = scandir($path);?>
<div class="row">
	<?php for ($a = 2; $a < count($files); $a++):?>
	<div class="col-lg-3 col-md-4 col-xs-6 thumb">
		<a class="thumbnail">
			<img class="img-thumbnail" src="<?php echo $path?><?php echo $files[$a]?>" style="height: 20em;">
		</a>
	</div>
	<!-- Trigger the Modal -->
<img id="myImg" src="img/gallery/qwe1.jpg" alt="Snow" style="width:100%;max-width:300px">

<!-- The Modal -->
<div id="myModal" class="modal">

  <!-- The Close Button -->
  <span class="close">&times;</span>

  <!-- Modal Content (The Image) -->
  <img class="modal-content" id="img01">

  <!-- Modal Caption (Image Text) -->
  <div id="caption"></div>
</div> 
	<?php endfor;?>
</div>