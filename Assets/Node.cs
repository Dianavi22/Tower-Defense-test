using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startColor;
    private GameObject turret;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("X");
            return;
        }
        GameObject turretToBuimd = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuimd, transform.position + positionOffset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
