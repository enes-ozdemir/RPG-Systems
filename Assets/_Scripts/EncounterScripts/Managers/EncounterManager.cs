using System;
using _Scripts.Tiles;
using UnityEngine;

namespace _Scripts.EncounterScripts.Managers
{
    public class EncounterManager : MonoBehaviour
    {
        public void StartEncounter(TileInfo currentTile)
        {
            var encounterType = currentTile.GetRandomEncounterType();
            
            switch (encounterType)
            {
                case EncounterType.Chest:
                    SceneController.LoadScene(2);
                    break;
                case EncounterType.Fight:
                    Debug.Log("Fight scene");
                    SceneController.LoadScene(1);
                    break;
                case EncounterType.Town:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}