using System.Threading.Tasks;
using _Scripts.Data;
using Enca.SaveSystem;
using UnityEngine;

namespace _Scripts
{
    public class DataManager : MonoBehaviour, ISaveable
    {
        public PlayerData playerData;

        public async Task OnSaveAsync() => await SaveLoadUtility.SaveAsync(playerData);

        public async Task OnLoadAsync() => await SaveLoadUtility.LoadAsync(playerData);

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
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