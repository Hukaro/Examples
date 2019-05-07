<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('index');
});


Route::get('cv', function () {
    return view('pages/cv');
});

Route::get('contact', function () {
    return view('pages/contacts');
});

Route::get('gallery', function () {
    return view('pages/gallery');
});
Route::get('cah', function () {
    return view('pages/cah');
});