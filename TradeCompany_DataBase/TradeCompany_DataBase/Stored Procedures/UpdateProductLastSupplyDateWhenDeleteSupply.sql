CREATE PROCEDURE [TradeCompany_DataBase].[UpdateProductLastSupplyDateWhenDeleteSupply]
		@SupplyID int
AS
	UPDATE  P
SET
    P.LastSupplyDate = LS.LastSupply  
FROM
(select P.ID, P.LastSupplyDate from
		[TradeCompany_DataBase].Products AS P
	JOIN [TradeCompany_DataBase].SupplyLists AS SL ON SL.ProductID = P.ID
	join [TradeCompany_DataBase].Supplies as S ON SL.SupplyID = S.ID
	where S.ID = @SupplyID) P 
	left join
(select P.ID, Max(S.DateTime) as LastSupply from
    [TradeCompany_DataBase].Products AS P
    JOIN [TradeCompany_DataBase].SupplyLists AS SL ON SL.ProductID = P.ID
	join [TradeCompany_DataBase].Supplies as S ON SL.SupplyID = S.ID
	where S.ID <> @SupplyID
	group by P.ID, P.LastSupplyDate) LS on P.ID = LS.ID