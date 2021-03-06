set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

/************************************************************
 * Code formatted by SoftTree SQL Assistant © v4.0.34
 * Time: 21/12/2011 3:02:21 PM
 ************************************************************/

ALTER PROCEDURE [dbo].[spGetPatientListByDate]
( --@Date DATETIME,
@pTestDateFrom   NVARCHAR(10),
    @pTestDateTo     NVARCHAR(10)

)
AS
	SELECT (
	           SELECT TOP 1 tti.Barcode
	           FROM   T_TEST_INFO tti
	           WHERE  tti.Patient_ID = lpi.Patient_ID
	       ) AS SID
	      ,lpi.*
	      ,(dbo.PatientSex(lpi.Sex)) AS SexName
	      ,(
	           SELECT TOP 1 ld.sName
	           FROM   L_Department ld
	           WHERE  ld.ID = lpi.DepartmentID
	       ) AS Department_Name
	FROM   L_PATIENT_INFO lpi
	WHERE  --dbo.trunc(lpi.DATEUPDATE) = dbo.trunc(@Date)AND 
	 (
	           CONVERT(DATETIME, CONVERT(NVARCHAR(10), DATEUPDATE, 103), 103) 
	           BETWEEN CONVERT(DATETIME, @pTestDateFrom, 103)
	           
	           AND
	           CONVERT(DATETIME, @pTestDateTo, 103)
	       )

	
	SELECT tti.*
	      ,(
	           SELECT TOP 1 tttl.TestType_Name
	           FROM   T_TEST_TYPE_LIST tttl
	           WHERE  tttl.TestType_ID = tti.TestType_ID
	       ) AS TestType_Name
	      ,(
	           SELECT TOP 1 lts.TestStatus_Name
	           FROM   L_Test_Status lts
	           WHERE  tti.Test_Status = lts.TestStatus_ID
	       ) AS TestStatus_Name
	FROM   T_TEST_INFO tti
	WHERE  EXISTS(
	           SELECT 1
	           FROM   L_PATIENT_INFO lpi
	           WHERE  lpi.Patient_ID = tti.Patient_ID
	                 AND  --AND dbo.trunc(lpi.DATEUPDATE) = dbo.trunc(@Date)
	                   (
	           CONVERT(DATETIME, CONVERT(NVARCHAR(10), DATEUPDATE, 103), 103) 
	           BETWEEN CONVERT(DATETIME, @pTestDateFrom, 103)
	           
	           AND
	           CONVERT(DATETIME, @pTestDateTo, 103)
	       )
	       )

