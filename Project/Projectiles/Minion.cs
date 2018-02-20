using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Projectiles
{
    public abstract class Minion : ModProjectile
    {
        public override void AI()
        {
            CheckActive();
            Behavior();
        }
        public abstract void CheckActive();
        public abstract void Behavior();
    }

}