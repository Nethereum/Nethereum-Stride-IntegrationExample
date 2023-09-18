# Nethereum-Stride-IntegrationExample
Nethereum Stride integration example using Stride's Jumpy Jet example: https://github.com/stride3d/stride/tree/master/samples/Games/JumpyJet

This simple integration, uses directly the Nethereum.Web3 Nuget, retrieving a block number in a background thread and then is diplayed in the UI component.

## Background thread
```csharp

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

```

## UI
```csharp
 public class UIScript : SyncScript
 {
 private EventReceiver<long> blockNumberListener = new EventReceiver<long>(GameGlobals.BlockNumberEventKey);

 public override void Update()
        {
          
            if (blockNumberListener.TryReceive(out currentBlockNumber))
            {
                blockNumberTextBlock.Text = @$"Block: {currentBlockNumber}";
            }  
        }
        private void CreateGameUI()
        {
           

            blockNumberTextBlock = new TextBlock
            {
                Font = Font,
                TextColor = Color.Black,
                VerticalAlignment = VerticalAlignment.Center
            };
            blockNumberTextBlock.SetCanvasPinOrigin(new Vector3(300f, 0.5f, 1f));
            blockNumberTextBlock.SetCanvasRelativePosition(new Vector3(300f, 0.7f, 0f));

            var blockNumberBoard = new ContentDecorator
            {
                BackgroundImage = SpriteFromSheet.Create(UIImages, "score_bg"),
                Content = blockNumberTextBlock,
                Padding = new Thickness(100, 31, 25, 35),
                MinimumWidth = 190f 
            };

            gameRoot = new Canvas();
            gameRoot.Children.Add(scoreBoard);
            gameRoot.Children.Add(blockNumberBoard);
        }

```

