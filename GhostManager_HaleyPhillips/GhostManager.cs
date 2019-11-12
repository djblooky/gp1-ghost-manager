using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public GhostManager(Game game) : base(game)
        {
            g = new Ghost(game);
            ghosts = new List<Ghost>();
            ghostsToRemove = new List<Ghost>();
        }

        public virtual Ghost spawnGhost()
        {
            return spawnGhost(new Ghost(Game)); //spawn a new ghost
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
