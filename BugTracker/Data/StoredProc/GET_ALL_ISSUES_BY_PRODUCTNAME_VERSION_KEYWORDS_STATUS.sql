-- ==========================================================================================================

-- Author: Dilip Agheda

-- Create date: 08/06/2020

-- Description: A stored proc which returns issues filtered by product name, version, keywords and status

-- ==========================================================================================================

  DROP PROCEDURE IF EXISTS GET_ALL_ISSUES_BY_PRODUCTNAME_VERSION_KEYWORDS_STATUS
  GO

  CREATE PROCEDURE GET_ALL_ISSUES_BY_PRODUCTNAME_VERSION_KEYWORDS_STATUS @VersionName nvarchar(max), @ProductName nvarchar(max), @Keywords nvarchar(max) , @Status nvarchar(max)
  AS

  SELECT I.Id, P.ProductName, V.VersionName, O.OSName, S.Status, I.Description, I.Resolution, I.CreationDate, I.ResolutionDate 
  FROM Issues I, Products P, Versions V, OperatingSystems O, IssueStatusList S, ProductOSVersions POV
  WHERE I.ProductOSVersionId = POV.Id
  AND POV.ProductId = P.Id
  AND POV.VersionId = V.Id
  AND POV.OperatingSystemId = O.Id
  AND I.IssueStatusId = S.Id
  AND S.Status = @Status
  AND P.ProductName = @ProductName
  AND V.VersionName = @VersionName
  AND dbo.DescriptionContainsKeywords(I.Description,@Keywords) > 0