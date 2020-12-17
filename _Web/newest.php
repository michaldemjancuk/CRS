<?php

$images = glob('*.{zip}', GLOB_BRACE);

sort($images);

print_r($images[0]);

?>