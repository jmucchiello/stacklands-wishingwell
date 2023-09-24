using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace WishingWellModNS
{
    public class HealingWish : Wish
    {
        public override void Invoke()
        {
            List<GameCard> cards = WorldManager.instance.AllCards.FindAll(card =>
                card.MyBoard == WorldManager.instance.CurrentBoard &&
                card.CardData is Villager && 
                (card.CardData.StatusEffects.Count > 0 || ((Combatable)(card.CardData)).BaseCombatStats.MaxHealth > ((Combatable)(card.CardData)).HealthPoints)
            );
            List<Villager> villagers = new();
            foreach (GameCard card in cards)
            {
                Villager? villager = card.CardData as Villager;
                if (villager != null)
                {
                    villagers.Add(villager);
                }
            }
            StartCoroutine(Animation(villagers));
        }

        private IEnumerator Animation(List<Villager> villagers)
        {
            Vector3 position = GameCamera.instance.transform.position;
            foreach (Villager villager in villagers)
            {
                GameCamera.instance.transform.position = villager.transform.position;
                yield return new WaitForSeconds(0.5f);
                villager.StatusEffects.Clear();
                villager.HealthPoints = villager.RealBaseCombatStats.MaxHealth;
                yield return new WaitForSeconds(0.5f);
            }
            GameCamera.instance.transform.position = position;
        }
    }
}
