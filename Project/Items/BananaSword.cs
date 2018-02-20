using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Items
{
	public class BananaSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Banana Sword");
			Tooltip.SetDefault("Mhhhhh Bananas");
		}
		public override void SetDefaults()
		{
			item.damage = 50;
			item.melee = true;
			item.width = 40;
			item.height = 74;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = Item.sellPrice(0, 2, 50, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;            
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.GetItem("Banana"), 10);
            recipe.AddIngredient(ItemID.Wood, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
