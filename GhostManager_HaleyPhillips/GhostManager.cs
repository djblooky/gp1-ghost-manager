using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GhostManager_HaleyPhillips
{
    public interface IGhostManager
    {
        List<Ghost> Ghosts { get; set; }
        Ghost spawnGhost();
        Ghost spawnGhost(Ghost g);
        string GhostTexture { get; set; }
    }

    public class GhostManager : GameComponent, IGhostManager
    {
        private List<Ghost> ghosts; 
        public List<Ghost> Ghosts
        {
            get => ghosts;
            set => ghosts = value;
        }

        List<Ghost> ghostsToRemove { get; set; }  //remove these ghosts when disabled
        public string GhostTexture { get; set; }

        protected Ghost g = null; //default ghost
        Random rand;

        public GhostManager(Game game) : base(game)
        {
            rand = new Random();
            g = new Ghost(game, GetRandomLocation(new Ghost(game)), GetRandomDirection());
            ghosts = new List<Ghost>();
            ghostsToRemove = new List<Ghost>();  
        }

        public virtual Ghost spawnGhost()
        {
            return spawnGhost(new Ghost(Game, GetRandomLocation(g), GetRandomDirection())); //spawn a new ghost
        }

        public virtual Ghost spawnGhost(Ghost g)
        {
            this.g = g; //set default ghost
            if (!string.IsNullOrEmpty(GhostTexture)) //make sure texture is set
            {
                g.GhostTexture = GhostTexture;
            }

            g.Initialize();
            addGhost(g);
            return g;
        }

        protected virtual void addGhost(Ghost g)
        {
            ghosts.Add(g);
        }

        protected virtual void removeGhost(Ghost g)
        {
            ghosts.Remove(g);
        }

        public Vector2 GetRandomDirection()
        {
            Vector2 vect = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            Vector2.Normalize(ref vect, out vect);
            return vect;
        }

        public Vector2 GetRandomLocation(Ghost g)
        {
            Vector2 location;
            location.X = rand.Next((Game.Window.ClientBounds.Width - g.spriteTexture.Width) + g.spriteTexture.Width);
            location.Y = rand.Next((Game.Window.ClientBounds.Height - g.spriteTexture.Height) + g.spriteTexture.Height);
            return location;
        }

        public override void Update(GameTime gameTime)
        {
            ghostsToRemove.Clear(); //clear old ghosts to be removed

            foreach (Ghost g in ghosts)
            {
                if (g.Enabled)
                {
                    g.Update(gameTime); //Only update enabled ghosts
                }
                else //If the ghost is not enabled 
                {
                    ghostsToRemove.Add(g);
                }
            }

            //Remove ghosts that are not enalbled anymore
            foreach (Ghost s in ghostsToRemove)
            {
                removeGhost(s);
            }
            base.Update(gameTime);
        }


        public void Draw(SpriteBatch sb)
        {
            foreach (var g in ghosts) //draw each ghost
            {
                 g.Draw(sb);
            }
        }
    }
}
