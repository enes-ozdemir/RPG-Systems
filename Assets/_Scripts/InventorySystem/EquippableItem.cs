using CharacterCreator2D;
using UnityEngine;

namespace _Scripts.InventorySystem
{
    [CreateAssetMenu]
    public class EquippableItem : Item, IEquippable
    {
       // [SerializeField] public PlayerAnimationManager.AnimState animName;
        [SerializeField] public EquipmentType equipmentType;
        [SerializeField] private int level;
        [SerializeField] public ParticleSystem particleSystem;
        [SerializeField] public Part part;

        public void Interact(Animator animator)
        {
            Debug.Log("Interact");
        }

        // public void InstantiateEquippableItem(Transform transform, Animator animator)
        // {
        //     Instantiate(itemPrefab.gameObject, transform);
        //     if (!holdingAnim.Equals(""))
        //     {
        //         animator.SetBool(holdingAnim, true);
        //     }
        //
        //     itemPrefab.gameObject.transform.position = coordinates;
        //     itemPrefab.gameObject.transform.rotation = rotation.normalized;
        // }
    }

    public interface IEquippable
    {
        void Interact(Animator animator);
    }
}