using System;
using System.Threading.Tasks;
using _Scripts.Data;
using _Scripts.EncounterScripts.Encounters;
using Enca.SaveSystem;
using UnityEngine;

namespace _Scripts
{
    public class DataManager : MonoBehaviour, ISaveable
    {
        public PlayerData playerData;

        public Action OnSaveCompleted;
        public Action OnLoadCompleted;
        
        public async Task OnSaveAsync()
        {
            await SaveLoadUtility.SaveAsync(playerData);
            OnSaveCompleted?.Invoke();
        }

        public async Task OnLoadAsync()
        {
            await SaveLoadUtility.LoadAsync(playerData);
            OnLoadCompleted?.Invoke();
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneController.onNewSceneLoaded += OnNewSceneLoaded;
        }

        public virtual async void OnNewSceneLoaded(int obj)
        {
            await OnSaveAsync();
            await OnLoadAsync();
        }
        
        private async void OnDestroy()
        {
            await OnSaveAsync();
        }
       
    }
}