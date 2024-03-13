using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VinylWebShop.Context;
using VinylWebShop.Controllers;
using VinylWebShop.Facades;

namespace VinylWebShop.Tests.ControllerTests.AlbumTests
{
    public class AlbumGetAlbumsTests
    {
        [Fact]
        public async Task GetAlbums_ReturnsOkResult()
        {
            // Arrange
            var expectedAlbums = new List<Album> {
        new Album { Id = 1, Title = "Album 1", Artist = "Artist 1", Description = "Description 1", Image = "Image 1"},
        new Album { Id = 2, Title = "Album 2", Artist = "Artist 2", Description = "Description 2", Image = "Image 2"},
    };

            var albumFacadeMock = new Mock<IAlbumFacade>();
            albumFacadeMock.Setup(x => x.GetAlbums()).ReturnsAsync(expectedAlbums);

            var loggerMock = new Mock<ILogger<AlbumController>>();

            var controller = new AlbumController(albumFacadeMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetAlbums();

            // Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualAlbums = Assert.IsAssignableFrom<IEnumerable<Album>>(okResult.Value);
            Assert.Equal(expectedAlbums.Count, actualAlbums.Count());
        }

        [Fact]
        public async Task GetAlbums_ReturnsBadRequestResultOnError()
        {
            var albumFacadeMock = new Mock<IAlbumFacade>();
            albumFacadeMock.Setup(x => x.GetAlbums()).ThrowsAsync(new Exception("Test exception"));
            var loggerMock = new Mock<ILogger<AlbumController>>();
            var controller = new AlbumController(albumFacadeMock.Object, loggerMock.Object);

            var result = await controller.GetAlbums();

            Assert.IsType<ActionResult<IEnumerable<Album>>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<Exception>(badRequestResult.Value);
        }
    }
}
