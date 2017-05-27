﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Core.ComFunc;
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
    private int count = 0;
    private void MainFrm_OnRibbonButtonClick(object sender, Y.Core.WinForm.Utility.BtnEventArgs e)
    {
      tabform frm = new tabform();
      AddTabFrm(tabControlEx1,frm);
    }

    private void buttonEx1_Click(object sender, EventArgs e)
    {
      base.DoWork(log);
    }

    private void log()
    {
      count++;
      LogFunc.WriteLog(string.Format("第{0}次点击执行的方法。",count));
      Thread.Sleep(10000);
    }
  }
}
