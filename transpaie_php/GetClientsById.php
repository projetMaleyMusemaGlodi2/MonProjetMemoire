<?php
	include('conn.php');

	$id=$_POST['id'];
    
		$rqt="SELECT * FROM tclient WHERE id='".$id."'";
		$rqt2=mysqli_query($connect,$rqt) OR die(mysql_error());

		$result=array();
		while($fetchData=$rqt2->fetch_assoc()){
			$result[]=$fetchData;
		}
		echo json_encode($result);

?>