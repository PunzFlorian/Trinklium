﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Items
{   
    class Banano : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Banano");
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 16f;
            item.knockBack = 2.5f;
            item.damage = 38;
            item.rare = 0;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 1);
            item.shoot = mod.ProjectileType<Projectiles.Banano>();
        }      
    }
}
