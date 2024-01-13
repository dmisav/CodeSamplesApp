using SampleCodeApp.Examples;

namespace SampleCodeApp.Tests;

[TestFixture]
public class AddOneToNumberFolllowedByDigitTests
{
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void ShoudCheckNumerIsAdded()
    {
       var res = AddOneToNumberFolllowedByDigit.GetAddOneToNumberFolllowedByDigit("abcr123456");
       Assert.AreEqual(res,"abcr123457");
    }

    [Test]
    public void ShouldAddUsingRegex()
    {
        var res = AddOneToNumberFolllowedByDigit.GetAddOnRegex("abcd1234");
        Assert.AreEqual(res, "abcd1235");
    }

}

/*
CREATE FUNCTION IncrementIdentifier(@Identifier NVARCHAR(255))
   RETURNS NVARCHAR(255)
   AS
   BEGIN
   DECLARE @AlphaPart NVARCHAR(255);
   DECLARE @NumericPart NVARCHAR(255);
   DECLARE @NumericValue INT;
   
   -- Extract alphabetic part
   SET @AlphaPart = LEFT(@Identifier, PATINDEX('%[0-9]%', @Identifier) - 1);
   
   -- Extract numeric part
   SET @NumericPart = SUBSTRING(@Identifier, PATINDEX('%[0-9]%', @Identifier), LEN(@Identifier));
   
   -- Convert numeric part to integer and add one
   SET @NumericValue = CAST(@NumericPart AS INT) + 1;
   
   -- Handle potential overflow if the number part reaches its maximum value
   IF LEN(CAST(@NumericValue AS NVARCHAR)) > LEN(@NumericPart)
   BEGIN
   -- Reset or handle overflow (e.g., reset to 1 or throw an error)
   SET @NumericValue = 1; -- Example: reset to 1
   END
   
   -- Concatenate back together and return
   RETURN @AlphaPart + CAST(@NumericValue AS NVARCHAR);
   END;
*/