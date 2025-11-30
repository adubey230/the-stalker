using UnityEngine;

public class ObjectOutline : MonoBehaviour
{
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] private Sprite originalSprite;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private LightController _lightController;

    private void Start()
    {
        _spriteRenderer = GetComponentInParent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _lightController = FindFirstObjectByType<LightController>();
        
    }
    private void SetOutlineActive()
    {
        _spriteRenderer.sprite = outlineSprite;
    }

    private void SetOutlineInactive()
    {
        
        _spriteRenderer.sprite = originalSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetOutlineActive();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetOutlineInactive();
        }
    }

    public void SetDisable()
    {
        this.enabled = false;
        if (_collider != null)
        {
            _collider.enabled = false;
        }
    }

    private void Update()
    {
        if (_lightController == null)
        {
            this.enabled = false;
            return;
        }

        if (_lightController.GetIsOffPerm() && gameObject.tag == "LightSwitch")
        {
            _collider.enabled = true;
        }
        else if (!_lightController.GetIsOffPerm() && gameObject.tag == "LightSwitch")
        {
            _collider.enabled = false;
        }
    }
}
