using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int Max_X, Max_Y;
    public GameObject Node;
    public GameObject Canvas;


    
    // Start is called before the first frame update
    void Start()
    {
        Node.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.safeArea.width/Max_X, Screen.safeArea.height/Max_Y);
        

        for (int x = 0; x < Max_X; x++)
        {
            for (int y = 0; y < Max_Y; y++)
            {
                GameObject temp = Instantiate(Node, new Vector2(x* Screen.safeArea.width / Max_X, y*Screen.safeArea.height / Max_Y), quaternion.identity);
                temp.gameObject.transform.SetParent(Canvas.transform);

            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
