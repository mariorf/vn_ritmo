using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //Quant de temps porta instanciada
    double timeInstantiated;
    
    //En que moment la nota s'ha de pulsar;
    public float assignedTime;
    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }


    void Update()
    {
        //Resta del moment de la canço en el que se va instanciar menos la posició actual de la canço
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        
        //Esto calcula el temps de vida de la nota, esta linea asegura que el resultat vaja entre 1 o 0
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));

        
        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            //Mou la nota desde la posició d'inici hasta a posició de despawn
            transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.Instance.noteSpawnY, Vector3.up * SongManager.Instance.noteDespawnY, t); 
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}