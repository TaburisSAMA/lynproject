/*
 * Note: this file originally auto-generated by mib2c using
 *       version : 14170 $ of $
 *
 * $Id:$
 */
/** \page MFD helper for wmanIfBsRegisteredSsTable
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
#include "wmanIfBsRegisteredSsTable.h"

#include <net-snmp/agent/mib_modules.h>

#include "wmanIfBsRegisteredSsTable_interface.h"

oid             wmanIfBsRegisteredSsTable_oid[] =
    { WMANIFBSREGISTEREDSSTABLE_OID };
int             wmanIfBsRegisteredSsTable_oid_size =
OID_LENGTH(wmanIfBsRegisteredSsTable_oid);

wmanIfBsRegisteredSsTable_registration
    wmanIfBsRegisteredSsTable_user_context;

void            initialize_table_wmanIfBsRegisteredSsTable(void);
void            shutdown_table_wmanIfBsRegisteredSsTable(void);


/**
 * Initializes the wmanIfBsRegisteredSsTable module
 */
void
init_wmanIfBsRegisteredSsTable(void)
{
    DEBUGMSGTL(("verbose:wmanIfBsRegisteredSsTable:init_wmanIfBsRegisteredSsTable", "called\n"));

    /*
     * TODO:300:o: Perform wmanIfBsRegisteredSsTable one-time module initialization.
     */

    /*
     * here we initialize all the tables we're planning on supporting
     */
    if (should_init("wmanIfBsRegisteredSsTable"))
        initialize_table_wmanIfBsRegisteredSsTable();

}                               /* init_wmanIfBsRegisteredSsTable */

/**
 * Shut-down the wmanIfBsRegisteredSsTable module (agent is exiting)
 */
void
shutdown_wmanIfBsRegisteredSsTable(void)
{
    if (should_init("wmanIfBsRegisteredSsTable"))
        shutdown_table_wmanIfBsRegisteredSsTable();

}

/**
 * Initialize the table wmanIfBsRegisteredSsTable
 *    (Define its contents and how it's structured)
 */
void
initialize_table_wmanIfBsRegisteredSsTable(void)
{
    wmanIfBsRegisteredSsTable_registration *user_context;
    u_long          flags;

    DEBUGMSGTL(("verbose:wmanIfBsRegisteredSsTable:initialize_table_wmanIfBsRegisteredSsTable", "called\n"));

    /*
     * TODO:301:o: Perform wmanIfBsRegisteredSsTable one-time table initialization.
     */

    /*
     * TODO:302:o: |->Initialize wmanIfBsRegisteredSsTable user context
     * if you'd like to pass in a pointer to some data for this
     * table, allocate or set it up here.
     */
    /*
     * a netsnmp_data_list is a simple way to store void pointers. A simple
     * string token is used to add, find or remove pointers.
     */
    user_context =
        netsnmp_create_data_list("wmanIfBsRegisteredSsTable", NULL, NULL);

    /*
     * No support for any flags yet, but in the future you would
     * set any flags here.
     */
    flags = 0;

    /*
     * call interface initialization code
     */
    _wmanIfBsRegisteredSsTable_initialize_interface(user_context, flags);
}                               /* initialize_table_wmanIfBsRegisteredSsTable */

/**
 * Shutdown the table wmanIfBsRegisteredSsTable
 */
void
shutdown_table_wmanIfBsRegisteredSsTable(void)
{
    /*
     * call interface shutdown code
     */
    _wmanIfBsRegisteredSsTable_shutdown_interface
        (&wmanIfBsRegisteredSsTable_user_context);
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
wmanIfBsRegisteredSsTable_rowreq_ctx_init
    (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
     void *user_init_ctx)
{
    DEBUGMSGTL(("verbose:wmanIfBsRegisteredSsTable:wmanIfBsRegisteredSsTable_rowreq_ctx_init", "called\n"));

    netsnmp_assert(NULL != rowreq_ctx);

    /*
     * TODO:210:o: |-> Perform extra wmanIfBsRegisteredSsTable rowreq initialization. (eg DEFVALS)
     */
    rowreq_ctx->data.wmanIfBsSs2ndMgmtArqBlockLifetime = 0;

    rowreq_ctx->data.wmanIfBsSs2ndMgmtArqSyncLossTimeout = 0;

    rowreq_ctx->data.wmanIfBsSs2ndMgmtArqRxPurgeTimeout = 0;


    return MFD_SUCCESS;
}                               /* wmanIfBsRegisteredSsTable_rowreq_ctx_init */

/**
 * extra context cleanup
 *
 */
void
wmanIfBsRegisteredSsTable_rowreq_ctx_cleanup
    (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx)
{
    DEBUGMSGTL(("verbose:wmanIfBsRegisteredSsTable:wmanIfBsRegisteredSsTable_rowreq_ctx_cleanup", "called\n"));

    netsnmp_assert(NULL != rowreq_ctx);

    /*
     * TODO:211:o: |-> Perform extra wmanIfBsRegisteredSsTable rowreq cleanup.
     */
}                               /* wmanIfBsRegisteredSsTable_rowreq_ctx_cleanup */

/**
 * pre-request callback
 *
 *
 * @retval MFD_SUCCESS              : success.
 * @retval MFD_ERROR                : other error
 */
int
wmanIfBsRegisteredSsTable_pre_request
    (wmanIfBsRegisteredSsTable_registration * user_context)
{
    DEBUGMSGTL(("verbose:wmanIfBsRegisteredSsTable:wmanIfBsRegisteredSsTable_pre_request", "called\n"));

    /*
     * TODO:510:o: Perform wmanIfBsRegisteredSsTable pre-request actions.
     */

    return MFD_SUCCESS;
}                               /* wmanIfBsRegisteredSsTable_pre_request */

/**
 * post-request callback
 *
 * Note:
 *   New rows have been inserted into the container, and
 *   deleted rows have been removed from the container and
 *   released.
 *
 * @param user_context
 * @param rc : MFD_SUCCESS if all requests succeeded
 *
 * @retval MFD_SUCCESS : success.
 * @retval MFD_ERROR   : other error (ignored)
 */
int
wmanIfBsRegisteredSsTable_post_request
    (wmanIfBsRegisteredSsTable_registration * user_context, int rc)
{
    DEBUGMSGTL(("verbose:wmanIfBsRegisteredSsTable:wmanIfBsRegisteredSsTable_post_request", "called\n"));

    /*
     * TODO:511:o: Perform wmanIfBsRegisteredSsTable post-request actions.
     */

    return MFD_SUCCESS;
}                               /* wmanIfBsRegisteredSsTable_post_request */


/** @{ */
