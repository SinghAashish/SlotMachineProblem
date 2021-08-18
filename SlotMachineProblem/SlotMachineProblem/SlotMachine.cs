using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SlotMachineProblem.Specs")]

namespace SlotMachineProblem
{
    public class SlotMachine
    {
        private Spinner spinner1;
        private Spinner spinner2;
        private Spinner spinner3;

        public SlotMachine(Spinner spinner1, Spinner spinner2, Spinner spinner3)
        {
            this.spinner1 = spinner1;
            this.spinner2 = spinner2;
            this.spinner3 = spinner3;
        }

        [Obsolete]
        public SlotMachine()
        {
            spinner1 = CreateSpinner();
            spinner2 = CreateSpinner();
            spinner3 = CreateSpinner();
        }

        internal virtual Spinner CreateSpinner()
        {
            return new Spinner();
        }

        public int Play(int tokens)
        {
            string color1 = spinner1.Spin();
            string color2 = spinner2.Spin();
            string color3 = spinner3.Spin();
            if (color1 != color2 && color2 != color3 && color3 != color1)
            {
                return 0;
            }
            return -1;
        }
    }
}
