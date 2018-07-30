using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI;


/// <summary>
/// ViewModel Example
/// </summary>
namespace WinFormRxUI.ViewModels
{
    public class HomeViewModel : ReactiveUI.ReactiveObject
    {
        string ModelString = "";
        public string EnteredText
        {
            get { return ModelString; }
            set { this.RaiseAndSetIfChanged(ref ModelString, value); }
        }

        string statusString = "";
        public string Status
        {
            get { return statusString; }
            set { this.RaiseAndSetIfChanged(ref statusString, value); }
        }

        public ReactiveCommand OKCmd { get; private set; }

        public HomeViewModel()
        {
            OKCmd = ReactiveCommand.Create(() => { Status = EnteredText + " is saved."; }
                , this.WhenAny(vm => vm.EnteredText, s => !string.IsNullOrWhiteSpace(s.Value)));
        }
    }
}
