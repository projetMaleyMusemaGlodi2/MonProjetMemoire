
<?php
//call chaine de connexion

//id,refEngin,refChauffeur,dateAffectation,usersession
// Set a connection to the database

include('./connexion.php');
?>
<?php 
// if(!empty($_POST['refEngin']) && !empty($_POST['refChauffeur']) && !empty($_POST['usersession']))
// 	{
// 			// declarations des variables 			
			
//     }
// 	else
// 	{
// 		$status= 'FAILED';
// 		echo json_encode(array("response"=>$status));
//      	$error = "Echec d'Enregistrement";
//    	}

			$refEngin=htmlspecialchars($_POST['refEngin']);
			$refChauffeur=htmlspecialchars($_POST['refChauffeur']);			
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("INSERT INTO taffectationchauffeur (refEngin, refChauffeur, usersession) VALUES (:refEngin, :refChauffeur, :usersession)");
			        $stmt->bindParam("refEngin", $refEngin,PDO::PARAM_STR) ;
			        $stmt->bindParam("refChauffeur", $refChauffeur,PDO::PARAM_STR) ;
					$stmt->bindParam("usersession", $usersession,PDO::PARAM_STR) ;					
					
          			$stmt->execute();
          			$status= 'OK';
          			echo json_encode(array("response"=>$status));
   	
 ?>