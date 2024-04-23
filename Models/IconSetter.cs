using System;
using Microsoft.WindowsAPICodePack.Dialogs;
using FolderIconSetter.Core;

namespace FolderIconSetter.Models
{
    internal class IconSetter : ObservableObject
    {

        private String folderPath;
        private String _iconPath;

        public String FolderPath
        {
            get { return folderPath; }
            set {
                folderPath = value; 
                OnProprtyChanged();
            }
        }

        public String IconPath
        {   
            get { return _iconPath; }
            set {
                _iconPath = value; 
                OnProprtyChanged();
            }
        }

        public IconSetter()
        {
            FolderPath = String.Empty;
            IconPath = String.Empty;
        }

        public void FolderSelector ()
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Select a folder"
            };

            CommonFileDialogResult result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                FolderPath = dialog.FileName;
            }

        }

        public void IconSelector ()
        {
            var dialog = new CommonOpenFileDialog
            {
                Title = "Select an ICO File"
            };

            dialog.Filters.Add(new CommonFileDialogFilter("ICO Files", "*.ico"));

            CommonFileDialogResult result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                string filePath = dialog.FileName;
                if (System.IO.Path.GetExtension(filePath).ToLower() == ".ico")
                {
                    IconPath = filePath;
                }
            }
        }

        public void SetIcon()
        {

        }
    }
}
