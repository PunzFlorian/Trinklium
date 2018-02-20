using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Items.Armor
{

    [AutoloadEquip(EquipType.Head)]
    class AppleHead : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apple Helmet");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.rare = 1;
            item.vanity = true;
        }
    }
}
