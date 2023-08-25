using _Scripts.EncounterScripts.Encounters;
using _Scripts.Tiles;
using UnityEngine;

namespace _Scripts.EncounterScripts.Managers
{
    public class EncounterManager : MonoBehaviour
    {
        private TileInfo _tileInfo;


        private void Awake()
        {
            _tileInfo = EncounterInfo.currentTileInfo;
        }


        private void Start()
        {
            if (_tileInfo == null)
            {
                //    throw new Exception("TileInfo is null");
            }

//            var encounterType = _tileInfo.GetRandomEncounterType();

            // switch (encounterType)
            // {
            //     case EncounterType.Chest:
            //        // var chestEncounter = gameObject.AddComponent<ChestEncounter>();
            //        
            //         chestEncounter.StartEncounter();
            //         break;
            //     case EncounterType.Fight:
            //       //  var enemyEncounter = gameObject.AddComponent<EnemyEncounter>();
            //         enemyEncounter.StartEncounter();
            //         break;
            //     case EncounterType.Town:
            //        // var townEncounter = gameObject.AddComponent<TownEncounter>();
            //         townEncounter.StartEncounter();
            //         break;
            //     default:
            //         throw new ArgumentOutOfRangeException();
            // }
        }
    }
}