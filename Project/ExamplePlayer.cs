using System;

using System.Collections.Generic;

using System.IO;

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

using Terraria;

using Terraria.DataStructures;

using Terraria.ID;

using Terraria.ModLoader;


using Terraria.ModLoader.IO;

using Terraria.GameInput;



namespace Trinklium

{

    public class ExamplePlayer : ModPlayer

    {

        private const int saveVersion = 0;

        public int score = 0;

        public bool eFlames = false;

        public bool elementShield = false;

        public int elementShields = 0;

        private int elementShieldTimer = 0;

        public int elementShieldPos = 0;

        public int lockTime = 0;

        public bool voidMonolith = false;

        public int heroLives = 0;

        public int reviveTime = 0;

        public int constantDamage = 0;

        public float percentDamage = 0f;

        public float defenseEffect = -1f;

        public bool badHeal = false;

        public int healHurt = 0;

        public bool nullified = false;

        public int purityDebuffCooldown = 0;

        public bool purityMinion = false;

        public bool examplePet = false;

        public bool exampleLightPet = false;

        public bool exampleShield = false;

        // These 5 relate to ExampleCostume.

        public bool blockyAccessoryPrevious;

        public bool blockyAccessory;

        public bool blockyHideVanity;

        public bool blockyForceVanity;

        public bool blockyPower;



        private const int maxExampleLifeFruits = 10;

        public int exampleLifeFruits = 0;



        public bool ZoneExample = false;



        public override void ResetEffects()

        {

            eFlames = false;

            elementShield = false;

            constantDamage = 0;

            percentDamage = 0f;

            defenseEffect = -1f;

            badHeal = false;

            healHurt = 0;

            nullified = false;

            purityMinion = false;

            examplePet = false;

            exampleLightPet = false;

            exampleShield = false;

            blockyAccessoryPrevious = blockyAccessory;

            blockyAccessory = blockyHideVanity = blockyForceVanity = blockyPower = false;



            player.statLifeMax2 += exampleLifeFruits * 2;

        }



        // In MP, other clients need accurate information about your player or else bugs happen.

        // clientClone, SyncPlayer, and SendClientChanges, ensure that information is correct.

        // We only need to do this for data that is changed by code not executed by all clients, 

        // or data that needs to be shared while joining a world.

        // For example, examplePet doesn't need to be synced because all clients know that the player is wearing the ExamplePet item in an equipment slot. 

        // The examplePet bool is set for that player on every clients computer independently (via the Buff.Update), keeping that data in sync.

        // ExampleLifeFruits, however might be out of sync. For example, when joining a server, we need to share the exampleLifeFruits variable with all other clients.

        public override void clientClone(ModPlayer clientClone)

        {

            ExamplePlayer clone = clientClone as ExamplePlayer;

            // Here we would make a backup clone of values that are only correct on the local players Player instance.

            // Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots

            // clone.someLocalVariable = someLocalVariable;

        }



        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)

        {

            ModPacket packet = mod.GetPacket();


            packet.Write((byte)player.whoAmI);

            packet.Write(exampleLifeFruits);

            packet.Send(toWho, fromWho);

        }



        public override void SendClientChanges(ModPlayer clientPlayer)

        {

            // Here we would sync something like an RPG stat whenever the player changes it.

            // So far, ExampleMod has nothing that needs this.

            // if (clientPlayer.someLocalVariable != someLocalVariable)

            // {

            //    Send a Mod Packet with the changes.

            // }

        }



        public override void UpdateDead()

        {

            eFlames = false;

            badHeal = false;

        }








        public override void LoadLegacy(BinaryReader reader)

        {

            int loadVersion = reader.ReadInt32();

            score = reader.ReadInt32();

        }









        public override bool CustomBiomesMatch(Player other)

        {

            ExamplePlayer modOther = other.GetModPlayer<ExamplePlayer>(mod);

            return ZoneExample == modOther.ZoneExample;

        }



        public override void CopyCustomBiomesTo(Player other)

        {

            ExamplePlayer modOther = other.GetModPlayer<ExamplePlayer>(mod);

            modOther.ZoneExample = ZoneExample;

        }



        public override void SendCustomBiomes(BinaryWriter writer)

        {

            BitsByte flags = new BitsByte();

            flags[0] = ZoneExample;

            writer.Write(flags);

        }



        public override void ReceiveCustomBiomes(BinaryReader reader)

        {

            BitsByte flags = reader.ReadByte();

            ZoneExample = flags[0];

        }











        public override void UpdateBadLifeRegen()

        {

            if (eFlames)

            {

                if (player.lifeRegen > 0)

                {

                    player.lifeRegen = 0;

                }

                player.lifeRegenTime = 0;

                player.lifeRegen -= 16;

            }

            if (healHurt > 0)

            {

                if (player.lifeRegen > 0)

                {

                    player.lifeRegen = 0;

                }

                player.lifeRegenTime = 0;

                player.lifeRegen -= 120 * healHurt;

            }

        }














        public void PuritySpiritDebuff()

        {

            bool flag = true;

            if (Main.rand.Next(2) == 0)

            {

                flag = false;

                for (int k = 0; k < 2; k++)

                {

                    int buffType;

                    int buffTime;

                    switch (Main.rand.Next(5))

                    {

                        case 0:

                            buffType = BuffID.Darkness;

                            buffTime = 1800;

                            break;

                        case 1:

                            buffType = BuffID.Cursed;

                            buffTime = 900;

                            break;

                        case 2:

                            buffType = BuffID.Confused;

                            buffTime = 1800;

                            break;

                        case 3:

                            buffType = BuffID.Slow;

                            buffTime = 1800;

                            break;

                        default:

                            buffType = BuffID.Silenced;

                            buffTime = 900;

                            break;

                    }

                    if (!player.buffImmune[buffType])

                    {

                        player.AddBuff(buffType, buffTime);

                        return;

                    }

                }

            }

            if (flag || Main.expertMode || Main.rand.Next(2) == 0)

            {

                player.AddBuff(mod.BuffType("Undead"), 1800, false);

            }

            for (int k = 0; k < 25; k++)

            {

                Dust.NewDust(player.position, player.width, player.height, mod.DustType("Negative"), 0f, -1f, 0, default(Color), 2f);

            }

        }



        public override void PostUpdateBuffs()

        {

            if (nullified)

            {

                Nullify();

            }

        }










        public override void PostUpdateEquips()

        {

            if (nullified)

            {

                Nullify();

            }

            if (elementShield)

            {

                if (elementShields > 0)

                {

                    elementShieldTimer--;

                    if (elementShieldTimer < 0)

                    {

                        elementShields--;

                        elementShieldTimer = 600;

                    }

                }

            }

            else

            {

                elementShields = 0;

                elementShieldTimer = 0;

            }

            elementShieldPos++;

            elementShieldPos %= 300;

        }



        public override void PostUpdateMiscEffects()

        {

            if (lockTime > 0)

            {

                lockTime--;

            }

            if (reviveTime > 0)

            {

                reviveTime--;

            }

        }



        //public override void FrameEffects()

        //{

        //    if ((blockyPower || blockyForceVanity) && !blockyHideVanity)

        //    {

        //        player.legs = mod.GetEquipSlot("BlockyLeg", EquipType.Legs);

        //        player.body = mod.GetEquipSlot("BlockyBody", EquipType.Body);

        //        player.head = mod.GetEquipSlot("BlockyHead", EquipType.Head);

        //    }

        //    if (nullified)

        //    {

        //        Nullify();

        //    }

        //}



        private void Nullify()

        {

            player.ResetEffects();

            player.head = -1;

            player.body = -1;

            player.legs = -1;

            player.handon = -1;

            player.handoff = -1;

            player.back = -1;

            player.front = -1;

            player.shoe = -1;

            player.waist = -1;

            player.shield = -1;

            player.neck = -1;

            player.face = -1;

            player.balloon = -1;

            nullified = true;

        }



        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,

            ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)

        {

            if (constantDamage > 0 || percentDamage > 0f)

            {

                int damageFromPercent = (int)(player.statLifeMax2 * percentDamage);

                damage = Math.Max(constantDamage, damageFromPercent);

                customDamage = true;

            }

            else if (defenseEffect >= 0f)

            {

                if (Main.expertMode)

                {

                    defenseEffect *= 1.5f;

                }

                damage -= (int)(player.statDefense * defenseEffect);

                if (damage < 0)

                {

                    damage = 1;

                }

                customDamage = true;

            }

            constantDamage = 0;

            percentDamage = 0f;

            defenseEffect = -1f;

            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);

        }








        public override float UseTimeMultiplier(Item item)

        {

            return exampleShield ? 1.5f : 1f;

        }



        public override void AnglerQuestReward(float quality, List<Item> rewardItems)

        {

            if (voidMonolith)

            {

                Item sticky = new Item();

                sticky.SetDefaults(ItemID.StickyDynamite);

                sticky.stack = 4;

                rewardItems.Add(sticky);

            }

            foreach (Item item in rewardItems)

            {

                if (item.type == ItemID.GoldCoin)

                {

                    int stack = item.stack;

                    item.SetDefaults(ItemID.PlatinumCoin);

                    item.stack = stack;

                }

            }

        }










        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)

        {

            if ((blockyPower || blockyForceVanity) && !blockyHideVanity)

            {

                player.headRotation = player.velocity.Y * (float)player.direction * 0.1f;

                player.headRotation = Utils.Clamp(player.headRotation, -0.3f, 0.3f);

                if (ZoneExample)

                {

                    player.headRotation = (float)Main.time * 0.1f * player.direction;

                }

            }

        }



        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)

        {

            if (eFlames)

            {

                if (Main.rand.Next(4) == 0 && drawInfo.shadow == 0f)

                {

                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("EtherealFlame"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 3f);

                    Main.dust[dust].noGravity = true;

                    Main.dust[dust].velocity *= 1.8f;

                    Main.dust[dust].velocity.Y -= 0.5f;

                    Main.playerDrawDust.Add(dust);

                }

                r *= 0.1f;

                g *= 0.2f;

                b *= 0.7f;

                fullBright = true;

            }

        }









    }

}