using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax; 
}

public class PlayerController : MonoBehaviour
{
    public Mover moverComponent;
    public float speed;
    public Boundary boundary;
    [SerializeField] private List<Shooter> shooters;
    [SerializeField] private PlayerConfig config;
    [SerializeField] private SpecialsController specialsController;
    private int powerLevel;
    private int unlockedCannons = 1;
    
    public delegate void PowerChanged(int currentPower, int totalPower);

    public event PowerChanged OnPowerChanged;







    // Start is called before the first frame update
    void Start()
    {
        moverComponent.speed = speed;
        InputProvider.OnHasShoot += OnHasShoot;
        InputProvider.OnDirection += OnDirection;

    }

    // Update is called once per frame

    private void OnHasShoot()
    {
        //var shoot = Instantiate(shootPrefab, shootOrigin, false);
        
        //Instantiate(shootPrefab, shootOrigin.position, shootOrigin.rotation);

        for (int i = 0; i < unlockedCannons; i++)
        {
            var shooter = shooters[i];
            shooter.DoShoot();
        }
    
      
    }

    private void OnDirection(Vector3 direction)
    {
        moverComponent.direction = direction;
    }



    void Update()
    {
      //  Vector3 direction = new Vector3(Input.GetAxis("Horizontal")  , Input.GetAxis("Vertical"),transform.position.z);
       // moverComponent.direction = direction;
        float x = Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax); 
        float y = Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax); 
        transform.position = new Vector3(x,y);
        
       /* if ( Input.GetButtonDown("Shoot"))
        {
            Instantiate(shootPrefab, shootOrigin, false);
        }*/

       /* if ( Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.F))
        {
            
        }*/
    }


    public void AddToPowerLevel(int powerToAdd)
    {
        powerLevel += powerToAdd;
        var powerConfig =  config.GetPowerConfig(powerLevel);
        unlockedCannons = powerConfig.cannonAmount;
        Debug.LogFormat("Player Has {0} cannon unlocked. Current power level: {1}",  unlockedCannons, powerLevel);

        if (OnPowerChanged != null)
        {
            OnPowerChanged.Invoke(powerLevel, config.GetMaxPowerLevel());
        }
    }


    public void OnPlayerDie()
    {
        GameController.Instance.OnPlayerDie();
        SceneManager.LoadScene("Perder");
        //Destroy(gameObject);
    }



    public void UnlockSpecial(PickUpConfig pickUpConfig)
    {
        Debug.LogFormat("UnlockSpecial pickup type {0}", pickUpConfig.type);
        specialsController.UnlockSpecial(pickUpConfig);
    }
    
    
    public  int GetCurrentPowerLevel()
    {
        return powerLevel;
    }
    
    public  int GetMaxPowerLevel()
    {
        return config.GetMaxPowerLevel();
    }


}
