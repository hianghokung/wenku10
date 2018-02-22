﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Net.Astropenguin.Loaders;

using GR.Resources;

namespace wenku10.Pages.Settings.Data
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Cache : Page
	{
		public Cache()
		{
			this.InitializeComponent();
			SetTemplate();
		}

		private void SetTemplate()
		{
			StringResources stx = new StringResources( "Settings" );
			CacheLimit.Text = stx.Text( "Data_CacheUsed" ) + "NotImplementedYet";
			// + " " + global::GR.GSystem.Utils.AutoByteUnit();
		}

		private void Button_Click_1( object sender, RoutedEventArgs e )
		{
			SetTemplate();
		}

	}

}
