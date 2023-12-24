using SampleCodeApp.Examples;
using SampleCodeApp.Implemnetations.Multimap;

namespace SampleCodeApp.Tests;

public class Tests
{
    private IMultimap<string, int> sut;

    [SetUp]
    public void Setup()
    {
        sut = new MultiMap<string, int>();
        sut.Add("C", 3);
    }

    [Test]
    public void ShouldRetrieveValuesByKey()
    {
        Assert.AreEqual(sut.GetValueForKey("C"), new List<int>{ 3 } );
    }
    
    [Test]
    public void ShouldAddValuesByKey()
    {
        sut.Add("A", 1);
        sut.Add("A", 2);
        Assert.That(new List<int>{ 1, 2 }, Is.EqualTo(sut.GetValueForKey("A")));
    } 
}