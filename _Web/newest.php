<?php

$crsFiles = glob('*.{zip}', GLOB_BRACE);

usort($crsFiles, 'version_compare');


print_r($crsFiles[count($crsFiles) - 1]);

?>