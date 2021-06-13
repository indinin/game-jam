using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeout : MonoBehaviour
{
    public GameObject obj;
    Color color;
    Material mat;
    public float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        if(obj == null)
        {
            obj = this.gameObject;
        }
        mat = obj.GetComponent<MeshRenderer>().material;
        print("starting alpha: " + color.a);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mat.SetFloat("_Metallic", mat.GetFloat("_Metallic") - 0.1f);
            print(mat.GetFloat("_Metallic"));

            if (mat.GetFloat("_Metallic") <= 0)
            {
                Destroy(this.gameObject);
            }

        }
        */
        mat.SetFloat("_Metallic", mat.GetFloat("_Metallic") - (1/fadeTime) * Time.deltaTime);

        if (mat.GetFloat("_Metallic") < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
