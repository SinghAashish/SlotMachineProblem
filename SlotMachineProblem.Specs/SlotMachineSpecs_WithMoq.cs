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
            FakeSpinner fake = new FakeSpinner();
            var slotMachine = new SlotMachine(fake, fake, fake); // Constructor mandatory dependency

            const int tokens = 1;

            // When
            var tokensReturned = slotMachine.Play(tokens); // Just in time

            // Then
            Assert.Equal(0, tokensReturned);
        }
    }
}
