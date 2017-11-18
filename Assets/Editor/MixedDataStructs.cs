using System;

public struct SingleFloatWrapper
{
	public Single f;

	public SingleFloatWrapper (Single f)
	{
		this.f = f;
	}
}

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

public struct DataProperties8
{
	public Single f { get; set; }
	public Int32 i { get; set; }

	public DataProperties8 (Single f, Int32 i)
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
	public MixedData16 m16;	

	public MixedData32 (Single f, Int32 i)
	{
		this.f = f;
		this.i = i;
		this.d = (Double)f;
		this.m16 = new MixedData16(f, i);
	}
}

public struct MixedData40
{
	public Single f;
	public Int32 i;			
	public MixedData32 m32;	

	public MixedData40 (Single f, Int32 i)
	{
		this.f = f;
		this.i = i;
		this.m32 = new MixedData32(f, i);
	}
}

public struct MixedData44
{
	public Single f;
	public MixedData8 m8;			
	public MixedData32 m32;	

	public MixedData44 (Single f, Int32 i)
	{
		this.f = f;
		this.m8 = new MixedData8(f, i);
		this.m32 = new MixedData32(f, i);
	}
}

public struct MixedData48
{
	public Single f;
	public Int32 i;			
	public MixedData8 m8;	
	public MixedData32 m32;	

	public MixedData48 (Single f, Int32 i)
	{
		this.f = f;
		this.i = i;
		this.m8 = new MixedData8(f, i);
		this.m32 = new MixedData32(f, i);
	}
}

public struct MixedData64
{
	public Single f;	
	public Int32 i;	
	public MixedData8 m8;	
	public MixedData16 m16;	
	public MixedData32 m32;	

	public MixedData64 (Single f, Int32 i)
	{
		this.f = f;
		this.i = i;
		this.m8 = new MixedData8(f, i);
		this.m16 = new MixedData16(f, i);
		this.m32 = new MixedData32(f, i);
	}
}

public struct MixedData68
{
	public Single f;	
	public MixedData64 m64;	

	public MixedData68 (Single f, Int32 i)
	{
		this.f = f;
		this.m64 = new MixedData64(f, i);
	}
}

public struct MixedData128
{
	public Single f;	
	public Int32 i;	
	public MixedData8 m8;	
	public MixedData16 m16;	
	public MixedData32 m32;	
	public MixedData64 m64;	

	public MixedData128 (Single f, Int32 i)
	{
		this.f = f;
		this.i = i;
		this.m8 = new MixedData8(f, i);
		this.m16 = new MixedData16(f, i);
		this.m32 = new MixedData32(f, i);
		this.m64 = new MixedData64(f, i);
	}
}

public struct MixedData256
{
	public Single f;	
	public Int32 i;	
	public MixedData8 m8;	
	public MixedData16 m16;	
	public MixedData32 m32;	
	public MixedData64 m64;	
	public MixedData128 m128;	

	public MixedData256 (Single f, Int32 i)
	{
		this.f = f;
		this.i = i;
		this.m8 = new MixedData8(f, i);
		this.m16 = new MixedData16(f, i);
		this.m32 = new MixedData32(f, i);
		this.m64 = new MixedData64(f, i);
		this.m128 = new MixedData128(f, i);
	}
}