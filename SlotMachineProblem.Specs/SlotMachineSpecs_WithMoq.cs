using Moq;
using System;
using Xunit;

namespace SlotMachineProblem.Specs
{
    public class SlotMachineSpecs_WithMoq
    {
        [Fact]
        public void AllDifferentColoursReturnNoToken() // UniqueColorsReturnNoToken ??
        {
            // Given
            var spinner1 = SetupStubSpinnerToReturnAColor("red");
            var spinner2 = SetupStubSpinnerToReturnAColor("green");
            var spinner3 = SetupStubSpinnerToReturnAColor("blue");
            var dummy = new Console();

            var slotMachine = new SlotMachine(spinner1.Object, spinner2.Object, spinner3.Object, dummy); // Constructor mandatory dependency

            const int tokens = 1;

            // When
            var tokensReturned = slotMachine.Play(tokens); // Just in time

            // Then
            Assert.Equal(0, tokensReturned);
        }

        [Fact]
        public void ShowStopedSpinnerColors()
        {
            //Given
            var spinner1 = SetupStubSpinnerToReturnAColor("green");
            var spinner2 = SetupStubSpinnerToReturnAColor("red");
            var spinner3 = SetupStubSpinnerToReturnAColor("blue");

            var console = new Mock<Console>();

            var slotMachine = new SlotMachine(spinner1.Object, spinner2.Object, spinner3.Object, console.Object); // Constructor mandatory dependency

            const int tokens = 2;

            //When
            var tokensReturned = slotMachine.Play(tokens);

            //Then
            console.Verify(x => x.Show("green,red,blue"), Times.Once);
        }

        private Mock<Spinner> SetupStubSpinnerToReturnAColor(string color)
        {
            Mock<Spinner> stub = new Mock<Spinner>();
            stub.Setup(x => x.Spin()).Returns(color);
            return stub;
        }
    }
}
