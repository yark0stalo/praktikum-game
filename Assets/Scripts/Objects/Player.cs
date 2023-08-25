using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _strength;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxVelocity;
    [SerializeField]
    private Vector2 _startPosition;

    private bool _isPlaying;

    public Action onObstacleCollide;
    public Action onCollectableCollide;
    
    private void Update(){
        if(_isPlaying){
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                _rigidbody.velocity += new Vector2(0, _strength * Time.deltaTime);
            }
        }
            _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, _maxVelocity);
            transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == 7){
            onCollectableCollide?.Invoke();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.layer == 8){
            onObstacleCollide?.Invoke();
        }
    }

    public void Show(){
        _rigidbody.gravityScale = 1;
        gameObject.SetActive(true);
        _isPlaying = true;
    }
    public void Hide(){
        _isPlaying = false;
        gameObject.SetActive(false);
        transform.position = _startPosition;
        _rigidbody.gravityScale = 0;
    }
}
