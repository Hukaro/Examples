<?php

Route::get('/', function () {
    return view('index', ['path' => 'img/main_page_carusel/']);
});

Route::get('gallery', function () {
    return view('pages/gallery', ['path' => 'img/gallery/']);
});

Route::get('water', function () {
    return view('pages/materials');
});
Route::get('company', function () {
    return view('pages/company');
});
Route::get('contacts', function () {
    return view('pages/contacts');
});
Route::get('examples', function () {
    return view('pages/finished');
});
/*All effects*/
Route::get('art', function () {
	return view('pages/effects', ['path' => 'img/effects/art/']);
});
Route::get('conrete', function () {
	return view('pages/effects', ['path' => 'img/effects/conrete/']);
});
Route::get('stone', function () {
	return view('pages/effects', ['path' => 'img/effects/stone/']);
});
Route::get('crystal', function () {
	return view('pages/effects', ['path' => 'img/effects/crystal/']);
});
Route::get('metal', function () {
	return view('pages/effects', ['path' => 'img/effects/metal/']);
});
Route::get('nacre', function () {
	return view('pages/effects', ['path' => 'img/effects/nacre/']);
});
Route::get('velvet', function () {
	return view('pages/effects', ['path' => 'img/effects/velvet/']);
});
Route::get('sand', function () {
	return view('pages/effects', ['path' => 'img/effects/sand/']);
});
Route::get('travertine', function () {
	return view('pages/effects', ['path' => 'img/effects/travertine/']);
});
Route::get('texture', function () {
	return view('pages/effects', ['path' => 'img/effects/texture/']);
});
/*
Route::get('test', function () {
    return view('pages/materials', ['path' => 'img/materials/decorative coatings']);
});/**/
Route::get('test', function () {
    return view('pages/test', ['path' => 'img/effects/travertine/', 'class' => '']);
});