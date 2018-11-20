<?xml version="1.0" encoding="utf-8" ?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

	<xsl:template match="/">

		<html>

			<head>

				<title>Orders</title>

			</head>

			<body>

				<ul>
          <xsl:for-each select="OrderService/orderDict/Order">

            <br/>

            <br/>
            <li>
              订单号：

              <xsl:value-of select="OrderId" />

            </li>
              <li>
              客户名：

              <xsl:value-of select="OrderCustomer" />

            </li>

  
            <li>
              手机号：

              <xsl:value-of select="phoneNumber" />

            </li>

            <li>
              总金额：

              <xsl:value-of select="Amount" />

            </li>
            <xsl:for-each select="Details/OrderDetail">
              <li>
                订单明细：

                <xsl:value-of select="Id" />
                &#160; &#160;
                <xsl:for-each select="Goods">
                商品名称：

                <xsl:value-of select="GoodName" />
                  &#160; &#160;
                商品单价：

                <xsl:value-of select="price" />
                  &#160; &#160;
                </xsl:for-each>
                商品数量：

                <xsl:value-of select="Quantity" />
                &#160; &#160;
                  
                商品总价：

                <xsl:value-of select="amount" />

              </li>

            </xsl:for-each>
        
          </xsl:for-each>
           

					

				</ul>

			</body>

		</html>

	</xsl:template>

</xsl:stylesheet>