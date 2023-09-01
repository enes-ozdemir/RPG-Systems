using System;
using _Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.AttackButtons
{
    public class SkillButton : AttackButtonUI
    {
        [SerializeField] private Sprite blockedSprite;
        [SerializeField] private Sprite normalSprite;
        [SerializeField] private Sprite highlightSprite;
         private Sprite _skillSprite;
        [SerializeField] private Image skillImage;
        [SerializeField] private TextMeshProUGUI skillText; //this is for disabling skill for duration of cooldown

        //todo make a hint UI for the skill

        private void Awake()
        {
            _skillSprite = this.ability.abilitySprite;
            skillImage.sprite = _skillSprite;
        }

     
    }
}