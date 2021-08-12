namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void CtorInitializeCorrectly() 
        {
            string aqName = "aName";
            int aqCapacity = 1;            

            Aquarium aquarium = new Aquarium(aqName, aqCapacity);

            //Assert.That(aquarium.Name, Is.EqualTo(aqName));
            Assert.AreEqual(aquarium.Name, aqName);
            Assert.AreEqual(aquarium.Capacity, aqCapacity);           

        }

        [Test]
        public void SetName_ThrowException_WhenNameInvalid() 
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 5));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 5));
        }

        [Test]
        public void Capacity_ThrowsException_WhenCapacityIsNegative() 
        {
            int testCapacity = -50;
            Assert.Throws<ArgumentException>(() => new Aquarium("Hi", testCapacity));
        }

        [Test]
        public void Count_IncreasesCount_WhenFishIsAdded() 
        {
            Aquarium aquarium = new Aquarium("Aq", 5);  //Arrange
            Fish fish = new Fish("Fi");
            int expectedCount = 1;

            aquarium.Add(fish); //Act
            Assert.That(aquarium.Count, Is.EqualTo(expectedCount)); ///Assert
            //Assert.AreEqual(aquarium.Count, expectedCunt);
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityReached() 
        {
            Aquarium aquarium = new Aquarium("Aq", 1);
            Fish fish = new Fish("Fi");
            aquarium.Add(fish);

            Fish fish2 = new Fish("FiHi");
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish2));
        }

        [Test]
        public void RemoveFish_ThrowsException_WhenFishExistsNot() 
        {
            Aquarium aquarium = new Aquarium("Aq", 1);
            string nonExistingFishName = "Jecky";

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(nonExistingFishName));
            //Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
        }

        [Test]
        public void RemoveFish_WhenFishExists() 
        {
            Aquarium aquarium = new Aquarium("Aq", 1);
            string fishName = "fishy";
            Fish fish = new Fish(fishName);
            aquarium.Add(fish);
            //int countFishes = 1;

            aquarium.RemoveFish(fishName);
            int countFishes = 0;
            Assert.That(aquarium.Count, Is.EqualTo(countFishes));
            //Assert.AreEqual(aquarium.Count, 0);

        }

        [Test]
        public void SellFish_ThrowsException_WhenFishNameExistsNot() 
        {
            Aquarium aquarium = new Aquarium("AQ", 1);
            string falseFishName = "False";

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(falseFishName));        
           // Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));        
        }

        [Test]
        public void SellFish_SuccessfullySold_WhenFishNameExists() 
        {
            Aquarium aquarium = new Aquarium("AQ", 1);
            string fishName = "fishy";
            Fish fish = new Fish(fishName);

            aquarium.Add(fish);
            Fish requestedFishToSell = aquarium.SellFish(fishName);
            //Assert.That(requestedFishToSell.Name, Is.EqualTo(fishName));
            Assert.AreEqual(requestedFishToSell.Name, fishName);
            Assert.AreEqual(fish.Available, false);
            //Assert.That(fish.Available, Is.False);

        }

        [Test]
        public void Report_ShowReport_WhenBothMesagesCorrect()
        {
            string aqName = "AQ";
            string fishName = "fishy";
            Aquarium aquarium = new Aquarium(aqName, 1); //Arr
            Fish fish = new Fish(fishName);

            aquarium.Add(fish); //Act
            string expectedMessage = $"Fish available at {aqName}: {fishName}";
            string actualMessage = aquarium.Report();

            //Assert.That(aquarium.Report(), Is.EqualTo(expectedMessage));
            Assert.AreEqual(expectedMessage, actualMessage); //Assert
        }
    }
}
