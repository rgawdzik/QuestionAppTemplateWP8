using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAppTemplate.Classes
{
    public class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Allows you to update any binding done to an object.
        /// </summary>
        /// <param name="assetName">The asset name that must be updated.</param>
        public void PropertyChangedEvent(string assetName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(assetName));
            }
        }

    }
}
