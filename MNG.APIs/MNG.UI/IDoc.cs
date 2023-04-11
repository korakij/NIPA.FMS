using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.UI
{
	public interface IDoc
	{
		void AddNew();
		void Edit();
		void Delete();
        void Save();
        void View();
        
		int Count { get; }
		int Current { get; }

		FormMode Mode { get; }

		event EventHandler ModeChanged;
		event EventHandler PositionChanged;
	}
}
