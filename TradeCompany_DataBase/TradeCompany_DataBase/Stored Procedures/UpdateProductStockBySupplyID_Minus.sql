	CREATE PROCEDURE [TradeCompany_DataBase].[UpdateProductStockBySupplyID_Minus]
	@SupplyID int
AS
	UPDATE  P
SET
    P.StockAmount =  P.StockAmount - SL.Amount
FROM
    [TradeCompany_DataBase].Products AS P
    JOIN [TradeCompany_DataBase].SupplyLists AS SL
        ON SL.ProductID = P.ID
WHERE
    SL.SupplyID = @SupplyID