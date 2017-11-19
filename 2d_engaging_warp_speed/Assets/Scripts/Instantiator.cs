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
	public int numAst = 1;
	public float currentSpawnTime = 0;

	public float bigCountdown = 120; // 120 seconds is 2 minutes
	public float currentBigTime = 0;

//	void Awake(){
//		if (spritesList.Count == 0)
//		{
//			LoadSprites();
//		}
//	}
    void Start()
    {
        _instantiateTimer = instantiateTime;
		StartCoroutine( InstatiateAst (_instantiateTimer));
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
			yield return new WaitForSeconds (secs);
		}
	}
    void Update()
    {
        _instantiateTimer -= Time.deltaTime;
        if(_instantiateTimer <= 0)
        {
			numAst = (int) (Random.Range (1, 3));
//			float s = Random.Range (0.8f, 1.0f);

			if (instantiateTime >= 0.8f) {
				instantiateTime -= 0.06f;

			}
			_instantiateTimer = instantiateTime;
        }
    }
//	[ContextMenu("Load Sprites")]
//	private void LoadSprites()
//	{
//		List<SpriteRenderer> spritesInObj = GetComponentsInChildren<SpriteRenderer>().ToList();
//		spritesList = spritesInObj.FindAll(t => spritesLayers == (spritesLayers | (1 << t.gameObject.layer)));
//	}
}
