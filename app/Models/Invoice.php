<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;


/**
 * @method static where(string $string, $id)
 */
class Invoice extends Model
{
    //
    // protected $guarded=[];
    // protected $primaryKey = 'cat_id';
    // public $timestamps = false;

    protected $fillable = ['pro_id', 'quantity', 'session_id', 'user_id'];

}
