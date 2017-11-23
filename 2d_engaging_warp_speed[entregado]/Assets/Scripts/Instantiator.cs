using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Instantiator : MonoBehaviour
{
    public List<GameObject> prefabtoInstantiate;
    public Vector2 maxOffset;
    public float instantiateTime;
    private float _instantiateTimer;
	private int numAst = 1;
	public float currentSpawnTime = 0;
	public float spawnInterval = 2.5f;
	public float bigCountdown = 8f; // 120 seconds is 2 minutes
	public float currentBigTime = 0f;

//	void Awake(){
//		if (spritesList.Count == 0)
//		{
//			LoadSprites();
//		}
//	}
    void Start()
    {
        _instantiateTimer = instantiateTime;

		//Time.timeScale = 1;
    }
	private IEnumerator InstatiateAst (float secs){
		for (int i = 0; i <= numAst; i++) {
			float scale = Random.Range (0.7f, 1.5f);
			Vector2 position = new Vector2 (Random.Range (-maxOffset.x, maxOffset.x), 7);
			//Quaternion rotation = Quaternion.Euler(0, 0, 0);
			int rng = Random.Range(0,prefabtoInstantiate.Count);
			GameObject obj = (GameObject)Instantiate (prefabtoInstantiate[rng], position, Quaternion.identity);
			obj.transform.SetParent (this.transform);
			obj.transform.localScale += new Vector3 (scale, scale, 0);
			_instantiateTimer = instantiateTime;
			Destroy (obj, 3);
			yield return new WaitForSeconds (0.2f);
		}
	}
    void Update()
    {
		currentSpawnTime += Time.deltaTime;
		currentBigTime += Time.deltaTime;
        _instantiateTimer -= Time.deltaTime;
		if (currentSpawnTime >= spawnInterval) {
			numAst = (int) (Random.Range (1, 3));
			StartCoroutine (InstatiateAst (spawnInterval));
			currentSpawnTime = 0;
		}
		if (currentBigTime >= bigCountdown && spawnInterval > 1.0f) {
			numAst = (int) (Random.Range (1, 3));
			spawnInterval -= .2f;
			currentBigTime = 0;
		}
        if(_instantiateTimer <= 0)
        {
			

			if (instantiateTime >= 0.8f) {
				instantiateTime -= 0.06f;

			}
			_instantiateTimer = instantiateTime;
        }
    }
}
