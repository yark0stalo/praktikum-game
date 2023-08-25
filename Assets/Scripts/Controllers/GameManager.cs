using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private ObstaclesController _obstacleContoller;
    [SerializeField]
    private CollectablesController _collectablesContoller;
    [SerializeField]
    private TextMeshProUGUI _startText;
    [SerializeField]
    private TextMeshProUGUI _points;

    private bool _isStarted = false;

    private void Start(){
        _player.onCollectableCollide += OnCollectableCollide;
        _player.onObstacleCollide += OnObstacleCollide;
    }

    private void Update(){
        if (!_isStarted){
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButton(0)){
                InitializeGame();
            }
        }
    }

    private void InitializeGame(){
        _isStarted = true;
        _player.Show();
        _startText.gameObject.SetActive(false);
        _obstacleContoller.StartSpawn();
        _collectablesContoller.StartSpawn();
    }

    private void StopGame(){
        _player.Hide();
        _obstacleContoller.StopSpawn();
        _collectablesContoller.StopSpawn();
        _startText.gameObject.SetActive(true);
        _points.text = "0";
        _isStarted = false;
    }

    private void OnCollectableCollide()
    {
        _points.text = (int.Parse(_points.text) + 1).ToString();
    }
    
    private void OnObstacleCollide()
    {
        StopGame();
    }

}
