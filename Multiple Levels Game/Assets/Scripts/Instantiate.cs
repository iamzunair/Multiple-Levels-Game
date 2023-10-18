using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {
	
	public int ufoSpeed;
	public float Timer = 2;
	public GameObject ufo;
	GameObject ufoClone;
	public Material[] materials = new Material[4];
	

	void Start () 
	{
		materials[0].color = Color.red;
        materials[1].color = Color.green;
        materials[2].color = Color.blue;
		materials[3].color = Color.yellow;

	}
	
	void Update()
{
    Timer -= Time.deltaTime;
    if (Timer <= 0f)
    {
        ufoClone = Instantiate(ufo, new Vector3(Random.Range(-1, 3), 0f, 2f), transform.rotation) as GameObject;
        Timer = 2f;

		ufoClone.GetComponent<Renderer>().material = materials[Random.Range(0,4)];
    }
}
}