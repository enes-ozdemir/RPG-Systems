namespace _Scripts.Data
{
    public class Enemy : Character
    {
        private void Awake()
        {
            characterViewer.SaveToJSON("Assets/Enemy.json");
        }

        public void SetCharInformation(CharData enemyData)
        {
            charData = enemyData;
        }
    }
}