<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class EffectsTextFields extends Migration
{
    public function up()
    {
        Schema::create('effect_text', function (Blueprint $table) {
            $table->increments('id');
            $table->string('title');
            $table->string('some_text');
            $table->string('sufrace_type');
            $table->string('dilution');
            $table->string('consumption');
            $table->string('application');
        });
    }
    public function down()
    {
        Schema::dropIfExists('effect_text');
    }
}