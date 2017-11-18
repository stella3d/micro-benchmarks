using System;
using NUnit.Framework;
using System.Diagnostics;
using UnityEngine;

public class TestFixtureBase 
{
	protected Stopwatch m_Timer = new Stopwatch();
	protected float m_TempFloat;
	protected Transform m_TempTransform;
}
