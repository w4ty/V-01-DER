using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMath
{

	static public float Squared(float a)
	{
		a = a * a;
		return a;
	}

	static public float QuickMaths(float a)
	{
		a = 2 + 2; // two plus two is four
		a = a - 1; // minus one thats three
		return a; // Quick maths
	}
}
