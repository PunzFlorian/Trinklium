using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Items
{
    class Banana : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Banana");
            Tooltip.SetDefault("Mhhhhh Bananas");                                  
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Bacon);
            this.item.maxStack = 999;            
        }      
    }
}
