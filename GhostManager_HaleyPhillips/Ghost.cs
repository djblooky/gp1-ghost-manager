using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (String.IsNullOrEmpty(GhostTexture))
            {
                GhostTexture = "PurpleGhost";
            }
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
