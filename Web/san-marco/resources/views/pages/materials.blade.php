@extends('layout')
@section('content')
<div class="container">
	<div class="row" style="margin-top: 50px;">
		<?php $_path=$path;$_texts=DB::select('select * from materials');?>
		<?php $folders = scandir($path)?>
		<?php for ($folder = 2; $folder < count($folders); $folder++):?>
		<?php $path = $_path."/".$folders[$folder]?>
		<div class="row">
			<div class="col-md-6 col-sm-6" id="materials_image">
				<img src="<?php echo $path;?>" alt="<?php echo $folders[$folder];?>">
			</div>
			<div class="col-md-6 col-sm-6">
				<div class="row">
					<div class="col-md-12">
						<?php foreach ($_texts as $text){if($text->name == basename($folders[$folder],".jpg") || $text->name == basename($folders[$folder],".png"))
							{
								$material_name=$text->translated_name;
								$just_name=$text->name;
								$base_name=$text->base;
								$main_name=$text->main;
								$contented_text=$text->text;
							}}?>
						<p><?php echo $material_name;?></p>
						<p><?php echo $just_name;?></p>
						<p><?php echo $base_name;?></p>
						<p><?php echo $main_name;?></p>
						<p><?php echo $contented_text;?></p>
					</div>
				</div>
			</div>
		</div>
		<hr>
		<?php endfor;?>
	</div>
</div>
@endsection