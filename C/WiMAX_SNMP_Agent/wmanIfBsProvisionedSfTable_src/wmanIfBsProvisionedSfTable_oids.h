/*
 * Note: this file originally auto-generated by mib2c using
 *  : generic-table-oids.m2c 12855 2005-09-27 15:56:08Z rstory $
 *
 * $Id:$
 */
#ifndef WMANIFBSPROVISIONEDSFTABLE_OIDS_H
#define WMANIFBSPROVISIONEDSFTABLE_OIDS_H

#ifdef __cplusplus
extern          "C" {
#endif


    /*
     * column number definitions for table wmanIfBsProvisionedSfTable 
     */
#define WMANIFBSPROVISIONEDSFTABLE_OID              1,3,6,1,2,1,10,184,1,1,1,1

#define COLUMN_WMANIFBSSFID         1

#define COLUMN_WMANIFBSSFDIRECTION         2
#define COLUMN_WMANIFBSSFDIRECTION_FLAG    (0x1 << 1)

#define COLUMN_WMANIFBSSERVICECLASSINDEX         3
#define COLUMN_WMANIFBSSERVICECLASSINDEX_FLAG    (0x1 << 2)

#define COLUMN_WMANIFBSSFSTATE         4
#define COLUMN_WMANIFBSSFSTATE_FLAG    (0x1 << 3)

#define COLUMN_WMANIFBSSFPROVISIONEDTIME         5
#define COLUMN_WMANIFBSSFPROVISIONEDTIME_FLAG    (0x1 << 4)

#define COLUMN_WMANIFBSSFCSSPECIFICATION         6
#define COLUMN_WMANIFBSSFCSSPECIFICATION_FLAG    (0x1 << 5)

#define COLUMN_WMANIFBSPROVISIONEDSFROWSTATUS         7
#define COLUMN_WMANIFBSPROVISIONEDSFROWSTATUS_FLAG    (0x1 << 6)


#define WMANIFBSPROVISIONEDSFTABLE_MIN_COL   COLUMN_WMANIFBSSFDIRECTION
#define WMANIFBSPROVISIONEDSFTABLE_MAX_COL   COLUMN_WMANIFBSPROVISIONEDSFROWSTATUS


    /*
     * TODO:405:r: Review WMANIFBSPROVISIONEDSFTABLE_SETTABLE_COLS macro.
     * OR together all the writable cols.
     */
#define WMANIFBSPROVISIONEDSFTABLE_SETTABLE_COLS (COLUMN_WMANIFBSSFDIRECTION_FLAG | COLUMN_WMANIFBSSERVICECLASSINDEX_FLAG | COLUMN_WMANIFBSSFSTATE_FLAG | COLUMN_WMANIFBSSFPROVISIONEDTIME_FLAG | COLUMN_WMANIFBSSFCSSPECIFICATION_FLAG | COLUMN_WMANIFBSPROVISIONEDSFROWSTATUS_FLAG)
    /*
     * TODO:405:r: Review WMANIFBSPROVISIONEDSFTABLE_REQUIRED_COLS macro.
     * OR together all the required rows for row creation.
     * default is writable cols w/out defaults.
     */
#define WMANIFBSPROVISIONEDSFTABLE_REQUIRED_COLS (COLUMN_WMANIFBSSFDIRECTION_FLAG | COLUMN_WMANIFBSSERVICECLASSINDEX_FLAG | COLUMN_WMANIFBSSFSTATE_FLAG | COLUMN_WMANIFBSSFPROVISIONEDTIME_FLAG | COLUMN_WMANIFBSSFCSSPECIFICATION_FLAG | COLUMN_WMANIFBSPROVISIONEDSFROWSTATUS_FLAG)


#ifdef __cplusplus
}
#endif
#endif                          /* WMANIFBSPROVISIONEDSFTABLE_OIDS_H */
