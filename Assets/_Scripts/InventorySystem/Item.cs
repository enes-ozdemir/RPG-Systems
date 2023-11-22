using System;
using UnityEditor;
using UnityEngine;

namespace _Scripts.InventorySystem
{
    [CreateAssetMenu] [Serializable]
    public class Item : ScriptableObject
    {
        [SerializeField] public string id;
        [Range(1,16)]
        public int maximumStacks = 1;
        public string ID
        {
            get { return id; }
        }
        public string itemName;
        public Sprite icon;
        public int value;

        private void OnValidate()
        {
            //Todo might want to delete it
            string path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(path);
        }

        public virtual Item GetCopy()
        {
            return this;
        }  
        public virtual void Destroy()
        {
        
        }

        public void UseItem()
        {
            Debug.Log("Item used");
        }
        
    }
}
