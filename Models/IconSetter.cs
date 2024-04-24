using FolderIconSetter.Core;
using System;
using System.IO;
using System.Windows.Forms;
//using Microsoft.WindowsAPICodePack.Dialogs;

namespace FolderIconSetter.Models
{
    internal class IconSetter : ObservableObject
    {

        private String folderPath;
        private String iconPath;

        public String FolderPath
        {
            get
            {
                if (folderPath == "")
                {
                    return folderPath;
                }
                else
                {
                    return folderPath + "\\";
                }
            }
            set
            {
                folderPath = value;
                OnProprtyChanged();
            }
        }

        public String IconPath
        {
            get { return iconPath; }
            set
            {
                iconPath = value;
                OnProprtyChanged();
            }
        }

        public IconSetter()
        {
            FolderPath = String.Empty;
            IconPath = String.Empty;
        }

        public void FolderSelector()
        {
            //var dialog = new CommonOpenFileDialog
            //{
            //    IsFolderPicker = true,
            //    Title = "Select a folder"
            //};

            //CommonFileDialogResult result = dialog.ShowDialog();

            //if (result == CommonFileDialogResult.Ok)
            //{
            //    FolderPath = dialog.FileName;
            //}

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderDialog.Description = "Select the folder to which the icon need to be set";
            folderDialog.ShowNewFolderButton = true;

            DialogResult x = folderDialog.ShowDialog();

            if (x == DialogResult.OK)
            {
                string selectedPath = folderDialog.SelectedPath;
                FolderPath = selectedPath;
            }

        }

        public void IconSelector()
        {
            //var dialog = new CommonOpenFileDialog
            //{
            //    Title = "Select an ICO File"
            //};

            //dialog.Filters.Add(new CommonFileDialogFilter("ICO Files", "*.ico"));

            //CommonFileDialogResult result = dialog.ShowDialog();

            //if (result == CommonFileDialogResult.Ok)
            //{
            //    string filePath = dialog.FileName;
            //    if (Path.GetExtension(filePath).ToLower() == ".ico")
            //    {
            //        IconPath = filePath;
            //    }
            //}

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Icon Files (*.ico)|*.ico";
            openFileDialog.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            openFileDialog.Title = "Select an Icon File";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedPath = openFileDialog.FileName;
                IconPath = selectedPath;
            }
        }

        public void SetIcon()
        {
            var iconName = "icon.ico";
            var iniFile = FolderPath + "desktop.ini";

            if (File.Exists(FolderPath + iconName))
            {
                Random r = new Random();
                while (File.Exists(FolderPath + iconName))
                {
                    iconName = "icon_" + r.Next() + ".ico";
                }
            }

            File.Copy(IconPath, FolderPath + iconName);

            StreamWriter sw = new StreamWriter(iniFile);

            sw.WriteLine("[.ShellClassInfo]");
            sw.WriteLine("IconResource=" + iconName + ",0");

            sw.Close();

            File.SetAttributes(iniFile, File.GetAttributes(iniFile) | FileAttributes.Hidden);
            File.SetAttributes(FolderPath + iconName, File.GetAttributes(FolderPath + iconName) | FileAttributes.Hidden);
            File.SetAttributes(FolderPath, File.GetAttributes(FolderPath) | FileAttributes.System);

        }
    }
}
