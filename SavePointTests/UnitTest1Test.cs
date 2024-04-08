using Xunit;
using SavePointAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SavePointTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetNote()
        {
            // Arrange
            var controller = new SavePointNotesController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TestGetNoteById()
        {
            // Arrange
            var controller = new SavePointNotesController();

            // Act
            var result = controller.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TestPutNote()
        {
            // Arrange
            var controller = new SavePointNotesController();

            // Act
            var result = controller.Put(1, new SavePointNoteDTO());

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void TestPostNote()
        {
            // Arrange
            var controller = new SavePointNotesController();

            // Act
            var result = controller.Post(new SavePointNoteDTO());

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
    }
}