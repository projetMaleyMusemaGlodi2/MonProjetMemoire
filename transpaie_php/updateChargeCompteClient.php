
<?php
//call chaine de connexion

//id,refClient,montant,datecharge,usersession FROM `tchargecompteclient`
include('./connexion.php');
?>
<?php 
if(!empty($_POST['id']) &&!empty($_POST['refClient']) && !empty($_POST['montant']) && !empty($_POST['usersession']))
	{
			// declarations des variables 	
			$id=htmlspecialchars($_POST['id']);		
			$refClient=htmlspecialchars($_POST['refClient']);
			$montant=htmlspecialchars($_POST['montant']);			
			$usersession=htmlspecialchars($_POST['usersession']);			

			$stmt = $dbConnection->prepare("UPDATE tchargecompteclient SET refClient=:refClient,montant=:montant,usersession=:usersession WHERE id=:id");
			        $stmt->bindParam("id", $id,PDO::PARAM_STR) ;
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