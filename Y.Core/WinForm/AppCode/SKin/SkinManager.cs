﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Win32;

namespace Y.Core.WinForm.SKin
{
    /// <summary>
    /// 皮肤管理中心:皮肤的编辑，设置，保存等等
    /// </summary>
    internal class SkinManager
    {
        #region 私有字段属性

        private static SkinTheme _CurrentSkin;

        private static readonly string SkinFilePath = System.Windows.Forms.Application.StartupPath + @"\Skin.ini";

        private static readonly string SkinSectionName = "SkinManager";

        private static readonly string CurrentSkinName = "CurrentSkin";

        #endregion

        #region Initialize

        public SkinManager()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// 当前使用的皮肤
        /// Gets  the current skin
        /// </summary>
        /// <value>The current skin.</value>
        public static SkinTheme CurrentSkin
        {
            get
            {
                if (_CurrentSkin == null)
                {
                    _CurrentSkin = GetSkinTeme();
                }

                return _CurrentSkin;
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// 默认皮肤
        /// Gets the default skin teme.
        /// </summary>
        /// <returns>Return a data(or instance) of SkinTheme.</returns>
        private static SkinTheme GetSkinTeme()
        {
            try
            {
                IniConfig ini = new IniConfig(SkinFilePath);
                int value;
                value = int.TryParse(ini.IniReadValue(SkinSectionName, CurrentSkinName, "0"), out value) ? value : 0;
                EnumTheme theme = (EnumTheme)System.Enum.ToObject(typeof(EnumTheme),value);//value.ToEnumByValue<EnumTheme>();
                switch (theme)
                {
                    case EnumTheme.BlueSea:
                        return new SkinThemeBlueSea();
                    case EnumTheme.KissOfAngel:
                        return new SkinThemeKissOfAngel();
                    case EnumTheme.NoFlower:
                        return new SkinThemeNoFlower();
                    case EnumTheme.SunsetRed:
                        return new SkinThemeSunsetRed();
                    case EnumTheme.Default:
                    default:
                        return new SkinThemeDefault();
                }
            }
            catch (Exception ex)
            {
                return new SkinThemeDefault();
            }
        }
    /// <summary>
    /// 根据皮肤枚举获取皮肤
    /// </summary>
    /// <param name="theme"></param>
    /// <returns></returns>
    public static SkinTheme GetSkinTeme(EnumTheme theme)
        {
          try
          {
            switch (theme)
            {
              case EnumTheme.BlueSea:
                return new SkinThemeBlueSea();
              case EnumTheme.KissOfAngel:
                return new SkinThemeKissOfAngel();
              case EnumTheme.NoFlower:
                return new SkinThemeNoFlower();
              case EnumTheme.SunsetRed:
                return new SkinThemeSunsetRed();
              case EnumTheme.Default:
              default:
                return new SkinThemeDefault();
            }
          }
          catch (Exception ex)
          {
            return new SkinThemeDefault();
          }
        }
    /// <summary>
    /// 设置当前主题皮肤
    /// </summary>
    /// <param name="theme">The theme.</param>
    public static void SettingSkinTeme(EnumTheme theme)
        {
            switch (theme)
            {
                case EnumTheme.BlueSea:
                    _CurrentSkin = new SkinThemeBlueSea();
                    break;
                case EnumTheme.KissOfAngel:
                    _CurrentSkin = new SkinThemeKissOfAngel();
                    break;
                case EnumTheme.NoFlower:
                    _CurrentSkin = new SkinThemeNoFlower();
                    break;
                case EnumTheme.SunsetRed:
                    _CurrentSkin = new SkinThemeSunsetRed();
                    break;
                case EnumTheme.Default:
                default:
                    _CurrentSkin = new SkinThemeDefault();
                    break;
            }
        }

        #endregion

        /// <summary>
        /// 保存配置文件
        /// </summary>
        public static void Save()
        {
            try
            {
                IniConfig ini = new IniConfig(SkinFilePath);
                ini.IniWriteValue(SkinSectionName, CurrentSkinName, ((int)CurrentSkin.ThemeStyle).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
