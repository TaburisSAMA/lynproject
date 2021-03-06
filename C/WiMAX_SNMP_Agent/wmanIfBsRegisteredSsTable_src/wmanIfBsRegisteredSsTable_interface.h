/*
 * Note: this file originally auto-generated by mib2c using
 *       version : 15899 $ of $
 *
 * $Id:$
 */
/** @ingroup interface: Routines to interface to Net-SNMP
 *
 * \warning This code should not be modified, called directly,
 *          or used to interpret functionality. It is subject to
 *          change at any time.
 * 
 * @{
 */
/*
 * *********************************************************************
 * *********************************************************************
 * *********************************************************************
 * ***                                                               ***
 * ***  NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE  ***
 * ***                                                               ***
 * ***                                                               ***
 * ***       THIS FILE DOES NOT CONTAIN ANY USER EDITABLE CODE.      ***
 * ***                                                               ***
 * ***                                                               ***
 * ***       THE GENERATED CODE IS INTERNAL IMPLEMENTATION, AND      ***
 * ***                                                               ***
 * ***                                                               ***
 * ***    IS SUBJECT TO CHANGE WITHOUT WARNING IN FUTURE RELEASES.   ***
 * ***                                                               ***
 * ***                                                               ***
 * *********************************************************************
 * *********************************************************************
 * *********************************************************************
 */
#ifndef WMANIFBSREGISTEREDSSTABLE_INTERFACE_H
#define WMANIFBSREGISTEREDSSTABLE_INTERFACE_H

#ifdef __cplusplus
extern          "C" {
#endif


#include "wmanIfBsRegisteredSsTable.h"


    /*
     ********************************************************************
     * Table declarations
     */

    /*
     * PUBLIC interface initialization routine 
     */
    void           
        _wmanIfBsRegisteredSsTable_initialize_interface
        (wmanIfBsRegisteredSsTable_registration * user_ctx, u_long flags);
    void           
        _wmanIfBsRegisteredSsTable_shutdown_interface
        (wmanIfBsRegisteredSsTable_registration * user_ctx);

    wmanIfBsRegisteredSsTable_registration
        *wmanIfBsRegisteredSsTable_registration_get(void);

    wmanIfBsRegisteredSsTable_registration
        *wmanIfBsRegisteredSsTable_registration_set
        (wmanIfBsRegisteredSsTable_registration * newreg);

    netsnmp_container *wmanIfBsRegisteredSsTable_container_get(void);
    int             wmanIfBsRegisteredSsTable_container_size(void);

    wmanIfBsRegisteredSsTable_rowreq_ctx
        *wmanIfBsRegisteredSsTable_allocate_rowreq_ctx(void *);
    void           
        wmanIfBsRegisteredSsTable_release_rowreq_ctx
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx);

    int             wmanIfBsRegisteredSsTable_index_to_oid(netsnmp_index *
                                                           oid_idx,
                                                           wmanIfBsRegisteredSsTable_mib_index
                                                           * mib_idx);
    int             wmanIfBsRegisteredSsTable_index_from_oid(netsnmp_index
                                                             * oid_idx,
                                                             wmanIfBsRegisteredSsTable_mib_index
                                                             * mib_idx);

    /*
     * access to certain internals. use with caution!
     */
    void           
        wmanIfBsRegisteredSsTable_valid_columns_set(netsnmp_column_info
                                                    *vc);


#ifdef __cplusplus
}
#endif
#endif                          /* WMANIFBSREGISTEREDSSTABLE_INTERFACE_H */
/** @} */
