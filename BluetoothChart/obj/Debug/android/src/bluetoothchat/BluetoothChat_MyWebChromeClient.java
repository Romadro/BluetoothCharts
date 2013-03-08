package bluetoothchat;


public class BluetoothChat_MyWebChromeClient
	extends android.webkit.WebChromeClient
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onConsoleMessage:(Ljava/lang/String;ILjava/lang/String;)V:GetOnConsoleMessage_Ljava_lang_String_ILjava_lang_String_Handler\n" +
			"";
		mono.android.Runtime.register ("BluetoothChat.BluetoothChat/MyWebChromeClient, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BluetoothChat_MyWebChromeClient.class, __md_methods);
	}


	public BluetoothChat_MyWebChromeClient ()
	{
		super ();
		if (getClass () == BluetoothChat_MyWebChromeClient.class)
			mono.android.TypeManager.Activate ("BluetoothChat.BluetoothChat/MyWebChromeClient, BluetoothChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onConsoleMessage (java.lang.String p0, int p1, java.lang.String p2)
	{
		n_onConsoleMessage (p0, p1, p2);
	}

	private native void n_onConsoleMessage (java.lang.String p0, int p1, java.lang.String p2);

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
