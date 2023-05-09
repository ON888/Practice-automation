using NUnit.Framework.Interfaces;
using static OksanaN_HW_3.ShoppingCartMain;
namespace ShoppingCartTests;

[TestFixture, Description ("Testing of Add/Remove action for Shopping Cart")]
[Author("Oksana N", "oksana.nahibina@jll.com")]
public class Tests
{
    ShoppingCart testCart;

    [OneTimeSetUp, Description("Let say we have some items have been added already")]
    public void InitSetup()
    {
        testCart = new ShoppingCart("FirstTests");
        testCart.AddItem("apple", 2, 1.0m);
        testCart.AddItem("pear", 1, 2.0m);
        testCart.AddItem("pineapple", 5, 1.00m);
        testCart.AddItem("tomato", 2, 1.0m);        
    }

    int itemsCount = 4;
    [TestCase("strawberry", 1, 5.00), Description("Check Adding Item")]
    [TestCase("cucumber", 10, 0.10)]
    [TestCase("blueberry", 1, 2.00)]
    [TestCase("tuna can", 2, 5.00)]

    public void ItemAdded(string Item, int Quantity, decimal Price)
    {
        testCart.AddItem(Item, Quantity, Price);
        itemsCount += 1;

        Assert.That(testCart.items.ContainsKey(Item), Is.EqualTo(true));
        Assert.That(testCart.items[Item].quantity, Is.EqualTo(Quantity));
        Assert.That(testCart.items[Item].price, Is.EqualTo(Price));
    }
    
    [TestCase(false,"apple"), Description("Check that Item doesn't exist in the cart any longer")]
    [TestCase(false,"pineapple")] 
    public void ItemRemoved(bool Expected, string Item )
    { 
        testCart.RemoveItem(Item);
        itemsCount -= 1;

        Assert.That(testCart.items.ContainsKey(Item), Is.EqualTo(false));
        Assert.That(testCart.items.Count, Is.EqualTo(itemsCount));

    }
    [Test, Description("Check if test Cart Amount is as expected after a few adding/removal actions")]
    public void CartAmount()
    {
        decimal sum = 0;
        foreach (var i in testCart.items)
        {
            sum += i.Value.quantity * i.Value.price;
        }

        Assert.That(testCart.CartAmount, Is.EqualTo(sum));
    }
}