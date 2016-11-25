/***************************************************************************** 
* Copyright 2016 Aurora Solutions 
* 
*    http://www.aurorasolutions.io 
* 
* Aurora Solutions is an innovative services and product company at 
* the forefront of the software industry, with processes and practices 
* involving Domain Driven Design(DDD), Agile methodologies to build 
* scalable, secure, reliable and high performance products.
* 
* Trade Mirror provides an infrastructure for low latency trade copying
* services from master to child traders, and also trader to different
* channels including social media. It is a highly customizable solution
* with low-latency signal transmission capabilities. The tool can copy trades
* from sender and publish them to all subscribed receiver’s in real time
* across a local network or the internet. Trade Mirror is built using
* languages and frameworks that include C#, C++, WPF, WCF, Socket Programming,
* MySQL, NUnit and MT4 and MT5 MetaTrader platforms.
* 
* Licensed under the Apache License, Version 2.0 (the "License"); 
* you may not use this file except in compliance with the License. 
* You may obtain a copy of the License at 
* 
*    http://www.apache.org/licenses/LICENSE-2.0 
* 
* Unless required by applicable law or agreed to in writing, software 
* distributed under the License is distributed on an "AS IS" BASIS, 
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
* See the License for the specific language governing permissions and 
* limitations under the License. 
*****************************************************************************/


﻿using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using UpDownSingnalsServer.ViewModels;

namespace UpDownSingnalsServer.Views
{
    /// <summary>
    /// Interaction logic for UpDownSignalsServerShell.xaml
    /// </summary>
    public partial class UpDownSignalsServerShell : Window
    {
        private ErrorMessageWindow _errorMessageWindow;
        private UpDownSignalsServerShellViewModel _signalsServerShellViewModel;

        public UpDownSignalsServerShell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets MainWindowViewModel
        /// </summary>
        [Dependency]
        public UpDownSignalsServerShellViewModel UpDownSignalsServerShellViewModel
        {
            set
            {
                _signalsServerShellViewModel = value;
                this.DataContext = _signalsServerShellViewModel;
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _errorMessageWindow = new ErrorMessageWindow { Owner = this };
            _errorMessageWindow.ShowDialog();
            if (_errorMessageWindow.MessageBoxSelection)
            {
                _signalsServerShellViewModel.FreeResources();
            }
            else
            {
                e.Cancel = true;
                _errorMessageWindow.Close();
            }
        }
    }
}
