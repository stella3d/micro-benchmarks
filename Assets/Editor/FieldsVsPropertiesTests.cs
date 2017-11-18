using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class FieldsVsPropertiesTests : TestFixtureBase
{
	const float k_TestFloat = 9.09f;
	const int k_DataArrayLength = 10000;

	MixedData8[] dataFields8 = new MixedData8[k_DataArrayLength];
	DataProperties8[] dataProps8 = new DataProperties8[k_DataArrayLength];

	long getFieldTicks, setFieldTicks;
	long getPropertyTicks, setPropertyTicks;

	[OneTimeSetUp]
	public void Setup()
	{
		for (int i = 0; i < k_DataArrayLength; i++)
		{
			float f = k_DataArrayLength / (i + 1);
			dataFields8[i] = new MixedData8(f, i);
			dataProps8[i] = new DataProperties8(f, i);
		}
	}

	[SetUp]
	public void BeforeEach()
	{
		m_Timer.Reset();
	}

	[Test]
	public void AccessFloatMember_AsField() 
	{
		m_Timer.Start();
		foreach (var entry in dataFields8)
			m_TempFloat = entry.f;

		getFieldTicks = m_Timer.ElapsedTicks;
		Debug.Log("access as field, elapsed ticks: " + getFieldTicks);
	}

	[Test]
	public void SetFloatMember_AsField() 
	{
		m_Timer.Start();
		for (int i = 0; i < dataFields8.Length; i++)
			dataFields8[i].f = k_TestFloat;

		setFieldTicks = m_Timer.ElapsedTicks;
		Debug.Log("set as field, elapsed ticks: " + setFieldTicks);
	}

	[Test]
	public void AccessFloatMember_AsProperty() 
	{
		m_Timer.Start();
		foreach (var entry in dataProps8)
			m_TempFloat = entry.f;

		getPropertyTicks = m_Timer.ElapsedTicks;
		Debug.Log("access as property, elapsed ticks: " + getPropertyTicks);
	}

	[Test]
	public void SetFloatMember_AsProperty() 
	{
		m_Timer.Start();
		for (int i = 0; i < dataProps8.Length; i++)
			dataProps8[i].f = k_TestFloat;

		setPropertyTicks = m_Timer.ElapsedTicks;
		Debug.Log("set as property, elapsed ticks: " + setPropertyTicks);
	}

	[OneTimeTearDown]
	public void TearDown()
	{
		var ratio = ((float)getFieldTicks / (float)getPropertyTicks) + " to 1";
		var diff = (float)(getPropertyTicks - getFieldTicks) / (float)k_DataArrayLength;
		
		Debug.Log("field get time to property get time ratio : " + ratio);
		Debug.Log("An average of " + diff + " ticks saved per call");

		var setRatio = ((float)setFieldTicks / (float)setPropertyTicks) + " to 1";
		var setDiff = (float)(setPropertyTicks - setFieldTicks) / (float)k_DataArrayLength;
		
		Debug.Log("field set time to property set time ratio : " + setRatio);
		Debug.Log("An average of " + setDiff + " ticks saved per call");
	}

}
