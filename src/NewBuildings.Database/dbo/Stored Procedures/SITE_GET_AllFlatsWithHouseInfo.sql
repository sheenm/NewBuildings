CREATE PROCEDURE [dbo].[SITE_GET_AllFlatsWithHouseInfo]
AS
BEGIN
	SELECT * 
	FROM Flats f
	INNER JOIN Houses h ON  f.IdHouse = h.Id
END

