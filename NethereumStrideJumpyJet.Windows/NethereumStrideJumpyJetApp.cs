using Stride.Engine;

namespace NethereumStrideJumpyJet
{
    class NethereumStrideJumpyJetApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
