using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class MovePlayer : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string SpeedParameterName = "Speed";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private CapsuleCollider2D _collider;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isJumping = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector2 velocity = new Vector2(Input.GetAxis(Horizontal) * _speed, _rigidbody.velocity.y);

        if (velocity.x != 0.0f)
        {
            _rigidbody.velocity = velocity;
            _animator.SetFloat(SpeedParameterName, _speed);
        }
        else
        {
            _animator.SetFloat(SpeedParameterName, 0.0f);
        }
        
        FlipPlayer();
    }

    private void FlipPlayer()
    {
        if (_rigidbody.velocity.x != 0)
        {
            _spriteRenderer.flipX = _rigidbody.velocity.x > 0 ? false : true;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _isJumping = false;
        }
    }
}
