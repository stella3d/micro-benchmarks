using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public struct MixedData8 
{
	public Single f;
	public Int32 i;

	public MixedData8 (Single f, Int32 i)
	{
		this.f = f;
		this.i = i;
	}
}

public struct MixedData16
{
	public Single f;	// 4 bytes
	public Int32 i;		// 4 bytes
	public Double d;	// 8 bytes

	public MixedData16 (Single f, Int32 i)
	{
		this.f = f;
		this.i = i;
		this.d = (Double)f;
	}
}

public struct MixedData32
{
	public Single f;	
	public Int32 i;	
	public Double d;	
	public Double d2;	
	public Double d3;	

	public MixedData32 (Single f, Int32 i)
	{
		this.f = f;
		this.i = i;
		this.d = (Double)f;
		this.d2 = (Double)(f * 2f);
		this.d3 = (Double)(f * 3f);
	}
}

public class DataOrientedPerfTests 
{
	const int k_DataArrayLength = 10000;

	float[] data = new float[k_DataArrayLength];
	MixedData8[] data8 = new MixedData8[k_DataArrayLength];
	MixedData16[] data16 = new MixedData16[k_DataArrayLength];
	MixedData32[] data32 = new MixedData32[k_DataArrayLength];

	Stopwatch m_Timer = new Stopwatch();
	float m_TempReadValue;

	[OneTimeSetUp]
	public void Setup()
	{
		for (int i = 0; i < k_DataArrayLength; i++)
		{
			float f = k_DataArrayLength / i;
			data[i] = f;
			data8[i] = new MixedData8(f, i);
			data16[i] = new MixedData16(f, i);
			data32[i] = new MixedData32(f, i);
		}
	}

	[SetUp]
	public void BeforeEach()
	{
		m_Timer.Reset();
	}

	[Test]
	public void OneFloat_AllByItself() 
	{
		m_Timer.Start();

		float temp;
		foreach (var floatValue in data)
			temp = floatValue;

		Debug.Log("only floats elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In8ByteStruct() 
	{
		m_Timer.Start();

		float temp;
		foreach (var floatValue in data8)
			temp = floatValue.f;

		Debug.Log("8 byte elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In16ByteStruct() 
	{
		m_Timer.Start();

		float temp;
		foreach (var floatValue in data16)
			temp = floatValue.f;

		Debug.Log("16 byte elapsed ticks: " + m_Timer.ElapsedTicks);
	}

	[Test]
	public void OneFloat_In32ByteStruct() 
	{
		m_Timer.Start();

		float temp;
		foreach (var floatValue in data16)
			temp = floatValue.f;

		Debug.Log("32 byte elapsed ticks: " + m_Timer.ElapsedTicks);
	}

}
