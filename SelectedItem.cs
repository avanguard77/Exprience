using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    [SerializeField] private GunSpawner gun;
    [SerializeField] private GameObject selectedItem;

    private void Start()
    {
        Player.Instance.OnSlelectedItem += InstanceOnOnSlelectedItem;
    }

    private void InstanceOnOnSlelectedItem(object sender, Player.OnSlelectedItemEventArgs e)
    {
        if (e.Gun == gun)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void Show()
    {
        selectedItem.SetActive(true);
    }

    public void Hide()
    {
        selectedItem.SetActive(false);
    }
}