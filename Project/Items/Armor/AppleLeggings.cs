using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Items.Armor
{

    [AutoloadEquip(EquipType.Legs)]
    class AppleLeggings : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apple Leggings");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.rare = 1;
            item.vanity = false;
            item.defense = 7;
        }
    }
}
