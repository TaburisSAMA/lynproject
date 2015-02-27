<?xml version="1.0" encoding="ISO-8859-1"?>

<!--

  INTEL CONFIDENTIAL

  Copyright 2000 - 2003 Intel Corporation All Rights Reserved.

  The source code contained or described herein and all documents related to
  the source code ("Material") are owned by Intel Corporation or its
  suppliers or licensors.

  Title to the Material remains with Intel Corporation or its suppliers and
  licensors. The Material contains trade secrets and proprietary and
  confidential information of Intel or its suppliers and licensors.
  The Material is protected by worldwide copyright and trade secret laws and
  treaty provisions. No part of the Material may be used, copied, reproduced,
  modified, published, uploaded, posted, transmitted, distributed,
  or disclosed in any way without Intel's prior express written permission.

  No license under any patent, copyright, trade secret or other intellectual
  property right is granted to or conferred upon you by disclosure
  or delivery of the Materials, either expressly, by implication, inducement,
  estoppel or otherwise. Any license under such intellectual property rights
  must be express and approved by Intel in writing.

-->

<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:output method="xml" indent="yes"/>

<!-- 
       Helper functions 
  -->

<xsl:template name="descr">
  <xsl:if test="$output = 'header'">
    <xsl:for-each select="descr">
      <xsl:copy-of select="."/>
    </xsl:for-each>
    <xsl:for-each select="oem/descr">
      <xsl:copy-of select="."/>
    </xsl:for-each>
    <xsl:for-each select="range">
      <xsl:copy-of select="."/>
    </xsl:for-each>
    <xsl:for-each select="see">
      <xsl:copy-of select="."/>
    </xsl:for-each>
    <xsl:for-each select="ref">
      <xsl:copy-of select="."/>
    </xsl:for-each>
  </xsl:if>
</xsl:template>

<xsl:template name="check-last">
  <xsl:attribute name="last">
    <xsl:if test="name(following-sibling::*[1]) != name(.)">
      <xsl:text>yes</xsl:text>
    </xsl:if>
    <xsl:if test="name(following-sibling::*[1]) = name(.)">
      <xsl:text>no</xsl:text>
    </xsl:if>
  </xsl:attribute>
</xsl:template>

<xsl:template name="field">
  <xsl:if test="name()='selectfield' or name(..)='struct' or 
                (name(../..)='struct' and name(..)!='selectunion') or name(..)='vector'">
    <xsl:element name="StructField">
      <xsl:attribute name="type">
        <xsl:value-of select="@type"/>
      </xsl:attribute>
      <xsl:attribute name="name">
        <xsl:value-of select="@name"/>
      </xsl:attribute>
      <xsl:attribute name="brief">
        <xsl:value-of select="@brief"/>
      </xsl:attribute>
      <xsl:if test="@size">
        <xsl:attribute name="size">
          <xsl:value-of select="@size"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:call-template name="descr"/>
      <xsl:copy-of select="selector"/>
    </xsl:element>
  </xsl:if>
  <xsl:if test="name() = 'field' and (name(..)='selectunion' or name(../..)='selectunion')">
    <xsl:element name="UnionField">
      <xsl:attribute name="type">
        <xsl:value-of select="@type"/>
      </xsl:attribute>
      <xsl:attribute name="name">
        <xsl:value-of select="@name"/>
      </xsl:attribute>
      <xsl:attribute name="brief">
        <xsl:value-of select="@brief"/>
      </xsl:attribute>
      <xsl:if test="@size">
        <xsl:attribute name="size">
          <xsl:value-of select="@size"/>
        </xsl:attribute>
      </xsl:if>
      <xsl:call-template name="descr"/>
      <xsl:copy-of select="selector"/>
    </xsl:element>
  </xsl:if>
</xsl:template>

<xsl:template name="get-xdrids">
  <xsl:if test="$output = 'xdr'">
    <XdrIds>
    <xsl:for-each select="//func | //functype">
      <xsl:if test="@xdrid">
        <xdrid>
          <xsl:attribute name="name">
            <xsl:value-of select="@xdrid"/>
          </xsl:attribute>
        </xdrid>
      </xsl:if>
    </xsl:for-each>
    </XdrIds>
  </xsl:if>
</xsl:template>

<xsl:template name="block-comment">
  <xsl:if test="$output = 'header'">
    <BlockComment>
      <xsl:attribute name="brief">
        <xsl:value-of select="@brief"/>
      </xsl:attribute>
      <xsl:call-template name="descr"/>
      <xsl:for-each select="param | return | callback">
        <xsl:copy-of select="."/>
      </xsl:for-each>
    </BlockComment>
  </xsl:if>
</xsl:template>
    
<xsl:template name="section">
  <xsl:if test="$output = 'header'">
    <Section>
      <xsl:attribute name="level">
        <xsl:value-of select="count(./ancestor::section)+1"/> 
      </xsl:attribute>
      <descr>
        <xsl:value-of select="@name"/>
      </descr>
      <descr/>
      <xsl:call-template name="descr"/>
    </Section>
  </xsl:if>
</xsl:template>

<xsl:template name="get-union">
  <xsl:if test="$output = 'xdr'">
    <xsl:for-each select="selectunion">
      <UnionBegin>
	<xsl:attribute name="type">
	  <xsl:value-of select="@type"/> 
	</xsl:attribute>
	<xsl:attribute name="selecttype">
	  <xsl:value-of select="selectfield/@type"/> 
	</xsl:attribute>
	<xsl:attribute name="selectname">
	  <xsl:value-of select="selectfield/@name"/> 
	</xsl:attribute>
      </UnionBegin>
        <xsl:apply-templates select="*[name()!='selectfield']"/>
      <UnionEnd/>
    </xsl:for-each>
  </xsl:if>
</xsl:template>

<!--
     Common rules
  -->

<xsl:template match="/api">
  <api>
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
    <xsl:apply-templates/>
    <ApiEnd/>
  </api> 
</xsl:template>

<xsl:template match="/api/preamble">
  <Preamble>
    <xsl:value-of select="."/>
  </Preamble>
</xsl:template>

<xsl:template match="oem">
  <xsl:if test="contains(@name,$oem)">
    <xsl:apply-templates/>
  </xsl:if>
</xsl:template>

<xsl:template match="imports">
  <Imports>
    <xsl:apply-templates/>
  </Imports>
  <xsl:call-template name="get-xdrids"/>
</xsl:template>

<xsl:template match="import">
  <xsl:copy-of select="."/>
</xsl:template>

<xsl:template match="section">
  <xsl:call-template name="section"/>
  <xsl:apply-templates/>
</xsl:template>



<xsl:template match="enum">
  <xsl:call-template name="block-comment"/>
  <EnumBegin>
    <xsl:attribute name="type">
      <xsl:value-of select="@type"/>
    </xsl:attribute>
  </EnumBegin>
  <xsl:apply-templates/>
  <EnumEnd>
    <xsl:attribute name="type">
      <xsl:value-of select="@type"/>
    </xsl:attribute>
  </EnumEnd>
</xsl:template>

<xsl:template match="enum/field | enum/oem/field">
  <EnumField>
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
    <xsl:attribute name="value">
      <xsl:value-of select="@value"/>
    </xsl:attribute>
    <xsl:attribute name="brief">
      <xsl:value-of select="@brief"/>
    </xsl:attribute>
    <xsl:call-template name="check-last"/>
    <xsl:copy-of select="./*"/>
  </EnumField>
</xsl:template>

<xsl:template match="struct">
  <xsl:call-template name="block-comment"/>
  <xsl:call-template name="get-union"/>
  <StructBegin>
    <xsl:attribute name="type">
      <xsl:value-of select="@type"/>
    </xsl:attribute>
  </StructBegin>
  <xsl:apply-templates/>
  <StructEnd>
    <xsl:attribute name="type">
      <xsl:value-of select="@type"/>
    </xsl:attribute>
  </StructEnd>
</xsl:template>

<xsl:template match="field | selectfield">
  <xsl:call-template name="field"/>
</xsl:template>

<xsl:template match="typedef">
  <xsl:call-template name="block-comment"/>
  <Typedef>
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
    <xsl:attribute name="type">
      <xsl:value-of select="@type"/>
    </xsl:attribute>
    <xsl:if test="@size">
      <xsl:attribute name="size">
        <xsl:value-of select="@size"/>
      </xsl:attribute>
    </xsl:if>
  </Typedef>
</xsl:template>

<xsl:template match="func">
  <xsl:if test="$output = 'header' or @xdrid">
    <xsl:call-template name="block-comment"/>
    <FuncBegin>
      <xsl:attribute name="name">
	<xsl:value-of select="@name"/>
      </xsl:attribute>
      <xsl:attribute name="type">
	<xsl:value-of select="@type"/>
      </xsl:attribute>
      <xsl:attribute name="class">
	<xsl:value-of select="@class"/>
      </xsl:attribute>
    </FuncBegin>
    <xsl:apply-templates/>
    <FuncEnd>
      <xsl:attribute name="class">
	<xsl:value-of select="@class"/>
      </xsl:attribute>
    </FuncEnd>        
  </xsl:if>
</xsl:template>

<xsl:template match="param">
  <xsl:if test="$output = 'header' or not($output = 'xdr' and @xdr = 'no')">
  <Param>
    <xsl:attribute name="io">
      <xsl:value-of select="@io"/>
    </xsl:attribute>
    <xsl:attribute name="type">
      <xsl:value-of select="@type"/>
    </xsl:attribute>
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
    <xsl:if test="@xdr">
      <xsl:attribute name="xdr">
	<xsl:value-of select="@xdr"/>
      </xsl:attribute>
    </xsl:if>
    <xsl:if test="not(@xdr)">
      <xsl:attribute name="xdr">
	<xsl:text>no</xsl:text>
      </xsl:attribute>
    </xsl:if>
    <xsl:call-template name="check-last"/>
    <xsl:if test="@class">
      <xsl:attribute name="class">
        <xsl:value-of select="@class"/>
      </xsl:attribute>
      <xsl:if test="@class = 'vector'">
        <xsl:copy-of select="length"/>
      </xsl:if>
    </xsl:if>
  </Param>
  </xsl:if>
</xsl:template>

<xsl:template match="define">
  <xsl:call-template name="block-comment"/>
  <Defines>
    <xsl:for-each select="field">
      <xsl:copy-of select="."/>
    </xsl:for-each>
  </Defines>
</xsl:template>

<xsl:template match="optional">
  <OptBegin>
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
    <xsl:call-template name="descr"/>
  </OptBegin>
  <xsl:apply-templates/>
  <OptEnd>
    <xsl:attribute name="name">
      <xsl:value-of select="@name"/>
    </xsl:attribute>
  </OptEnd>
</xsl:template>


<!--
       Header/Xdr
  -->

<xsl:template match="functype">
  <xsl:if test="$output = 'header'">
    <xsl:call-template name="block-comment"/>
    <FunctypeBegin>
      <xsl:attribute name="name">
	<xsl:value-of select="@name"/>
      </xsl:attribute>
      <xsl:attribute name="type">
	<xsl:value-of select="@type"/>
      </xsl:attribute>
    </FunctypeBegin>
    <xsl:apply-templates/>
    <FunctypeEnd/>
  </xsl:if>
</xsl:template>

<xsl:template match="vector">
  <xsl:if test="$output = 'header'">
    <xsl:apply-templates/>
    <StructField>
      <xsl:attribute name="type">
	<xsl:value-of select="@type"/>
	<xsl:text>*</xsl:text>
      </xsl:attribute>
      <xsl:attribute name="name">
	<xsl:value-of select="@name"/>
      </xsl:attribute>
      <xsl:attribute name="brief">
	<xsl:value-of select="@brief"/>
      </xsl:attribute>
      <xsl:call-template name="descr"/>
    </StructField>
  </xsl:if>
  <xsl:if test="$output = 'xdr'">
    <xsl:apply-templates/>
    <StructField>
      <xsl:attribute name="type">
	<xsl:value-of select="@type"/>
      </xsl:attribute>
      <xsl:attribute name="name">
	<xsl:value-of select="@name"/>
	<xsl:text>&lt;&gt;</xsl:text>
      </xsl:attribute>
    </StructField>
  </xsl:if>
</xsl:template>

<xsl:template match="vector/length">
  <xsl:if test="$output = 'header'">
    <xsl:call-template name="field"/>
  </xsl:if>
</xsl:template>

<xsl:template match="selectunion">
  <xsl:if test="$output = 'header'">
    <xsl:apply-templates select="selectfield"/>
    <UnionBegin/>
    <xsl:apply-templates select="*[name()!='selectfield']"/>
    <UnionEnd>
      <xsl:attribute name="name">
        <xsl:value-of select="@name"/>
      </xsl:attribute>
      <xsl:call-template name="descr"/>
    </UnionEnd>
  </xsl:if>
  <xsl:if test="$output = 'xdr'">
    <xsl:call-template name="field"/>
  </xsl:if>
</xsl:template>


<!-- 
       Eat unused text nodes
  -->
<xsl:template match="text()">
</xsl:template>

</xsl:stylesheet>
