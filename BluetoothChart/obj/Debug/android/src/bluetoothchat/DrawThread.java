package bluetoothchat;


public class DrawThread
	extends java.lang.Thread
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler\n" +
			"";
		mono.android.Runtime.register ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DrawThread.class, __md_methods);
	}


	public DrawThread ()
	{
		super ();
		if (getClass () == DrawThread.class)
			mono.android.TypeManager.Activate ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public DrawThread (java.lang.Runnable p0)
	{
		super (p0);
		if (getClass () == DrawThread.class)
			mono.android.TypeManager.Activate ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public DrawThread (java.lang.Runnable p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == DrawThread.class)
			mono.android.TypeManager.Activate ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public DrawThread (java.lang.String p0)
	{
		super (p0);
		if (getClass () == DrawThread.class)
			mono.android.TypeManager.Activate ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public DrawThread (java.lang.ThreadGroup p0, java.lang.Runnable p1)
	{
		super (p0, p1);
		if (getClass () == DrawThread.class)
			mono.android.TypeManager.Activate ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public DrawThread (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2)
	{
		super (p0, p1, p2);
		if (getClass () == DrawThread.class)
			mono.android.TypeManager.Activate ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public DrawThread (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2, long p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == DrawThread.class)
			mono.android.TypeManager.Activate ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int64, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public DrawThread (java.lang.ThreadGroup p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == DrawThread.class)
			mono.android.TypeManager.Activate ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}

	public DrawThread (android.view.SurfaceHolder p0)
	{
		super ();
		if (getClass () == DrawThread.class)
			mono.android.TypeManager.Activate ("BluetoothChat.DrawThread, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.ISurfaceHolder, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
