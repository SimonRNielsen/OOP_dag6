using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Monogame_intro
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D sprite;
        private Rectangle rectangle;
        private Random random = new Random();
        private int interrupt;
        private int randomSprite;
        private SpriteFont gameWorldFont;
        private int foxCounter = 1;
        private int fishCounter;
        private int elephantCounter;
        private int giraffeCounter;
        private int monkeyCounter;
        private int lionCounter;
        private int owlCounter;
        private int bunnyCounter;
        private int catCounter;
        private int pandaCounter;
        private int randomMovement;
        private Vector2 vector2 = new Vector2();
        private float scale;

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sprite = Content.Load<Texture2D>("tile_fox");
            rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);

            gameWorldFont = Content.Load<SpriteFont>("GameWorldFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            vector2.Y++;
            interrupt++;
            if (interrupt == 4)
            {
                randomMovement = random.Next(-15, 16);
                interrupt = 0;
                scale += 0.08f;
                vector2.X += randomMovement;

                if (vector2.X < -10)
                {
                    vector2.X = -10;
                }
                else if (vector2.X > (_graphics.PreferredBackBufferWidth - 40))
                {
                    vector2.X = (_graphics.PreferredBackBufferWidth - 40);
                }
            }
            if (vector2.Y > _graphics.PreferredBackBufferHeight)
            {
                scale = 3f;
                vector2.Y = -10;
                vector2.X = random.Next(0, (_graphics.PreferredBackBufferWidth - 40));
                randomSprite = random.Next(1, 11);
                sprite = Content.Load<Texture2D>($"{(AnimalSelection)randomSprite}");
                switch (randomSprite)
                {
                    case 1:
                        foxCounter++;
                        break;
                    case 2:
                        fishCounter++;
                        break;
                    case 3:
                        elephantCounter++;
                        break;
                    case 4:
                        giraffeCounter++;
                        break;
                    case 5:
                        monkeyCounter++;
                        break;
                    case 6:
                        lionCounter++;
                        break;
                    case 7:
                        owlCounter++;
                        break;
                    case 8:
                        bunnyCounter++;
                        break;
                    case 9:
                        catCounter++;
                        break;
                    case 10:
                        pandaCounter++;
                        break;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            if (randomMovement < 0)
            {
                _spriteBatch.Draw(sprite, vector2, rectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                _spriteBatch.Draw(sprite, vector2, rectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
            _spriteBatch.DrawString(gameWorldFont, $"Foxes: {foxCounter}\nFishes: {fishCounter}\nElephants: {elephantCounter}\nGiraffes: {giraffeCounter}\nMonkeys: {monkeyCounter}\nLions: {lionCounter}\nOwls: {owlCounter}\nBunnies: {bunnyCounter}\nCats: {catCounter}\nPandas: {pandaCounter}", Vector2.Zero, Color.Black);
            _spriteBatch.End();

        }
    }

    public enum AnimalSelection : int
    {
        tile_fox = 1,
        tile_fish = 2,
        tile_elephant = 3,
        tile_giraffe = 4,
        tile_monkey = 5,
        tile_lion = 6,
        tile_owl = 7,
        tile_bunny = 8,
        tile_cat = 9,
        tile_panda = 10
    }
}
