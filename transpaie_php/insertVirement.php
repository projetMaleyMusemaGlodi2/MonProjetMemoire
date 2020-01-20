
<?php
//call chaine de connexion

//id,montant,refAffectChauffeur,refEngin,libelle,datevirement,usersession FROM `tvirement`
// Set a connection to the database

include('./connexion.php');
?>
<?php 
// if(!empty($_POST['montant']) && !empty($_POST['refAffectChauffeur']) && !empty($_POST['refEngin']) && !empty($_POST['libelle']) && !empty($_POST['usersession']))
// 	{
// 			// declarations des variables 			
			
//     }
// 	else
// 	{
// 		$status= 'FAILED';
// 		echo json_encode(array("response"=>$status));
//      	$error = "Echec d'Enregistrement";
//    	}

			$montant=htmlspecialchars($_POST['montant']);
			$refAffectChauffeur=htmlspecialchars($_POST['refAffectChauffeur']);	
			$refEngin=htmlspecialchars($_POST['refEngin']);	
			$libelle=htmlspecialchars($_POST['libelle']);				
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("INSERT INTO tvirement (montant,refAffectChauffeur,refEngin,libelle,usersession) VALUES (:montant,:refAffectChauffeur,:refEngin,:libelle,:usersession)");
			        $stmt->bindParam("montant", $montant,PDO::PARAM_STR) ;
			        $stmt->bindParam("refAffectChauffeur", $refAffectChauffeur,PDO::PARAM_STR) ;
			        $stmt->bindParam("refEngin", $refEngin,PDO::PARAM_STR) ;
			        $stmt->bindParam("libelle", $libelle,PDO::PARAM_STR) ;			        
					$stmt->bindParam("usersession", $usersession,PDO::PARAM_STR) ;					
					
          			$stmt->execute();
          			$status= 'OK';
          			echo json_encode(array("response"=>$status));

   	
 ?>