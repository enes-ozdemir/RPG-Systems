using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class StatusBar : MonoBehaviour
    {
        [SerializeField] private Image mainBar;
        [SerializeField] private Color barColor;
        [SerializeField] private TextMeshProUGUI barText;

        private void OnValidate()
        {
            mainBar.color = barColor;
        }

        public void SetAmount(int currentAmount, int maxAmount)
        {
            mainBar.fillAmount = (float)currentAmount / maxAmount;
            barText.text = $"{currentAmount} / {maxAmount}";
        }
    }
}