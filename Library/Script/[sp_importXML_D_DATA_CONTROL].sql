set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROC [dbo].[sp_importXML_D_DATA_CONTROL]
(
    @Device_ID NUMERIC,
    @Data_Sequence INT,
    @Control_Type BIT,
    @Data_Name NVARCHAR(50),
    @Alias_Name NVARCHAR(50),
    @Measure_Unit NVARCHAR(50),
    @Data_Point SMALLINT,
    @Normal_Level NVARCHAR(100),
    @Normal_LevelW NVARCHAR(100),
    @Data_View BIT,
    @Data_Print BIT,
    @Description NVARCHAR(200)
)
AS
IF NOT EXISTS (
       SELECT TOP 1 Alias_Name
       FROM   D_DATA_CONTROL ddc
       WHERE  Alias_Name = @Alias_Name
   )
    INSERT INTO D_DATA_CONTROL
      (
        Device_ID,
        Data_Sequence,
        Control_Type,
        Data_Name,
        Alias_Name,
        Measure_Unit,
        Data_Point,
        Normal_LevelW,
        Normal_Level,
        Data_View,
        Data_Print,
        [Description]
      )
    VALUES
      (
        @Device_ID,
        @Data_Sequence,
        @Control_Type,
        @Data_Name,
        @Alias_Name,
        @Measure_Unit,
        @Data_Point,
        @Normal_Level,
        @Normal_LevelW,
        @Data_View,
        @Data_Print,
        @Description
      )
ELSE
    UPDATE D_DATA_CONTROL
    SET    Device_ID = @Device_ID,
           Data_Sequence = @Data_Sequence,
           Control_Type = @Control_Type,
           Data_Name = @Data_Name,
           Measure_Unit = @Measure_Unit,
           Data_Point = @Data_Point,
           Normal_Level = @Normal_Level,
           Normal_LevelW = @Normal_LevelW,
           Data_View = @Data_View,
           Data_Print = @Data_Print,
           [Description] = @Description
    WHERE  Alias_Name = @Alias_Name


