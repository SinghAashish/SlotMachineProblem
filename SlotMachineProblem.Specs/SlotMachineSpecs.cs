using System;
using Xunit;

namespace SlotMachineProblem.Specs
{
    public class SlotMachineSpecs
    {
        [Fact]
        public void AllDifferentColoursReturnNoToken() // UniqueColorsReturnNoToken ??
        {
            // Given
            var slotMachine = new SlotMachine(); // Constructor mandatory dependency

            const int tokens = 1;

            // When
            var tokensReturned = slotMachine.Play(tokens); // Just in time

            // Then
            Assert.Equal(0, tokensReturned);
        }
    }
}
