using System;

namespace CSDemos
{
    public class RunMe
    {
        [STAThread]
        public static void Main()
        {
            Mainxx.CsOutput.CsOutput output = new Mainxx.CsOutput.CsOutput(typeof(RunMe));
            output.Run();
        }
    }
}
