using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu(fileName = "New Hit Effect", menuName = "Abilities/HitEffect")]
    public class HitEffect : ScriptableObject
    {
        public Color hitTextColor;
        public Color hitEffectColor;
        public List<GameObject> hitEffectPrefab;
        public GameObject bloodParticlePrefab;
    }
}