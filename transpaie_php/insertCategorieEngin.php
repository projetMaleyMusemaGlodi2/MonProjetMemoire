include('./connexion.php');
?>
<?php 
if(!empty($_POST['designation']))
	{
			// declarations des variables 			
			$designation=htmlspecialchars($_POST['designation']);
			
			$stmt = $dbConnection->prepare("INSERT INTO tcategorieengin (designation) VALUES (:designation)");
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