using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    public GameObject[] turretPrefab;

    private int currentTurretType;
    private AudioSource audioSource;
    private GameObject turretNeedToSpawn;

    private bool isTouchDown;

    private float timer;

    public void BuildTurret()
    {
        if (transform.childCount==0)//build no more than one turret at the same place
        {
            currentTurretType = BuildController.currentTurret;
            switch (currentTurretType)
            {
                case 0:
                    Debug.Log("current type not specified!");
                    break;
                case 1:
                    if (BuildController.goldLeft >= 100)//gold check
                    {
                        turretNeedToSpawn = Instantiate(turretPrefab[0], transform.position, Quaternion.identity);
                        turretNeedToSpawn.transform.SetParent(transform);
                        turretNeedToSpawn.GetComponent<RectTransform>().sizeDelta = new Vector2(289.8f, 240f);
                        isTouchDown = false;
                        BuildController.goldLeft -= 100;
                        audioSource.Play();
                    }
                    else
                    {
                        Debug.Log("Not Enough Gold");
                    }
                    break;
                case 2:
                    if (BuildController.goldLeft >= 150)//gold check
                    {
                        turretNeedToSpawn = Instantiate(turretPrefab[1], transform.position, Quaternion.identity);
                        turretNeedToSpawn.transform.SetParent(transform);
                        turretNeedToSpawn.GetComponent<RectTransform>().sizeDelta = new Vector2(289.8f, 240f);
                        isTouchDown = false;
                        BuildController.goldLeft -= 150;
                        audioSource.Play();
                    }
                    else
                    {
                        Debug.Log("Not Enough Gold");
                    }
                    break;
                default:
                    Debug.Log("Unexpected Error!");
                    return;
            }
        }
        
    }

    public void DestroyTurret()
    {
        if (isTouchDown == true && timer > 2 && transform.childCount > 0)
        {
            if (currentTurretType == 1)
            {
                BuildController.goldLeft += 33;
            }
            else if (currentTurretType == 2)
            {
                BuildController.goldLeft += 50;
            }
            Debug.Log("OnDestroy");
            Destroy(transform.GetChild(0).gameObject);
        }
    }



    public void OnPointerDown()
    {
        isTouchDown = true;
        timer = 0;
    }

    public void OnPointerUp()
    {
        isTouchDown = false;
    }


    void Start()
    {
        audioSource = transform.parent.GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        DestroyTurret();
    }
}




