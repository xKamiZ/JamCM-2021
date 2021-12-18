using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVida : MonoBehaviour
{
    public Image COrazon;
    public int CantCorazones;
    public RectTransform PosicionPrimerCorazon;
    public Canvas MyCanvas;
    public int OffSet;
    public GameObject Boss;
    
    
    void Start()
    {
        Transform PosCorazon = PosicionPrimerCorazon;
        for (int i=0;i<CantCorazones;i++)
        {
            Image NewCorazon = Instantiate(COrazon, PosCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform;
            PosCorazon.position = new Vector2(PosCorazon.position.x + OffSet, PosCorazon.position.y);
        }
    }

   
    void Update()
    {
        Muerte();
    }
    void Muerte()
    {
        if (CantCorazones <=0)
        {
            Destroy(gameObject);
            Destroy(COrazon);
            Boss.SetActive(false);          
        }
        else
        {
            Boss.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Destroy(MyCanvas.transform.GetChild(CantCorazones + 1).gameObject);
            CantCorazones -= 1;
            Destroy(collision.gameObject);
            Debug.Log("Menos Vida");
        }
    }
}
