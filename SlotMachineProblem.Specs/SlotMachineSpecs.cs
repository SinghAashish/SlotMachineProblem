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
            FakeSpinner fake = new FakeSpinner();
            var slotMachine = new SlotMachine(fake, fake, fake); // Constructor mandatory dependency

            const int tokens = 1;

            // When
            var tokensReturned = slotMachine.Play(tokens); // Just in time

            // Then
            Assert.Equal(0, tokensReturned);
        }
    }

    internal class FakeSpinner : Spinner
    {
        private int callCount = 0;
        internal override string Spin()
        {
            callCount++;
            if (callCount == 1)
            {
                return "red";
            }
            else if (callCount == 2)
            {
                return "green";
            }
            else
            {
                return "blue";
            }
        }
    }

    //internal class BlueSpinner : Spinner
    //{
    //    internal override string Spin()
    //    {
    //        return "blue";
    //    }
    //}

    //internal class GreenSpinner : Spinner
    //{
    //    internal override string Spin()
    //    {
    //        return "green";
    //    }
    //}

    //internal class RedSpinner : Spinner
    //{
    //    internal override string Spin()
    //    {
    //        return "red";
    //    }
    //}
}
