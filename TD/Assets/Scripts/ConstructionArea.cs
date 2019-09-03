using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionArea : MonoBehaviour
{
    [Header("Tile Buttons")]
    [SerializeField] private GameObject Arrow = null;
    [SerializeField] private GameObject Rock = null;
    [SerializeField] private GameObject Mage = null;
    [SerializeField] private GameObject Defese = null;

    [Header("Tower Buttons")]
    [SerializeField] private GameObject upgrade = null;
    [SerializeField] private GameObject sell = null;

    private GameObject ActiveTower = null;

    private StatusController resource;

    private void Start()
    {
        resource = GameObject.FindGameObjectWithTag("GameController").GetComponent<StatusController>();
    }

    public void ActiveUI()
    {
        if (ActiveTower == null)
        {
            Arrow.SetActive(true);
            Rock.SetActive(true);
            Mage.SetActive(true);
            Defese.SetActive(true);

            TileButton tb = Arrow.GetComponent<TileButton>();
            if (tb.canBuy())
                tb.SetGrey = false;
            else
                tb.SetGrey = true;

            tb = Rock.GetComponent<TileButton>();
            if (tb.canBuy())
                tb.SetGrey = false;
            else
                tb.SetGrey = true;

            tb = Mage.GetComponent<TileButton>();
            if (tb.canBuy())
                tb.SetGrey = false;
            else
                tb.SetGrey = true;

            tb = Defese.GetComponent<TileButton>();
            if (tb.canBuy())
                tb.SetGrey = false;
            else
                tb.SetGrey = true;
        }
        else
        {
            upgrade.SetActive(true);
            sell.SetActive(true);

            TowerUpgrade tu = ActiveTower.GetComponent<TowerUpgrade>();
            if (tu.CanUpgrade && resource.Money >= tu.Cost)
                upgrade.GetComponent<TileButton>().SetGrey = false;
            else
                upgrade.GetComponent<TileButton>().SetGrey = true;
        }
    }

    public void DeactiveUI()
    {
        if (ActiveTower == null)
        {
            Arrow.SetActive(false);
            Rock.SetActive(false);
            Mage.SetActive(false);
            Defese.SetActive(false);
        }
        else
        {
            upgrade.SetActive(false);
            sell.SetActive(false);
        }
    }

    public void SpawnTower(GameObject tower)
    {
        TowerUpgrade tu = tower.GetComponent<TowerUpgrade>();

        if (tu.CanUpgrade && resource.Money >= tu.Cost)
        {
            ActiveTower = Instantiate(tower, transform.position, Quaternion.identity);
            tu = ActiveTower.GetComponent<TowerUpgrade>();
            resource.Money -= tu.Cost;
        }
        else
        {
            Debug.Log("Don't have money to do this");
        }
    }

    public void SellTower()
    {
        resource.Money += ActiveTower.GetComponent<TowerUpgrade>().SellCost / 2;
        GameObject.Destroy(ActiveTower);
        ActiveTower = null;
    }

    public void Upgrade()
    {
        TowerUpgrade tu = ActiveTower.GetComponent<TowerUpgrade>();
        if (tu.CanUpgrade && resource.Money >= tu.Cost)
        {
            resource.Money -= tu.Cost;
            tu.Upgrade();
            upgrade.GetComponent<TileButton>().SetUpgradeImage();
        }
        else
        {
            Debug.Log("Don't have money to do this");
        }
    }
}
