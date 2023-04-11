using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public partial class ToolBar : UserControl
    {
        public event EventHandler btnCreateClick;
        public event EventHandler btnEditClick;
        public event EventHandler btnSaveClick;
        public event EventHandler btnCancelClick;

        public ToolBar()
        {
            InitializeComponent();
        }

        private bool _EditMode;

        public bool EditMode
        {
            get
            {
                return _EditMode;
            }
            set
            {
                _EditMode = value;
                SetButtonStatus(_EditMode);
            }
        }

        public bool AllowCreate { get; set; }
        public bool AllowEdit { get; set; }

        private void tsbCreate_Click(object sender, EventArgs e)
        {
            btnCreateClick?.Invoke(this, EventArgs.Empty);
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            btnEditClick?.Invoke(this, EventArgs.Empty);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            btnSaveClick?.Invoke(this, EventArgs.Empty);
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            btnCancelClick?.Invoke(this, EventArgs.Empty);
        }

        private void SetButtonStatus(bool editMode)
        {
            tsbCreate.Enabled = AllowCreate && !editMode;
            tsbEdit.Enabled = AllowEdit && !editMode;
            tsbSave.Enabled = editMode;
            tsbCancel.Enabled = editMode;
        }
    }
}
