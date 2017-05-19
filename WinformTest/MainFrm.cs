﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Core.WinForm.FormEx;
using Y.Core.WinForm.Utility;

namespace WinformTest
{
  public partial class MainFrm : MainForm
  {
    public MainFrm()
    {
      InitializeComponent();
    }

    private void MainFrm_OnRibbonButtonClick(object sender, Y.Core.WinForm.Utility.BtnEventArgs e)
    {
      tabform frm = new tabform();
      AddTabFrm(tabControlEx1,frm);
    }
  }
}
