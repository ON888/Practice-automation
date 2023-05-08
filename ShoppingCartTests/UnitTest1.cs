using static OksanaN_HW_3.ShoppingCartMain;
namespace ShoppingCartTests;
[TestFixture]
[Author("Oksana N", "oksana.nahibina@jll.com")]
public class Tests
{
    ShoppingCart testCart;

    [SetUp]
    public void Setup()
    {
        testCart = new ShoppingCart("FirstTests");
        testCart.AddItem("apple", 2, 1.10m);
        testCart.AddItem("pear", 1, 2.20m);
        //testCart.AddItem("pineapple", 1, 3.50m);
    }

    [Test]
    public void ItemAdded()
    {
        testCart.AddItem("apple", 2, 1.10m);

        Assert.That(testCart.items.ContainsKey("apple"), Is.EqualTo(true));
        Assert.That(testCart.items["apple"].quantity, Is.EqualTo(4));
        Assert.That(testCart.items["apple"].price, Is.EqualTo(1.10m));
    }
    [Test] 
    public void ItemRemoved()
    { 
        Assert.That(testCart.items.Count, Is.EqualTo(3));

        testCart.RemoveItem("apple");

        Assert.That(testCart.items.ContainsKey("apple"), Is.EqualTo(false));
        Assert.That(testCart.items.Count, Is.EqualTo(2));

    }
    [Test]
    public void CartAmount()
    {
        Console.WriteLine($"Current Cart value is:{testCart.CartAmount}");
        Assert.That(testCart.CartAmount, Is.EqualTo(7.90m));
    }
}