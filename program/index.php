<?php

$file = "main.vbs";
header("Content-Disposition: attachment; filename=\"" . basename($file) . "\"");
header("Content-Type: application/octet-stream");
header("Content-Length: " . filesize($file));
header("Connection: close");
