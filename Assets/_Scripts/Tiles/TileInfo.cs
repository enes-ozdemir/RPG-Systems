using System;
using _Scripts.MapScripts;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace _Scripts.Tiles
{
    [CreateAssetMenu(fileName = "TileInfo", menuName = "TileInfo", order = 0)]
    public class TileInfo : ScriptableObject
    {
        public TileBase[] tiles;
        public TileType tileType;
        public Sprite bgSprite;
        public Encounterment[] encounterment;
        public float walkingSpeed;

        public EncounterType GetRandomEncounterType()
        {
            int totalChance = 0;
            foreach (var encounter in encounterment)
            {
                totalChance += encounter.chance;
            }

            int randomValue = Random.Range(0, totalChance);
            int currentSum = 0;

            foreach (var encounter in encounterment)
            {
                currentSum += encounter.chance;
                if (randomValue < currentSum)
                {
                    return encounter.encounterType;
                }
            }

            return EncounterType.Fight; // Default value, should never be reached
        }
    }

    [Serializable]
    public class Encounterment
    {
        public EncounterType encounterType;
        public int chance;
    }

    public enum EncounterType
    {
        Town,
        Fight,
        Nothing,
        Shop,
        Chest,
        Dungeon,
        Boss
    }
}