package bluetoothchat;


public class BluetoothChat_MyHandler
	extends android.os.Handler
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_handleMessage:(Landroid/os/Message;)V:GetHandleMessage_Landroid_os_Message_Handler\n" +
			"";
		mono.android.Runtime.register ("BluetoothChat.BluetoothChat/MyHandler, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BluetoothChat_MyHandler.class, __md_methods);
	}


	public BluetoothChat_MyHandler ()
	{
		super ();
		if (getClass () == BluetoothChat_MyHandler.class)
			mono.android.TypeManager.Activate ("BluetoothChat.BluetoothChat/MyHandler, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public BluetoothChat_MyHandler (bluetoothchat.BluetoothChat p0)
	{
		super ();
		if (getClass () == BluetoothChat_MyHandler.class)
			mono.android.TypeManager.Activate ("BluetoothChat.BluetoothChat/MyHandler, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "BluetoothChat.BluetoothChat, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void handleMessage (android.os.Message p0)
	{
		n_handleMessage (p0);
	}

	private native void n_handleMessage (android.os.Message p0);

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
