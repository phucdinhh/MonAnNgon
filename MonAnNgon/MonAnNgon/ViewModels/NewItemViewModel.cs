using MonAnNgon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonAnNgon.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string name;
        private string instruction;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(instruction);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Instruction
        {
            get => instruction;
            set => SetProperty(ref instruction, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Food newItem = new Food()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Instruction = Instruction
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
