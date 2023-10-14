using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHearts : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField]
    private int nHearts = 3;
    public int NHearts{
        get { return this.nHearts; }
    }

    [SerializeField]
    private bool isAlive;
    public bool IsAlive{
        get { return this.isAlive; }
    }

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(nHearts == 0) {
            isAlive = false;
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Asteroid") {
            nHearts--;
        }
    }
}
