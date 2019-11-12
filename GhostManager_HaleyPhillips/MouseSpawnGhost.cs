using Microsoft.Xna.Framework;
using MonoGameLibrary.Util;
using Microsoft.Xna.Framework.Input;

namespace GhostManager_HaleyPhillips
{
    class MouseSpawnGhost : GhostSpawnerLimit
    {
        InputHandler input;
        float mouseX, mouseY;

        public MouseSpawnGhost(Game game) : base(game)
        {
            input = (InputHandler)Game.Services.GetService<IInputHandler>();

            if (input == null)
            {
                input = new InputHandler(Game);
                input.Initialize();
                Game.Components.Add(input);
            }
            LimitGhostRate = .01f;
        }

        public override void Update(GameTime gameTime)
        {
            updateMousePosition();
            if (input.MouseState.LeftButton == ButtonState.Pressed)
            {
                //if(input.MouseState.LeftButton == ButtonState.Released)
                spawnGhost();
            }
            base.Update(gameTime);
        }

        void updateMousePosition()
        {
            mouseX = input.MouseState.X;
            mouseY = input.MouseState.Y;
        }

        public override Ghost spawnGhost()
        {
            g = base.spawnGhost();
            g.Direction = g.Location - new Vector2(mouseX, mouseY);
            g.Direction = g.Direction * -1;
            g.Direction.Normalize();
            g.Speed = 300;
            return g;
        }

    }
}
