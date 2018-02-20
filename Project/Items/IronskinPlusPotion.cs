using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Items
{
    class IronskinPlusPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ironskin Plus Potion");
            Tooltip.SetDefault("Increase defense by 12");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useTime = 17;
            item.useAnimation = 17;
            item.maxStack = 30;
            item.consumable = true;
            item.width = 20;
            item.height = 30;
            item.value = 0;
            item.rare = 0;
            item.buffType = mod.BuffType("IronskinPlus");
            item.buffTime = 10000;
        }
    }
}