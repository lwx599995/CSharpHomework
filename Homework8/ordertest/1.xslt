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

  <xsl:template match="books">
    <html>
      <head>Orders</head>
      <body>
        <table border="1">
          <tr  bgcolor="#9acd32">
            <th>OrderID</th>
            <th>Customer</th>
            <th>Details</th>
          </tr>
 
          <xsl:for-each select="Order">
              <tr>
                <td>
                  <xsl:value-of select="ID"/>
                </td>
                <td>
                  <xsl:value-of select="Customer"/>
                </td>
                <td>
                  <xsl:value-of select="Details"/>
                </td>
              </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>