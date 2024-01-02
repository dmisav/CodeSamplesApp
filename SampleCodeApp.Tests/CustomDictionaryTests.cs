using System.Collections;
using SampleCodeApp.Implemnetations.CustomDictionary;

namespace SampleCodeApp.Tests;

public class CustomDictionaryTests
{
    private ICustomDictionary<string, int> sut = new CustomDictionary<string, int>();

    [SetUp]
    public void Init()
    {
    }

    [Test]
    public void Add_ThrowsExceptionForNullKey()
    {
        // Arrange
        var s = new CustomDictionary<string, int>();

        // Act & Assert
        Assert.Throws<Exception>(() => s.Add(null, 42));
    }

    [Test]
    public void TryAdd_ReturnsFalseForKeyAlreadyExists()
    {
        // Arrange
        var sut = new CustomDictionary<int, string>();
        sut.Add(1, "One");

        // Act
        bool result = sut.TryAdd(1, "Duplicate");

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void TryAdd_ReturnsFalseForNullKey()
    {
        // Arrange
        var sut = new CustomDictionary<string, int>();

        // Act
        bool result = sut.TryAdd(null, 42);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsKey_ReturnsTrueForExistingKey()
    {
        // Arrange
        var sut = new CustomDictionary<int, string>();
        sut.Add(1, "One");

        // Act
        bool result = sut.ContainsKey(1);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsKey_ReturnsFalseForNonExistingKey()
    {
        // Arrange
        var s = new CustomDictionary<string, int>();

        // Act
        bool result = s.ContainsKey("blah");

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void TryGetValue_ReturnsTrueForExistingKey()
    {
        // Arrange
        var s = new CustomDictionary<string, int>();
        sut.Add("One", 1);

        // Act
        bool result = sut.TryGetValue("One", out int value);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(1, value);
    }

    [Test]
    public void TryGetValue_ReturnsFalseForNonExistingKey()
    {
        // Arrange
        var sut = new CustomDictionary<int, string>();

        // Act
        bool result = sut.TryGetValue(1, out string value);

        // Assert
        Assert.IsFalse(result);
        Assert.IsNull(value);
    }

    [Test]
    public void Remove_RemovesKey()
    {
        // Arrange
        var sut = new CustomDictionary<int, string>();
        sut.Add(1, "One");

        // Act
        sut.Remove(1);

        // Assert
        Assert.IsFalse(sut.ContainsKey(1));
    }

    [Test]
    public void GetClonedHt_ReturnsCloneOfHashtable()
    {
        // Arrange
        var sut = new CustomDictionary<int, string>();
        sut.Add(1, "One");

        // Act
        var clonedHashtable = sut.GetClonedHt();

        // Assert
        Assert.IsInstanceOf<Hashtable>(clonedHashtable);
        Assert.AreEqual(sut.ContainsKey(1), clonedHashtable.ContainsKey(1));
    }
    
    [Test]
    public void TestExcept()
    {
        var dict1 = new CustomDictionary<string, int>
        {
            { "a", 1 },
            { "b", 2 }
        };
        var dict2 = new CustomDictionary<string, int>
        {
            { "b", 2 },
            { "c", 3 }
        };

        var result = dict1.Except(dict2);

        Assert.IsTrue(result.ContainsKey("a"));
        Assert.IsFalse(result.ContainsKey("b"));
        Assert.IsFalse(result.ContainsKey("c"));
    }

    [Test]
    public void TestIntersect()
    {
        var dict1 = new CustomDictionary<string, int>
        {
            { "a", 1 },
            { "b", 2 }
        };
        var dict2 = new CustomDictionary<string, int>
        {
            { "b", 2 },
            { "c", 3 }
        };

        var result = dict1.Intersect(dict2);

        Assert.IsFalse(result.ContainsKey("a"));
        Assert.IsTrue(result.ContainsKey("b"));
        Assert.IsFalse(result.ContainsKey("c"));
    }

    [Test]
    public void TestSymmetricExcept()
    {
        var dict1 = new CustomDictionary<string, int>
        {
            { "a", 1 },
            { "b", 2 }
        };
        var dict2 = new CustomDictionary<string, int>
        {
            { "b", 2 },
            { "c", 3 }
        };

        var result = dict1.SymmetricExcept(dict2);

        Assert.IsTrue(result.ContainsKey("a"));
        Assert.IsFalse(result.ContainsKey("b"));
        Assert.IsTrue(result.ContainsKey("c"));
    }

    [Test]
    public void TestUnion()
    {
        var dict1 = new CustomDictionary<string, int>
        {
            { "a", 1 },
            { "b", 2 }
        };
        var dict2 = new CustomDictionary<string, int>
        {
            { "b", 2 },
            { "c", 3 }
        };

        var result = dict1.Union(dict2);

        Assert.IsTrue(result.ContainsKey("a"));
        Assert.IsTrue(result.ContainsKey("b"));
        Assert.IsTrue(result.ContainsKey("c"));
    }

}