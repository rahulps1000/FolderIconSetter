using FolderIconSetter.Core;
using System;

namespace FolderIconSetter.Models
{
    internal class MessageBoxModel: ObservableObject
    {
		private String title = "Test";

		public String Title
		{
			get { return title; }
			set {
                title = value;
				OnProprtyChanged();
            }
		}

		private String message;

		public String Message
		{
			get { return message; }
			set {
                message = value;
				OnProprtyChanged();
            }
		}

		private String error = null;

		public String Error
		{
			get { return error; }
			set {
                error = value;
				OnProprtyChanged();
            }
		}

        public String Text { 
			get
			{
				return error ?? message;
			}
		}

        public Boolean IsError
        {
            get
            {
                return error != null;
            }
        }

    }
}
