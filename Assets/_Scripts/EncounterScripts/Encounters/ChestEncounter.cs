using _Scripts.Data;
using UnityEngine;

namespace _Scripts.EncounterScripts.Encounters
{
    public class ChestEncounter : MonoBehaviour, IEncounter
    {
        private PlayerData _playerData;
        private int _chestGoldAmount;
        private int _chestHealth;
        public SpriteRenderer spriteRenderer;
        public DataManager dataManager;

        public void InitPlayerData(PlayerData playerData) => _playerData = playerData;

        private int GenerateGoldReward(int playerLevel)
        {
            //todo set Sprite based on gold
            _chestHealth = playerLevel;
            return playerLevel * 100;
        }

        private Camera mainCamera;

        public int GetGold() => _chestGoldAmount;

        private void Start()
        {
            mainCamera = Camera.main;

            //todo get from playerPrefs maybe or set it here
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                if (hit.collider != null && hit.collider.gameObject.tag.Equals("Chest"))
                {
                    OnSpriteClicked();
                }
            }
        }

        private void OnSpriteClicked()
        {
            Debug.Log($"Chest Clicked {_chestHealth}");
            _chestHealth--;
            if (_chestHealth <= 0)
            {
                //todo additional effects
                Destroy(gameObject);
                RewardPlayer();
            }
        }

        private void RewardPlayer()
        {
            Debug.Log($"Chest Encounter {_chestGoldAmount}");
            var playerLevel = _playerData.playerLevel;
            _chestGoldAmount = GenerateGoldReward(playerLevel);
            _playerData.AddGold(_chestGoldAmount);
        }
    }

    public interface IEncounter
    {
        public void InitPlayerData(PlayerData playerData);
    }
}