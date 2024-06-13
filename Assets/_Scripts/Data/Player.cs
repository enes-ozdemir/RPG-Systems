using System.Threading.Tasks;
using Enca.SaveSystem;
using UnityEngine;

namespace _Scripts.Data
{
    public class Player : Character, ISaveable
    {
        [SerializeField] private PlayerData _playerData;

        private void Start()
        {
            InitializeAsync();
        }

        private void OnDisable()
        {
            OnSaveAsync();
            SaveLoadManager.OnSaveAsync -= OnSaveAsync;
            SaveLoadManager.OnLoadAsync -= OnLoadAsync;
        }

        private void OnEnable()
        {
            SaveLoadManager.OnSaveAsync += OnSaveAsync;
            SaveLoadManager.OnLoadAsync += OnLoadAsync;
        }

        private async void InitializeAsync()
        {
            SaveLoadUtility.InitializeSaveData(charData, "Player");
            SaveLoadUtility.InitializeSaveData(_playerData, "Player_data");

            await OnLoadAsync();
        }

        public async Task OnSaveAsync()
        {
            await SaveLoadUtility.SaveAsync(charData);
            await SaveLoadUtility.SaveAsync(_playerData);
        }

        public async Task OnLoadAsync()
        {
            await SaveLoadUtility.LoadAsync(charData);
            await SaveLoadUtility.LoadAsync(_playerData);
        }
    }
}