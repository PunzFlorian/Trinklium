using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Buffs
{
    class IronskinPlus : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("IronskinPlus");
            Description.SetDefault("Increase defense by 12");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.ClearBuff(BuffID.Ironskin);
            player.statDefense += 12;
        }
    }
}
