using UnityEngine;
using UnityEngine.UI;

public class ConstructionAreaUI : MonoBehaviour
{
    [SerializeField] private GameObject constructionArea = null;

    [Header("Construction Buttons")]
    [SerializeField] private Button upgradeArrow;

    private ConstructionArea cArea = null;

    private void Start()
    {
        cArea = constructionArea.GetComponent<ConstructionArea>();

        transform.position = Camera.main.WorldToScreenPoint(constructionArea.transform.position);
    }

    public void SelectTower()
    {
        switch (cArea.WhatItIs())
        {
            case "ConstructionArea":
                Debug.Log("It is a construction Area");
                upgradeArrow.enabled = true;
                break;
            default:
                break;
        }
    }

    public void Upgrade()
    {
        Debug.Log("<color = puple>TODO:</color> Verify if has money to upgrade the tower!");
        cArea.Upgrade();
    }

    public void UpgradeArrow()
    {
        Debug.Log("<color = puple>TODO:</color> Verify if has money to buy this tower!");
        cArea.SetToArrow();
    }
}
