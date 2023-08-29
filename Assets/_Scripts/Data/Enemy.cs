using System;
using System.Threading.Tasks;
using _Scripts.TurnSystem;
using UnityEngine;

namespace _Scripts.Data
{
    public class Enemy : Character
    {
       // [SerializeField] private EnemyAIManager _enemyAIManager;
        [SerializeField] private TurnManager turnManager;
        
        private void Awake()
        {
        //    _enemyAIManager=GetComponent<EnemyAIManager>();
        }
        
        public async Task Attack()
        {
            
         //   await _enemyAIManager.Attack();
        }
    }
}