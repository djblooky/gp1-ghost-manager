using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;

namespace GhostManager_HaleyPhillips
{
    public class Ghost : Sprite
    {
        float elapsedtime;
        public Vector2 StartLocation { get; set; }
        private string ghostTexture; //private instance data menber
        public string GhostTexture
        {
            get { return ghostTexture; }
            set
            {
                ghostTexture = value;
                LoadContent();
            }
        }

        public Ghost(Game game) : base(game)
        {
            if (string.IsNullOrEmpty(GhostTexture))
                GhostTexture = "PurpleGhost";
            LoadContent();
        }

        public Ghost(Game game, Vector2 Location, Vector2 Direction) : base(game)
        {
            if (string.IsNullOrEmpty(GhostTexture))
            {
                GhostTexture = "PurpleGhost";
            }

            this.Location = Location;
            this.Direction = Direction;
        }

        protected override void LoadContent()
        {
            spriteTexture = Game.Content.Load<Texture2D>(GhostTexture);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            elapsedtime = gameTime.ElapsedGameTime.Milliseconds;

            if (Location == null)
                Location = StartLocation;

            Location += (Direction * Speed * (elapsedtime / 1000));

            if (IsOffScreen())
            {
                Enabled = false;
            }

            base.Update(gameTime);
        }
    }
}
