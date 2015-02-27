<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>FindItemsAdvanced</title>
<script src="./js/jQuery.js"></script>
<script src="./js/jQueryUI/ui.tablesorter.js"></script>

<script>
    $(document).ready(function() { 
        $("table").tablesorter({ 
            sortList:[[7,0],[4,0]],      // upon screen load, sort by col 7, 4 ascending (0)
            debug: false,                // if true, useful to debug Tablesorter issues
            headers: { 
                0: { sorter: false },    // col 0 = first = left most column - no sorting
                5: { sorter: false }, 
                6: { sorter: false },
                7: { sorter: 'text'}     // specify text sorter, otherwise mistakenly takes shortDate parser
            } 
        }); 
    });
</script>
  
</head>
<body>

<link rel="stylesheet" href="./css/flora.all.css" type="text/css" media="screen" title="Flora (Default)">

<form action="FindItemsAdvanced.php" method="post">
<table cellpadding="2" border="0">
    <tr>
        <th>Query</th>
        <th>Site to Search</th>
        <th>Max Price</th>
        <th>Items per range</th>
        <th>Debug</th>
    </tr>    
    <tr>
        <td><input type="text" name="Query" value="ipod"></td>
        <td>
        <select name="SiteID">
            <option value="15">Australia - 15 - AUD</option>
            <option value="2">Canada - 2 - CAD</option>
            <option value="77">Germany - 77 - EUR</option>
            <option value="3">United Kingdom - 3 - GBP</option>
            <option value="0">United States - 0 - USD</option>
            </select>
        </td>
        <td><input type="text" name="MaxPrice" value="500"></td>
        <td>
        <select name="ItemsPerRange">
            <option value="1">1</option>
            <option value="2">2</option>
            <option selected value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            </select>
        </td>
        <td>
        <select name="Debug">
            <option value="1">true</option>
            <option selected value="0">false</option>
            </select>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center"><INPUT type="submit" name="submit" value="Search">
        </td>
    </tr>
</table>
</form>


<?php

require_once('DisplayUtils.php');  // functions to aid with display of information

error_reporting(E_ALL);  // turn on all errors, warnings and notices for easier debugging
    
$results = '';

if(isset($_POST['Query']))
{
    $endpoint = 'http://open.api.ebay.com/shopping';  // URL to call
    $responseEncoding = 'XML';   // Format of the response 

    $safeQuery = urlencode($_POST['Query']); 
    $siteID    = $_POST['SiteID'];   

    $priceRangeMin = 0.0;
    $priceRangeMax = $_POST['MaxPrice'];
    $itemsPerRange = $_POST['ItemsPerRange'];
    $debug = (boolean) $_POST['Debug']; 

    $rangeArr = array('Low-Range', 'Mid-Range', 'High-Range');
    
    $priceRange = ($priceRangeMax - $priceRangeMin) / 3;  // find price ranges for three tables
    $priceRangeMin =  sprintf("%01.2f", 0.00);
    $priceRangeMax = $priceRangeMin;  // needed for initial setup
    
    foreach ($rangeArr as $range) 
    {
        $priceRangeMax = sprintf("%01.2f", ($priceRangeMin + $priceRange));
        $results .=  "<h2>$range : $priceRangeMin ~ $priceRangeMax</h2>\n";
        // Construct the FindItems call 
        $apicall = "$endpoint?callname=FindItemsAdvanced"
                 . "&version=537"
                 . "&siteid=$siteID"
                 . "&appid=Commlink-1427-44be-8ad5-99789cefe681"
                 . "&QueryKeywords=$safeQuery"
                 . "&MaxEntries=$itemsPerRange"
                 . "&ItemSort=BestMatch"
                 . "&ItemType=FixedPricedItem"
                 . "&PriceMin.Value=$priceRangeMin"
                 . "&PriceMax.Value=$priceRangeMax"
                 . "&IncludeSelector=SearchDetails"  
                 . "&trackingpartnercode=9"              // fill in your information in next 3 lines
                 . "&trackingid=123456789"
                 . "&affiliateuserid=456"
                 . "&responseencoding=$responseEncoding";
        
        if ($debug) {
            print "GET call = $apicall <br>";  // see GET request generated
        }  
        // Load the call and capture the document returned by the Shopping API
        $resp = simplexml_load_file($apicall);
        
        // Check to see if the response was loaded, else print an error
        // Probably best to split into two different tests, but have as one for brevity
        if ($resp && $resp->TotalItems > 0) {
            $results .= 'Total items : ' . $resp->TotalItems . "<br />\n";
            $results .= '<table id="example" class="tablesorter" border="0" cellpadding="0" cellspacing="1">' . "\n";
            $results .= "<thead><tr><th /><th>Title</th><th>Price &nbsp; &nbsp; </th><th>Shipping &nbsp; &nbsp; </th><th>Total &nbsp; &nbsp; </th><th><!--Currency--></th><th>Time Left</th><th>End Time</th></tr></thead>\n";
            
            // If the response was loaded, parse it and build links  
            foreach($resp->SearchResult->ItemArray->Item as $item) {
                if ($item->GalleryURL) {
                    $picURL = $item->GalleryURL;
                } else {
                    $picURL = "http://pics.ebaystatic.com/aw/pics/express/icons/iconPlaceholder_96x96.gif";
                }
                $link  = $item->ViewItemURLForNaturalSearch;
                $title = $item->Title;
                
                $price = sprintf("%01.2f", $item->ConvertedCurrentPrice);
                $ship  = sprintf("%01.2f", $item->ShippingCostSummary->ShippingServiceCost);
                $total = sprintf("%01.2f", ((float)$item->ConvertedCurrentPrice 
                                          + (float)$item->ShippingCostSummary->ShippingServiceCost));
                
                // Determine currency to display - so far only seen cases where priceCurr = shipCurr, but may be others
                $priceCurr = (string) $item->ConvertedCurrentPrice['currencyID'];
                $shipCurr  = (string) $item->ShippingCostSummary->ShippingServiceCost['currencyID'];
                if ($priceCurr == $shipCurr) {
                    $curr = $priceCurr;
                } else {
                    $curr = "$priceCurr / $shipCurr";  // potential case where price/ship currencies differ
                }
    
                $timeLeft = getPrettyTimeFromEbayTime($item->TimeLeft);
                $endTime = strtotime($item->EndTime);   // returns Epoch seconds
                $endTime = $item->EndTime;
                
                
                $results .= "<tr><td><a href=\"$link\"><img src=\"$picURL\"></a></td><td><a href=\"$link\">$title</a></td>"
                         .  "<td>$price</td><td>$ship</td><td>$total</td><td>$curr</td><td>$timeLeft</td><td><nobr>$endTime</nobr></td></tr>";
            }
            $results .= "</table>";
        }
        // If there was no response, print an error
        else {
            $results = "<p><i><b>No items found<b></i></p>";
        }
        $priceRangeMin = $priceRangeMax; // set up for next iteration
    } // foreach
    
} // if    

?>


<?php echo $results;?>
</body>
</html>
