
namespace HotelVancouver
{
    partial class FormCadastroReservas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBoxCpf = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxAcomodacao = new System.Windows.Forms.ComboBox();
            this.comboBoxMeioPagamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeCheckin = new System.Windows.Forms.DateTimePicker();
            this.dateTimeCheckout = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Digite o CPF do cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selecione a acomodação";
            // 
            // maskedTextBoxCpf
            // 
            this.maskedTextBoxCpf.Location = new System.Drawing.Point(39, 109);
            this.maskedTextBoxCpf.Mask = "000,000,000-00";
            this.maskedTextBoxCpf.Name = "maskedTextBoxCpf";
            this.maskedTextBoxCpf.Size = new System.Drawing.Size(221, 23);
            this.maskedTextBoxCpf.TabIndex = 12;
            this.maskedTextBoxCpf.TextChanged += new System.EventHandler(this.maskedTextBoxCpf_TextChanged);
            // 
            // comboBoxAcomodacao
            // 
            this.comboBoxAcomodacao.FormattingEnabled = true;
            this.comboBoxAcomodacao.Location = new System.Drawing.Point(288, 109);
            this.comboBoxAcomodacao.Name = "comboBoxAcomodacao";
            this.comboBoxAcomodacao.Size = new System.Drawing.Size(221, 23);
            this.comboBoxAcomodacao.TabIndex = 4;
            // 
            // comboBoxMeioPagamento
            // 
            this.comboBoxMeioPagamento.FormattingEnabled = true;
            this.comboBoxMeioPagamento.Location = new System.Drawing.Point(41, 171);
            this.comboBoxMeioPagamento.Name = "comboBoxMeioPagamento";
            this.comboBoxMeioPagamento.Size = new System.Drawing.Size(221, 23);
            this.comboBoxMeioPagamento.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Selecione a forma de pagamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Check-in";
            // 
            // dateTimeCheckin
            // 
            this.dateTimeCheckin.Location = new System.Drawing.Point(41, 234);
            this.dateTimeCheckin.Name = "dateTimeCheckin";
            this.dateTimeCheckin.Size = new System.Drawing.Size(200, 23);
            this.dateTimeCheckin.TabIndex = 8;
            // 
            // dateTimeCheckout
            // 
            this.dateTimeCheckout.Location = new System.Drawing.Point(288, 234);
            this.dateTimeCheckout.Name = "dateTimeCheckout";
            this.dateTimeCheckout.Size = new System.Drawing.Size(200, 23);
            this.dateTimeCheckout.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Check-out";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Montserrat Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(39, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 51);
            this.button1.TabIndex = 11;
            this.button1.Text = "CADASTRAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Montserrat Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(712, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 51);
            this.button2.TabIndex = 13;
            this.button2.Text = "VOLTAR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormCadastroReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.maskedTextBoxCpf);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimeCheckout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimeCheckin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxMeioPagamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxAcomodacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCadastroReservas";
            this.Text = "Cadastrar reserva";
            this.Load += new System.EventHandler(this.FormCadastroReservas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCpf;
        private System.Windows.Forms.ComboBox comboBoxAcomodacao;
        private System.Windows.Forms.ComboBox comboBoxMeioPagamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimeCheckin;
        private System.Windows.Forms.DateTimePicker dateTimeCheckout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}