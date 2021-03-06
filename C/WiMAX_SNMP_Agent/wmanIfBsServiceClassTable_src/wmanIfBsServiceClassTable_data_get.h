/*
 * Note: this file originally auto-generated by mib2c using
 *       version : 12088 $ of $
 *
 * $Id:$
 *
 * @file wmanIfBsServiceClassTable_data_get.h
 *
 * @addtogroup get
 *
 * Prototypes for get functions
 *
 * @{
 */
#ifndef WMANIFBSSERVICECLASSTABLE_DATA_GET_H
#define WMANIFBSSERVICECLASSTABLE_DATA_GET_H

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
 *** Table wmanIfBsServiceClassTable
 ***
 **********************************************************************
 **********************************************************************/
    /*
     * WMAN-IF-MIB::wmanIfBsServiceClassTable is subid 3 of wmanIfBsPacketCs.
     * Its status is Current.
     * OID: .1.3.6.1.2.1.10.184.1.1.1.3, length: 12
     */
    /*
     * indexes
     */

    int            
        wmanIfBsQosServiceClassName_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         char **wmanIfBsQosServiceClassName_val_ptr_ptr,
         size_t *wmanIfBsQosServiceClassName_val_ptr_len_ptr);
    int            
        wmanIfBsQoSTrafficPriority_get(wmanIfBsServiceClassTable_rowreq_ctx
                                       * rowreq_ctx,
                                       long
                                       *wmanIfBsQoSTrafficPriority_val_ptr);
    int            
        wmanIfBsQoSMaxSustainedRate_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         u_long * wmanIfBsQoSMaxSustainedRate_val_ptr);
    int            
        wmanIfBsQoSMaxTrafficBurst_get(wmanIfBsServiceClassTable_rowreq_ctx
                                       * rowreq_ctx,
                                       u_long *
                                       wmanIfBsQoSMaxTrafficBurst_val_ptr);
    int            
        wmanIfBsQoSMinReservedRate_get(wmanIfBsServiceClassTable_rowreq_ctx
                                       * rowreq_ctx,
                                       u_long *
                                       wmanIfBsQoSMinReservedRate_val_ptr);
    int            
        wmanIfBsQoSToleratedJitter_get(wmanIfBsServiceClassTable_rowreq_ctx
                                       * rowreq_ctx,
                                       u_long *
                                       wmanIfBsQoSToleratedJitter_val_ptr);
    int            
        wmanIfBsQoSMaxLatency_get(wmanIfBsServiceClassTable_rowreq_ctx *
                                  rowreq_ctx,
                                  u_long * wmanIfBsQoSMaxLatency_val_ptr);
    int            
        wmanIfBsQoSFixedVsVariableSduInd_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         u_long * wmanIfBsQoSFixedVsVariableSduInd_val_ptr);
    int            
        wmanIfBsQoSSduSize_get(wmanIfBsServiceClassTable_rowreq_ctx *
                               rowreq_ctx,
                               u_long * wmanIfBsQoSSduSize_val_ptr);
    int            
        wmanIfBsQosScSchedulingType_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         u_long * wmanIfBsQosScSchedulingType_val_ptr);
    int            
        wmanIfBsQosScArqEnable_get(wmanIfBsServiceClassTable_rowreq_ctx *
                                   rowreq_ctx,
                                   u_long *
                                   wmanIfBsQosScArqEnable_val_ptr);
    int            
        wmanIfBsQosScArqWindowSize_get(wmanIfBsServiceClassTable_rowreq_ctx
                                       * rowreq_ctx,
                                       long
                                       *wmanIfBsQosScArqWindowSize_val_ptr);
    int            
        wmanIfBsQosScArqBlockLifetime_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsQosScArqBlockLifetime_val_ptr);
    int            
        wmanIfBsQosScArqSyncLossTimeout_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsQosScArqSyncLossTimeout_val_ptr);
    int            
        wmanIfBsQosScArqDeliverInOrder_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         u_long * wmanIfBsQosScArqDeliverInOrder_val_ptr);
    int            
        wmanIfBsQosScArqRxPurgeTimeout_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         long *wmanIfBsQosScArqRxPurgeTimeout_val_ptr);
    int            
        wmanIfBsQosScArqBlockSize_get(wmanIfBsServiceClassTable_rowreq_ctx
                                      * rowreq_ctx,
                                      long
                                      *wmanIfBsQosScArqBlockSize_val_ptr);
    int            
        wmanIfBsQosSCMinRsvdTolerableRate_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         u_long * wmanIfBsQosSCMinRsvdTolerableRate_val_ptr);
    int            
        wmanIfBsQoSReqTxPolicy_get(wmanIfBsServiceClassTable_rowreq_ctx *
                                   rowreq_ctx,
                                   u_long *
                                   wmanIfBsQoSReqTxPolicy_val_ptr);
    int            
        wmanIfBsQoSServiceClassRowStatus_get
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         u_long * wmanIfBsQoSServiceClassRowStatus_val_ptr);


    int            
        wmanIfBsServiceClassTable_indexes_set_tbl_idx
        (wmanIfBsServiceClassTable_mib_index * tbl_idx, long ifIndex_val,
         long wmanIfBsQoSProfileIndex_val);
    int            
        wmanIfBsServiceClassTable_indexes_set
        (wmanIfBsServiceClassTable_rowreq_ctx * rowreq_ctx,
         long ifIndex_val, long wmanIfBsQoSProfileIndex_val);




#ifdef __cplusplus
}
#endif
#endif                          /* WMANIFBSSERVICECLASSTABLE_DATA_GET_H */
/** @} */
