//using FakeItEasy;
//using FluentAssertions;
//using ISP.API.Controllers;
//using ISP.BL;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ISPBackEnd.Tests.Controller
//{
//    public class BranchControllerTests
//    {
//        private IBranchService _BranchService;
//        public BranchControllerTests()
//        {
//            _BranchService = A.Fake<IBranchService>();  
//        }

<<<<<<< HEAD
//        [Fact]

//        public async Task BranchController_GetBranches_ReturnsOk()
//        {
//            //arrange
//            var expectedBranchlist = new List<ReadBranchDTO>
//            {
//                new ReadBranchDTO{Id =  1, Name ="branch1" , Address = "cairo"},
//                new ReadBranchDTO{Id =  2, Name ="branch2" , Address = "benha"}

//            };

//            var fakebranchservice = A.Fake<IBranchService>();

//            //congigure the mock object
//            A.CallTo(() => fakebranchservice.GetAll()).Returns(expectedBranchlist);

//            var controller = new BranchController(fakebranchservice);

//            //act
//            var result = await controller.GetAll(); 

//            // assert
//            var okObjectResult  = Assert.IsAssignableFrom<ActionResult<List<ReadBranchDTO>>>(result); 
//            var actualbranchlist = Assert.IsAssignableFrom<List<ReadBranchDTO>>(okObjectResult.Value);

//            actualbranchlist.Should().BeEquivalentTo(expectedBranchlist);


//        }

//        [Fact]

//        public async Task BranchController_GetBranchByID_ReturnsOk()
//        {
//            int id = 5;
//            var expectedBranch = new ReadBranchDTO { Id = 1, Name = "branch1", Address = "cairo" };

//            var fakeBranchService = A.Fake<IBranchService>();


//            //configure the mock object
//            A.CallTo(() => fakeBranchService.GetById(id)).Returns(expectedBranch);

//            var controller = new BranchController(fakeBranchService);

//            //act
//            var result = await controller.GetById(id);

//            // assert

//            var okobject = Assert.IsAssignableFrom<ActionResult<ReadBranchDTO>>(result);

//            var actualBranch = Assert.IsAssignableFrom<ReadBranchDTO>(okobject.Value);

//            actualBranch.Should().BeEquivalentTo(expectedBranch);
//        }



//        [Fact]
//        public async Task BranchController_Add_ReturnsOk()
//        {
//            //arrange

//            WriteBranchDTO writeBranchDTO = new WriteBranchDTO { address = "cairo" , Name = "branch3"   };
//            ReadBranchDTO expectedBranch = new ReadBranchDTO { Name = "branch3" , Address = "cairo" };

//            var fakeBranchService = A.Fake<IBranchService>();

//            A.CallTo(() => fakeBranchService.AddBranch(writeBranchDTO)).Returns(expectedBranch);

//            var controller = new BranchController(fakeBranchService);


//            // act
//            var result = await controller.Add(writeBranchDTO);

//            // assert

//            var Okobjectresult = Assert.IsType<ActionResult<ReadBranchDTO>>(result);

//            var actualresault = Assert.IsAssignableFrom<ReadBranchDTO>(Okobjectresult.Value);

//            actualresault.Should().BeEquivalentTo(expectedBranch);

//        }

//        [Fact]
//        public async Task BranchController_Add_ReturnsBadRequest()
//        {
//            // Arrange
//            WriteBranchDTO writeBranchDTO = new WriteBranchDTO { Name = null , address = "cairo" };

//            var fakeBranchService = A.Fake<IBranchService>();
//            var controller = new BranchController(fakeBranchService);

//            controller.ModelState.AddModelError("Name", "The Name field is required.");

//            // Act
//            var result = await controller.Add(writeBranchDTO);

//            // Assert
//            Assert.IsType<BadRequestObjectResult>(result.Result);
//        }

//        [Fact]
//        public async Task BranchController_Edit_ReturnsNoContentResult()
//        {
//            // arrange
//            int id = 5;
//            UpdateBranchDTO updateBranchDTO = new UpdateBranchDTO { Id = 1 , Name ="branch1" , address="cairo" };

//            var expectedBranchDto = new ReadBranchDTO { Name = "branch2" , Address="cairo" };


//            //create fake iBranchservice
//            var fakeBranchService = A.Fake<IBranchService>();

//            //configure the mock object

//            A.CallTo(() => fakeBranchService.UpdateBranch(id, updateBranchDTO)).Returns(expectedBranchDto);

//            var controller = new BranchController(fakeBranchService);

//            //act
//            var result = await controller.Edit(id, updateBranchDTO);

//            // assert
//            Assert.IsType<NoContentResult>(result);

//        }



//        [Fact]
//        public async Task Delete_ReturnsOkObjectResult_When_ObjectExists()
//        {
//            // Arrange
//            var Id = 1;
//            var expectedReadBranchDTO = new ReadBranchDTO { Name = "branch1" , Address = "benha" };

//            var fakeBranchService = A.Fake<IBranchService>();
//            A.CallTo(() => fakeBranchService.DeleteBranch(Id)).Returns(expectedReadBranchDTO);

//            var controller = new BranchController(fakeBranchService);

//            // Act
//            var result = await controller.Delete(Id);

//            // Assert
//            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
//            var readBranchDTO = Assert.IsType<ReadBranchDTO>(okObjectResult.Value);

//            Assert.Equal(expectedReadBranchDTO.Name, readBranchDTO.Name);


//        }
=======
        //[Fact]

        //public async Task BranchController_GetBranches_ReturnsOk()
        //{
        //    //arrange
        //    var expectedBranchlist = new List<ReadBranchDTO>
        //    {
        //        new ReadBranchDTO{Id =  1, Name ="branch1" , Address = "cairo"},
        //        new ReadBranchDTO{Id =  2, Name ="branch2" , Address = "benha"}

        //    };

        //    var fakebranchservice = A.Fake<IBranchService>();

        //    //congigure the mock object
        //    A.CallTo(() => fakebranchservice.GetAll()).Returns(expectedBranchlist);

        //    var controller = new BranchController(fakebranchservice);

        //    //act
        //    var result = await controller.GetAll(); 

        //    // assert
        //    var okObjectResult  = Assert.IsAssignableFrom<ActionResult<List<ReadBranchDTO>>>(result); 
        //    var actualbranchlist = Assert.IsAssignableFrom<List<ReadBranchDTO>>(okObjectResult.Value);

        //    actualbranchlist.Should().BeEquivalentTo(expectedBranchlist);


        //}

        //[Fact]

        //public async Task BranchController_GetBranchByID_ReturnsOk()
        //{
        //    int id = 5;
        //    var expectedBranch = new ReadBranchDTO { Id = 1, Name = "branch1", Address = "cairo" };

        //    var fakeBranchService = A.Fake<IBranchService>();


        //    //configure the mock object
        //    A.CallTo(() => fakeBranchService.GetById(id)).Returns(expectedBranch);

        //    var controller = new BranchController(fakeBranchService);

        //    //act
        //    var result = await controller.GetById(id);

        //    // assert

        //    var okobject = Assert.IsAssignableFrom<ActionResult<ReadBranchDTO>>(result);

        //    var actualBranch = Assert.IsAssignableFrom<ReadBranchDTO>(okobject.Value);

        //    actualBranch.Should().BeEquivalentTo(expectedBranch);
        //}



        //[Fact]
        //public async Task BranchController_Add_ReturnsOk()
        //{
        //    //arrange

        //    WriteBranchDTO writeBranchDTO = new WriteBranchDTO { address = "cairo" , Name = "branch3"   };
        //    ReadBranchDTO expectedBranch = new ReadBranchDTO { Name = "branch3" , Address = "cairo" };

        //    var fakeBranchService = A.Fake<IBranchService>();

        //    A.CallTo(() => fakeBranchService.AddBranch(writeBranchDTO)).Returns(expectedBranch);

        //    var controller = new BranchController(fakeBranchService);


        //    // act
        //    var result = await controller.Add(writeBranchDTO);

        //    // assert

        //    var Okobjectresult = Assert.IsType<ActionResult<ReadBranchDTO>>(result);

        //    var actualresault = Assert.IsAssignableFrom<ReadBranchDTO>(Okobjectresult.Value);

        //    actualresault.Should().BeEquivalentTo(expectedBranch);

        //}

        //[Fact]
        //public async Task BranchController_Add_ReturnsBadRequest()
        //{
        //    // Arrange
        //    WriteBranchDTO writeBranchDTO = new WriteBranchDTO { Name = null , address = "cairo" };

        //    var fakeBranchService = A.Fake<IBranchService>();
        //    var controller = new BranchController(fakeBranchService);

        //    controller.ModelState.AddModelError("Name", "The Name field is required.");

        //    // Act
        //    var result = await controller.Add(writeBranchDTO);

        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(result.Result);
        //}

        //[Fact]
        //public async Task BranchController_Edit_ReturnsNoContentResult()
        //{
        //    // arrange
        //    int id = 5;
        //    UpdateBranchDTO updateBranchDTO = new UpdateBranchDTO { Id = 1 , Name ="branch1" , address="cairo" };

        //    var expectedBranchDto = new ReadBranchDTO { Name = "branch2" , Address="cairo" };


        //    //create fake iBranchservice
        //    var fakeBranchService = A.Fake<IBranchService>();

        //    //configure the mock object

        //    A.CallTo(() => fakeBranchService.UpdateBranch(id, updateBranchDTO)).Returns(expectedBranchDto);

        //    var controller = new BranchController(fakeBranchService);

        //    //act
        //    var result = await controller.Edit(id, updateBranchDTO);

        //    // assert
        //    Assert.IsType<NoContentResult>(result);

        //}



        //[Fact]
        //public async Task Delete_ReturnsOkObjectResult_When_ObjectExists()
        //{
        //    // Arrange
        //    var Id = 1;
        //    var expectedReadBranchDTO = new ReadBranchDTO { Name = "branch1" , Address = "benha" };

        //    var fakeBranchService = A.Fake<IBranchService>();
        //    A.CallTo(() => fakeBranchService.DeleteBranch(Id)).Returns(expectedReadBranchDTO);

        //    var controller = new BranchController(fakeBranchService);

        //    // Act
        //    var result = await controller.Delete(Id);

        //    // Assert
        //    var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
        //    var readBranchDTO = Assert.IsType<ReadBranchDTO>(okObjectResult.Value);

        //    Assert.Equal(expectedReadBranchDTO.Name, readBranchDTO.Name);


        //}
>>>>>>> 80c10beacf9e52fcf1a6f375ff7430898209d673







//    }
//}
