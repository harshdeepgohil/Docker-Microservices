using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Services.ProductAPI.Controllers;
using Product.Services.ProductAPI.Data;
using Product.Services.ProductAPI.Models;

public class ProductsControllerTests
{
    [Fact]
    public void Get_ReturnsOk_WhenProductExists()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductDb1")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            context.Products.Add(new Products { ID = 1, Name = "Test",Description="asasdasd",Price="123" });
            context.SaveChanges();

            var controller = new ProductsController(context);

            // Act
            var result = controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var product = Assert.IsType<Products>(okResult.Value);
            Assert.Equal(1, product.ID);
        }
    }

    [Fact]
    public void Get_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductDb2")
            .Options;

        using (var context = new ApplicationDbContext(options))
        {
            var controller = new ProductsController(context);

            // Act
            var result = controller.Get(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
