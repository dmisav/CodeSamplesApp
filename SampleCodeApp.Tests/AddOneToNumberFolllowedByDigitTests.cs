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
       var res = AddOneToNumberFolllowedByDigit.GetAddOneToNumberFolllowedByDigit("abcr123456", 4, 6);
       Assert.AreEqual(res,123457);
    }
}