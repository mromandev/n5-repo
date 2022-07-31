using Microsoft.AspNetCore.Mvc;
using Moq;
using N5.Api.Controllers;
using N5.Api.Entity.DTO;
using N5.Api.Entity.Models;
using N5.Api.Interfaces.Service;
using N5.Api.Utils;

namespace N5.Api.Tests
{
    public class TestPermissionsController
    {
        private readonly Mock<IPermissionsService> _mockService;
        private readonly PermisosController _controller;

        public TestPermissionsController()
        {
            _mockService = new Mock<IPermissionsService>();
            _controller = new PermisosController(_mockService.Object);
        }

        [Fact]
        public async void GetPermissions_ReturnsOk()
        {
            var result = await _controller.GetPermissions();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetPermissions_ReturnsPermissions()
        {
            _mockService.Setup(service => service.GetAll())
                .Returns(new List<PermissionDTO>() { new PermissionDTO(), new PermissionDTO() });

            var result = await _controller.GetPermissions() as OkObjectResult;
            var parsedResult = Assert.IsType<List<PermissionDTO>>(result?.Value);
            Assert.True(parsedResult.Any());
        }

        [Theory]
        [InlineData(1)]
        public async void GetPermissions_GetSinglePermission(int id)
        {
            _mockService.Setup(service => service.Get(id))
                .ReturnsAsync(new PermissionDTO() { Id = id });

            var result = await _controller.GetPermissions(id) as OkObjectResult;
            var parsedResult = Assert.IsType<PermissionDTO>(result?.Value);
            Assert.Equal(parsedResult.Id, id);
        }

        [Fact]
        public async void RequestPermission_ReturnsOk()
        {
            var permissionMock = new PermissionDTO()
            {
                NombreEmpleado = "Test",
                ApellidoEmpleado = "Testerez",
                IdTipoPermiso = 1,
                FechaPermiso = DateTime.Now
            };

            var result = await _controller.RequestPermission(permissionMock);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void RequestPermission_AddRunsOnce()
        {
            Permission? addedPermission = null;

            _mockService.Setup(service => service.Add(It.IsAny<Permission>())).Callback<Permission>(x => addedPermission = x);

            var permissionMock = new Permission()
            {
                NombreEmpleado = "Test",
                ApellidoEmpleado = "Testerez",
                IdTipoPermiso = 1,
                FechaPermiso = DateTime.Now
            };

            var result = await _controller.RequestPermission(permissionMock.ToDTO());
            _mockService.Verify(service => service.Add(It.IsAny<Permission>()), Times.Once);

            Assert.Equal(addedPermission?.NombreEmpleado, permissionMock.NombreEmpleado);
        }

        [Fact]
        public async void ModifyPermission_ReturnsOk()
        {
            var permissionMock = new PermissionDTO()
            {
                NombreEmpleado = "Marce",
                ApellidoEmpleado = "Roman",
                IdTipoPermiso = 1,
                Id = 1,
                FechaPermiso = DateTime.Now
            };

            var result = await _controller.ModifyPermission(permissionMock);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void ModifyPermission_UpdRunsOnce()
        {
            Permission? modPermission = null;

            _mockService.Setup(service => service.Update(It.IsAny<Permission>())).Callback<Permission>(x => modPermission = x);

            var permissionMock = new Permission()
            {
                NombreEmpleado = "Test",
                ApellidoEmpleado = "Testerez",
                IdTipoPermiso = 1,
                FechaPermiso = DateTime.Now
            };

            var result = await _controller.ModifyPermission(permissionMock.ToDTO());
            _mockService.Verify(service => service.Update(It.IsAny<Permission>()), Times.Once);

            Assert.Equal(modPermission?.NombreEmpleado, permissionMock.NombreEmpleado);
            Assert.Equal(modPermission?.ApellidoEmpleado, permissionMock.ApellidoEmpleado);
            Assert.Equal(modPermission?.IdTipoPermiso, permissionMock.IdTipoPermiso);
            Assert.Equal(modPermission?.Id, permissionMock.Id);
            Assert.Equal(modPermission?.FechaPermiso.Date, permissionMock.FechaPermiso.Date);
        }
    }
}