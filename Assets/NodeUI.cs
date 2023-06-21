using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [SerializeField] GameObject ui;
    private Node target;
    public Text upgradeCost;
    public Text sellAmound;
    public Button upgradeButton;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretBlueprint.upgradeCost + "$";
            upgradeButton.interactable = true;

        }
        else
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "<i>Done</i>";

        }
        sellAmound.text = "+" + target.turretBlueprint.GetSellAmount() + "$";
        ui.SetActive(true);
    }
  public void Hide()
    {
        ui.SetActive(false);
    }

    public void UpgradeTurret()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
