using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Items.Armor
{

    [AutoloadEquip(EquipType.Body)]
    class AppleBreastplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apple Breastplate");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.rare = 1;
            item.vanity = false;
            item.defense = 10;
        }
    }
}