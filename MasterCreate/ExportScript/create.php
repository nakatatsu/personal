<?php
/**
 * 試しにデータをmessagepack形式で保存してみる
 *
 */
$pdo = new PDO('mysql:host=localhost;dbname=test_master;charset=utf8','root','password');

$statement = $pdo->query("SELECT * FROM test;");

$dataList = $statement->fetchAll(PDO::FETCH_ASSOC);

// $fp = fopen('data.mpac', 'w');
// fwrite($fp, msgpack_pack($dataList));
// fclose($fp);
$filename = 'test.mpac';

file_put_contents($filename, msgpack_pack($dataList));

$unpacked = msgpack_unpack(file_get_contents($filename));

var_dump($unpacked);
