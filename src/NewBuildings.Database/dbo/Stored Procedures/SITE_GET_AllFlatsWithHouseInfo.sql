CREATE PROCEDURE [dbo].[SITE_GET_AllFlatsWithHouseInfo]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * 
	FROM Flats f
	INNER JOIN Houses h ON  f.IdHouse = h.Id;
END

