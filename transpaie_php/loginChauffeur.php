<?php
	include('conn.php');

		$username=$_POST['username'];
		$password = $_POST['password'];
		$passwordhash =md5($password);
		
		$rqt='SELECT * FROM tchauffeur WHERE username = "'.$username.'" AND password = "'.$passwordhash.'"';
		$rqt2=mysqli_query($connect,$rqt) OR die(mysql_error());

		$result=array();
		while($fetchData=$rqt2->fetch_assoc()){
			$result[]=$fetchData;
		}
		echo json_encode($result);

?>