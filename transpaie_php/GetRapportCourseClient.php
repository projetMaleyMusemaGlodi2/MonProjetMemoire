<?php
	include('conn.php');

	$date1=$_POST['date1'];
	$date2=$_POST['date2'];
	$refClient=$_POST['refClient'];
		$rqt="SELECT * FROM vpaiementTransport WHERE (datepaiement BETWEEN '".$date1."' AND '".$date2."') AND refClient='".$refClient."'";
		$rqt2=mysqli_query($connect,$rqt) OR die(mysql_error());

		$result=array();
		while($fetchData=$rqt2->fetch_assoc()){
			$result[]=$fetchData;
		}
		echo json_encode($result);

?>