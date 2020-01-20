
<?php
//call chaine de connexion

//id,marque,couleur,numeroplaque,refProprietaire,refCategorie,nombreplace,compte,usersession FROM `tengin`
// Set a connection to the database

include('./connexion.php');
?>
<?php 
//marque,couleur,numeroplaque,refProprietaire,refCategorie,nombreplace,compte,usersession
            $marque=htmlspecialchars($_POST['marque']);
			$couleur=htmlspecialchars($_POST['couleur']);	
			$numeroplaque=htmlspecialchars($_POST['numeroplaque']);	
			$refProprietaire=htmlspecialchars($_POST['refProprietaire']);	
			$refCategorie=htmlspecialchars($_POST['refCategorie']);	
			$nombreplace=htmlspecialchars($_POST['nombreplace']);	
			$compte=htmlspecialchars($_POST['compte']);			
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("INSERT INTO tengin (marque,couleur,numeroplaque,refProprietaire,refCategorie,nombreplace,compte,usersession) VALUES (:marque,:couleur,:numeroplaque,:refProprietaire,:refCategorie,:nombreplace,:compte,:usersession)");
			        $stmt->bindParam("marque", $marque,PDO::PARAM_STR) ;
			        $stmt->bindParam("couleur", $couleur,PDO::PARAM_STR) ;
			        $stmt->bindParam("numeroplaque", $numeroplaque,PDO::PARAM_STR) ;
			        $stmt->bindParam("refProprietaire", $refProprietaire,PDO::PARAM_STR) ;
			        $stmt->bindParam("refCategorie", $refCategorie,PDO::PARAM_STR) ;
			        $stmt->bindParam("nombreplace", $nombreplace,PDO::PARAM_STR) ;
			        $stmt->bindParam("compte", $compte,PDO::PARAM_STR) ;
					$stmt->bindParam("usersession", $usersession,PDO::PARAM_STR) ;					
					
          			$stmt->execute();
          			$status= 'OK';
          			echo json_encode(array("response"=>$status));
   	
 ?>