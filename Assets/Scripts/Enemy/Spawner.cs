using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastWave;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<float,float> EnemyCountChange;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave==null)
        {
            return;
        }

        _timeAfterLastWave += Time.deltaTime;

        if (_timeAfterLastWave >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastWave = 0;
            EnemyCountChange?.Invoke(_spawned,_currentWave.Count);
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber+1)
            {
                AllEnemySpawned?.Invoke();
            }
            // Здесь вставить метод который выводит панель победы
            _currentWave = null;
        }
        
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template,_spawnPoint.position,_spawnPoint.rotation,_spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDie;
    }

    private void SetWave(int Index)
    {
        _currentWave = _waves[Index];
        EnemyCountChange?.Invoke(0, 1);
    }

    public void OnEnemyDie(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDie;
        _player.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public  float Delay;
    public  int Count;
}