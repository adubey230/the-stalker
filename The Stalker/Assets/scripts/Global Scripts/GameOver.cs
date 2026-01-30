using UnityEngine;


public class GameOver: MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private Transition _transition;

    public void ActivateGameOver ()
    {
        _transition.FadeOut();
        _gameOver.SetActive(true);
    }
}
