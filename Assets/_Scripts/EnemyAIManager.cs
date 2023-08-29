using System.Threading.Tasks;
using _Scripts.Data;
using DG.Tweening;
using UnityEngine;

namespace _Scripts
{
   /*  public class EnemyAIManager : MonoBehaviour
    {
        private AttackManager _attackManager = new AttackManager();
        
        private async Task Attack(Character target, AttackType attackType,Vector3 attackPos,Vector3 originalPos)
        {
            Debug.Log($"Enemy should move to {attackPos}");
            transform.DOMove(attackPos, 0.3f);
            await Task.Delay(300);
            await _attackManager.PerformAttack(attackType, this, target);
            await Task.Delay(500);
            transform.DOMove(originalPos, 0.3f);
            await Task.Delay(300);
        }
    } */
}