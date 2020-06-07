CREATE FUNCTION DescriptionContainsKeywords (@desc VARCHAR(max), @keywords nvarchar(max))
RETURNS int
AS BEGIN
    DECLARE @MatchCount int
	DECLARE @TotalKeyWords int

	set @MatchCount = (select count(a.value) from 
	(select distinct REPLACE(value,'.','') as value from string_split(@desc,' ')) a,
	(select distinct value from string_split(@keywords, ';')) b
	where REPLACE(a.value,'.','') = b.value)

	select @TotalKeyWords = (select count(a.value) from (select value from string_split(@keywords, ';')) a)


    RETURN @MatchCount - @TotalKeyWords
END