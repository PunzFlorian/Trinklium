﻿using Microsoft.Xna.Framework;

using Terraria;

using Terraria.ModLoader;



namespace Trinklium.Buffs

{

    public class LightPet : ModBuff

    {

        public override void SetDefaults()

        {

            DisplayName.SetDefault("Banana Pet");

            Description.SetDefault("Holy light knows da wae");

            Main.buffNoTimeDisplay[Type] = true;

            Main.lightPet[Type] = true;

        }



        public override void Update(Player player, ref int buffIndex)

        {

            player.GetModPlayer<ExamplePlayer>(mod).exampleLightPet = true;

            player.buffTime[buffIndex] = 18000;

            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("LightPet")] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)

            {

                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("LightPet"), 0, 0f, player.whoAmI, 0f, 0f);

            }

            if ((player.controlDown && player.releaseDown))

            {

                if (player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15)

                {

                    for (int j = 0; j < 1000; j++)

                    {

                        if (Main.projectile[j].active && Main.projectile[j].type == mod.ProjectileType("LightPet") && Main.projectile[j].owner == player.whoAmI)

                        {

                            Projectile lightpet = Main.projectile[j];

                            Vector2 vectorToMouse = Main.MouseWorld - lightpet.Center;

                            lightpet.velocity += 5f * Vector2.Normalize(vectorToMouse);

                        }

                    }

                }

            }

        }

    }

}