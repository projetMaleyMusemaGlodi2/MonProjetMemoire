
<?php
//call chaine de connexion

//id,refAffectChauffeur,montant,dateretrait,libelle,usersession
// Set a connection to the database

include('./connexion.php');
?>
<?php 

            $refAffectChauffeur=htmlspecialchars($_POST['refAffectChauffeur']);
            $montant=htmlspecialchars($_POST['montant']);
			$libelle=htmlspecialchars($_POST['libelle']);					
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("INSERT INTO tretraitbus (refAffectChauffeur,montant,libelle,usersession) VALUES (:refAffectChauffeur,:montant,:libelle,:usersession)");
					$stmt->bindParam("refAffectChauffeur", $refAffectChauffeur,PDO::PARAM_STR) ;
			        $stmt->bindParam("montant", $montant,PDO::PARAM_STR) ;
			        $stmt->bindParam("libelle", $libelle,PDO::PARAM_STR) ;			        		        
					$stmt->bindParam("usersession", $usersession,PDO::PARAM_STR) ;					
					
          			$stmt->execute();
          			$status= 'OK';
          			echo json_encode(array("response"=>$status));
   	
 ?>