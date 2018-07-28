CREATE VIEW [dbo].[Address]
WITH SCHEMABINDING
AS

SELECT TOP 5000 T.[To] AS Address
      ,T.[Value] AS ToValue
      ,T.[Count] AS ToCount
	  ,F.[Value] AS FromValue
	  ,F.[Count] AS FromCount
	  ,T.[Value] - F.[Value] as TotalValue
	  ,T.[Count] + F.[Count] as TotalCount
  FROM [dbo].[AddressTo] as T
  JOIN [dbo].[AddressFrom] as F ON T.[To] = F.[From]
  ORDER BY TotalValue DESC
GO
