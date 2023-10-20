<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output omit-xml-declaration="yes" indent="yes"/>
  <xsl:strip-space elements="*"/>
  <xsl:param name="age" select="'444'"/>
  <xsl:template match="node()|@*">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="pageViewModel/fields/group/field/text()">
    <xsl:attribute name="{name()}">
      <xsl:value-of select="$age"/>
    </xsl:attribute>
  </xsl:template>
</xsl:stylesheet>