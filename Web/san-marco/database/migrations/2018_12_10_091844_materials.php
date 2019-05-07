<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class Materials extends Migration
{
    public function up()
    {
        Schema::create('materials', function (Blueprint $table) {
            $table->increments('id');
            $table->string('name');
            $table->string('translated_name');
            $table->string('base');
            $table->string('main');
            $table->string('text');
            $table->integer('price');
            $table->string('sufrace_type');
            $table->string('dilution');
            $table->string('consumption');
            $table->string('application');
        });
    }
    public function down()
    {
        Schema::dropIfExists('materials');
    }
}