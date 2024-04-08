using Xunit;
using SavePointAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using SavePointAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SavePointTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestPostNote()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SavePointContext>()
                .UseInMemoryDatabase(databaseName: "SavePointNotes")
                .Options;
            var context = new SavePointContext(options);
            var controller = new SavePointNotesController(context);

            // Act
            var result = controller.PostSavePointNote(new SavePointNoteDTO());

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
        [Fact]
        public void TestGetNote()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SavePointContext>()
                .UseInMemoryDatabase(databaseName: "SavePointNotes")
                .Options;
            var context = new SavePointContext(options);
            var controller = new SavePointNotesController(context);

            // Act
            var result = controller.GetSavePointNotes();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TestGetNoteById()
        {
            var options = new DbContextOptionsBuilder<SavePointContext>()
                .UseInMemoryDatabase(databaseName: "SavePointNotes")
                .Options;
            var context = new SavePointContext(options);
            var controller = new SavePointNotesController(context);

            // Act
            var result = controller.GetSavePointNote(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TestPutNote()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SavePointContext>()
                .UseInMemoryDatabase(databaseName: "SavePointNotes")
                .Options;
            var context = new SavePointContext(options);
            var controller = new SavePointNotesController(context);

            // Act
            var result = controller.PutSavePointNote(1, new SavePointNoteDTO());

            // Assert
            Assert.IsType<OkResult>(result);
        }

    }
}