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
            var dummy = new Console();

            var slotMachine = new SlotMachine(fake, fake, fake, dummy); // Constructor mandatory dependency

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
            FakeSpinner fake = new FakeSpinner();
            FakeConsole fakeConsole = new FakeConsole();

            var slotMachine = new SlotMachine(fake, fake, fake, fakeConsole); // Constructor mandatory dependency

            const int tokens = 2;

            //When
            var tokensReturned = slotMachine.Play(tokens);

            //Then
            //fakeConsole.Verify(x => x.Show("green,red,blue"), Times.Once);

            Assert.Equal("red,green,blue", fakeConsole.data);
            Assert.Equal(1, fakeConsole.callCounter);
        }
    }

    internal class FakeConsole : Console
    {
        internal string data = "";
        internal int callCounter = 0;

        public override void Show(string data)
        {
            this.data = data;
            callCounter++;
        }
    }

    internal class FakeSpinner : Spinner
    {
        private int callCount = 0;
        public override string Spin()
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
