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
	private IEnumerator InstatiateAst (float secs){
		for (int i = 0; i <= numAst; i++) {
			float scale = Random.Range (0f, 3.0f);
			Vector2 position = new Vector2 (Random.Range (-maxOffset.x, maxOffset.x), 7);
			//Quaternion rotation = Quaternion.Euler(0, 0, 0);
			GameObject obj = (GameObject)Instantiate (prefabtoInstantiate, position, Quaternion.identity);
			obj.transform.SetParent (this.transform);
			obj.transform.localScale += new Vector3 (scale, scale, 0);
			_instantiateTimer = instantiateTime;
			Destroy (obj, 3);
			yield return new WaitForSeconds (secs);
		}
	}
    void Update()
    {
        _instantiateTimer -= Time.deltaTime;
        if(_instantiateTimer <= 0)
        {
			numAst = (int) (Random.Range (1, 3));
			float s = Random.Range (0.8f, 1.4f);
			StartCoroutine( InstatiateAst (s));
			if (instantiateTime >= 1) {
				instantiateTime -= 0.05f;

			}
			_instantiateTimer = instantiateTime;
        }
    }
}
