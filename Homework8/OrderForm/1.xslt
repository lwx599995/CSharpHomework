<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

  <xsl:template match="ArrayOfOrder">
    <html>
      <head><h1 align="center">___Orders___</h1></head>
      <body>
        <table align="center" border="1">
          <tr  bgcolor="#9acd32">
            <th>OrderID</th>
            <th>Customer</th>
            <th>Details</th>
          </tr>
 
          <xsl:for-each select="Order">
              <tr>
                <td>
                  <xsl:value-of select="Id"/>
                </td>
                <td>
				<xsl:for-each select="Customer">
                  <xsl:value-of select="Name"/>,TEL:
				  <xsl:value-of select="TelNumber"/>
				</xsl:for-each>
                </td>
                <td>
				<xsl:for-each select="Details/OrderDetail">
				(<xsl:for-each select="Goods">
				<xsl:value-of select="gName"/>,Price:
				<xsl:value-of select="Price"/>,Quantity:
				</xsl:for-each>
	              <xsl:value-of select="Quantity"/>)<br/>
				</xsl:for-each>
                </td>
              </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

				
</xsl:stylesheet>
