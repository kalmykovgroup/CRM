using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KTSF.ViewModel
{
    public static class Regedit
    {

     

        public static void SetValue(string key, string value)
        {
            if (AppControl.CompanyName == null || AppControl.ProgramName == null) return;

            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey? subCompany = currentUserKey.OpenSubKey(AppControl.CompanyName, true);

            if (subCompany is null) subCompany = currentUserKey.CreateSubKey(AppControl.CompanyName, true);

            RegistryKey? subProgram = subCompany?.OpenSubKey(AppControl.ProgramName, true);

            if (subProgram is null) subProgram = subCompany?.CreateSubKey(AppControl.ProgramName, true) ?? null;


            subProgram?.SetValue(key, value);
            subProgram?.Close();
            subCompany?.Close();

        }

        public static string? GetValue(string key)
        {
            if (AppControl.CompanyName == null || AppControl.ProgramName == null) return null;

            RegistryKey currentUserKey = Registry.CurrentUser;

            RegistryKey? subCompany = currentUserKey.OpenSubKey(AppControl.CompanyName);

            if (subCompany == null) return null;

            RegistryKey? subProgram = subCompany.OpenSubKey(AppControl.ProgramName);

            if (subProgram == null) return null;

            object? value = subProgram != null ? subProgram.GetValue(key) : null;
            subProgram?.Close();
            subCompany?.Close();

            return value is string token ? token : null;
        }
    }
}
