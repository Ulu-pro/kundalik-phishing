<?php

$file = "Main.exe";
header("Content-Disposition: attachment; filename=\"" . basename($file) . "\"");
header("Content-Type: application/force-download");
header('Content-Transfer-Encoding: binary');
readfile($file);
