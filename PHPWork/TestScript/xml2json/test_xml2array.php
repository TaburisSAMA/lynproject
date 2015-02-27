<?php 
//ini_set("memory_limit","512M");

//	include 'xml2ary.php';
//	$xml=xml2json(file_get_contents('test100.xml'));
//	echo json_encode($xml);
	
	
	
function contents($parser, $data){
    echo $data;
}

function startTag($parser, $data){
    echo "<b>";
}

function endTag($parser, $data){
    echo "</b><br />";
}
	$xml_parser  =  xml_parser_create();
	xml_set_element_handler($xml_parser, "startTag", "endTag");
	xml_set_character_data_handler($xml_parser, "contents"); 

	xml_parse();


?>