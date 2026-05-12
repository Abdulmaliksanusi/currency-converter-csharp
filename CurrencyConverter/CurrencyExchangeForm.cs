using System;
using System.Windows.Forms;

namespace CurrencyConverter
{
    public partial class CurrencyExchangeForm : Form
    {
        private Label lblTitle;

        public CurrencyExchangeForm()
        {
            InitializeComponent();
            cmbFrom.Items.AddRange(new string[] { "GBP", "USD", "EUR" });
            cmbTo.Items.AddRange(new string[] { "USD", "GBP", "EUR" });
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnClear = new Button();
            btnConvert = new Button();
            txtResult = new TextBox();
            lblResultTitle = new Label();
            cmbTo = new ComboBox();
            lblTo = new Label();
            cmbFrom = new ComboBox();
            lblFrom = new Label();
            txtAmount = new TextBox();
            lblAmount = new Label();
            txtCustomerName = new TextBox();
            lblCustomerName = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Algerian", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(0, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(495, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CURRENCY EXCHANGE CALCULATOR";
            // 
            // btnClear
            // 
            btnClear.ForeColor = System.Drawing.Color.CornflowerBlue;
            btnClear.Location = new System.Drawing.Point(112, 291);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(95, 38);
            btnClear.TabIndex = 12;
            btnClear.Text = "CLEAR";
            btnClear.Click += btnClear_Click;
            // 
            // btnConvert
            // 
            btnConvert.ForeColor = System.Drawing.Color.CornflowerBlue;
            btnConvert.Location = new System.Drawing.Point(248, 291);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(131, 38);
            btnConvert.TabIndex = 11;
            btnConvert.Text = "CONVERT";
            btnConvert.Click += btnConvert_Click;
            // 
            // txtResult
            // 
            txtResult.BackColor = System.Drawing.Color.LightGray;
            txtResult.Font = new System.Drawing.Font("Times New Roman", 13F);
            txtResult.Location = new System.Drawing.Point(248, 230);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new System.Drawing.Size(180, 32);
            txtResult.TabIndex = 10;
            // 
            // lblResultTitle
            // 
            lblResultTitle.AutoSize = true;
            lblResultTitle.ForeColor = System.Drawing.Color.White;
            lblResultTitle.Location = new System.Drawing.Point(48, 230);
            lblResultTitle.Name = "lblResultTitle";
            lblResultTitle.Size = new System.Drawing.Size(96, 25);
            lblResultTitle.TabIndex = 9;
            lblResultTitle.Text = "RESULT:";
            // 
            // cmbTo
            // 
            cmbTo.Location = new System.Drawing.Point(248, 190);
            cmbTo.Name = "cmbTo";
            cmbTo.Size = new System.Drawing.Size(180, 33);
            cmbTo.TabIndex = 8;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.ForeColor = System.Drawing.Color.White;
            lblTo.Location = new System.Drawing.Point(48, 190);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size(159, 25);
            lblTo.TabIndex = 7;
            lblTo.Text = "TO CURRENCY:";
            // 
            // cmbFrom
            // 
            cmbFrom.Location = new System.Drawing.Point(248, 150);
            cmbFrom.Name = "cmbFrom";
            cmbFrom.Size = new System.Drawing.Size(180, 33);
            cmbFrom.TabIndex = 6;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.ForeColor = System.Drawing.Color.White;
            lblFrom.Location = new System.Drawing.Point(48, 150);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size(188, 25);
            lblFrom.TabIndex = 5;
            lblFrom.Text = "FROM CURRENCY:";
            // 
            // txtAmount
            // 
            txtAmount.Font = new System.Drawing.Font("Times New Roman", 13F);
            txtAmount.Location = new System.Drawing.Point(248, 110);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new System.Drawing.Size(180, 32);
            txtAmount.TabIndex = 4;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.ForeColor = System.Drawing.Color.White;
            lblAmount.Location = new System.Drawing.Point(48, 110);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new System.Drawing.Size(104, 25);
            lblAmount.TabIndex = 3;
            lblAmount.Text = "AMOUNT:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new System.Drawing.Point(248, 70);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new System.Drawing.Size(180, 36);
            txtCustomerName.TabIndex = 2;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.ForeColor = System.Drawing.Color.White;
            lblCustomerName.Location = new System.Drawing.Point(48, 70);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new System.Drawing.Size(193, 25);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "CUSTOMER NAME:";
            // 
            // CurrencyExchangeForm
            // 
            BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            ClientSize = new System.Drawing.Size(494, 400);
            Controls.Add(lblTitle);
            Controls.Add(lblCustomerName);
            Controls.Add(txtCustomerName);
            Controls.Add(lblAmount);
            Controls.Add(txtAmount);
            Controls.Add(lblFrom);
            Controls.Add(cmbFrom);
            Controls.Add(lblTo);
            Controls.Add(cmbTo);
            Controls.Add(lblResultTitle);
            Controls.Add(txtResult);
            Controls.Add(btnConvert);
            Controls.Add(btnClear);
            Font = new System.Drawing.Font("Algerian", 13F);
            Name = "CurrencyExchangeForm";
            Text = "Currency Exchange Calculator";
            Load += CurrencyExchangeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (decimal.TryParse(txtAmount.Text, out amount))
            {
                decimal rate = GetExchangeRate(cmbFrom.Text, cmbTo.Text);
                decimal result = amount * rate;
                txtResult.Text = result.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerName.Clear();
            txtAmount.Clear();
            txtResult.Clear();
            cmbFrom.SelectedIndex = -1;
            cmbTo.SelectedIndex = -1;
        }

        private decimal GetExchangeRate(string from, string to)
        {
            if (from == "EUR" && to == "GBP") return 0.87m;
            else if (from == "GBP" && to == "EUR") return 1.15m;
            else if (from == "GBP" && to == "USD") return 1.25m;
            else if (from == "USD" && to == "GBP") return 0.80m;
            else if (from == "EUR" && to == "USD") return 1.07m;
            else if (from == "USD" && to == "EUR") return 0.93m;
            else return 1; // default if currencies are the same
        }


        private void CurrencyExchangeForm_Load(object sender, EventArgs e)
        {

        }
        private Button btnClear;
        private Button btnConvert;
        private TextBox txtResult;
        private Label lblResultTitle;
        private ComboBox cmbTo;
        private Label lblTo;
        private ComboBox cmbFrom;
        private Label lblFrom;
        private TextBox txtAmount;
        private Label lblAmount;
        private TextBox txtCustomerName;
        private Label lblCustomerName;
    }
}