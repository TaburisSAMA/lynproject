<?php 

$data = array(
    "hoge" => 123,
    "foo" => 456,
    "bar" => 789,
    "aaa" => array(
        "abc" => 111,
        "bcd" => 222,
        "cde" => 333
    ),
    "bbb" => array(
        "def" => array(
            "efg" => "hoge"
        )
    )
);

//
//treffik data(date_from, date_to)
// -->games
//    -->match(id)[]
//	-->id_c
//	-->date
//	-->time
//	-->id_h
//	-->id_a
//	-->round(po)
//	-->result(ot,ps)
//	   -->g_h
//	   -->g_a
//	   -->p_h
//	   -->p_a
//	-->m_parts
//	   -->p1(h,a)
//	   -->p2(h,a)
//	-->odds
//	   -->bo(id)[]
//	      -->o1
//	      -->ox
//	      -->o2
//










$xml = new XmlWriter();
$xml->openMemory();
$xml->startDocument('1.0', 'UTF-8');
$xml->startElement('root');

function write(XMLWriter $xml, $data){
    foreach($data as $key => $value){
        if(is_array($value)){
            $xml->startElement($key);
            write($xml, $value);
            $xml->endElement();
            continue;
        }
        $xml->writeElement($key, $value);
    }
}
write($xml, $data);

$xml->endElement();
//echo $xml->outputMemory(true);


echo json_encode($data);


?>