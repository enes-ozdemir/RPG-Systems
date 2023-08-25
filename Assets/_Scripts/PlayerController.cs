using CharacterCreator2D;
using UnityEngine;

namespace _Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private Animator _animator;
        private CharacterViewer _characterViewer;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterViewer = GetComponent<CharacterViewer>();
        }
    }
}