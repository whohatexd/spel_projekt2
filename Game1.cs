using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Spel__projekt2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SoundEffect Coin_Sound;
        Song Game_Song;
        

        Texture2D backgrund;
        Vector2 bak = new Vector2(0, 0);

        Texture2D hero;
        Rectangle sonicrec = new Rectangle(550, 480, 200, 200);

        Texture2D coin;
        Rectangle coinrec = new Rectangle(560, 25, 75, 75);
        KeyboardState keybord = Keyboard.GetState();

        SpriteFont Times;
        Random RandonNum = new Random();
        int score = 0;
        int tid = 0;
        int sek = 0;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
             _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgrund = Content.Load<Texture2D>("backgrund");
            hero = Content.Load<Texture2D>("sonic");
            coin = Content.Load<Texture2D>("coin");
            Coin_Sound = Content.Load<SoundEffect>("coinsound");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            keybord = Keyboard.GetState();
            tid++;

            if (tid == 60)
            {
                sek++;
                tid = 0;
            }
            coinrec.Y += 6;
            int randomPlats = RandonNum.Next(0, 1140);
            if (keybord.IsKeyDown(Keys.D))
            {
                sonicrec.X += 9;
            }

            if (keybord.IsKeyDown(Keys.A))
            {
                sonicrec.X -= 9;
            }
            
            if (sonicrec.Intersects(coinrec))
            {
                coinrec = new Rectangle(randomPlats, -1, 75, 75);
                score++;
                Coin_Sound.Play();
            }
            else if (coinrec.Y == 480)
            {
                
            }

           
            if(sonicrec.X > 1295)
            {
                sonicrec.X = -199;
            }

            else if(sonicrec.X <= -200)
                 {
                   sonicrec.X = 1290;
                 }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgrund, bak, Color.White);
            _spriteBatch.Draw(coin, coinrec, Color.White);
            _spriteBatch.Draw(hero, sonicrec, Color.White);
           
            _spriteBatch.End();
          
            

            

            base.Draw(gameTime);
        }
    }
}