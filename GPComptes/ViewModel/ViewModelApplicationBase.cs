using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPComptes.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPComptes.ViewModel
{
	public abstract class ViewModelApplicationBase<T> : ViewModelBase where T : class, new()
	{
		#region Items
		protected IList<T> _items;
		public IList<T> Items {
			get { return this._items; }
			set {
				if (this._items != value) {
					this._items = value;
					this.RaisePropertyChanged(() => this.Items);
				}
			}
		}
		#endregion

		#region CurrentItem
		protected T _currentItem;
		public T CurrentItem {
			get { return this._currentItem; }
			set {
				if (this._currentItem == null || !this._currentItem.Equals(value)) {
					this._currentItem = value;
					this.RaisePropertyChanged(() => this.CurrentItem);
				}
			}
		}
		#endregion

		#region constructeur
		protected ViewModelApplicationBase() {
			this.CreateSelectItemCommand();

			this.CreateAddItemCommand();
		}
		#endregion

		#region SelectItemCommand
		public ICommand SelectItemCommand { get; set; }

		private void CreateSelectItemCommand() {
			this.SelectItemCommand = new RelayCommand<object>(this.ExecuteSelectItemCommand, this.CanExecuteSelectItemCommand);
		}

		private bool CanExecuteSelectItemCommand(object item) {
			return true;
		}

		private void ExecuteSelectItemCommand(object item) {
			if (item is T) {
				this.CurrentItem = (T)item;
			}
		}
		#endregion

		#region AddItemCommand
		public ICommand AddItemCommand { get; set; }

		private void CreateAddItemCommand() {
			this.AddItemCommand = new RelayCommand(this.ExecuteAddItemCommand, this.CanExecuteAddItemCommand);
		}

		private bool CanExecuteAddItemCommand() {
			return this.CurrentItem != null;
		}

		private void ExecuteAddItemCommand() {
			using (var ct = new AppContext()) {
				ct.Set<T>().Add(this.CurrentItem);
				ct.SaveChanges();
			}
		}
		#endregion
	}
}
