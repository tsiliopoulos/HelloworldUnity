using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class HelloWorldPluginWrapper : MonoBehaviour {

	const string DLL_NAME = "HelloWorldPlugin";

	[DllImport(DLL_NAME)]
	private static extern int Add(int first, int second);

	[DllImport(DLL_NAME)]
	private static extern System.IntPtr Sayhello();
	
	[DllImport(DLL_NAME)]
	private static extern  void SetGreeting(string greeting);
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.H)) {
			print(Add(7, 3));
			SetGreeting("Hello, World!");

			string message = Marshal.PtrToStringAnsi(Sayhello());
			print(message);
		}

		if(Input.GetKeyDown(KeyCode.G)) {
			SetGreeting("Goodbye!");
			
			string message = Marshal.PtrToStringAnsi(Sayhello());
			print(message);
		}
	}
}
