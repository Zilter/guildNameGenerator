<!DOCTYPE html>
<html>
	<head>
	</head>
	<body>
		This is a name generator written by Christian Stokkebekk in Des. 2012. <br>
		The names generated are intended for fictional orginizations, such as guilds, shops and taverns. <br>
		The code should be available on my github: https://github.com/Zilter/guildNameGenerator <br><br><br>
		<form action="generator.php" method="get">
			How many names do you want?
			<br>
			<input type="number" name="number"/>
			<br>
			<br>
			<input type="submit" value="Generate" />
			<br>
			<br>
		</form>
	</body>
</html>
<?php

function inputFile($filename) {
	$file = file_get_contents($filename);
	$readText = explode("\n", $file);

	return $readText;
}



if (isset($_GET["number"])) {
	
	if ($_GET["number"] > 100) {
		
		$numberOfNames = 100;
		echo "Requested too many names. Showing 100: <br><br>";
	} 
	else {
		$numberOfNames = $_GET["number"];
	}
	
	$prefixChance = 40;
	$adjectiveChance = 75;
	$suffixChance = 40;

	$prefix = inputFile("prefix.txt");
	$adjective = inputFile("adjective.txt");
	$noun = inputFile("noun.txt");
	$suffix = inputFile("suffix.txt");

	for ($i = 0; $i < $numberOfNames; $i++) {
		if (rand(0, 99) < $prefixChance) {
			echo $prefix[rand(0, sizeof($prefix) - 1)] . " ";
		}

		if (rand(0, 99) < $adjectiveChance) {
			echo $adjective[rand(0, sizeof($adjective) - 1)] . " ";
		}

		echo $noun[rand(0, sizeof($noun) - 1)];

		if (rand(0, 99) < $suffixChance) {
			echo " " . $suffix[rand(0, sizeof($suffix) - 1)];
		}
		echo "<br>";
	}
}
?>