using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private Player _player;

    private void Update()
    {
        _moneyCount.text = _player.Money.ToString();
    }

}
