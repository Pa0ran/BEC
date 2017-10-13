using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
	public Sprite sprite;
	public string description;

	public string GetDesc() {
		return description;
	}
	public Sprite GetSprite() {
		return sprite;
	}

}

