<?php

$format = "page-%s.html";
$stack = ["ru", "uz"];
$default = "ru";

if (!isset($_GET["language"])) {
  header("Location: ?language=$default");
}

$language = $_GET["language"];
$condition = in_array($language, $stack);
require sprintf($format, $condition ? $language : $default);
