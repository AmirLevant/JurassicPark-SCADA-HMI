using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.classFolder
{
    abstract class resourceClass
    {
        public virtual void updateResource(System.Windows.Controls.Label displayLabel)
        {
            displayLabel.Content = "Not Implemented 1";
        }
        public virtual void updateResource(System.Windows.Controls.Label displayLabel, System.Windows.Controls.Button toggleButton, System.Windows.Threading.Dispatcher dispatcher)
        {
            displayLabel.Content = "Not Implemented 2";
        }
        public virtual void updateResource(System.Windows.Controls.Label displayLabel, System.Windows.Controls.Image lightning, System.Windows.Controls.Button toggleButton, System.Windows.Threading.Dispatcher dispatcher)
        {
            displayLabel.Content = "Not Implemented 5";
        }

        public virtual void updateResource(System.Windows.Controls.Label displayLabel, bool status)
        {
            displayLabel.Content = "Not Implemented 3";
        }
        public virtual void updateResource(bool status)
        {
        }
    }
}
