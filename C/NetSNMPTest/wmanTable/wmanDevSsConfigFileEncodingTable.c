/*
 * Note: this file originally auto-generated by mib2c using
 *       version : 1.49 $ of : mfd-top.m2c,v $
 *
 * $Id:$
 */
/** \mainpage MFD helper for wmanDevSsConfigFileEncodingTable
 *
 * \section intro Introduction
 * Introductory text.
 *
 */
/*
 * standard Net-SNMP includes
 */
#include <net-snmp/net-snmp-config.h>
#include <net-snmp/net-snmp-includes.h>
#include <net-snmp/agent/net-snmp-agent-includes.h>

/*
 * include our parent header
 */
#include "wmanDevSsConfigFileEncodingTable.h"

#include <net-snmp/agent/mib_modules.h>

#include "wmanDevSsConfigFileEncodingTable_interface.h"

oid             wmanDevSsConfigFileEncodingTable_oid[] =
    { WMANDEVSSCONFIGFILEENCODINGTABLE_OID };
int             wmanDevSsConfigFileEncodingTable_oid_size =
OID_LENGTH(wmanDevSsConfigFileEncodingTable_oid);

wmanDevSsConfigFileEncodingTable_registration
    wmanDevSsConfigFileEncodingTable_user_context;

void            initialize_table_wmanDevSsConfigFileEncodingTable(void);
void            shutdown_table_wmanDevSsConfigFileEncodingTable(void);


/**
 * Initializes the wmanDevSsConfigFileEncodingTable module
 */
void
init_wmanDevSsConfigFileEncodingTable(void)
{
    DEBUGMSGTL(("verbose:wmanDevSsConfigFileEncodingTable:init_wmanDevSsConfigFileEncodingTable", "called\n"));

    /*
     * TODO:300:o: Perform wmanDevSsConfigFileEncodingTable one-time module initialization.
     */

    /*
     * here we initialize all the tables we're planning on supporting
     */
    if (should_init("wmanDevSsConfigFileEncodingTable"))
        initialize_table_wmanDevSsConfigFileEncodingTable();

}                               /* init_wmanDevSsConfigFileEncodingTable */

/**
 * Shut-down the wmanDevSsConfigFileEncodingTable module (agent is exiting)
 */
void
shutdown_wmanDevSsConfigFileEncodingTable(void)
{
    if (should_init("wmanDevSsConfigFileEncodingTable"))
        shutdown_table_wmanDevSsConfigFileEncodingTable();

}

/**
 * Initialize the table wmanDevSsConfigFileEncodingTable
 *    (Define its contents and how it's structured)
 */
void
initialize_table_wmanDevSsConfigFileEncodingTable(void)
{
    wmanDevSsConfigFileEncodingTable_registration *user_context;
    u_long          flags;

    DEBUGMSGTL(("verbose:wmanDevSsConfigFileEncodingTable:initialize_table_wmanDevSsConfigFileEncodingTable", "called\n"));

    /*
     * TODO:301:o: Perform wmanDevSsConfigFileEncodingTable one-time table initialization.
     */

    /*
     * TODO:302:o: |->Initialize wmanDevSsConfigFileEncodingTable user context
     * if you'd like to pass in a pointer to some data for this
     * table, allocate or set it up here.
     */
    /*
     * a netsnmp_data_list is a simple way to store void pointers. A simple
     * string token is used to add, find or remove pointers.
     */
    user_context =
        netsnmp_create_data_list("wmanDevSsConfigFileEncodingTable", NULL,
                                 NULL);

    /*
     * No support for any flags yet, but in the future you would
     * set any flags here.
     */
    flags = 0;

    /*
     * call interface initialization code
     */
    _wmanDevSsConfigFileEncodingTable_initialize_interface(user_context,
                                                           flags);
}                               /* initialize_table_wmanDevSsConfigFileEncodingTable */

/**
 * Shutdown the table wmanDevSsConfigFileEncodingTable
 */
void
shutdown_table_wmanDevSsConfigFileEncodingTable(void)
{
    /*
     * call interface shutdown code
     */
    _wmanDevSsConfigFileEncodingTable_shutdown_interface
        (&wmanDevSsConfigFileEncodingTable_user_context);
}

/**
 * extra context initialization (eg default values)
 *
 * @param rowreq_ctx    : row request context
 * @param user_init_ctx : void pointer for user (parameter to rowreq_ctx_allocate)
 *
 * @retval MFD_SUCCESS  : no errors
 * @retval MFD_ERROR    : error (context allocate will fail)
 */
int
wmanDevSsConfigFileEncodingTable_rowreq_ctx_init
    (wmanDevSsConfigFileEncodingTable_rowreq_ctx * rowreq_ctx,
     void *user_init_ctx)
{
    DEBUGMSGTL(("verbose:wmanDevSsConfigFileEncodingTable:wmanDevSsConfigFileEncodingTable_rowreq_ctx_init", "called\n"));

    netsnmp_assert(NULL != rowreq_ctx);

    /*
     * TODO:210:o: |-> Perform extra wmanDevSsConfigFileEncodingTable rowreq initialization. (eg DEFVALS)
     */

    return MFD_SUCCESS;
}                               /* wmanDevSsConfigFileEncodingTable_rowreq_ctx_init */

/**
 * extra context cleanup
 *
 */
void
wmanDevSsConfigFileEncodingTable_rowreq_ctx_cleanup
    (wmanDevSsConfigFileEncodingTable_rowreq_ctx * rowreq_ctx)
{
    DEBUGMSGTL(("verbose:wmanDevSsConfigFileEncodingTable:wmanDevSsConfigFileEncodingTable_rowreq_ctx_cleanup", "called\n"));

    netsnmp_assert(NULL != rowreq_ctx);

    /*
     * TODO:211:o: |-> Perform extra wmanDevSsConfigFileEncodingTable rowreq cleanup.
     */
}                               /* wmanDevSsConfigFileEncodingTable_rowreq_ctx_cleanup */

/**
 * pre-request callback
 *
 *
 * @retval MFD_SUCCESS              : success.
 * @retval MFD_ERROR                : other error
 */
int
wmanDevSsConfigFileEncodingTable_pre_request
    (wmanDevSsConfigFileEncodingTable_registration * user_context)
{
    DEBUGMSGTL(("verbose:wmanDevSsConfigFileEncodingTable:wmanDevSsConfigFileEncodingTable_pre_request", "called\n"));

    /*
     * TODO:510:o: Perform wmanDevSsConfigFileEncodingTable pre-request actions.
     */

    return MFD_SUCCESS;
}                               /* wmanDevSsConfigFileEncodingTable_pre_request */

/**
 * post-request callback
 *
 * Note:
 *   New rows have been inserted into the container, and
 *   deleted rows have been removed from the container and
 *   released.
 *
 * @param rc : MFD_SUCCESS if all requests succeeded
 *
 * @retval MFD_SUCCESS : success.
 * @retval MFD_ERROR   : other error (ignored)
 */
int
wmanDevSsConfigFileEncodingTable_post_request
    (wmanDevSsConfigFileEncodingTable_registration * user_context, int rc)
{
    DEBUGMSGTL(("verbose:wmanDevSsConfigFileEncodingTable:wmanDevSsConfigFileEncodingTable_post_request", "called\n"));

    /*
     * TODO:511:o: Perform wmanDevSsConfigFileEncodingTable post-request actions.
     */

    return MFD_SUCCESS;
}                               /* wmanDevSsConfigFileEncodingTable_post_request */


/** @{ */
