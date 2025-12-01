using UnityEngine;

public class BotDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayerSolved()
    {
        _animator.SetBool("player", true);
    }
}