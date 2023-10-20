<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:sig="http://www.w3.org/2000/09/xmldsig#">
  <xsl:output indent="yes" method="xml" omit-xml-declaration="yes"/>

  <xsl:template match="node() | @*">
    <xsl:copy>
      <xsl:apply-templates select="node() | @*"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="@id">
    <!-- @ matches on attributes, possible to restrict! -->
    <xsl:attribute name="{name()}">
      <!-- creates a new attribute with the same name -->
      <xsl:text>2</xsl:text>
      <!-- variable statement to get your desired value -->
    </xsl:attribute>
  </xsl:template>
</xsl:stylesheet>