
<?php
//call chaine de connexion

//id,marque,couleur,numeroplaque,refProprietaire,refCategorie,nombreplace,compte,usersession FROM `tengin`
// Set a connection to the database

include('./connexion.php');
?>
<?php 
if(!empty($_POST['id']) && !empty($_POST['marque']) && !empty($_POST['numeroplaque']) && !empty($_POST['refProprietaire']) && !empty($_POST['refCategorie']) && !empty($_POST['nombreplace']) && !empty($_POST['usersession']))
	{
			// declarations des variables 
			$id=htmlspecialchars($_POST['id']);			
			$marque=htmlspecialchars($_POST['marque']);
			$couleur=htmlspecialchars($_POST['couleur']);	
			$numeroplaque=htmlspecialchars($_POST['numeroplaque']);	
			$refProprietaire=htmlspecialchars($_POST['refProprietaire']);	
			$refCategorie=htmlspecialchars($_POST['refCategorie']);	
			$nombreplace=htmlspecialchars($_POST['nombreplace']);					
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("UPDATE tengin SET marque=:marque,couleur=:couleur,numeroplaque=:numeroplaque,refProprietaire=:refProprietaire,refCategorie=:refCategorie,nombreplace=:nombreplace,usersession=:usersession where id=:id");
			        $stmt->bindParam("id", $id,PDO::PARAM_STR) ;
			        $stmt->bindParam("marque", $marque,PDO::PARAM_STR) ;
			        $stmt->bindParam("couleur", $couleur,PDO::PARAM_STR) ;
			        $stmt->bindParam("numeroplaque", $numeroplaque,PDO::PARAM_STR) ;
			        $stmt->bindParam("refProprietaire", $refProprietaire,PDO::PARAM_STR) ;
			        $stmt->bindParam("refCategorie", $refCategorie,PDO::PARAM_STR) ;
			        $stmt->bindParam("nombreplace", $nombreplace,PDO::PARAM_STR) ;			        
					$stmt->bindParam("usersession", $usersession,PDO::PARAM_STR) ;					
					
          			$stmt->execute();
          			$status= 'OK';
          			echo json_encode(array("response"=>$status));
    }
	else
	{
		$status= 'FAILED';
		echo json_encode(array("response"=>$status));
     	$error = "Echec d'Enregistrement";
   	}

   	
 ?>