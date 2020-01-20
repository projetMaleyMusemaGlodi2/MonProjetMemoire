include('./connexion.php');
?>
<?php 
if(!empty($_POST['id']) && !empty($_POST['refEngin']) && !empty($_POST['refChauffeur']) && !empty($_POST['usersession']))
	{
			// declarations des variables 			
			$id=htmlspecialchars($_POST['id']);
			$refEngin=htmlspecialchars($_POST['refEngin']);
			$refChauffeur=htmlspecialchars($_POST['refChauffeur']);			
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("UPDATE taffectationchauffeur SET refEngin=:refEngin, refChauffeur=:refChauffeur, usersession=:usersession WHERE id=:id");
					$stmt->bindParam("id", $id,PDO::PARAM_STR) ;
			        $stmt->bindParam("refEngin", $refEngin,PDO::PARAM_STR) ;
			        $stmt->bindParam("refChauffeur", $refChauffeur,PDO::PARAM_STR) ;
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