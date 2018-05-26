using NewBuildings.Data.Abstract;
using Dapper;
using NewBuildings.Data.Objects;
using System.Data.Common;
using System;
using OfficeOpenXml;
using System.IO;

namespace NewBuildings.BootstrapApp
{
    /// <summary>
    /// This class is used to seed database
    /// </summary>
    public class DatabaseBootstraper
    {
        private readonly IDbConnectionFactory _connectionFactory;

        /// <summary>
        /// This class is used to seed database
        /// </summary>
        /// <param name="connectionFactory">we can't use repositories because we have to insert items with specified IDs</param>
        public DatabaseBootstraper(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Bootstrap()
        {
            var seedDataFile = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}DataForSeed.xlsx");

            using (var connection = _connectionFactory.CreateConnection())
            using (var excel = new ExcelPackage(seedDataFile))
            {
                connection.Open();
                if (IsSeedNeeded(connection) == false)
                    return;

                var worksheet = excel.Workbook.Worksheets["Sheet1"];

                SeedRegions(connection, worksheet);
                SeedDistricts(connection, worksheet);
                SeedHouses(connection, worksheet);
                SeedFlats(connection, worksheet);
            }
        }

        private bool IsSeedNeeded(DbConnection openedConnection)
        {
            var regionsCount = openedConnection.RecordCount<Region>();
            return regionsCount == 0;
        }

        private void SeedRegions(DbConnection openedConnection, ExcelWorksheet worksheet)
        {
            openedConnection.Execute("SET IDENTITY_INSERT Regions ON");

            var insertSql = @"IF (NOT EXISTS(SELECT 1 FROM Regions WHERE Id = @Id))
                                INSERT INTO Regions (Id, Name) VALUES(@Id,@Name)";

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var id = worksheet.Cells[row, 6].GetValue<int>();
                var name = worksheet.Cells[row, 7].GetValue<string>();
                openedConnection.Execute(
                    sql: insertSql,
                    param: new { Id = id, Name = name });
            }

            openedConnection.Execute("SET IDENTITY_INSERT Regions OFF");
        }
        private void SeedDistricts(DbConnection openedConnection, ExcelWorksheet worksheet)
        {
            openedConnection.Execute("SET IDENTITY_INSERT Districts ON");

            var insertSql = @"IF (NOT EXISTS(SELECT 1 FROM Districts WHERE Id = @Id))
                                INSERT INTO Districts (Id, Name, IdRegion) VALUES(@Id,@Name,@IdRegion)";

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var id = worksheet.Cells[row, 8].GetValue<int>();
                var name = worksheet.Cells[row, 9].GetValue<string>();
                var regionId = worksheet.Cells[row, 6].GetValue<int>();

                openedConnection.Execute(
                    sql: insertSql,
                    param: new { Id = id, Name = name, IdRegion = regionId });
            }

            openedConnection.Execute("SET IDENTITY_INSERT Districts OFF");
        }

        private void SeedHouses(DbConnection openedConnection, ExcelWorksheet worksheet)
        {
            openedConnection.Execute("SET IDENTITY_INSERT Houses ON");

            var insertSql = @"IF (NOT EXISTS(SELECT 1 FROM Houses WHERE Id = @Id))
                                INSERT INTO Houses ( Id
                                                    ,ConstructionStage
                                                    ,HousingNumber
                                                    ,ResidentialComplexName
                                                    ,IdDistrict) 
                                            VALUES(  @Id
                                                    ,@ConstructionStage
                                                    ,@HousingNumber
                                                    ,@ResidentialComplexName
                                                    ,@IdDistrict)";

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var id = worksheet.Cells[row, 2].GetValue<int>();
                var constructionStage = worksheet.Cells[row, 4].GetValue<int>();
                var housingNumber = worksheet.Cells[row, 5].GetValue<string>();
                var residentialComplexName = worksheet.Cells[row, 3].GetValue<string>();
                var districtId = worksheet.Cells[row, 8].GetValue<int>();

                openedConnection.Execute(
                    sql: insertSql,
                    param: new
                    {
                        Id = id,
                        ConstructionStage = constructionStage,
                        HousingNumber = housingNumber,
                        ResidentialComplexName = residentialComplexName,
                        IdDistrict = districtId
                    });
            }

            openedConnection.Execute("SET IDENTITY_INSERT Houses OFF");
        }
        private void SeedFlats(DbConnection openedConnection, ExcelWorksheet worksheet)
        {
            openedConnection.Execute("SET IDENTITY_INSERT Flats ON");

            var insertSql = @" INSERT INTO Flats (   Id
                                                    ,IdHouse
                                                    ,RoomsCount
                                                    ,FullArea
                                                    ,KitchenArea
                                                    ,Floor
                                                    ,Cost) 
                                           VALUES(   @Id
                                                    ,@IdHouse
                                                    ,@RoomsCount
                                                    ,@FullArea
                                                    ,@KitchenArea
                                                    ,@Floor
                                                    ,@Cost)";

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var id = worksheet.Cells[row, 1].GetValue<int>();
                var houseId = worksheet.Cells[row, 2].GetValue<int>();
                var roomsCount = worksheet.Cells[row, 10].GetValue<int>();
                var fullArea = worksheet.Cells[row, 11].GetValue<double>();
                var kitchenArea = worksheet.Cells[row, 12].GetValue<double>();
                var floor = worksheet.Cells[row, 13].GetValue<int>();
                var cost = worksheet.Cells[row, 14].GetValue<decimal>();

                openedConnection.Execute(
                    sql: insertSql,
                    param: new
                    {
                        Id = id,
                        IDHouse = houseId,
                        RoomsCount = roomsCount,
                        FullArea = fullArea,
                        KitchenArea = kitchenArea,
                        Floor = floor,
                        Cost = cost,
                    });
            }

            openedConnection.Execute("SET IDENTITY_INSERT Flats OFF");
        }
    }
}
