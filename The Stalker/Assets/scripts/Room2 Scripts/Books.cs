using UnityEngine;

public class Books : MonoBehaviour
{
    [SerializeField] private Sprite completed;
    [SerializeField] private BotDoor _door;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Player player;
    [SerializeField] private GameObject bookshelf;
    [SerializeField] private GameObject spoon;
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject collider;


    public void Solved()
    {
        _sprite.sprite = completed;
        player.SetUiOpenFalse();
        bookshelf.SetActive(false);
        _door.PlayerSolved();
        spoon.SetActive(false);
        light.SetActive(true);
        collider.SetActive(true);
    }
}
