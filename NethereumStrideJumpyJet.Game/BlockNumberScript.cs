// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using Nethereum.Web3;
using Stride.Engine;
using Stride.Engine.Events;
using Stride.Physics;
using Stride.Rendering.Compositing;

namespace NethereumStrideJumpyJet
{
    public class BlockNumberScript : AsyncScript
    {
        public override async Task Execute()
        {
            var web3 = new Web3();
            while (Game.IsRunning)
            {
                try
                {
                    var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                    GameGlobals.BlockNumberEventKey.Broadcast((long)blockNumber.Value);
                    await Task.Delay(1000);

                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                
            }
           
           
        }
    }
}
