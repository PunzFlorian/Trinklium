﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinklium.Items
{
    class BananaBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Banana Bow");
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 5;
            item.useAnimation = 20;
            item.useStyle = 20;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Arrow;            
        }

    }
}
