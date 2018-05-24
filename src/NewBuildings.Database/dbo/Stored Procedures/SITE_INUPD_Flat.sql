CREATE PROCEDURE [dbo].[SITE_INUPD_Flat]
	@Id uniqueidentifier,
	@IdHouse uniqueidentifier,
	@RoomsCount int,
	@FullArea int,
	@KitchenArea int,
	@Floor int,
	@Cost decimal(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	IF (NOT EXISTS(SELECT 1 FROM Flats WHERE ID=@Id))
		INSERT INTO 
			Flats (
				 Id
				,IdHouse
				,RoomsCount
				,FullArea
				,KitchenArea
				,[Floor]
				,Cost)
		VALUES (
			 @Id
			,@IdHouse
			,@RoomsCount
			,@FullArea
			,@KitchenArea
			,@Floor
			,@Cost)
	ELSE
		UPDATE Flats
		SET
			IdHouse = @IdHouse,
			RoomsCount = @RoomsCount,
			FullArea = @FullArea,
			KitchenArea = @KitchenArea,
			[Floor] = @Floor,
			Cost = @Cost
		WHERE Id = @Id
END