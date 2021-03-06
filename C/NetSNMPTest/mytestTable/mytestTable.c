/*
 * Note: this file originally auto-generated by mib2c using
 *        : mib2c.create-dataset.conf,v 5.4 2004/02/02 19:06:53 rstory Exp $
 */

#include <net-snmp/net-snmp-config.h>
#include <net-snmp/net-snmp-includes.h>
#include <net-snmp/agent/net-snmp-agent-includes.h>
#include "mytestTable.h"

/** Initialize the mytestTable table by defining its contents and how it's structured */
void
initialize_table_mytestTable(void)
{
    static oid      mytestTable_oid[] =
        { 1, 3, 6, 1, 4, 1, 8072, 2, 70, 1, 3 };
    size_t          mytestTable_oid_len = OID_LENGTH(mytestTable_oid);
    netsnmp_table_data_set *table_set;

    /*
     * create the table structure itself
     */
    table_set = netsnmp_create_table_data_set("mytestTable");

    /*
     * comment this out or delete if you don't support creation of new rows
     */
    table_set->allow_creation = 1;

    table_set->rowstatus_column = COLUMN_MYTESTROWSTATUS;

    /***************************************************
     * Adding indexes
     */
    DEBUGMSGTL(("initialize_table_mytestTable",
                "adding indexes to table mytestTable\n"));
    netsnmp_table_set_add_indexes(table_set, ASN_INTEGER,       /* index: mytestIndex */
                                  0);

    DEBUGMSGTL(("initialize_table_mytestTable",
                "adding column types to table mytestTable\n"));
    netsnmp_table_set_multi_add_default_row(table_set,
                                            COLUMN_MYTESTINDEX,
                                            ASN_INTEGER, 0, NULL, 0,
                                            COLUMN_MYTESTCOLUMN1,
                                            ASN_INTEGER, 1, NULL, 0,
                                            COLUMN_MYTESTROWSTATUS,
                                            ASN_INTEGER, 1, NULL, 0, 0);

    /*
     * registering the table with the master agent
     */
    /*
     * note: if you don't need a subhandler to deal with any aspects
     * of the request, change mytestTable_handler to "NULL"
     */
    netsnmp_register_table_data_set(netsnmp_create_handler_registration
                                    ("mytestTable", mytestTable_handler,
                                     mytestTable_oid, mytestTable_oid_len,
                                     HANDLER_CAN_RWRITE), table_set, NULL);
}

/** Initializes the mytestTable module */
void
init_mytestTable(void)
{

    /*
     * here we initialize all the tables we're planning on supporting
     */
    initialize_table_mytestTable();
}

/** handles requests for the mytestTable table, if anything else needs to be done */
int
mytestTable_handler(netsnmp_mib_handler *handler,
                    netsnmp_handler_registration *reginfo,
                    netsnmp_agent_request_info *reqinfo,
                    netsnmp_request_info *requests)
{
    /*
     * perform anything here that you need to do.  The requests have
     * already been processed by the master table_dataset handler, but
     * this gives you chance to act on the request in some other way
     * if need be.
     */
    return SNMP_ERR_NOERROR;
}
