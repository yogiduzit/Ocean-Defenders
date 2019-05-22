using UnityEngine;

public class Shop : MonoBehaviour {

    //Prefabs for the turrets
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint slowTurret;
    public TurretBluePrint poisonTurret;
    public TurretBluePrint moneyTurret;

    //Help button sprite
    public Sprite OffSprite;
    public Sprite OnSprite;
    public UnityEngine.UI.Button but;

    //Check for if the button is clicked
    private bool reset = false;
    
    //Refreshes the button
    public void refreshButton() {
        but.image.sprite = OnSprite;
    }

    //On click function that damages all enemies then turns off the button for 50 seconds
    public void ChangeImage()
    {
        Debug.Log("Clicked");
        Debug.Log(OffSprite);
        if (but.image.sprite == OnSprite) {
            but.image.sprite = OffSprite;
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++) {
                 Enemy anEnemy = enemies[i].GetComponent<Enemy>();
                anEnemy.takeDamage(90);
            }
            if (reset == false) {
                reset = true;
                InvokeRepeating("refreshButton", 50f, 50f);
            }
        }
    }

    //Selects a tree to build
    public void purchaseTree()
    {
        BuildManager.instance.SelectTurretToBuild(moneyTurret);
    }
    //Selects turret one to build
    public void purchaseTurret1()
    {
        BuildManager.instance.SelectTurretToBuild(standardTurret);
    }
    //Selects turret two to build
    public void purchaseTurret2()
    {
        BuildManager.instance.SelectTurretToBuild(missileLauncher);
    }
    //Selects turret three to build
    public void purchaseTurret3()
    {
        BuildManager.instance.SelectTurretToBuild(slowTurret);
    }
    //Selects turret four to build
    public void purchaseTurret4()
    {
        BuildManager.instance.SelectTurretToBuild(poisonTurret);
    }

    //Additional keyboard selections
    public void Update () {
        if (Input.GetKeyDown ("1"))
        {
            BuildManager.instance.SelectTurretToBuild (standardTurret);
        }
        if (Input.GetKeyDown ("2"))
        {
            BuildManager.instance.SelectTurretToBuild (missileLauncher);
        }
        if (Input.GetKeyDown ("3"))
        {
            BuildManager.instance.SelectTurretToBuild (slowTurret);
        }
        if (Input.GetKeyDown ("4"))
        {
            BuildManager.instance.SelectTurretToBuild (poisonTurret);
        }
        if (Input.GetKeyDown("5"))
        {
            BuildManager.instance.SelectTurretToBuild(moneyTurret);
        }
    }
}