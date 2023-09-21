using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Ocr.Handwriting.Azure.AI;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
