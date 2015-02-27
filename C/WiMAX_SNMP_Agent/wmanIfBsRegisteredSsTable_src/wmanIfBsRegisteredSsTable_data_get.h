/*
 * Note: this file originally auto-generated by mib2c using
 *       version : 12088 $ of $
 *
 * $Id:$
 *
 * @file wmanIfBsRegisteredSsTable_data_get.h
 *
 * @addtogroup get
 *
 * Prototypes for get functions
 *
 * @{
 */
#ifndef WMANIFBSREGISTEREDSSTABLE_DATA_GET_H
#define WMANIFBSREGISTEREDSSTABLE_DATA_GET_H

#ifdef __cplusplus
extern          "C" {
#endif

    /*
     *********************************************************************
     * GET function declarations
     */

    /*
     *********************************************************************
     * GET Table declarations
     */
/**********************************************************************
 **********************************************************************
 ***
 *** Table wmanIfBsRegisteredSsTable
 ***
 **********************************************************************
 **********************************************************************/
    /*
     * WMAN-IF-MIB::wmanIfBsRegisteredSsTable is subid 1 of wmanIfBsCps.
     * Its status is Current.
     * OID: .1.3.6.1.2.1.10.184.1.1.2.1, length: 12
     */
    /*
     * indexes
     */

    int            
        wmanIfBsSsBasicCid_get(wmanIfBsRegisteredSsTable_rowreq_ctx *
                               rowreq_ctx,
                               long *wmanIfBsSsBasicCid_val_ptr);
    int            
        wmanIfBsSsPrimaryCid_get(wmanIfBsRegisteredSsTable_rowreq_ctx *
                                 rowreq_ctx,
                                 long *wmanIfBsSsPrimaryCid_val_ptr);
    int            
        wmanIfBsSsSecondaryCid_get(wmanIfBsRegisteredSsTable_rowreq_ctx *
                                   rowreq_ctx,
                                   long *wmanIfBsSsSecondaryCid_val_ptr);
    int            
        wmanIfBsSsManagementSupport_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         u_long * wmanIfBsSsManagementSupport_val_ptr);
    int            
        wmanIfBsSsIpManagementMode_get(wmanIfBsRegisteredSsTable_rowreq_ctx
                                       * rowreq_ctx,
                                       u_long *
                                       wmanIfBsSsIpManagementMode_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqEnable_get(wmanIfBsRegisteredSsTable_rowreq_ctx
                                       * rowreq_ctx,
                                       u_long *
                                       wmanIfBsSs2ndMgmtArqEnable_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqWindowSize_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsSs2ndMgmtArqWindowSize_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqDnLinkTxDelay_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsSs2ndMgmtArqDnLinkTxDelay_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqUpLinkTxDelay_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsSs2ndMgmtArqUpLinkTxDelay_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqDnLinkRxDelay_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsSs2ndMgmtArqDnLinkRxDelay_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqUpLinkRxDelay_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsSs2ndMgmtArqUpLinkRxDelay_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqBlockLifetime_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsSs2ndMgmtArqBlockLifetime_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqSyncLossTimeout_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsSs2ndMgmtArqSyncLossTimeout_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqDeliverInOrder_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         u_long * wmanIfBsSs2ndMgmtArqDeliverInOrder_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqRxPurgeTimeout_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsSs2ndMgmtArqRxPurgeTimeout_val_ptr);
    int            
        wmanIfBsSs2ndMgmtArqBlockSize_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsSs2ndMgmtArqBlockSize_val_ptr);
    int            
        wmanIfBsSsVendorIdEncoding_get(wmanIfBsRegisteredSsTable_rowreq_ctx
                                       * rowreq_ctx,
                                       char
                                       **wmanIfBsSsVendorIdEncoding_val_ptr_ptr,
                                       size_t
                                       *wmanIfBsSsVendorIdEncoding_val_ptr_len_ptr);
    int            
        wmanIfBsSsAasBroadcastPermission_get
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         u_long * wmanIfBsSsAasBroadcastPermission_val_ptr);
    int            
        wmanIfBsSsMaxTxPowerBpsk_get(wmanIfBsRegisteredSsTable_rowreq_ctx *
                                     rowreq_ctx,
                                     long
                                     *wmanIfBsSsMaxTxPowerBpsk_val_ptr);
    int            
        wmanIfBsSsMaxTxPowerQpsk_get(wmanIfBsRegisteredSsTable_rowreq_ctx *
                                     rowreq_ctx,
                                     long
                                     *wmanIfBsSsMaxTxPowerQpsk_val_ptr);
    int            
        wmanIfBsSsMaxTxPower16Qam_get(wmanIfBsRegisteredSsTable_rowreq_ctx
                                      * rowreq_ctx,
                                      long
                                      *wmanIfBsSsMaxTxPower16Qam_val_ptr);
    int            
        wmanIfBsSsMaxTxPower64Qam_get(wmanIfBsRegisteredSsTable_rowreq_ctx
                                      * rowreq_ctx,
                                      long
                                      *wmanIfBsSsMaxTxPower64Qam_val_ptr);
    int            
        wmanIfBsSsMacVersion_get(wmanIfBsRegisteredSsTable_rowreq_ctx *
                                 rowreq_ctx,
                                 u_long * wmanIfBsSsMacVersion_val_ptr);


    int            
        wmanIfBsRegisteredSsTable_indexes_set_tbl_idx
        (wmanIfBsRegisteredSsTable_mib_index * tbl_idx, long ifIndex_val,
         char *wmanIfBsSsMacAddress_val_ptr,
         size_t wmanIfBsSsMacAddress_val_ptr_len);
    int            
        wmanIfBsRegisteredSsTable_indexes_set
        (wmanIfBsRegisteredSsTable_rowreq_ctx * rowreq_ctx,
         long ifIndex_val, char *wmanIfBsSsMacAddress_val_ptr,
         size_t wmanIfBsSsMacAddress_val_ptr_len);




#ifdef __cplusplus
}
#endif
#endif                          /* WMANIFBSREGISTEREDSSTABLE_DATA_GET_H */
/** @} */
