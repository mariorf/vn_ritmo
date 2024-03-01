using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager Instance;

    public GameObject ChicaGuay;

    public GameObject Yasuhiro;

    public GameObject Zagreus;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    
    public static SpriteManager getInstance()
    {
        return Instance;
    }

    public void setAllVisible(bool visible)
    {
        if (visible)
        {
            Yasuhiro.SetActive(true);
            ChicaGuay.SetActive(true);
            Zagreus.SetActive(true);
        }
        else
        {
            Yasuhiro.SetActive(false);
            ChicaGuay.SetActive(false);
            Zagreus.SetActive(false);
        }
    }
}
