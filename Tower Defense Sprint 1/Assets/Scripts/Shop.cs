using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint slowTurret;
    public TurretBluePrint poisonTurret;
    public TurretBluePrint moneyTurret;

    public Sprite OffSprite;
    public Sprite OnSprite;
    public UnityEngine.UI.Button but;



    public void refreshButton() {
        but.image.sprite = OnSprite;
    }

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
                anEnemy.takeDamage(70);
            }
            InvokeRepeating("refreshButton", 50f, 50f);
        }

        
    }





    public void purchaseTree()
    {
        Debug.Log("Plant the tree.");
        BuildManager.instance.SelectTurretToBuild(moneyTurret);
    }
    public void purchaseTurret1()
    {
        Debug.Log("Place the turret.");
        BuildManager.instance.SelectTurretToBuild(standardTurret);
    }
    public void purchaseTurret2()
    {
        Debug.Log("Place the turret.");
        BuildManager.instance.SelectTurretToBuild(missileLauncher);
    }
    public void purchaseTurret3()
    {
        Debug.Log("Place the turret.");
        BuildManager.instance.SelectTurretToBuild(slowTurret);
    }
    public void purchaseTurret4()
    {
        Debug.Log("Place the turret.");
        BuildManager.instance.SelectTurretToBuild(poisonTurret);
    }

    public void Update () {
       
        if (Input.GetKeyDown ("1")) {
            Debug.Log ("selected default tower");

            BuildManager.instance.SelectTurretToBuild (standardTurret);
        }

        if (Input.GetKeyDown ("2")) {

            Debug.Log ("selected second tower");

            BuildManager.instance.SelectTurretToBuild (missileLauncher);
        }

        if (Input.GetKeyDown ("3")) {

            Debug.Log ("selected third tower");

            BuildManager.instance.SelectTurretToBuild (slowTurret);

        }
        if (Input.GetKeyDown ("4")) {

            Debug.Log ("selected fourth tower");

            BuildManager.instance.SelectTurretToBuild (poisonTurret);

        }
        if (Input.GetKeyDown("5"))
        {

            Debug.Log("selected fifth tower");

            BuildManager.instance.SelectTurretToBuild(moneyTurret);

        }
    }
}