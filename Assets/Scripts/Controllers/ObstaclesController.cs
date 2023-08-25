using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField]
    private Obstacle _obstaclePrefab;
    [SerializeField]
    private float _xOffset;
    [SerializeField]
    private Vector2 _spawnCooldown;
    [SerializeField]
    private Player _player;

    private List<Obstacle> _obstacles;

    private bool _isPlaying = false;

    private void Start(){
        _obstacles = new List<Obstacle>();
    }

    private void CreateObstacle(){
        var obstacle = Instantiate(_obstaclePrefab);
        var newY = Random.Range(-3.5f, 3.5f);
        obstacle.transform.position = new Vector2(_xOffset + _player.transform.position.x, newY);
        _obstacles.Add(obstacle);
    }

    public void StartSpawn(){
        _isPlaying = true;
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles(){
        while(_isPlaying){
            yield return new WaitForSeconds(Random.Range(_spawnCooldown.x, _spawnCooldown.y));
            CreateObstacle();
        }
    }

    public void StopSpawn(){
        _isPlaying = false;
        StopAllCoroutines();
        foreach (var obstacle in _obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        _obstacles.Clear();
    }
}
