CREATE PROCEDURE [dbo].[SITE_GET_FullFlatInfoById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Flats f
	INNER JOIN Houses h ON h.Id = f.IdHouse
	INNER JOIN Districts d ON d.Id = h.IdDistrict
	INNER JOIN Regions r ON r.Id = d.IdRegion
	WHERE f.Id = @Id;
END