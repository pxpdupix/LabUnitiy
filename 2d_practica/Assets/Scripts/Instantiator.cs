using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour
{
    public GameObject prefabtoInstantiate;
    public Vector2 maxOffset;
    public float instantiateTime;
    private float _instantiateTimer;
	public int numAst = 1;

    void Start()
    {
        _instantiateTimer = instantiateTime;
		Time.timeScale = 1;
    }
	void InstatiateAst (){
		for (int i = 0; i < numAst; i++) {
			float scale = Random.Range (0f, 3.0f);
			Vector2 position = new Vector2 (Random.Range (-maxOffset.x, maxOffset.x), 7);
			//Quaternion rotation = Quaternion.Euler(0, 0, 0);
			GameObject obj = (GameObject)Instantiate (prefabtoInstantiate, position, Quaternion.identity);
			obj.transform.SetParent (this.transform);
			obj.transform.localScale += new Vector3 (scale, scale, 0);
			_instantiateTimer = instantiateTime;
			Destroy (obj, 2);
		}
	}
    void Update()
    {
        _instantiateTimer -= Time.deltaTime;
		//Tisme.timeScale += 0.001f;
        if(_instantiateTimer <= 0)
        {
			numAst = (int) (Random.Range (1, 3));
			InstatiateAst ();
			if (instantiateTime >= 1) {
				instantiateTime -= 0.05f;

			}
			_instantiateTimer = instantiateTime;
        }
		//Time.deltaTime;
    }
}
