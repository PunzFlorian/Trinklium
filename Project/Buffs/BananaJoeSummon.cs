using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Buffs
{
    public class BananaJoeSummon : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Banana Joe");
            Description.SetDefault("He'll protect you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            ExamplePlayer modPlayer = player.GetModPlayer<ExamplePlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType("BananaJoeSummon")] > 0)
            {
                modPlayer.purityMinion = true;
            }

            if (!modPlayer.purityMinion)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}