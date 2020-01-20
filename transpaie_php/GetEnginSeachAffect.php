<?php
	include('conn.php');

	$refProprietaire=$_POST['refProprietaire'];
    
		$rqt="SELECT * FROM vEngin WHERE refProprietaire='".$refProprietaire."'";
		$rqt2=mysqli_query($connect,$rqt) OR die(mysql_error());

		$result=array();
		while($fetchData=$rqt2->fetch_assoc()){
			$result[]=$fetchData;
		}
		echo json_encode($result);

?>