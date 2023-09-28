using _Scripts.Data;
using UnityEngine;

namespace _Scripts
{
    public class DropSystem : MonoBehaviour
    {
        [SerializeField] private ItemGenerator itemGenerator;
        [SerializeField] private Character character;
        
        
        public void DropItem()
        {
            var itemDrop = itemGenerator.GenerateRandomItem(character.charData.level);
            //Todo add item to char
           // character.
        }


    }
}