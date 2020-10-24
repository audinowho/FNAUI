using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using ExampleFNA;
using ReactiveUI;

namespace FNAAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public int Intensity
        {
            get { return GameBase.lum; }
            set { this.RaiseAndSetIfChanged(ref GameBase.lum, value); }
        }


        public void btnClear_Click()
        {
            GameBase.pts.Clear();
            Intensity = 255;
        }
    }
}
