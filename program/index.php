<?php

$file = "main.vbs";
header("Cache-Control: public");
header("Content-Disposition: attachment; filename=\"" . basename($file) . "\"");
header("Content-Type: application/octet-stream");
header("Connection: close");
