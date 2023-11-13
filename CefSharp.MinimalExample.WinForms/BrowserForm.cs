// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using CefSharp.DevTools.IO;
using CefSharp.MinimalExample.WinForms.Controls;
using CefSharp.WinForms;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharp.MinimalExample.WinForms
{
    public partial class BrowserForm : Form
    {
        private readonly ChromiumWebBrowser browser;

        public BrowserForm()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            browser = new ChromiumWebBrowser("https://chat.openai.com/");
            //toolStripContainer.ContentPanel.Controls.Add(browser);
            this.Controls.Add(browser);
        }

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            string script = @"
console.log('Hello World');
    ";

            try
            {
                var result = await browser.EvaluateScriptAsPromiseAsync(script);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
