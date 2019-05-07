<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class AllTextFields extends Migration
{
    public function up()
    {
        Schema::create('text_fields', function (Blueprint $table) {
            $table->increments('id');
            $table->string('name');
            $table->string('text');
        });
    }
    public function down()
    {
        Schema::dropIfExists('text_fields');
    }
}