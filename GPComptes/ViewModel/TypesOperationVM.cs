using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPComptes.Dal;
using GPComptes.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GPComptes.ViewModel
{
	public class TypesOperationVM : ViewModelApplicationBase<TypeOperation>
	{
		/// <summary>
		/// Constructeur
		/// </summary>
		public TypesOperationVM() : base() {
			this.CurrentItem = new TypeOperation();			
			this.PopulateTypes();
		}

		private void PopulateTypes() {
			using (var ct = new AppContext()) {
				this.Items = ct.Types.OrderBy(x => x.Libelle).ToList<TypeOperation>();
			}
		}
	}
}
