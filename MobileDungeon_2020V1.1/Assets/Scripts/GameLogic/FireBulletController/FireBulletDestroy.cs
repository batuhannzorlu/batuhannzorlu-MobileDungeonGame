using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletDestroy : MonoBehaviour
{
    float CurrentTime=0;
    void Update()
    {
        if (CurrentTime >= 3)
            Destroy(this.gameObject);
        CurrentTime += Time.deltaTime;
    }
}
