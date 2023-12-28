using SampleCodeApp.Implemnetations.Multimap;

namespace SampleCodeApp.Tests;

public class MultiMapTests
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
        Assert.AreEqual(sut.GetValueForKey("C"), new HashSet<int>{ 3 } );
    }
    
    [Test]
    public void ShouldAddValuesByKey()
    {
        sut.Add("A", 1);
        sut.Add("A", 2);
        Assert.That(new HashSet<int>{ 1, 2 }, Is.EqualTo(sut.GetValueForKey("A")));
    }
    
           [Test]
        public void Union_ShouldReturnUnionOfMultiMaps()
        {
            var multiMap1 = new MultiMap<string, int>();
            multiMap1.Add("one", 1);
            multiMap1.Add("two", 2);

            var multiMap2 = new MultiMap<string, int>();
            multiMap2.Add("two", 2);
            multiMap2.Add("three", 3);

            var unionResult = multiMap1.Union(multiMap2);

            Assert.AreEqual(new HashSet<int>{ 1 }, unionResult["one"]);
            Assert.AreEqual(new HashSet<int>{ 2 }, unionResult["two"]);
            Assert.AreEqual(new HashSet<int>{ 3 }, unionResult["three"]);
        }

        [Test]
        public void Intersect_ShouldReturnIntersectionOfMultiMaps()
        {
            var multiMap1 = new MultiMap<string, int>();
            multiMap1.Add("one", 1);
            multiMap1.Add("two", 2);

            var multiMap2 = new MultiMap<string, int>();
            multiMap2.Add("two", 2);
            multiMap2.Add("three", 3);

            var intersectResult = multiMap1.Intersect(multiMap2);

            Assert.AreEqual(new[] { 2 }, intersectResult["two"]);
        }

        [Test]
        public void Except_ShouldReturnDifferenceOfMultiMaps()
        {
            var multiMap1 = new MultiMap<string, int>();
            multiMap1.Add("one", 1);
            multiMap1.Add("two", 2);

            var multiMap2 = new MultiMap<string, int>();
            multiMap2.Add("two", 2);
            multiMap2.Add("three", 3);

            var exceptResult = multiMap1.Except(multiMap2);

            Assert.AreEqual(new[] { 1 }, exceptResult["one"]);
        }

        [Test]
        public void SymmetricExcept_ShouldReturnSymmetricDifferenceOfMultiMaps()
        {
            var multiMap1 = new MultiMap<string, int>();
            multiMap1.Add("one", 1);
            multiMap1.Add("two", 2);

            var multiMap2 = new MultiMap<string, int>();
            multiMap2.Add("two", 2);
            multiMap2.Add("three", 3);

            var symmetricExceptResult = multiMap1.SymmetricExcept(multiMap2);

            Assert.AreEqual(new[] { 1 }, symmetricExceptResult["one"]);
            Assert.AreEqual(new[] { 3 }, symmetricExceptResult["three"]);
        }
}