using UnityEngine;

public class Room2Manager : MonoBehaviour
{
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;
    [SerializeField] private GameObject _player;
    [SerializeField] private Timer _time;
    //audio
    [SerializeField] private AudioSource _audioS;
    [SerializeField] private AudioClip clip;

    private float time = 300f;

    void Start()
    {
        _audioS.clip = clip;
        _audioS.Play();
    }

    void Update()
    {
        Vector3 pos = _player.transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        _player.transform.position = pos;
    }
}
