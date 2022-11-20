using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeSpawner : MonoBehaviour
{

    [SerializeField]
    private RawImage polariodPrefab;

    public bool destroy;

    public float lifeNum;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lifeNum; i++) {
            var polaroid = Instantiate(polariodPrefab);
            polaroid.transform.SetParent(transform, false);
        }
        destroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(destroy) {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
            destroy = false;
        }
    }
}
