using CharacterCreator2D;

namespace _Scripts.Data
{
    public class Enemy : Character
    {
        private CharacterViewer _characterViewer;

        private void Awake()
        {
            _characterViewer = GetComponent<CharacterViewer>();
            _characterViewer.SaveToJSON("Assets/Enemy.json");
        }
    }
}