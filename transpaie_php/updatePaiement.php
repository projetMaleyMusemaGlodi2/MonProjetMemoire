
<?php
//call chaine de connexion

//id,montant,refClient,refAffectChauffeur,datepaiement,usersession FROM `tpaiement`
// Set a connection to the database

include('./connexion.php');
?>
<?php 
if(!empty($_POST['id']) &&!empty($_POST['montant']) && !empty($_POST['refClient']) && !empty($_POST['refAffectChauffeur']) && !empty($_POST['usersession']))
	{
			// declarations des variables 
			$id=htmlspecialchars($_POST['id']);			
			$montant=htmlspecialchars($_POST['montant']);
			$refClient=htmlspecialchars($_POST['refClient']);	
			$refAffectChauffeur=htmlspecialchars($_POST['refAffectChauffeur']);				
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("UPDATE tpaiement SET montant=:montant,refClient=:refClient,refAffectChauffeur=:refAffectChauffeur,usersession=:usersession where id=:id");
			        $stmt->bindParam("id", $id,PDO::PARAM_STR) ;
			        $stmt->bindParam("montant", $montant,PDO::PARAM_STR) ;
			        $stmt->bindParam("refClient", $refClient,PDO::PARAM_STR) ;
			        $stmt->bindParam("refAffectChauffeur", $refAffectChauffeur,PDO::PARAM_STR) ;		        
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