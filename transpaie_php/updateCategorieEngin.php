include('./connexion.php');
?>
<?php 
if(!empty($_POST['id']) && !empty($_POST['designation']))
	{
			// declarations des variables 	
			$id=htmlspecialchars($_POST['id']);		
			$designation=htmlspecialchars($_POST['designation']);
			
			$stmt = $dbConnection->prepare("UPDATE tcategorieengin SET designation=:designation WHERE id=:id");
					$stmt->bindParam("id", $id,PDO::PARAM_STR) ;
			        $stmt->bindParam("designation", $designation,PDO::PARAM_STR) ;
			        
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