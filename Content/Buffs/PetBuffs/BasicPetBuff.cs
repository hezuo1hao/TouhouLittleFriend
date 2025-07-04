﻿using Microsoft.Xna.Framework;
using Terraria;

namespace TouhouPets.Content.Buffs
{
    public abstract class BasicPetBuff : ModBuff
    {
        public virtual int PetType => -1;
        public virtual bool LightPet => false;
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = !LightPet;
            Main.lightPet[Type] = LightPet;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            bool flag = PetType != -1 && player.ownedProjectileCounts[PetType] <= 0;
            if (flag && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, PetType, 0, 0f, player.whoAmI);
                OnSummonPet(player);
            }
        }
        public virtual void OnSummonPet(Player player)
        {
        }
    }
}
