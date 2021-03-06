set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go









ALTER PROCEDURE [dbo].[sp_DailyTestReport_NB]
(
    @pTestDateFrom  NVARCHAR(10)
   ,@pTestDateTo    NVARCHAR(10)
   ,@pTestType_ID   INT
)
AS
	SELECT T.*
	      ,(
	           SELECT TOP 1 CONVERT(NVARCHAR(10) ,test_date ,103)
	           FROM   T_RESULT_DETAIL
	           WHERE  Barcode = T.Barcode
	       ) AS TestDate
	      ,(
	           SELECT TOP 1 TestType_Name
	           FROM   T_Test_Type_List
	           WHERE  TestType_ID = T.TestType_ID
	       ) AS TestTypeName
	FROM   (
	           SELECT DISTINCT Barcode
	                 ,Testtype_ID
	           FROM   T_RESULT_DETAIL
	           --WHERE  
--	            dbo.trunc( TEST_DATE)BETWEEN dbo.trunc( @pTestDateFrom) 
--	                  AND dbo.trunc (@pTestDateTo)
	           WHERE  
	           CONVERT(VARCHAR(10) ,TEST_DATE ,103) BETWEEN 
	                             CONVERT(VARCHAR(10) ,@pTestDateFrom ,103) AND 
	                             CONVERT(VARCHAR(10) ,@pTestDateTo ,103)
--	           CONVERT(DATETIME ,TEST_DATE ,103) BETWEEN CONVERT(DATETIME ,@pTestDateFrom ,103) 
--	                  AND CONVERT(DATETIME ,@pTestDateTo ,103)

	                  AND (@pTestType_ID=-1 OR TESTTYPE_ID=@pTestType_ID)
	       ) T





