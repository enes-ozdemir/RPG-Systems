using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using _Scripts.Data;

namespace _Scripts.SaveSystem
{
    public class SaveManager : MonoBehaviour
    {
        private const string SavePath = "/Player.dat";
        [SerializeField] private Player player;

        public void Save()
        {
            var file = new FileStream(Application.persistentDataPath + SavePath, FileMode.OpenOrCreate);
            var formatter = new BinaryFormatter();
            SerializeData(formatter, file);
            file.Close();
        }

        public void Load()
        {
            var file = new FileStream(Application.persistentDataPath + SavePath, FileMode.Open);
            var formatter = new BinaryFormatter();
            DeSerializeData(formatter, file);
            file.Close();
        }

        private void SerializeData(BinaryFormatter formatter, FileStream file)
        {
            try
            {
                formatter.Serialize(file, player.charData);
            }
            catch (SerializationException e)
            {
                Debug.LogError($"Serialization Error : {e.Message}");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        private void DeSerializeData(BinaryFormatter formatter, FileStream file)
        {
            try
            {
                player.charData = (CharData)formatter.Deserialize(file);
            }
            catch (SerializationException e)
            {
                Debug.LogError($"Serialization Error : {e.Message}");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}

