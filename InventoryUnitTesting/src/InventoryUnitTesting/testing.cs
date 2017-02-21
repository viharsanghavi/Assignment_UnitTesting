using System.Collections.Generic;
using Xunit;

namespace InventoryUnitTesting
{
    public class Testing
    {
        private readonly IList<Product> _productList;
        private readonly IList<Cart> _cartList;
        private readonly IList<Inventory> _inventoryList;
        [Fact]
        public void WhenAddingProductToInventory_InventoryListShouldbeIncreasedPass()
        {
            var db = new Database();
            var inventory = new Inventory()
            {
                Id = 6,
                ProductId = 5,
                Quantity = 5,

            };

            var prgm = new Program();
           var list = prgm.AddInventory(inventory);
            Assert.Equal(list.Count, db.InventoryList.Count);
        }

        public void WhenAddingProductToInventory_InventoryListShouldbeIncreasedFail()
        {
            var db = new Database();
            var inventory = new Inventory()
            {
                Id = 6,
                ProductId = 5,
                Quantity = 5,

            };

            var prgm = new Program();
            var list = prgm.AddInventory(inventory);
            Assert.Equal(4, db.InventoryList.Count);
        }

        [Fact]
        public void WhenCartIsCheckout_ProductsShouldbeReducedPass()
        {
            var db = new Database();
            var inventory = new Inventory();
            var prgm = new Program();
            var UpdatedList = prgm.CheckOutTheCartandUpdateInventory(db.CartList as List<Cart>);
            Assert.Equal(UpdatedList,db.InventoryList);

        }

        [Fact]
        public void WhenCartIsCheckout_ProductsShouldbeReducedFail()
        {
            var db = new Database();
            var inventory = new Inventory();
            var prgm = new Program();
            var UpdatedList = prgm.CheckOutTheCartandUpdateInventory(db.CartList as List<Cart>);
            Assert.NotEqual(UpdatedList, db.InventoryList);

        }
        [Fact]
        public void WhenProductDetailsChange_InventoryShouldbeUpdatedPass()
        {
            var db = new Database();
            var inventory = new Inventory()
            {
                Id = 1,
                Quantity = 90,

            };
            var prgm = new Program();
            var list = prgm.UpdateInventory(inventory);
            Assert.Equal(list, db.InventoryList[inventory.Id]);

        }
        [Fact]
        public void WhenProductDetailsChange_InventoryShouldbeUpdatedFall()
        {
            var db = new Database();
            var inventory = new Inventory()
            {
                Id = 1,
                Quantity = 90,

            };
            var prgm = new Program();
            var list = prgm.UpdateInventory(inventory);
            Assert.NotEqual(list, db.InventoryList[inventory.Id]);

        }
        [Fact]
        public void WhenInventoryIsDeleted_InventoryListIsUpdatedPass()
        {
            var db = new Database();
            var inventory = new Inventory()
            {
                Id = 1,

            };
            var prgm = new Program();
            var list = prgm.DeleteInventory(inventory);
            Assert.Equal(list, db.InventoryList);

        }
        [Fact]
        public void WhenInventoryIsDeleted_InventoryListIsUpdatedFall()
        {
            var db = new Database();
            var inventory = new Inventory()
            {
                Id = 1,

            };
            var prgm = new Program();
            var list = prgm.DeleteInventory(inventory);
            Assert.NotEqual(list, db.InventoryList);

        }
        #region Constructor
        public Testing()
        {
            
        }
        #endregion
    }
}
