using System;
using _Scripts.Data;
using _Scripts.EncounterScripts.Encounters;

namespace _Scripts
{
    public class ChestDataManager: DataManager
    {
        public ChestEncounter encounter;
        private PlayerData _playerData;

        private void OnEnable()
        {
            OnLoadCompleted += OnLoadCompletedHandler;
        }

        private void OnDisable()
        {
            OnLoadCompleted -= OnLoadCompletedHandler;
        }

        private void OnLoadCompletedHandler()
        {
            encounter.InitPlayerData(playerData);
        }
    }
}