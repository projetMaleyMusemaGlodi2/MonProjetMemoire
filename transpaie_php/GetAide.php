<?php
	include('conn.php');

	    $rqt="SELECT * FROM taide ORDER BY id DESC";
		$rqt2=mysqli_query($connect,$rqt) OR die(mysql_error());

		$result=array();
		while($fetchData=$rqt2->fetch_assoc()){
			$result[]=$fetchData;
		}
		echo json_encode($result);

?>