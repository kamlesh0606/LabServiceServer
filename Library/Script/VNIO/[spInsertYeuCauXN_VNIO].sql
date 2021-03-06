ALTER PROCEDURE [dbo].[spInsertYeuCauXN_VNIO]
(
    @pidCanLamSangThucHien  INT
   ,@pthucHienCho           SMALLINT
   ,@ptrangThaiThucHien     INT
   ,@pyeuCauXetNghiem_Id    SMALLINT
   ,@pId                    INT
   ,@pmaBenhNhan            NVARCHAR(50)
   ,@pBarcode               NVARCHAR(50)
   ,@pTestType_ID           INT
   ,@psophieu               NVARCHAR(100)
   ,@pTestdate              DATETIME
   ,@pIsTestName            BIT,@pSendStatus bit
)
AS
	IF NOT EXISTS (
	       SELECT *
	       FROM   tblYeucauXetnghiem_VNIO 
	       WHERE  id = @pId
	   )
	    INSERT INTO tblYeucauXetnghiem_VNIO
	      (
	        idCanLamSangThucHien
	       ,thucHienCho
	       ,trangThaiThucHien
	       ,yeuCauXetNghiem_Id
	       ,Id
	       ,maBenhNhan
	       ,Barcode
	       ,TestType_ID
	       ,sophieu
	       ,test_date,   IsTestName ,SendStatus
	      )
	    VALUES
	      (
	        @pidCanLamSangThucHien
	       ,@pthucHienCho
	       ,@ptrangThaiThucHien
	       ,@pyeuCauXetNghiem_Id
	       ,@pId
	       ,@pmaBenhNhan
	       ,@pBarcode
	       ,@pTestType_ID
	       ,@psophieu
	       ,dbo.trunc(@pTestdate),@pIsTestName,@pSendStatus
	      )
	ELSE
	    UPDATE tblYeucauXetnghiem_VNIO
	    SET    idCanLamSangThucHien = @pidCanLamSangThucHien
	          ,thucHienCho = @pthucHienCho
	          ,trangThaiThucHien = @ptrangThaiThucHien
	          ,yeuCauXetNghiem_Id = @pyeuCauXetNghiem_Id
	          ,Id = @pId
	          ,maBenhNhan = @pmaBenhNhan
	          ,Barcode = @pBarcode
	          ,TestType_ID = @pTestType_ID
	          ,sophieu = @psophieu
	          ,test_date = dbo.trunc(@pTestdate)
	          ,IsTestName=@pIsTestName,SendStatus = @pSendStatus
	    WHERE   id = @pId
--
--
