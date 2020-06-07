-- =========================================================================================

-- Author: Dilip Agheda

-- Create date: 08/06/2020

-- Description: A function which returns total matches in a description based on keywords

-- =========================================================================================
CREATE FUNCTION DescriptionContainsKeywords (@desc VARCHAR(max), @keywords nvarchar(max))
RETURNS int
AS BEGIN
    DECLARE @MatchCount int
	DECLARE @TotalKeyWords int
	DECLARE @Result bit

	set @MatchCount = (select count(distinct a.value) from 
	(select distinct value from string_split(@desc,' ')) a,
	(select distinct value from string_split(@keywords, ';')) b
	where '%'+a.value+'%' LIKE '%'+b.value+'%'  )

	return @MatchCount

END