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
