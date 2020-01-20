<?php
// demarrage des variables de session au lancement de la page
	//session_start();
$hostname='localhost';
$username="root";
$pwd="root";
$bd='transpie_db';
	try {
	$dbConnection = new PDO("mysql:host=localhost;dbname=".$bd, $username, $pwd);	
	$dbConnection->exec("set names utf8");
	$dbConnection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	return $dbConnection;
    }  catch (PDOException $e) {
    echo 'Connection failed: ' . $e->getMessage();
	}
?>