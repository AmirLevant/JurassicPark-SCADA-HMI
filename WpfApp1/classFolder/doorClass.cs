using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WpfApp1.classFolder
{
    internal class doorClass
    {
        private bool doorStatus = true;

        public doorClass()
        {
        }

        public bool getDoorStatus()
        {
            return this.doorStatus;
        }

        public void setDoorStatus(bool newStatus)
        {
            this.doorStatus = newStatus;
        }


        public void updateDoorStatus(System.Windows.Controls.Button doorButton, System.Windows.Controls.Image lock_Image)
        {
            if(this.doorStatus == true)
            {
                this.doorStatus = false;
                doorButton.Content = "Locked";
                lock_Image.Source = new BitmapImage(new Uri("/images/lock_Locked.png", UriKind.Relative));
            }
            else
            {
                this.doorStatus = true;
                doorButton.Content = "Opened";
                lock_Image.Source = new BitmapImage(new Uri("/images/lock_Open.png", UriKind.Relative));
            }


        }
    }
}
