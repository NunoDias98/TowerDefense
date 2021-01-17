using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelection : MonoBehaviour
{
    public GameObject UI;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private TurretPlacement target;

    public void setTarget(TurretPlacement targetRecieved)
    {
        target = targetRecieved;

        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost.ToString() + "$";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Maxed";
            upgradeButton.interactable = false;
        }

        sellAmount.text = target.turretBlueprint.GetSellAmout() + "$";

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectTurretSpot();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectTurretSpot();

    }
}
