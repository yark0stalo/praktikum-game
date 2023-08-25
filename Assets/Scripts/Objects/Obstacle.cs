using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float _frequency = 1f;
    [SerializeField]
    private float _amplitude = 0.5f;
    [SerializeField]
    private float _speed;

    private Vector2 posOffset = new Vector2();
    private Vector2 tempPos = new Vector2();

    private void Start(){
        posOffset = transform.position;
    }

    private void Update(){
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * _frequency) * _amplitude;
        //posOffset.x -= _speed * Time.deltaTime;
        transform.position = tempPos;
    }
    
}
