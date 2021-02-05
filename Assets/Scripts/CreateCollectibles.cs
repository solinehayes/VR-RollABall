using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCollectibles : MonoBehaviour
{
    public int numberOfPositiveCollectibles = 5;
    public int numberOfNegativeCollectibles = 5;

    public Transform positiveCollectiblePrefab;
    public Transform negativeCollectiblePrefab;

    Vector3 randomPosition(){
        float x = Random.Range(-15,15);
        float z = Random.Range(-15,15);
        return new Vector3(x,0.5f,z);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0 ; i< numberOfPositiveCollectibles ; i++){
            Instantiate(positiveCollectiblePrefab, randomPosition(), Quaternion.identity);
        }
        for(int i=0 ; i< numberOfNegativeCollectibles ; i++){
            Instantiate(negativeCollectiblePrefab, randomPosition(), Quaternion.identity);        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}