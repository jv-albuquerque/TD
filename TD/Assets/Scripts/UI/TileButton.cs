using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileButton : MonoBehaviour
{
    [SerializeField] private ConstructionArea tile = null;
    [SerializeField] private GameObject tower = null;

    private StatusController resource = null;
    private Color originalColor;

    //todo: try to put this in the editor.
    //when a select one, the other is automatic unselected
    public bool towerSpawn = true;
    public bool sell = false;
    public bool upgrade = false;

    [SerializeField] private Sprite imgUpgrade1 = null;
    [SerializeField] private Sprite imgUpgrade2 = null;

    private void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
        resource = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatusController>();

        if (upgrade)
            GetComponent<SpriteRenderer>().sprite = imgUpgrade1;
        gameObject.SetActive(false);
    }

    public void Action()
    {
        if (towerSpawn)
            SpawnTower();
        else if (upgrade)
            Upgrade();
        else
            Sell();
    }

    public bool canBuy()
    {
        if (towerSpawn && tower.GetComponent<TowerUpgrade>().Cost < resource.Money)
            return true;
        return false;
    }

    public bool SetGrey
    {
        set
        {
            if (value)
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            else
                GetComponent<SpriteRenderer>().color = originalColor;
        }
    }

    private void SpawnTower()
    {
        tile.SpawnTower(tower);
    }

    private void Upgrade()
    {
        tile.Upgrade();
    }

    public void SetUpgradeImage()
    {
        GetComponent<SpriteRenderer>().sprite = imgUpgrade2;
    }

    private void Sell()
    {
        tile.SellTower();
    }
}
