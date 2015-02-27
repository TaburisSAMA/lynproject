echo Started Generating MIB2C files...
if [ ! -d wmanIfBsProvisionedSfTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsProvisionedSfTable_src
cd wmanIfBsProvisionedSfTable_src
echo Generating MIB TABLE ... wmanIfBsProvisionedSfTable
mib2c -c mib2c.mfd.conf wmanIfBsProvisionedSfTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi	


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsSsProvisionedForSfTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsSsProvisionedForSfTable_src
cd wmanIfBsSsProvisionedForSfTable_src
echo Generating MIB TABLE ... wmanIfBsSsProvisionedForSfTable
mib2c -c mib2c.mfd.conf wmanIfBsSsProvisionedForSfTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsServiceClassTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsServiceClassTable_src
cd wmanIfBsServiceClassTable_src
echo Generating MIB TABLE ... wmanIfBsServiceClassTable
mib2c -c mib2c.mfd.conf wmanIfBsServiceClassTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsClassifierRuleTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsClassifierRuleTable_src
cd wmanIfBsClassifierRuleTable_src
echo Generating MIB TABLE ... wmanIfBsClassifierRuleTable
mib2c -c mib2c.mfd.conf wmanIfBsClassifierRuleTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsSsPacketCounterTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsSsPacketCounterTable_src
cd wmanIfBsSsPacketCounterTable_src
echo Generating MIB TABLE ... wmanIfBsSsPacketCounterTable
mib2c -c mib2c.mfd.conf wmanIfBsSsPacketCounterTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsRegisteredSsTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsRegisteredSsTable_src
cd wmanIfBsRegisteredSsTable_src
echo Generating MIB TABLE ... wmanIfBsRegisteredSsTable
mib2c -c mib2c.mfd.conf wmanIfBsRegisteredSsTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsConfigurationTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsConfigurationTable_src
cd wmanIfBsConfigurationTable_src
echo Generating MIB TABLE ... wmanIfBsConfigurationTable
mib2c -c mib2c.mfd.conf wmanIfBsConfigurationTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsChannelMeasurementTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsChannelMeasurementTable_src
cd wmanIfBsChannelMeasurementTable_src
echo Generating MIB TABLE ... wmanIfBsChannelMeasurementTable
mib2c -c mib2c.mfd.conf wmanIfBsChannelMeasurementTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsSsReqCapabilitiesTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsSsReqCapabilitiesTable_src
cd wmanIfBsSsReqCapabilitiesTable_src
echo Generating MIB TABLE ... wmanIfBsSsReqCapabilitiesTable
mib2c -c mib2c.mfd.conf wmanIfBsSsReqCapabilitiesTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsSsRspCapabilitiesTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsSsRspCapabilitiesTable_src
cd wmanIfBsSsRspCapabilitiesTable_src
echo Generating MIB TABLE ... wmanIfBsSsRspCapabilitiesTable
mib2c -c mib2c.mfd.conf wmanIfBsSsRspCapabilitiesTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsBasicCapabilitiesTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsBasicCapabilitiesTable_src
cd wmanIfBsBasicCapabilitiesTable_src
echo Generating MIB TABLE ... wmanIfBsBasicCapabilitiesTable
mib2c -c mib2c.mfd.conf wmanIfBsBasicCapabilitiesTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsCapabilitiesConfigTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsCapabilitiesConfigTable_src
cd wmanIfBsCapabilitiesConfigTable_src
echo Generating MIB TABLE ... wmanIfBsCapabilitiesConfigTable
mib2c -c mib2c.mfd.conf wmanIfBsCapabilitiesConfigTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsSsActionsTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsSsActionsTable_src
cd wmanIfBsSsActionsTable_src
echo Generating MIB TABLE ... wmanIfBsSsActionsTable
mib2c -c mib2c.mfd.conf wmanIfBsSsActionsTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsPkmBaseTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsPkmBaseTable_src
cd wmanIfBsPkmBaseTable_src
echo Generating MIB TABLE ... wmanIfBsPkmBaseTable
mib2c -c mib2c.mfd.conf wmanIfBsPkmBaseTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsSsPkmAuthTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsSsPkmAuthTable_src
cd wmanIfBsSsPkmAuthTable_src
echo Generating MIB TABLE ... wmanIfBsSsPkmAuthTable
mib2c -c mib2c.mfd.conf wmanIfBsSsPkmAuthTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsPkmTekTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsPkmTekTable_src
cd wmanIfBsPkmTekTable_src
echo Generating MIB TABLE ... wmanIfBsPkmTekTable
mib2c -c mib2c.mfd.conf wmanIfBsPkmTekTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsTrapControl_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsTrapControl_src
cd wmanIfBsTrapControl_src
echo Generating MIB TABLE ... wmanIfBsTrapControl
mib2c -c mib2c.mfd.conf wmanIfBsTrapControl
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsThresholdConfigTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsThresholdConfigTable_src
cd wmanIfBsThresholdConfigTable_src
echo Generating MIB TABLE ... wmanIfBsThresholdConfigTable
mib2c -c mib2c.mfd.conf wmanIfBsThresholdConfigTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsSsNotificationObjectsTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsSsNotificationObjectsTable_src
cd wmanIfBsSsNotificationObjectsTable_src
echo Generating MIB TABLE ... wmanIfBsSsNotificationObjectsTable
mib2c -c mib2c.mfd.conf wmanIfBsSsNotificationObjectsTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmUplinkChannelTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmUplinkChannelTable_src
cd wmanIfBsOfdmUplinkChannelTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmUplinkChannelTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmUplinkChannelTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmDownlinkChannelTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmDownlinkChannelTable_src
cd wmanIfBsOfdmDownlinkChannelTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmDownlinkChannelTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmDownlinkChannelTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmUcdBurstProfileTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmUcdBurstProfileTable_src
cd wmanIfBsOfdmUcdBurstProfileTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmUcdBurstProfileTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmUcdBurstProfileTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmDcdBurstProfileTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmDcdBurstProfileTable_src
cd wmanIfBsOfdmDcdBurstProfileTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmDcdBurstProfileTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmDcdBurstProfileTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmConfigurationTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmConfigurationTable_src
cd wmanIfBsOfdmConfigurationTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmConfigurationTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmConfigurationTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsSsOfdmReqCapabilitiesTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsSsOfdmReqCapabilitiesTable_src
cd wmanIfBsSsOfdmReqCapabilitiesTable_src
echo Generating MIB TABLE ... wmanIfBsSsOfdmReqCapabilitiesTable
mib2c -c mib2c.mfd.conf wmanIfBsSsOfdmReqCapabilitiesTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsSsOfdmRspCapabilitiesTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsSsOfdmRspCapabilitiesTable_src
cd wmanIfBsSsOfdmRspCapabilitiesTable_src
echo Generating MIB TABLE ... wmanIfBsSsOfdmRspCapabilitiesTable
mib2c -c mib2c.mfd.conf wmanIfBsSsOfdmRspCapabilitiesTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmCapabilitiesTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmCapabilitiesTable_src
cd wmanIfBsOfdmCapabilitiesTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmCapabilitiesTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmCapabilitiesTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmCapabilitiesConfigTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmCapabilitiesConfigTable_src
cd wmanIfBsOfdmCapabilitiesConfigTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmCapabilitiesConfigTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmCapabilitiesConfigTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmaUplinkChannelTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmaUplinkChannelTable_src
cd wmanIfBsOfdmaUplinkChannelTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmaUplinkChannelTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmaUplinkChannelTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmaDownlinkChannelTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmaDownlinkChannelTable_src
cd wmanIfBsOfdmaDownlinkChannelTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmaDownlinkChannelTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmaDownlinkChannelTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmaUcdBurstProfileTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmaUcdBurstProfileTable_src
cd wmanIfBsOfdmaUcdBurstProfileTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmaUcdBurstProfileTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmaUcdBurstProfileTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfBsOfdmaDcdBurstProfileTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfBsOfdmaDcdBurstProfileTable_src
cd wmanIfBsOfdmaDcdBurstProfileTable_src
echo Generating MIB TABLE ... wmanIfBsOfdmaDcdBurstProfileTable
mib2c -c mib2c.mfd.conf wmanIfBsOfdmaDcdBurstProfileTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsConfigurationTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsConfigurationTable_src
cd wmanIfSsConfigurationTable_src
echo Generating MIB TABLE ... wmanIfSsConfigurationTable
mib2c -c mib2c.mfd.conf wmanIfSsConfigurationTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsChannelMeasurementTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsChannelMeasurementTable_src
cd wmanIfSsChannelMeasurementTable_src
echo Generating MIB TABLE ... wmanIfSsChannelMeasurementTable
mib2c -c mib2c.mfd.conf wmanIfSsChannelMeasurementTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsPkmAuthTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsPkmAuthTable_src
cd wmanIfSsPkmAuthTable_src
echo Generating MIB TABLE ... wmanIfSsPkmAuthTable
mib2c -c mib2c.mfd.conf wmanIfSsPkmAuthTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsPkmTekTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsPkmTekTable_src
cd wmanIfSsPkmTekTable_src
echo Generating MIB TABLE ... wmanIfSsPkmTekTable
mib2c -c mib2c.mfd.conf wmanIfSsPkmTekTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsDeviceCertTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsDeviceCertTable_src
cd wmanIfSsDeviceCertTable_src
echo Generating MIB TABLE ... wmanIfSsDeviceCertTable
mib2c -c mib2c.mfd.conf wmanIfSsDeviceCertTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsTrapControl_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsTrapControl_src
cd wmanIfSsTrapControl_src
echo Generating MIB TABLE ... wmanIfSsTrapControl
mib2c -c mib2c.mfd.conf wmanIfSsTrapControl
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsThresholdConfigTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsThresholdConfigTable_src
cd wmanIfSsThresholdConfigTable_src
echo Generating MIB TABLE ... wmanIfSsThresholdConfigTable
mib2c -c mib2c.mfd.conf wmanIfSsThresholdConfigTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsNotificationObjectsTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsNotificationObjectsTable_src
cd wmanIfSsNotificationObjectsTable_src
echo Generating MIB TABLE ... wmanIfSsNotificationObjectsTable
mib2c -c mib2c.mfd.conf wmanIfSsNotificationObjectsTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsOfdmUplinkChannelTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsOfdmUplinkChannelTable_src
cd wmanIfSsOfdmUplinkChannelTable_src
echo Generating MIB TABLE ... wmanIfSsOfdmUplinkChannelTable
mib2c -c mib2c.mfd.conf wmanIfSsOfdmUplinkChannelTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsOfdmDownlinkChannelTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsOfdmDownlinkChannelTable_src
cd wmanIfSsOfdmDownlinkChannelTable_src
echo Generating MIB TABLE ... wmanIfSsOfdmDownlinkChannelTable
mib2c -c mib2c.mfd.conf wmanIfSsOfdmDownlinkChannelTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsOfdmUcdBurstProfileTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsOfdmUcdBurstProfileTable_src
cd wmanIfSsOfdmUcdBurstProfileTable_src
echo Generating MIB TABLE ... wmanIfSsOfdmUcdBurstProfileTable
mib2c -c mib2c.mfd.conf wmanIfSsOfdmUcdBurstProfileTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsOfdmDcdBurstProfileTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsOfdmDcdBurstProfileTable_src
cd wmanIfSsOfdmDcdBurstProfileTable_src
echo Generating MIB TABLE ... wmanIfSsOfdmDcdBurstProfileTable
mib2c -c mib2c.mfd.conf wmanIfSsOfdmDcdBurstProfileTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsOfdmaUplinkChannelTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsOfdmaUplinkChannelTable_src
cd wmanIfSsOfdmaUplinkChannelTable_src
echo Generating MIB TABLE ... wmanIfSsOfdmaUplinkChannelTable
mib2c -c mib2c.mfd.conf wmanIfSsOfdmaUplinkChannelTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsOfdmaDownlinkChannelTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsOfdmaDownlinkChannelTable_src
cd wmanIfSsOfdmaDownlinkChannelTable_src
echo Generating MIB TABLE ... wmanIfSsOfdmaDownlinkChannelTable
mib2c -c mib2c.mfd.conf wmanIfSsOfdmaDownlinkChannelTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsOfdmaUcdBurstProfileTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsOfdmaUcdBurstProfileTable_src
cd wmanIfSsOfdmaUcdBurstProfileTable_src
echo Generating MIB TABLE ... wmanIfSsOfdmaUcdBurstProfileTable
mib2c -c mib2c.mfd.conf wmanIfSsOfdmaUcdBurstProfileTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfSsOfdmaDcdBurstProfileTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfSsOfdmaDcdBurstProfileTable_src
cd wmanIfSsOfdmaDcdBurstProfileTable_src
echo Generating MIB TABLE ... wmanIfSsOfdmaDcdBurstProfileTable
mib2c -c mib2c.mfd.conf wmanIfSsOfdmaDcdBurstProfileTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfCmnClassifierRuleTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfCmnClassifierRuleTable_src
cd wmanIfCmnClassifierRuleTable_src
echo Generating MIB TABLE ... wmanIfCmnClassifierRuleTable
mib2c -c mib2c.mfd.conf wmanIfCmnClassifierRuleTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfCmnPhsRuleTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfCmnPhsRuleTable_src
cd wmanIfCmnPhsRuleTable_src
echo Generating MIB TABLE ... wmanIfCmnPhsRuleTable
mib2c -c mib2c.mfd.conf wmanIfCmnPhsRuleTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfCmnCpsServiceFlowTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfCmnCpsServiceFlowTable_src
cd wmanIfCmnCpsServiceFlowTable_src
echo Generating MIB TABLE ... wmanIfCmnCpsServiceFlowTable
mib2c -c mib2c.mfd.conf wmanIfCmnCpsServiceFlowTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfCmnBsSsConfigurationTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfCmnBsSsConfigurationTable_src
cd wmanIfCmnBsSsConfigurationTable_src
echo Generating MIB TABLE ... wmanIfCmnBsSsConfigurationTable
mib2c -c mib2c.mfd.conf wmanIfCmnBsSsConfigurationTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


echo Started Generating MIB2C files...
if [ ! -d wmanIfCmnCryptoSuiteTable_src ]		# be sure the directory /mnt exists
then	echo Creating Directory...
mkdir wmanIfCmnCryptoSuiteTable_src
cd wmanIfCmnCryptoSuiteTable_src
echo Generating MIB TABLE ... wmanIfCmnCryptoSuiteTable
mib2c -c mib2c.mfd.conf wmanIfCmnCryptoSuiteTable
echo Removing Temporary files ...
rm -f *~
cd ..
fi


