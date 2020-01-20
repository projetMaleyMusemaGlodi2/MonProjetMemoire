<?php 



include('conn.php');
 
	        $image = $_FILES['image']['name'];	              
			$noms = mysqli_real_escape_string($connect,$_POST["noms"]);
            $adresse =mysqli_real_escape_string($connect,$_POST["adresse"]);
			$contact =mysqli_real_escape_string($connect, $_POST["contact"]);
			$mail = mysqli_real_escape_string($connect,$_POST["mail"]);
			$typepieceid = mysqli_real_escape_string($connect,$_POST["typepieceid"]);
			$numeropieceid = mysqli_real_escape_string($connect,$_POST["numeropieceid"]);
			$username = mysqli_real_escape_string($connect,$_POST["username"]);
			$password = $_POST["password"];
			$passwordhash =md5($password);			
			$usersession = mysqli_real_escape_string($connect,$_POST["usersession"]);
			
$imagePath="./images/".$image;
move_uploaded_file($_FILES['image']['tmp_name'],$imagePath);
			$sql="INSERT INTO tclient (noms,adresse,contact,mail,typepieceid,numeropieceid,image,username,password,usersession) VALUES('".$noms."','".$adresse."','".$contact."','".$mail."','".$typepieceid."','".$numeropieceid."','".$image."','".$username."','".$passwordhash."','".$usersession."')";
			$connect->query($sql);


?>