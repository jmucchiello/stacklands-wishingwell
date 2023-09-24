using HarmonyLib;
using System;
using System.Collections;
using UnityEngine;

namespace WishingWellModNS
{
    public class WishingWellMod : Mod
    {
        public static WishingWellMod instance;

        public CardType CardTypeWish;

        public List<Wish> Wishes = new();

        private void Awake()
        {
            instance = this;
            CardTypeWish = EnumHelper.ExtendEnum<CardType>("Wish");
            Harmony.PatchAll();
        }
        public override void Ready()
        {
            Logger.Log("Ready!");
        }

        public void Log(string msg)
        {
            Logger.Log(msg);
        }
    }
}