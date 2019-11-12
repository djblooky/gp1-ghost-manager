using Microsoft.Xna.Framework;

namespace GhostManager_HaleyPhillips
{
    public class GhostSpawnerLimit : GhostManager
    {
        protected float limitGhostRateForMiliseconds, limitGhostRateMilisecondsTimer, limitGhostRate;
        public float LimitGhostRate
        {
            get { return limitGhostRate; }
            set
            {
                limitGhostRate = value;
                limitGhostRateForMiliseconds = limitGhostRate * 1000;
            }
        } //limit ghosts to X per second set to 0 for no Rate limit

        public int MaxGhosts { get; set; }

        public GhostSpawnerLimit(Game game) : base(game) {

            MaxGhosts = 5;
            limitGhostRate = 10;
        }

        public override Ghost spawnGhost(Ghost ghost)
        {
            if (!CheckTimerToAllowGhost()) return null;
            g = base.spawnGhost(ghost);
            limitGhostRateMilisecondsTimer = limitGhostRateForMiliseconds;
            return g;
        }

        private bool CheckTimerToAllowGhost()
        {
            if (limitGhostRate > 1)
            {
                if ((limitGhostRateMilisecondsTimer > 0) || (Ghosts.Count >= MaxGhosts))
                {
                    return false;
                }
            }
            return true;
        }

        public override void Update(GameTime gameTime)
        {
            //If ghost rate is limited use timer 0 means unlimited
            if (limitGhostRateMilisecondsTimer > 0)
                limitGhostRateMilisecondsTimer -= gameTime.ElapsedGameTime.Milliseconds;
            base.Update(gameTime);
        }
    }
}
