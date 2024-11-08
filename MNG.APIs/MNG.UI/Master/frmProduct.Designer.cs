namespace ASRS.UI
{
    partial class frmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label activeControlPlanIdLabel;
            System.Windows.Forms.Label customerIdLabel;
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label materialCodeLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label weightLabel;
            System.Windows.Forms.Label drawingLabel;
            System.Windows.Forms.Label customerPartNoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct));
            this.itemDataGridView = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnBrowse = new System.Windows.Forms.Panel();
            this.btnMaterial = new System.Windows.Forms.Button();
            this.btnFlip = new System.Windows.Forms.Button();
            this.btnImageBrowse = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lbImageSize = new System.Windows.Forms.Label();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.customerCodeTextBox = new System.Windows.Forms.TextBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerPartNoTextBox = new System.Windows.Forms.TextBox();
            this.customerIdTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.BarCodeBox = new System.Windows.Forms.PictureBox();
            this.activeControlPlanIdTextBox = new System.Windows.Forms.TextBox();
            this.btnProductBrowse = new System.Windows.Forms.Button();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.drawingTextBox = new System.Windows.Forms.TextBox();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.materialCodeTextBox = new System.Windows.Forms.TextBox();
            this.tbCustName = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnToolbar = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnTool = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            activeControlPlanIdLabel = new System.Windows.Forms.Label();
            customerIdLabel = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            materialCodeLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            weightLabel = new System.Windows.Forms.Label();
            drawingLabel = new System.Windows.Forms.Label();
            customerPartNoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnBrowse.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeBox)).BeginInit();
            this.panel10.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.panel15.SuspendLayout();
            this.pnToolbar.SuspendLayout();
            this.pnTool.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // activeControlPlanIdLabel
            // 
            activeControlPlanIdLabel.AutoSize = true;
            activeControlPlanIdLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            activeControlPlanIdLabel.Location = new System.Drawing.Point(19, 244);
            activeControlPlanIdLabel.Name = "activeControlPlanIdLabel";
            activeControlPlanIdLabel.Size = new System.Drawing.Size(109, 17);
            activeControlPlanIdLabel.TabIndex = 0;
            activeControlPlanIdLabel.Text = "Control Plan Id:";
            // 
            // customerIdLabel
            // 
            customerIdLabel.AutoSize = true;
            customerIdLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            customerIdLabel.Location = new System.Drawing.Point(19, 308);
            customerIdLabel.Name = "customerIdLabel";
            customerIdLabel.Size = new System.Drawing.Size(71, 17);
            customerIdLabel.TabIndex = 2;
            customerIdLabel.Text = "Customer";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idLabel.Location = new System.Drawing.Point(19, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(24, 17);
            idLabel.TabIndex = 8;
            idLabel.Text = "Id:";
            // 
            // materialCodeLabel
            // 
            materialCodeLabel.AutoSize = true;
            materialCodeLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            materialCodeLabel.Location = new System.Drawing.Point(19, 157);
            materialCodeLabel.Name = "materialCodeLabel";
            materialCodeLabel.Size = new System.Drawing.Size(60, 17);
            materialCodeLabel.TabIndex = 10;
            materialCodeLabel.Text = "Material";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.Location = new System.Drawing.Point(19, 67);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(78, 17);
            nameLabel.TabIndex = 12;
            nameLabel.Text = "Part Name";
            // 
            // weightLabel
            // 
            weightLabel.AutoSize = true;
            weightLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            weightLabel.Location = new System.Drawing.Point(19, 186);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new System.Drawing.Size(87, 17);
            weightLabel.TabIndex = 14;
            weightLabel.Text = "Weight (kg.)";
            // 
            // drawingLabel
            // 
            drawingLabel.AutoSize = true;
            drawingLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            drawingLabel.Location = new System.Drawing.Point(19, 215);
            drawingLabel.Name = "drawingLabel";
            drawingLabel.Size = new System.Drawing.Size(63, 17);
            drawingLabel.TabIndex = 18;
            drawingLabel.Text = "Drawing";
            // 
            // customerPartNoLabel
            // 
            customerPartNoLabel.AutoSize = true;
            customerPartNoLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            customerPartNoLabel.Location = new System.Drawing.Point(19, 99);
            customerPartNoLabel.Name = "customerPartNoLabel";
            customerPartNoLabel.Size = new System.Drawing.Size(61, 17);
            customerPartNoLabel.TabIndex = 22;
            customerPartNoLabel.Text = "Part No.";
            // 
            // itemDataGridView
            // 
            this.itemDataGridView.AllowUserToAddRows = false;
            this.itemDataGridView.AllowUserToDeleteRows = false;
            this.itemDataGridView.AllowUserToResizeColumns = false;
            this.itemDataGridView.AllowUserToResizeRows = false;
            this.itemDataGridView.AutoGenerateColumns = false;
            this.itemDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.itemDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.itemDataGridView.ColumnHeadersHeight = 28;
            this.itemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.itemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.nameDataGridViewTextBoxColumn,
            this.MaterialCode});
            this.itemDataGridView.DataSource = this.productBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemDataGridView.EnableHeadersVisualStyles = false;
            this.itemDataGridView.Location = new System.Drawing.Point(0, 90);
            this.itemDataGridView.MultiSelect = false;
            this.itemDataGridView.Name = "itemDataGridView";
            this.itemDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.itemDataGridView.RowHeadersVisible = false;
            this.itemDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.itemDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.itemDataGridView.RowTemplate.Height = 25;
            this.itemDataGridView.RowTemplate.ReadOnly = true;
            this.itemDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.itemDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemDataGridView.Size = new System.Drawing.Size(430, 650);
            this.itemDataGridView.TabIndex = 1;
            this.itemDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemDataGridView_CellContentClick);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 85;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 240;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "Material";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(MNG.UI.Product);
            this.productBindingSource.CurrentChanged += new System.EventHandler(this.productBindingSource_CurrentChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(6, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(172, 29);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.tbSearch);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 45);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(430, 45);
            this.panel5.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.pnMain);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.pnToolbar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1002, 740);
            this.panel3.TabIndex = 7;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(494, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(508, 740);
            this.panel7.TabIndex = 24;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pnBrowse);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 90);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(508, 650);
            this.panel6.TabIndex = 21;
            // 
            // pnBrowse
            // 
            this.pnBrowse.Controls.Add(this.btnMaterial);
            this.pnBrowse.Controls.Add(this.btnFlip);
            this.pnBrowse.Controls.Add(this.btnImageBrowse);
            this.pnBrowse.Controls.Add(this.btnCustomer);
            this.pnBrowse.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnBrowse.Location = new System.Drawing.Point(430, 0);
            this.pnBrowse.Name = "pnBrowse";
            this.pnBrowse.Size = new System.Drawing.Size(39, 650);
            this.pnBrowse.TabIndex = 21;
            // 
            // btnMaterial
            // 
            this.btnMaterial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterial.Location = new System.Drawing.Point(7, 154);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Size = new System.Drawing.Size(26, 23);
            this.btnMaterial.TabIndex = 19;
            this.btnMaterial.Text = "...";
            this.btnMaterial.UseVisualStyleBackColor = false;
            this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click);
            // 
            // btnFlip
            // 
            this.btnFlip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlip.Image = ((System.Drawing.Image)(resources.GetObject("btnFlip.Image")));
            this.btnFlip.Location = new System.Drawing.Point(7, 415);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(26, 26);
            this.btnFlip.TabIndex = 19;
            this.btnFlip.Text = "...";
            this.btnFlip.UseVisualStyleBackColor = false;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            // 
            // btnImageBrowse
            // 
            this.btnImageBrowse.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImageBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImageBrowse.Location = new System.Drawing.Point(7, 386);
            this.btnImageBrowse.Name = "btnImageBrowse";
            this.btnImageBrowse.Size = new System.Drawing.Size(26, 23);
            this.btnImageBrowse.TabIndex = 19;
            this.btnImageBrowse.Text = "...";
            this.btnImageBrowse.UseVisualStyleBackColor = false;
            this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Location = new System.Drawing.Point(7, 305);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(26, 23);
            this.btnCustomer.TabIndex = 19;
            this.btnCustomer.Text = "...";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // panel11
            // 
            this.panel11.AutoScroll = true;
            this.panel11.Controls.Add(this.lbImageSize);
            this.panel11.Controls.Add(this.imagePictureBox);
            this.panel11.Controls.Add(this.customerCodeTextBox);
            this.panel11.Controls.Add(customerPartNoLabel);
            this.panel11.Controls.Add(this.customerPartNoTextBox);
            this.panel11.Controls.Add(this.customerIdTextBox);
            this.panel11.Controls.Add(this.codeTextBox);
            this.panel11.Controls.Add(idLabel);
            this.panel11.Controls.Add(this.BarCodeBox);
            this.panel11.Controls.Add(this.activeControlPlanIdTextBox);
            this.panel11.Controls.Add(this.btnProductBrowse);
            this.panel11.Controls.Add(this.btnPrintBarcode);
            this.panel11.Controls.Add(activeControlPlanIdLabel);
            this.panel11.Controls.Add(drawingLabel);
            this.panel11.Controls.Add(customerIdLabel);
            this.panel11.Controls.Add(this.drawingTextBox);
            this.panel11.Controls.Add(weightLabel);
            this.panel11.Controls.Add(this.weightTextBox);
            this.panel11.Controls.Add(nameLabel);
            this.panel11.Controls.Add(this.materialCodeTextBox);
            this.panel11.Controls.Add(this.tbCustName);
            this.panel11.Controls.Add(this.nameTextBox);
            this.panel11.Controls.Add(materialCodeLabel);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(430, 650);
            this.panel11.TabIndex = 20;
            // 
            // lbImageSize
            // 
            this.lbImageSize.AutoSize = true;
            this.lbImageSize.Location = new System.Drawing.Point(93, 629);
            this.lbImageSize.Name = "lbImageSize";
            this.lbImageSize.Size = new System.Drawing.Size(35, 13);
            this.lbImageSize.TabIndex = 26;
            this.lbImageSize.Text = "label1";
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.productBindingSource, "Image", true));
            this.imagePictureBox.Location = new System.Drawing.Point(90, 386);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(320, 240);
            this.imagePictureBox.TabIndex = 25;
            this.imagePictureBox.TabStop = false;
            // 
            // customerCodeTextBox
            // 
            this.customerCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "CustomerCode", true));
            this.customerCodeTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerCodeTextBox.Location = new System.Drawing.Point(213, 305);
            this.customerCodeTextBox.Name = "customerCodeTextBox";
            this.customerCodeTextBox.Size = new System.Drawing.Size(100, 23);
            this.customerCodeTextBox.TabIndex = 24;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(MNG.UI.Customer);
            // 
            // customerPartNoTextBox
            // 
            this.customerPartNoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerPartNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "CustomerPartNo", true));
            this.customerPartNoTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerPartNoTextBox.Location = new System.Drawing.Point(155, 96);
            this.customerPartNoTextBox.Name = "customerPartNoTextBox";
            this.customerPartNoTextBox.Size = new System.Drawing.Size(255, 23);
            this.customerPartNoTextBox.TabIndex = 23;
            // 
            // customerIdTextBox
            // 
            this.customerIdTextBox.BackColor = System.Drawing.Color.White;
            this.customerIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "CustomerId", true));
            this.customerIdTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerIdTextBox.Location = new System.Drawing.Point(155, 305);
            this.customerIdTextBox.Name = "customerIdTextBox";
            this.customerIdTextBox.ReadOnly = true;
            this.customerIdTextBox.Size = new System.Drawing.Size(52, 23);
            this.customerIdTextBox.TabIndex = 21;
            this.customerIdTextBox.TextChanged += new System.EventHandler(this.customerIdTextBox_TextChanged);
            // 
            // codeTextBox
            // 
            this.codeTextBox.BackColor = System.Drawing.Color.White;
            this.codeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Code", true));
            this.codeTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox.Location = new System.Drawing.Point(155, 6);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ReadOnly = true;
            this.codeTextBox.Size = new System.Drawing.Size(113, 23);
            this.codeTextBox.TabIndex = 4;
            this.codeTextBox.TextChanged += new System.EventHandler(this.codeTextBox_TextChanged);
            // 
            // BarCodeBox
            // 
            this.BarCodeBox.Location = new System.Drawing.Point(155, 35);
            this.BarCodeBox.Name = "BarCodeBox";
            this.BarCodeBox.Size = new System.Drawing.Size(113, 26);
            this.BarCodeBox.TabIndex = 17;
            this.BarCodeBox.TabStop = false;
            // 
            // activeControlPlanIdTextBox
            // 
            this.activeControlPlanIdTextBox.BackColor = System.Drawing.Color.White;
            this.activeControlPlanIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activeControlPlanIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ActiveControlPlanId", true));
            this.activeControlPlanIdTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeControlPlanIdTextBox.Location = new System.Drawing.Point(155, 241);
            this.activeControlPlanIdTextBox.Name = "activeControlPlanIdTextBox";
            this.activeControlPlanIdTextBox.ReadOnly = true;
            this.activeControlPlanIdTextBox.Size = new System.Drawing.Size(113, 23);
            this.activeControlPlanIdTextBox.TabIndex = 1;
            // 
            // btnProductBrowse
            // 
            this.btnProductBrowse.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnProductBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductBrowse.ForeColor = System.Drawing.Color.White;
            this.btnProductBrowse.Location = new System.Drawing.Point(274, 6);
            this.btnProductBrowse.Name = "btnProductBrowse";
            this.btnProductBrowse.Size = new System.Drawing.Size(26, 23);
            this.btnProductBrowse.TabIndex = 18;
            this.btnProductBrowse.Text = "...";
            this.btnProductBrowse.UseVisualStyleBackColor = false;
            this.btnProductBrowse.Click += new System.EventHandler(this.btnProductBrowse_Click);
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.BackColor = System.Drawing.Color.Indigo;
            this.btnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintBarcode.Image")));
            this.btnPrintBarcode.Location = new System.Drawing.Point(274, 35);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(26, 26);
            this.btnPrintBarcode.TabIndex = 18;
            this.btnPrintBarcode.UseVisualStyleBackColor = false;
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // drawingTextBox
            // 
            this.drawingTextBox.BackColor = System.Drawing.Color.White;
            this.drawingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Drawing", true));
            this.drawingTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingTextBox.Location = new System.Drawing.Point(155, 212);
            this.drawingTextBox.Name = "drawingTextBox";
            this.drawingTextBox.ReadOnly = true;
            this.drawingTextBox.Size = new System.Drawing.Size(255, 23);
            this.drawingTextBox.TabIndex = 19;
            // 
            // weightTextBox
            // 
            this.weightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weightTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Weight", true));
            this.weightTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightTextBox.Location = new System.Drawing.Point(155, 183);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(113, 23);
            this.weightTextBox.TabIndex = 15;
            // 
            // materialCodeTextBox
            // 
            this.materialCodeTextBox.BackColor = System.Drawing.Color.White;
            this.materialCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "MaterialCode", true));
            this.materialCodeTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialCodeTextBox.Location = new System.Drawing.Point(155, 154);
            this.materialCodeTextBox.Name = "materialCodeTextBox";
            this.materialCodeTextBox.ReadOnly = true;
            this.materialCodeTextBox.Size = new System.Drawing.Size(113, 23);
            this.materialCodeTextBox.TabIndex = 11;
            this.materialCodeTextBox.TextChanged += new System.EventHandler(this.materialCodeTextBox_TextChanged);
            // 
            // tbCustName
            // 
            this.tbCustName.BackColor = System.Drawing.Color.White;
            this.tbCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCustName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustName.Location = new System.Drawing.Point(155, 334);
            this.tbCustName.Name = "tbCustName";
            this.tbCustName.ReadOnly = true;
            this.tbCustName.Size = new System.Drawing.Size(255, 23);
            this.tbCustName.TabIndex = 11;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Name", true));
            this.nameTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(155, 67);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(255, 23);
            this.nameTextBox.TabIndex = 13;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 45);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(508, 45);
            this.panel9.TabIndex = 4;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel10.Controls.Add(this.label6);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(508, 45);
            this.panel10.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(508, 45);
            this.label6.TabIndex = 0;
            this.label6.Text = "Product Info.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label5_MouseDown_1);
            this.label6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label5_MouseMove_1);
            this.label6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label5_MouseUp_1);
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.itemDataGridView);
            this.pnMain.Controls.Add(this.panel5);
            this.pnMain.Controls.Add(this.panel15);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMain.Location = new System.Drawing.Point(64, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(430, 740);
            this.pnMain.TabIndex = 23;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel15.Controls.Add(this.label5);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(430, 45);
            this.panel15.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(430, 45);
            this.label5.TabIndex = 0;
            this.label5.Text = "Products";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label5_MouseDown_1);
            this.label5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label5_MouseMove_1);
            this.label5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label5_MouseUp_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(59, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 740);
            this.panel2.TabIndex = 22;
            // 
            // pnToolbar
            // 
            this.pnToolbar.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnToolbar.Controls.Add(this.label4);
            this.pnToolbar.Controls.Add(this.pnTool);
            this.pnToolbar.Controls.Add(this.panel13);
            this.pnToolbar.Controls.Add(this.label3);
            this.pnToolbar.Controls.Add(this.label2);
            this.pnToolbar.Controls.Add(this.panel8);
            this.pnToolbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnToolbar.Name = "pnToolbar";
            this.pnToolbar.Size = new System.Drawing.Size(59, 740);
            this.pnToolbar.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MidnightBlue;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "--------";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnTool
            // 
            this.pnTool.Controls.Add(this.btnDelete);
            this.pnTool.Controls.Add(this.btnEdit);
            this.pnTool.Controls.Add(this.btnAdd);
            this.pnTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTool.Location = new System.Drawing.Point(0, 134);
            this.pnTool.Name = "pnTool";
            this.pnTool.Size = new System.Drawing.Size(59, 166);
            this.pnTool.TabIndex = 16;
            this.pnTool.Paint += new System.Windows.Forms.PaintEventHandler(this.panel14_Paint);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(0, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 50);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(0, 50);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(59, 50);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 50);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnOk);
            this.panel13.Controls.Add(this.tbClose);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 585);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(59, 134);
            this.panel13.TabIndex = 15;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(0, 34);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(59, 50);
            this.btnOk.TabIndex = 9;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbClose
            // 
            this.tbClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.tbClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbClose.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.tbClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.tbClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbClose.Image = ((System.Drawing.Image)(resources.GetObject("tbClose.Image")));
            this.tbClose.Location = new System.Drawing.Point(0, 84);
            this.tbClose.Name = "tbClose";
            this.tbClose.Size = new System.Drawing.Size(59, 50);
            this.tbClose.TabIndex = 8;
            this.tbClose.UseVisualStyleBackColor = false;
            this.tbClose.Click += new System.EventHandler(this.tbClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MidnightBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "--------\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MidnightBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 719);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "--------";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(59, 113);
            this.panel8.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Material";
            this.dataGridViewTextBoxColumn5.HeaderText = "Material";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1002, 740);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmItem";
            this.Load += new System.EventHandler(this.frmItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.pnBrowse.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarCodeBox)).EndInit();
            this.panel10.ResumeLayout(false);
            this.pnMain.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.pnToolbar.ResumeLayout(false);
            this.pnToolbar.PerformLayout();
            this.pnTool.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView itemDataGridView;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnToolbar;
        private System.Windows.Forms.Button tbClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox materialCodeTextBox;
        private System.Windows.Forms.TextBox activeControlPlanIdTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbCustName;
        private System.Windows.Forms.TextBox drawingTextBox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel pnBrowse;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btnMaterial;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Panel pnTool;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnFlip;
        private System.Windows.Forms.Button btnImageBrowse;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.TextBox customerIdTextBox;
        private System.Windows.Forms.Button btnProductBrowse;
        private System.Windows.Forms.PictureBox BarCodeBox;
        private System.Windows.Forms.TextBox customerPartNoTextBox;
        private System.Windows.Forms.TextBox customerCodeTextBox;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.Label lbImageSize;
    }
}