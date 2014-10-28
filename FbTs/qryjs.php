<?php
header("Content-Type: text/html; charset=ISO-8859-1");
include_once "../../../files/dbfuncs.inc";
$mysqli_;

//---------------------------------------------------------------------------
function my_sqli() {
	global $mysqli_;
	$b = is_null($mysqli_);
	if (is_null($mysqli_)) {
		$mysqli_ = new mysqli(db_server, db_user, db_passwort, db_name)
			or die("DB-error");
		if ($mysqli_->connect_errno) {
			die("Connect failed: ". $mysqli->connect_error);
		}
		//$mysqli_->set_charset('utf8');
	}
	return $mysqli_;
}

//---------------------------------------------------------------------------
function DbQueryJs($Query) {
//http://www.ehow.com/how_8762023_convert-query-json-php.html
	$qry = my_sqli()->query($Query)
		or die(my_sqli()->error);
	$json .= "[\n";

	$rows = 0; 
	
	$maximum = $qry->num_rows;  // The total rows in the query
	while($data = $qry->fetch_assoc()) {
		if(count($data) > 1) 
			$json .= "{\n";
		$num = 0;
		foreach($data as $key => $value) { // Break the query up
			if(count($data) > 1) 
				$json .= "\"$key\":\"$value\""; // This will come out as "key":"value"
			else 
				$json .= "\"$value\""; // If it is not in an associative array
			$num++;
			if($num < count($data)) 
				$json .= ",\n";
		}
		$rows++;
		if(count($data) > 1) $json .= "}";	//if(count($data) > 1) $json .= "}\n";
		if($rows < $maximum) $json .= ",\n"; 
	}
	$qry->free();
	$json .= "]\n";
	return $json;
}


if (isset($_GET['DbQueryJs'])) {
	if (isset($_GET['html'])) {
		echo $_GET['DbQueryJs']."<br>";
		echo nl2br(DbQueryJs($_GET['DbQueryJs']));
	}
	else {
		echo DbQueryJs($_GET['DbQueryJs']);
	}
}


?>