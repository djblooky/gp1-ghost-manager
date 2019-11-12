﻿using Microsoft.Xna.Framework;
using MonoGameLibrary.Util;
using Microsoft.Xna.Framework.Input;

namespace GhostManager_HaleyPhillips
{
    class MouseSpawnGhost : GhostSpawnerLimit
    {
        InputHandler input;

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
            if (input.MouseState.LeftButton == ButtonState.Pressed)
            {
                spawnGhost();
            }
            base.Update(gameTime);
        }

        public override Ghost spawnGhost()
        {
            g = base.spawnGhost();
            g.Direction = g.Location - input.MouseState.Position.ToVector2();
            g.Direction = g.Direction * -1;
            g.Direction.Normalize();
            g.Speed = 300;
            return g;
        }

    }
}
