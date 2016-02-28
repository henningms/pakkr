using PakkR.Windows10.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PakkR.Windows10.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private bool AlreadyHitLoginPage { get; set; } = false;

        public LoginPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            LoginWebView.Navigate(new Uri(PostenApiConstants.LoginStartUrl, UriKind.Absolute));
        }

        private void LoginWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            var absoluteUri = args.Uri.AbsoluteUri;

            // If we've hit the LoginStartUrl for the second time we're "logged in"
            if (absoluteUri == PostenApiConstants.LoginStartUrl && AlreadyHitLoginPage)
            {
                Debug.WriteLine("Logged in");

                Frame.Navigate(typeof(MainPage));
            }
        }

        private void LoginWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            var absoluteUri = args.Uri.AbsoluteUri;

            if (absoluteUri.StartsWith(PostenApiConstants.LoginActualLoginUrl))
            {
                AlreadyHitLoginPage = true;
            }
        }
    }
}
