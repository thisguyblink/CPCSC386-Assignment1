using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement2D : MonoBehaviour
{
    private float _moveSpeed = 7f;
    [SerializeField] private float _moveDelay = 0.2f; // delay in seconds

    private Vector3 _moveInput = Vector2.zero;
    private float _moveTimer = 0f;

    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;

    [SerializeField] public string direction = "idle";
    [SerializeField] private Transform upOffset;
    [SerializeField] private Transform downOffset;
    [SerializeField] private Transform leftOffset;
    [SerializeField] private Transform rightOffset;

    private SpriteRenderer sr;

    [SerializeField] private GameObject rayPrefab;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null && idleSprite != null)
        {
            sr.sprite = idleSprite;
        }
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();

        // Reset timer whenever new input is received
        if (_moveInput.magnitude > 0)
            _moveTimer = Time.time + _moveDelay;
    }

    public void OnAttack(InputValue value)
    {
        if (!value.isPressed) return; // only fire on button press

        Vector3 spawnPos = transform.position; // default to player position

        switch(direction)
        {
            case "up": spawnPos = upOffset.position; break;
            case "down": spawnPos = downOffset.position; break;
            case "left": spawnPos = leftOffset.position; break;
            case "right": spawnPos = rightOffset.position; break;
        }

        GameObject bullet = Instantiate(rayPrefab, spawnPos, Quaternion.identity);
        bullet.GetComponent<RayBehavior>().playerMovement = this;
    }

    void Update()
    {
        // Only move if the delay timer has passed
        if (Time.time >= _moveTimer)
        {
            transform.position += _moveInput * _moveSpeed * Time.deltaTime;
        }

        // Change sprite based on input
        if (_moveInput.y > 0.1f && upSprite)
        {
            sr.sprite = upSprite;
            direction = "up";
        }
        else if (_moveInput.y < -0.1f && downSprite)
        {
            sr.sprite = downSprite;
            direction = "down";
        }
        else if (_moveInput.x < -0.1f && leftSprite)
        {
            sr.sprite = leftSprite;
            direction = "left";
        }
        else if (_moveInput.x > 0.1f && rightSprite)
        {
            sr.sprite = rightSprite;
            direction = "right";
        }
    }

}
