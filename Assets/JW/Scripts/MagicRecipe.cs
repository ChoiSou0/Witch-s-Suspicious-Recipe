using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicRecipe", menuName = "Scriptable Object/MagicRecipe")]
public class MagicRecipe : ScriptableObject
{
	public int[] recipes = new int[9];
}