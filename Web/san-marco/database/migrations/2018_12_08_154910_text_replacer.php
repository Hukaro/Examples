<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class TextReplacer extends Migration
{
    public function up()
    {
        Schema::create('replacer', function (Blueprint $table) {
            $table->increments('id');
            $table->string('origin');
            $table->string('replace');
        });
    }
    public function down()
    {
        Schema::dropIfExists('replacer');
    }
}
