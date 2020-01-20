
<?php
//call chaine de connexion

//id,montant,refClient,refAffectChauffeur,datepaiement,usersession FROM `tpaiement`
// Set a connection to the database

include('./connexion.php');
?>
<?php 

            $montant=htmlspecialchars($_POST['montant']);
			$refClient=htmlspecialchars($_POST['refClient']);	
			$refAffectChauffeur=htmlspecialchars($_POST['refAffectChauffeur']);				
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("INSERT INTO tpaiement (montant,refClient,refAffectChauffeur,usersession) VALUES (:montant,:refClient,:refAffectChauffeur,:usersession)");
			        $stmt->bindParam("montant", $montant,PDO::PARAM_STR) ;
			        $stmt->bindParam("refClient", $refClient,PDO::PARAM_STR) ;
			        $stmt->bindParam("refAffectChauffeur", $refAffectChauffeur,PDO::PARAM_STR) ;		        
					$stmt->bindParam("usersession", $usersession,PDO::PARAM_STR) ;					
					
          			$stmt->execute();
          			$status= 'OK';
          			echo json_encode(array("response"=>$status));
   	
 ?>