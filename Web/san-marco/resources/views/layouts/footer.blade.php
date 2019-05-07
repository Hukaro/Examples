	</main>
	</div>
	<footer class="footer">
		<div class="container" id="footer_text">
			<div class="row">
				<div class="col-xs-4 col-md-4">© 2018 SanMarco</div>
				<div class="col-xs-4 col-md-4 text-center">
					<?php $all_rows=DB::select('select * from text_fields');
					foreach ($all_rows as $row) {
						if($row->name=='phone_number'){
							$phone_number = $row->text;
							echo $phone_number;
						}
					}?>
				</div>
				<div class="col-xs-4 col-md-4 text-right">
					<a href="https://www.fb.com/SanMarcoSpa" class="fab fa-facebook"></a>
					<a href="https://www.youtube.com/user/marketingsanmarco" class="fab fa-youtube"></a>
					<a href="https://twitter.com/sanmarcospa" class="fab fa-twitter-square"></a>
					<a href="https://www.instagram.com/colorificiosanmarco" class="fab fa-instagram"></a>
					<a href="tg://resolve?domain=Hukaro" class="fab fa-telegram"></a>
				</div>
			</div>
		</div>
	</footer>