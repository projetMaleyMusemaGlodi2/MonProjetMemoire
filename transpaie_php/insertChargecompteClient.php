
<?php
//call chaine de connexion

//id,refClient,montant,datecharge,usersession FROM `tchargecompteclient`
include('./connexion.php');
?>
<?php 
if(!empty($_POST['refClient']) && !empty($_POST['montant']) && !empty($_POST['usersession']))
	{
			// declarations des variables 			
			$refClient=htmlspecialchars($_POST['refClient']);
			$montant=htmlspecialchars($_POST['montant']);			
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("INSERT INTO tchargecompteclient (refClient,montant,usersession) VALUES (:refClient,:montant,:usersession)");
			        $stmt->bindParam("refClient", $refClient,PDO::PARAM_STR) ;
			        $stmt->bindParam("montant", $montant,PDO::PARAM_STR) ;
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