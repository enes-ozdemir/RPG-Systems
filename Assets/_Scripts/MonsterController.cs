using UnityEngine;

namespace _Scripts
{
    public class MonsterController : MonoBehaviour
    {
        public Monster monsterData; // Reference to the monster's Scriptable Object

        public void Start()
        {
            // Initialize the monster using monsterData
        }

        public void UseAbility(int index)
        {
            // Use an ability from monsterData.abilities[index]
        }
    }
}