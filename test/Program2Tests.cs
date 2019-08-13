using System;
using Xunit;
using src.Problem2;
namespace test
{
    public class Program2Tests
    {

        #region "Final Counter Tests"
        [Fact]
        public void Should_Return_Demand_To_Resource_Ratio()
        {
            Demands demands = new Demands();
            demands.Add(new Requirements(eResourceType.Hardware,5));
            demands.Add(new Requirements(eResourceType.Firmware,5));
            demands.Add(new Requirements(eResourceType.Software,5));
            demands.Add(new Requirements(eResourceType.Other,5));

            Provider provider = new Provider();
            provider.Add(new Resource(eResourceType.Hardware,10));
            provider.Add(new Resource(eResourceType.Firmware,10));
            provider.Add(new Resource(eResourceType.Software,10));
            provider.Add(new Resource(eResourceType.Other,10));


            int count = TestDriver.GetCount(provider,demands);
            Assert.Equal(8,count);

        }

        [Fact]
        public void Should_Return_ZERO_When_Insufficient_Resources()
        {
            Demands demands = new Demands();
            demands.Add(new Requirements(eResourceType.Hardware,5));
            demands.Add(new Requirements(eResourceType.Firmware,5));
            demands.Add(new Requirements(eResourceType.Software,5));
            demands.Add(new Requirements(eResourceType.Other,5));

            Provider provider = new Provider();
            provider.Add(new Resource(eResourceType.Hardware,4));
            provider.Add(new Resource(eResourceType.Firmware,4));
            provider.Add(new Resource(eResourceType.Software,4));
            provider.Add(new Resource(eResourceType.Other,4));


            int count = TestDriver.GetCount(provider,demands);
            Assert.Equal(0,count);

        }
        [Fact]
        public void Should_Return_RightNumber_When_Some_Resources_Insufficient()
        {
            Demands demands = new Demands();
            demands.Add(new Requirements(eResourceType.Hardware,5));
            demands.Add(new Requirements(eResourceType.Firmware,5));
            demands.Add(new Requirements(eResourceType.Software,5));
            demands.Add(new Requirements(eResourceType.Other,5));

            Provider provider = new Provider();
            provider.Add(new Resource(eResourceType.Hardware,10));
            provider.Add(new Resource(eResourceType.Firmware,4)); //Insufficient for the demand
            provider.Add(new Resource(eResourceType.Software,4)); //Insufficient for the demand
            provider.Add(new Resource(eResourceType.Other,10));


            int count = TestDriver.GetCount(provider,demands);
            Assert.Equal(4,count);

        }

        [Fact]
        public void Should_Return_RightNumber_When_Some_Resources_DoesntExists()
        {
            Demands demands = new Demands();
            demands.Add(new Requirements(eResourceType.Hardware,5));
            demands.Add(new Requirements(eResourceType.Firmware,5));
            demands.Add(new Requirements(eResourceType.Software,5));
            demands.Add(new Requirements(eResourceType.Other,5));

            Provider provider = new Provider();
            provider.Add(new Resource(eResourceType.Hardware,10));
           // provider.Add(new Resource(eResourceType.Firmware,4)); //
           // provider.Add(new Resource(eResourceType.Software,4)); //
            provider.Add(new Resource(eResourceType.Other,10));


            int count = TestDriver.GetCount(provider,demands);
            Assert.Equal(4,count);

        }

        #endregion
        #region "Demands Tests"
            [Fact]
        public void Should_Add_Requirements_To_Demands()
        {
            //Arrange
            Demands demands = new Demands();
            demands.Add(new Requirements(eResourceType.Hardware,5));
            demands.Add(new Requirements(eResourceType.Firmware,5));
            demands.Add(new Requirements(eResourceType.Software,5));
            demands.Add(new Requirements(eResourceType.Other,5));
            

            //Act,Assert
            Assert.Equal(4,demands.Requirements.Count);
        }
        [Fact]
        public void AddRequirement_Should_ThowException_For_Existing_Requirement_Types()
        {
            //Arrange
            Demands demands = new Demands();
            demands.Add(new Requirements(eResourceType.Hardware,5));
            demands.Add(new Requirements(eResourceType.Firmware,5));

            Action addDuplicateRequirement = ()=>demands.Add(new Requirements(eResourceType.Hardware,10));
            
            //Act,Assert
            var exception = Assert.Throws<Exception>(addDuplicateRequirement);
            Assert.Equal("Can add only one instance of a particualr requriement type",exception.Message);
        }

        [Fact]
        public void AddRequirements_Should_Allow_Max_Four_Requriemnt_Types()
        {
            //Arrange
            Demands demands = new Demands();
            demands.Add(new Requirements(eResourceType.Hardware,5));
            demands.Add(new Requirements(eResourceType.Firmware,15));
            demands.Add(new Requirements(eResourceType.Other,25));
            demands.Add(new Requirements(eResourceType.Software,15));

            //Adding 5th one.
            Action addDuplicateRequirement = ()=>demands.Add(new Requirements(eResourceType.Hardware,10));
            
            //Act,Assert
            var exception = Assert.Throws<Exception>(addDuplicateRequirement);
            Assert.Equal("Allowed zero to four instances only",exception.Message);
        }


        [Fact]
        public void RemoveRequirement_ForExistingRequriement_Should_Work()
        {
            //Arrange
            Demands demands = new Demands();
            demands.Add(new Requirements(eResourceType.Hardware,5));
            demands.Add(new Requirements(eResourceType.Firmware,15));
            demands.Add(new Requirements(eResourceType.Other,25));
            demands.Add(new Requirements(eResourceType.Software,15));

            demands.Remove(new Requirements(eResourceType.Other,25));

            Assert.Equal(3,demands.Requirements.Count);
        }
        [Fact]
        public void RemoveRequirement_ForNonExistingRequirement_Should_ThrowException()
        {
            //Arrange
            Demands demands = new Demands();
            demands.Add(new Requirements(eResourceType.Hardware,5));
            demands.Add(new Requirements(eResourceType.Firmware,15));

            //Remove nonexisting resource.
            Action removeRequirement = ()=>demands.Remove(new Requirements(eResourceType.Other,10));
           
            //Act,Assert
            var exception =Assert.Throws<Exception>(removeRequirement);
            Assert.Equal("Requriement doesn't exist",exception.Message);
        }
        #endregion
        #region "Provider Tests"
            [Fact]
        public void Should_Add_Resource_To_Provider()
        {
            //Arrange
            Provider provider = new Provider();
            provider.Add(new Resource(eResourceType.Hardware,5));
            provider.Add(new Resource(eResourceType.Firmware,5));
            provider.Add(new Resource(eResourceType.Software,5));
            provider.Add(new Resource(eResourceType.Other,5));
            

            //Act,Assert
            Assert.Equal(4,provider.Resources.Count);
        }
        [Fact]
        public void AddResource_Should_ThowException_For_Existing_Resources_Types()
        {
            //Arrange
            Provider provider = new Provider();
            provider.Add(new Resource(eResourceType.Hardware,5));
            provider.Add(new Resource(eResourceType.Firmware,5));

            Action addDuplicateResource = ()=>provider.Add(new Resource(eResourceType.Hardware,10));
            //Act,Assert
            var exception = Assert.Throws<Exception>(addDuplicateResource);
            Assert.Equal("Can add only one instance of a particualr resource type",exception.Message);
        }

        [Fact]
        public void AddResource_Should_Allow_Max_Four_Resources_Types()
        {
            //Arrange
            Provider provider = new Provider();
            provider.Add(new Resource(eResourceType.Hardware,5));
            provider.Add(new Resource(eResourceType.Firmware,15));
            provider.Add(new Resource(eResourceType.Other,25));
            provider.Add(new Resource(eResourceType.Software,15));

            //Adding 5th one.
            Action addDuplicateResource = ()=>provider.Add(new Resource(eResourceType.Hardware,10));
            
            //Act,Assert
            var exception =Assert.Throws<Exception>(addDuplicateResource);
            Assert.Equal("Allowed zero to four instances only",exception.Message);
        }


        [Fact]
        public void RemoveResource_ForExistingResource_Should_Work()
        {
            //Arrange
            Provider provider = new Provider();
            provider.Add(new Resource(eResourceType.Hardware,5));
            provider.Add(new Resource(eResourceType.Firmware,15));
            provider.Add(new Resource(eResourceType.Other,25));
            provider.Add(new Resource(eResourceType.Software,15));

            provider.Remove(new Resource(eResourceType.Other,25));

            Assert.Equal(3,provider.Resources.Count);
        }
        [Fact]
        public void RemoveResource_ForNonExistingResource_Should_ThrowException()
        {
            //Arrange
            Provider provider = new Provider();
            provider.Add(new Resource(eResourceType.Hardware,5));
            provider.Add(new Resource(eResourceType.Firmware,15));
            provider.Add(new Resource(eResourceType.Software,15));

            //Remove nonexisting resource.
            Action removeResource = ()=>provider.Remove(new Resource(eResourceType.Other,10));
           
            //Act,Assert
            var exception =Assert.Throws<Exception>(removeResource);
            Assert.Equal("Resource doesn't exist",exception.Message);
        }
        #endregion
    }
}
