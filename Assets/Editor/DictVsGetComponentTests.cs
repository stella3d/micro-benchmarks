using System;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using Debug = UnityEngine.Debug;

public class DictVsGetComponentTests : TestFixtureBase
{
	const int k_DataArrayLength = 10000;

	GameObject[] objects = new GameObject[k_DataArrayLength];
	Dictionary<int, Transform> instanceTransforms;

	long getComponentTicks;
	long dictLookupTicks;

	[OneTimeSetUp]
	public void Setup()
	{
		instanceTransforms = new Dictionary<int, Transform>(k_DataArrayLength);
		for (int i = 0; i < k_DataArrayLength; i++)
		{
			var obj = new GameObject();
			instanceTransforms.Add(obj.GetInstanceID(), obj.transform);
			objects[i] = obj;			
		}
	}

	[SetUp]
	public void BeforeEach()
	{
		m_Timer.Reset();
	}

	[Test]
	public void AccessTransform_ByGetComponent() 
	{
		m_Timer.Start();
		for (int i = 0; i < objects.Length; i++)
			m_TempTransform = objects[i].GetComponent<Transform>();

		getComponentTicks = m_Timer.ElapsedTicks;
		Debug.Log("access by GetComponent<T>, elapsed ticks: " + getComponentTicks);
	}

	[Test]
	public void AccessTransform_ByInstanceDictionary() 
	{
		m_Timer.Start();
		for (int i = 0; i < objects.Length; i++)
			m_TempTransform = instanceTransforms[objects[i].GetInstanceID()];

		dictLookupTicks = m_Timer.ElapsedTicks;
		Debug.Log("access by instanceID-keyed dict, elapsed ticks: " + dictLookupTicks);
	}

	[OneTimeTearDown]
	public void TearDown()
	{
		var ratio = ((float)dictLookupTicks / (float)getComponentTicks) + " to 1";
		var diff = (float)(getComponentTicks - dictLookupTicks) / (float)k_DataArrayLength;
		
		Debug.Log("Dictionary lookup time ratio to GetComponent<T> : " + ratio);
		Debug.Log("An average of " + diff + " ticks saved per call");

		if (objects != null)
			foreach (var obj in objects)
				GameObject.DestroyImmediate(obj);
	}

}
