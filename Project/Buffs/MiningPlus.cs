using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Buffs
{
    class MiningPlus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("MiningPlus");
            Description.SetDefault("50% increased Mining speed");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.ClearBuff(BuffID.Mining);
            player.pickSpeed = player.pickSpeed / 2;
        }       
    }
}
