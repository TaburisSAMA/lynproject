/*
 * Note: this file originally auto-generated by mib2c using
 *       version : 14170 $ of $ 
 *
 * $Id:$
 */
/** \page MFD helper for wmanIfBsServiceClassTable
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
#include "wmanIfBsServiceClassTable.h"

#include <net-snmp/agent/mib_modules.h>

#include "wmanIfBsServiceClassTable_interface.h"

oid             wmanIfBsServiceClassTable_oid[] =
    { WMANIFBSSERVICECLASSTABLE_OID };
int             wmanIfBsServiceClassTable_oid_size =
OID_LENGTH(wmanIfBsServiceClassTable_oid);

wmanIfBsServiceClassTable_registration
    wmanIfBsServiceClassTable_user_context;

void            initialize_table_wmanIfBsServiceClassTable(void);
void            shutdown_table_wmanIfBsServiceClassTable(void);


/**
 * Initializes the wmanIfBsServiceClassTable module
 */
void
init_wmanIfBsServiceClassTable(void)
{
    DEBUGMSGTL(("verbose:wmanIfBsServiceClassTable:init_wmanIfBsServiceClassTable", "called\n"));

    /*
     * TODO:300:o: Perform wmanIfBsServiceClassTable one-time module initialization.
     */

    /*
     * here we initialize all the tables we're planning on supporting
     */
    if (should_init("wmanIfBsServiceClassTable"))
        initialize_table_wmanIfBsServiceClassTable();

}                               /* init_wmanIfBsServiceClassTable */

/**
 * Shut-down the wmanIfBsServiceClassTable module (agent is exiting)
 */
void
shutdown_wmanIfBsServiceClassTable(void)
{
    if (should_init("wmanIfBsServiceClassTable"))
        shutdown_table_wmanIfBsServiceClassTable();

}

/**
 * Initialize the table wmanIfBsServiceClassTable 
 *    (Define its contents and how it's structured)
 */
void
initialize_table_wmanIfBsServiceClassTable(void)
{
    wmanIfBsServiceClassTable_registration *user_context;
    u_long          flags;

    DEBUGMSGTL(("verbose:wmanIfBsServiceClassTable:initialize_table_wmanIfBsServiceClassTable", "called\n"));

    /*
     * TODO:301:o: Perform wmanIfBsServiceClassTable one-time table initialization.
     */

    /*
     * TODO:302:o: |->Initialize wmanIfBsServiceClassTable user context
     * if you'd like to pass in a pointer to some data for this
     * table, allocate or set it up here.
     */
    /*
     * a netsnmp_data_list is a simple way to store void pointers. A simple
     * string token is used to add, find or remove pointers.
     */
    user_context =
        netsnmp_create_data_list("wmanIfBsServiceClassTable", NULL, NULL);

    /*
     * No support for any flags yet, but in the future you would
     * set any flags here.
     */
    flags = 0;

    /*
     * call interface initialization code
     */
    _wmanIfBsServiceClassTable_initialize_interface(user_context, flags);
}                               /* initialize_table_wmanIfBsServiceClassTable */

/**
 * Shutdown the table wmanIfBsServiceClassTable 
 */
void
shutdown_table_wmanIfBsServiceClassTable(void)
{
    /*
     * call interface shutdown code
     */
    _wmanIfBsServiceClassTable_shutdown_interface
        (&wmanIfBsServiceClassTable_user_context);
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
wmanIfBsServiceClassTable_rowreq_ctx_init
    (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
     void *user_init_ctx)
{
    DEBUGMSGTL(("verbose:wmanIfBsServiceClassTable:wmanIfBsServiceClassTable_rowreq_ctx_init", "called\n"));

    netsnmp_assert(NULL != rowreq_ctx);

    /*
     * TODO:210:o: |-> Perform extra wmanIfBsServiceClassTable rowreq initialization. (eg DEFVALS)
     */
    rowreq_ctx->data.wmanIfBsQoSFixedVsVariableSduInd =
        WMANIFBSQOSFIXEDVSVARIABLESDUIND_VARIABLELENGTH;

    rowreq_ctx->data.wmanIfBsQoSSduSize = 49;

    rowreq_ctx->data.wmanIfBsQosScSchedulingType =
        WMANIFSFSCHEDULINGTYPE_BESTEFFORT;

    rowreq_ctx->data.wmanIfBsQosScArqBlockLifetime = 0;

    rowreq_ctx->data.wmanIfBsQosScArqSyncLossTimeout = 0;

    rowreq_ctx->data.wmanIfBsQosScArqRxPurgeTimeout = 0;


    return MFD_SUCCESS;
}                               /* wmanIfBsServiceClassTable_rowreq_ctx_init */

/**
 * extra context cleanup
 *
 */
void
wmanIfBsServiceClassTable_rowreq_ctx_cleanup
    (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx)
{
    DEBUGMSGTL(("verbose:wmanIfBsServiceClassTable:wmanIfBsServiceClassTable_rowreq_ctx_cleanup", "called\n"));

    netsnmp_assert(NULL != rowreq_ctx);

    /*
     * TODO:211:o: |-> Perform extra wmanIfBsServiceClassTable rowreq cleanup.
     */
}                               /* wmanIfBsServiceClassTable_rowreq_ctx_cleanup */

/**
 * pre-request callback
 *
 *
 * @retval MFD_SUCCESS              : success.
 * @retval MFD_ERROR                : other error
 */
int
wmanIfBsServiceClassTable_pre_request
    (wmanIfBsServiceClassTable_registration * user_context)
{
    DEBUGMSGTL(("verbose:wmanIfBsServiceClassTable:wmanIfBsServiceClassTable_pre_request", "called\n"));

    /*
     * TODO:510:o: Perform wmanIfBsServiceClassTable pre-request actions.
     */

    return MFD_SUCCESS;
}                               /* wmanIfBsServiceClassTable_pre_request */

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
wmanIfBsServiceClassTable_post_request
    (wmanIfBsServiceClassTable_registration * user_context, int rc)
{
    DEBUGMSGTL(("verbose:wmanIfBsServiceClassTable:wmanIfBsServiceClassTable_post_request", "called\n"));

    /*
     * TODO:511:o: Perform wmanIfBsServiceClassTable post-request actions.
     */

    /*
     * check to set if any rows were changed.
     */
    if (wmanIfBsServiceClassTable_dirty_get()) {
        /*
         * check if request was successful. If so, this would be
         * a good place to save data to its persistent store.
         */
        if (MFD_SUCCESS == rc) {
            /*
             * save changed rows, if you haven't already
             */
        }

        wmanIfBsServiceClassTable_dirty_set(0); /* clear table dirty flag */
    }

    return MFD_SUCCESS;
}                               /* wmanIfBsServiceClassTable_post_request */


/** @{ */
