<xsl:stylesheet version="2.0"
 xmlns="urn:schemas-microsoft-com:office:spreadsheet"
 xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
 xmlns:msxsl="urn:schemas-microsoft-com:xslt"
 xmlns:user="urn:my-scripts"
 xmlns:o="urn:schemas-microsoft-com:office:office"
 xmlns:x="urn:schemas-microsoft-com:office:excel"
 xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
 xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xsl:preserve-space elements="*" />
  <xsl:template match="/">
    <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
      xmlns:o="urn:schemas-microsoft-com:office:office"
      xmlns:x="urn:schemas-microsoft-com:office:excel"
      xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
      xmlns:html="http://www.w3.org/TR/REC-html40">
      <xsl:apply-templates/>
    </Workbook>
  </xsl:template>
  <xsl:preserve-space elements="*" />
  <xsl:template match="/*">

    <Styles>
      <Style ss:ID="Default" ss:Name="Normal">
        <Alignment ss:Vertical="Bottom"/>
        <Borders/>
        <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        <Interior/>
        <NumberFormat/>
        <Protection/>
      </Style>
      <Style ss:ID="s63">
        <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
        <Borders/>
        <Font ss:FontName="Book Antiqua" x:Family="Roman" ss:Size="11"
         ss:Color="#FFFFFF" ss:Bold="1"/>
        <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
      </Style>
      <Style ss:ID="s69">
        <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
        <Borders>
          <Border ss:Position="Bottom" ss:LineStyle="Dot" ss:Weight="1"
           ss:Color="#000000"/>
          <Border ss:Position="Left" ss:LineStyle="Dot" ss:Weight="1" ss:Color="#000000"/>
          <Border ss:Position="Right" ss:LineStyle="Dot" ss:Weight="1" ss:Color="#000000"/>
          <Border ss:Position="Top" ss:LineStyle="Dot" ss:Weight="1" ss:Color="#000000"/>
        </Borders>
        <Font ss:FontName="Book Antiqua" x:Family="Roman" ss:Color="#000000"/>
      </Style>
      <Style ss:ID="s70">
        <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
        <Borders>
          <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"
           ss:Color="#1F497D"/>
          <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"
           ss:Color="#1F497D"/>
          <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"
           ss:Color="#1F497D"/>
        </Borders>
        <Font ss:FontName="Book Antiqua" x:Family="Roman" ss:Size="11"
         ss:Color="#FFFFFF" ss:Bold="1"/>
        <Interior ss:Color="#1F497D" ss:Pattern="Solid"/>
      </Style>
      <Style ss:ID="s71">
        <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
        <Borders>
          <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"
           ss:Color="#1F497D"/>
          <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"
           ss:Color="#1F497D"/>
        </Borders>
        <Font ss:FontName="Book Antiqua" x:Family="Roman" ss:Size="11"
         ss:Color="#FFFFFF" ss:Bold="1"/>
        <Interior ss:Color="#1F497D" ss:Pattern="Solid"/>
      </Style>
      <Style ss:ID="s72">
        <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
        <Borders>
          <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"
           ss:Color="#1F497D"/>
          <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"
           ss:Color="#1F497D"/>
          <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"
           ss:Color="#1F497D"/>
        </Borders>
        <Font ss:FontName="Book Antiqua" x:Family="Roman" ss:Size="11"
         ss:Color="#FFFFFF" ss:Bold="1"/>
        <Interior ss:Color="#1F497D" ss:Pattern="Solid"/>
      </Style>
      <Style ss:ID="s75">
        <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
      </Style>
      <Style ss:ID="s76">
        <Font ss:FontName="Book Antiqua" x:Family="Roman" ss:Size="14"
         ss:Color="#000000" ss:Bold="1"/>
        <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
      </Style>
      <Style ss:ID="s88">
        <Font ss:FontName="Book Antiqua" x:Family="Roman" ss:Size="14"
         ss:Color="#000000"/>
        <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
      </Style>
    </Styles>
    <Worksheet ss:Name="Report" >

      <Table  x:FullColumns="1" x:FullRows="1" ss:DefaultRowHeight="15">
        <xsl:for-each select="*[position() = 1]/*">
          <Column ss:AutoFitWidth="0" ss:Width="123.75"/>
        </xsl:for-each>
       
        <Row ss:AutoFitHeight="0" ss:Height="25.5">
          <xsl:for-each select="*[position() = 1]/*">
            <Cell ss:StyleID="s72">
              <Data ss:Type="String" >
                <xsl:value-of select="translate(local-name(),'_-','- ')"/>
              </Data>
            </Cell>
          </xsl:for-each>
        </Row>
        <!--<Row ss:AutoFitHeight="0" ss:Height="4.5">
          <xsl:for-each select="*[position() = 1]/*">
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">

              </Data>
            </Cell>
          </xsl:for-each>
        </Row>-->
        <xsl:apply-templates/>
      </Table>
    </Worksheet>
  </xsl:template>


  <xsl:template match="/*/*">
    <Row>
      <xsl:apply-templates/>
    </Row>
  </xsl:template>


  <xsl:template match="/*/*/*">
    <!--<xsl:choose>
      <xsl:when test="local-name() = 'ID'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Color'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="String" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Copied'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Emailed'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Faxed'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Hour'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Jobs'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Monthly-Pages'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Pages'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Per-Month'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Printed'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Scanned'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Cost'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Costs'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Total-Simplex-Pages'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Total-Duplex-Pages'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = '_-of-Total-Simplex'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = '_-of-Total-Duplex'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Total-Pages'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Total-Color-Pages'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Total-Monochrome-Pages'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = '_-of-Total-Color'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = '_-of-Total-Monochrome'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Users'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = 'Total-Simplex-Pages'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:when test="local-name() = '_-of-Total-Simplex'">
        <Cell ss:StyleID="s69">
          <Data ss:Type="Number" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      </xsl:when>
      <xsl:otherwise>-->
        <Cell ss:StyleID="s69">
          <Data ss:Type="String" >
            <xsl:value-of select="."/>
          </Data>
        </Cell>
      <!--</xsl:otherwise>
    </xsl:choose>-->
  </xsl:template>
</xsl:stylesheet>
