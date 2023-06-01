using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _newtWaveButton;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawn;
        _newtWaveButton.onClick.AddListener(OnNewxtWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawn;
        _newtWaveButton.onClick.RemoveListener(OnNewxtWaveButtonClick);
    }

    public void OnAllEnemySpawn()
    {
        _newtWaveButton.gameObject.SetActive(true);
    }

    public void OnNewxtWaveButtonClick()
    {
        _spawner.NextWave();
        _newtWaveButton.gameObject.SetActive(false);
    }
}
