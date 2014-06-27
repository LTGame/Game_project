using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace StructureGame
{
    public class CoinModel : GameModel
    {
        Coin coin;
        Vector2 Target = new Vector2(20, 20);//noi ma mat troi sau khi nhat chuoi vo day
        public CoinModel(Coin coin)
        {
            this.coin = coin;
            this._mainSpite = GameManager.spriteProvider.getSprite(coin.idCoin);
            this._mainSpite.Vector = coin.posStart;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (coin.currentState == Coin.CoinState.Falling)
                this._mainSpite.Vector = new Vector2(coin.posStart.X,coin.posStart.Y+coin.currentFallingPath);
            else if (coin.currentState == Coin.CoinState.Idle)
                this._mainSpite.Vector = new Vector2(coin.posStart.X,coin.posStart.Y+coin.FallingMaxPath;
            else if (coin.currentState == Coin.CoinState.PickUp)
                ;//Xuong code ho duong thang nao :D
            base.Draw(gameTime, spriteBatch);
        }
    }
}
