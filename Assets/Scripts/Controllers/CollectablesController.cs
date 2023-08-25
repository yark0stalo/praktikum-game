using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesController : MonoBehaviour
{
    [SerializeField]
    private Collectable _collectablePrefab;
    [SerializeField]
    private float _xOffset;
    [SerializeField]
    private Vector2 _spawnCooldown;
    [SerializeField]
    private Player _player;

    private List<Collectable> _collectables;

    private bool _isPlaying = false;

    private void Start(){
        _collectables = new List<Collectable>();
    }

    private void CreateCollectable(){
        var collectable = Instantiate(_collectablePrefab);
        var newY = Random.Range(-3.5f, 3.5f);
        collectable.transform.position = new Vector2(_xOffset + _player.transform.position.x, newY);
        _collectables.Add(collectable);
    }

    public void StartSpawn(){
        _isPlaying = true;
        StartCoroutine(SpawnCollectables());
    }

    private IEnumerator SpawnCollectables(){
        while(_isPlaying){
            yield return new WaitForSeconds(Random.Range(_spawnCooldown.x, _spawnCooldown.y));
            CreateCollectable();
        }
    }

    public void StopSpawn(){
        _isPlaying = false;
        StopAllCoroutines();
        foreach (var collectable in _collectables)
        {
            if (collectable.gameObject != null){
                Destroy(collectable.gameObject);
            }
        }
        _collectables.Clear();
    }
}
