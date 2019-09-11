using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField] private int maxUpgrade = 3;

    [SerializeField] private int[] cost = null;
    [SerializeField] private int[] damages = null;
    [SerializeField] private float[] attackRanges = null;
    [SerializeField] private float[] cooldownsToShoot = null;

    private int lvl = 0;
    private TowerShoot towerShoot;

    private void Start()
    {
        towerShoot = GetComponent<TowerShoot>();
        Upgrade();
    }

    public void Upgrade()
    {
        if (CanUpgrade)
        {
            towerShoot.Upgrade(damages[lvl], attackRanges[lvl], cooldownsToShoot[lvl]);
            lvl++;
        }
    }

    public bool CanUpgrade
    {
        get
        {
            return lvl < maxUpgrade;
        }
    }

    public int Cost
    {
        get
        {
            return cost[lvl];
        }
    }

    public int SellCost
    {
        get
        {
            return cost[lvl - 1];
        }
    }
}
