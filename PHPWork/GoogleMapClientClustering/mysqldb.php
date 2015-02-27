<?
define("DB_SERVER", "localhost");
define("DB_USER", "root");
define("DB_PASS", "");
define("DB_NAME", "gdata");
class MySQLDB
{
    public $connection; //The MySQL database connection
    /* Class constructor */
    function MySQLDB ()
    {
        /* Make connection to database */
        $this->connection = mysql_connect(DB_SERVER, DB_USER, DB_PASS) or die(mysql_error());
        mysql_select_db(DB_NAME, $this->connection) or die(mysql_error());
        //For unicode support
        mysql_query('SET CHARACTER SET utf8');
        mysql_query('SET SESSION collation_connection ="utf8_general_ci"');
    }
    //This function returns sql result.
    function query ($query)
    {
        return mysql_query($query, $this->connection);
    }
    //This function returns sql result as a array.
    function sqlArray ($query)
    {
        $result = mysql_query($query);
        $array = mysql_fetch_array($result);
        return $array;
    }
}
;
?>