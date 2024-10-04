
namespace Lifora
{
    partial class backoffice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(backoffice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.btnBlockTheUser = new System.Windows.Forms.Button();
            this.btnUnlockTheUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewInfoUser = new System.Windows.Forms.DataGridView();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCambiarNombre = new System.Windows.Forms.TextBox();
            this.textBoxCambiarApellido = new System.Windows.Forms.TextBox();
            this.textBoxCambiarTelefono = new System.Windows.Forms.TextBox();
            this.textBoxCambiarEmail = new System.Windows.Forms.TextBox();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCrearEvento = new System.Windows.Forms.Button();
            this.textBoxFechaDeNacimiento = new System.Windows.Forms.TextBox();
            this.dataGridViewEventos = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxNuevaFechaEvento = new System.Windows.Forms.TextBox();
            this.textBoxNuevoLugarEvento = new System.Windows.Forms.TextBox();
            this.textBoxNuevaInfoEvento = new System.Windows.Forms.TextBox();
            this.textBoxNuevoNombreEvento = new System.Windows.Forms.TextBox();
            this.BtnModificarEvento = new System.Windows.Forms.Button();
            this.BtnBloquearEvento = new System.Windows.Forms.Button();
            this.BtnDesbloquearEvento = new System.Windows.Forms.Button();
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.dataGridViewGrupos = new System.Windows.Forms.DataGridView();
            this.btnBloquearGrupo = new System.Windows.Forms.Button();
            this.btnHabilitarGrupo = new System.Windows.Forms.Button();
            this.btnModificarGrupo = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxIDescripcionGrupo = new System.Windows.Forms.TextBox();
            this.textBoxNombreGrupo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfoUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Location = new System.Drawing.Point(12, 101);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(176, 38);
            this.btnSearchUser.TabIndex = 0;
            this.btnSearchUser.Text = "Buscar Usuario";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // btnBlockTheUser
            // 
            this.btnBlockTheUser.Location = new System.Drawing.Point(378, 279);
            this.btnBlockTheUser.Name = "btnBlockTheUser";
            this.btnBlockTheUser.Size = new System.Drawing.Size(114, 35);
            this.btnBlockTheUser.TabIndex = 3;
            this.btnBlockTheUser.Text = "Bloquear Usuario";
            this.btnBlockTheUser.UseVisualStyleBackColor = true;
            this.btnBlockTheUser.Click += new System.EventHandler(this.btnBlockTheUser_Click);
            // 
            // btnUnlockTheUser
            // 
            this.btnUnlockTheUser.Location = new System.Drawing.Point(498, 279);
            this.btnUnlockTheUser.Name = "btnUnlockTheUser";
            this.btnUnlockTheUser.Size = new System.Drawing.Size(114, 34);
            this.btnUnlockTheUser.TabIndex = 4;
            this.btnUnlockTheUser.Text = "Habilitar Usuario";
            this.btnUnlockTheUser.UseVisualStyleBackColor = true;
            this.btnUnlockTheUser.Click += new System.EventHandler(this.btnUnlockTheUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 55);
            this.label1.TabIndex = 13;
            this.label1.Text = "LIFORA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Live for Art";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "BACKOFFICE";
            // 
            // dataGridViewInfoUser
            // 
            this.dataGridViewInfoUser.AllowUserToOrderColumns = true;
            this.dataGridViewInfoUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInfoUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInfoUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewInfoUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInfoUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewInfoUser.Location = new System.Drawing.Point(12, 145);
            this.dataGridViewInfoUser.MultiSelect = false;
            this.dataGridViewInfoUser.Name = "dataGridViewInfoUser";
            this.dataGridViewInfoUser.ReadOnly = true;
            this.dataGridViewInfoUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewInfoUser.RowHeadersWidth = 62;
            this.dataGridViewInfoUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInfoUser.Size = new System.Drawing.Size(902, 128);
            this.dataGridViewInfoUser.TabIndex = 16;
            this.dataGridViewInfoUser.SelectionChanged += new System.EventHandler(this.dataGridViewInfoUser_SelectionChanged);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(194, 113);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxSearch.Size = new System.Drawing.Size(284, 26);
            this.txtBoxSearch.TabIndex = 17;
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.txtBoxSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Ingresar email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 284);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 306);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Apellido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 327);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Telefono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 348);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Email";
            // 
            // textBoxCambiarNombre
            // 
            this.textBoxCambiarNombre.Location = new System.Drawing.Point(77, 281);
            this.textBoxCambiarNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCambiarNombre.Name = "textBoxCambiarNombre";
            this.textBoxCambiarNombre.Size = new System.Drawing.Size(175, 20);
            this.textBoxCambiarNombre.TabIndex = 23;
            this.textBoxCambiarNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCambiarApellido
            // 
            this.textBoxCambiarApellido.Location = new System.Drawing.Point(77, 303);
            this.textBoxCambiarApellido.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCambiarApellido.Name = "textBoxCambiarApellido";
            this.textBoxCambiarApellido.Size = new System.Drawing.Size(175, 20);
            this.textBoxCambiarApellido.TabIndex = 24;
            this.textBoxCambiarApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCambiarTelefono
            // 
            this.textBoxCambiarTelefono.Location = new System.Drawing.Point(77, 324);
            this.textBoxCambiarTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCambiarTelefono.Name = "textBoxCambiarTelefono";
            this.textBoxCambiarTelefono.Size = new System.Drawing.Size(175, 20);
            this.textBoxCambiarTelefono.TabIndex = 25;
            this.textBoxCambiarTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCambiarEmail
            // 
            this.textBoxCambiarEmail.Location = new System.Drawing.Point(77, 345);
            this.textBoxCambiarEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCambiarEmail.Name = "textBoxCambiarEmail";
            this.textBoxCambiarEmail.Size = new System.Drawing.Size(175, 20);
            this.textBoxCambiarEmail.TabIndex = 26;
            this.textBoxCambiarEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(258, 281);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(114, 33);
            this.BtnModificar.TabIndex = 27;
            this.BtnModificar.Text = "ModificarUsuario";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 367);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Fecha Nac";
            // 
            // BtnCrearEvento
            // 
            this.BtnCrearEvento.Location = new System.Drawing.Point(1072, 644);
            this.BtnCrearEvento.Name = "BtnCrearEvento";
            this.BtnCrearEvento.Size = new System.Drawing.Size(175, 37);
            this.BtnCrearEvento.TabIndex = 29;
            this.BtnCrearEvento.Text = "Eventos";
            this.BtnCrearEvento.UseVisualStyleBackColor = true;
            this.BtnCrearEvento.Click += new System.EventHandler(this.BtnCrearEvento_Click);
            // 
            // textBoxFechaDeNacimiento
            // 
            this.textBoxFechaDeNacimiento.Location = new System.Drawing.Point(77, 367);
            this.textBoxFechaDeNacimiento.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFechaDeNacimiento.Name = "textBoxFechaDeNacimiento";
            this.textBoxFechaDeNacimiento.Size = new System.Drawing.Size(175, 20);
            this.textBoxFechaDeNacimiento.TabIndex = 30;
            this.textBoxFechaDeNacimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewEventos
            // 
            this.dataGridViewEventos.AllowUserToOrderColumns = true;
            this.dataGridViewEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEventos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEventos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEventos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewEventos.Location = new System.Drawing.Point(646, 471);
            this.dataGridViewEventos.MultiSelect = false;
            this.dataGridViewEventos.Name = "dataGridViewEventos";
            this.dataGridViewEventos.ReadOnly = true;
            this.dataGridViewEventos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewEventos.RowHeadersWidth = 62;
            this.dataGridViewEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEventos.Size = new System.Drawing.Size(600, 128);
            this.dataGridViewEventos.TabIndex = 34;
            this.dataGridViewEventos.SelectionChanged += new System.EventHandler(this.dataGridViewEventos_SelectionChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(642, 689);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Fecha";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(642, 663);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Lugar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(642, 637);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Informacion";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(642, 611);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Nombre evento";
            // 
            // textBoxNuevaFechaEvento
            // 
            this.textBoxNuevaFechaEvento.Location = new System.Drawing.Point(728, 683);
            this.textBoxNuevaFechaEvento.Name = "textBoxNuevaFechaEvento";
            this.textBoxNuevaFechaEvento.Size = new System.Drawing.Size(175, 20);
            this.textBoxNuevaFechaEvento.TabIndex = 38;
            // 
            // textBoxNuevoLugarEvento
            // 
            this.textBoxNuevoLugarEvento.Location = new System.Drawing.Point(728, 656);
            this.textBoxNuevoLugarEvento.Name = "textBoxNuevoLugarEvento";
            this.textBoxNuevoLugarEvento.Size = new System.Drawing.Size(175, 20);
            this.textBoxNuevoLugarEvento.TabIndex = 37;
            // 
            // textBoxNuevaInfoEvento
            // 
            this.textBoxNuevaInfoEvento.Location = new System.Drawing.Point(728, 630);
            this.textBoxNuevaInfoEvento.Name = "textBoxNuevaInfoEvento";
            this.textBoxNuevaInfoEvento.Size = new System.Drawing.Size(175, 20);
            this.textBoxNuevaInfoEvento.TabIndex = 36;
            // 
            // textBoxNuevoNombreEvento
            // 
            this.textBoxNuevoNombreEvento.Location = new System.Drawing.Point(728, 604);
            this.textBoxNuevoNombreEvento.Name = "textBoxNuevoNombreEvento";
            this.textBoxNuevoNombreEvento.Size = new System.Drawing.Size(175, 20);
            this.textBoxNuevoNombreEvento.TabIndex = 35;
            // 
            // BtnModificarEvento
            // 
            this.BtnModificarEvento.Location = new System.Drawing.Point(1137, 605);
            this.BtnModificarEvento.Name = "BtnModificarEvento";
            this.BtnModificarEvento.Size = new System.Drawing.Size(109, 33);
            this.BtnModificarEvento.TabIndex = 43;
            this.BtnModificarEvento.Text = "ModificarEvento";
            this.BtnModificarEvento.UseVisualStyleBackColor = true;
            this.BtnModificarEvento.Click += new System.EventHandler(this.BtnModificarEvento_Click_1);
            // 
            // BtnBloquearEvento
            // 
            this.BtnBloquearEvento.Location = new System.Drawing.Point(1023, 605);
            this.BtnBloquearEvento.Name = "BtnBloquearEvento";
            this.BtnBloquearEvento.Size = new System.Drawing.Size(108, 33);
            this.BtnBloquearEvento.TabIndex = 44;
            this.BtnBloquearEvento.Text = "Bloquear Evento";
            this.BtnBloquearEvento.UseVisualStyleBackColor = false;
            this.BtnBloquearEvento.Click += new System.EventHandler(this.BtnBloquearEvento_click);
            // 
            // BtnDesbloquearEvento
            // 
            this.BtnDesbloquearEvento.Location = new System.Drawing.Point(909, 604);
            this.BtnDesbloquearEvento.Name = "BtnDesbloquearEvento";
            this.BtnDesbloquearEvento.Size = new System.Drawing.Size(108, 33);
            this.BtnDesbloquearEvento.TabIndex = 45;
            this.BtnDesbloquearEvento.Text = "Habilitar Evento";
            this.BtnDesbloquearEvento.UseVisualStyleBackColor = true;
            this.BtnDesbloquearEvento.Click += new System.EventHandler(this.BtnDesbloquearEvento_click);
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.Location = new System.Drawing.Point(439, 653);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(173, 36);
            this.btnCrearGrupo.TabIndex = 47;
            this.btnCrearGrupo.Text = "Crear Grupo";
            this.btnCrearGrupo.UseVisualStyleBackColor = true;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // dataGridViewGrupos
            // 
            this.dataGridViewGrupos.AllowUserToOrderColumns = true;
            this.dataGridViewGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGrupos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGrupos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewGrupos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewGrupos.Location = new System.Drawing.Point(13, 471);
            this.dataGridViewGrupos.MultiSelect = false;
            this.dataGridViewGrupos.Name = "dataGridViewGrupos";
            this.dataGridViewGrupos.ReadOnly = true;
            this.dataGridViewGrupos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewGrupos.RowHeadersWidth = 62;
            this.dataGridViewGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGrupos.Size = new System.Drawing.Size(600, 128);
            this.dataGridViewGrupos.TabIndex = 48;
            // 
            // btnBloquearGrupo
            // 
            this.btnBloquearGrupo.Location = new System.Drawing.Point(390, 605);
            this.btnBloquearGrupo.Name = "btnBloquearGrupo";
            this.btnBloquearGrupo.Size = new System.Drawing.Size(108, 33);
            this.btnBloquearGrupo.TabIndex = 49;
            this.btnBloquearGrupo.Text = "Bloquear Grupo";
            this.btnBloquearGrupo.UseVisualStyleBackColor = false;
            this.btnBloquearGrupo.Click += new System.EventHandler(this.btnBloquearGrupo_Click);
            // 
            // btnHabilitarGrupo
            // 
            this.btnHabilitarGrupo.Location = new System.Drawing.Point(504, 605);
            this.btnHabilitarGrupo.Name = "btnHabilitarGrupo";
            this.btnHabilitarGrupo.Size = new System.Drawing.Size(108, 33);
            this.btnHabilitarGrupo.TabIndex = 50;
            this.btnHabilitarGrupo.Text = "Habilitar Grupo";
            this.btnHabilitarGrupo.UseVisualStyleBackColor = true;
            this.btnHabilitarGrupo.Click += new System.EventHandler(this.btnHabilitarGrupo_Click);
            // 
            // btnModificarGrupo
            // 
            this.btnModificarGrupo.Location = new System.Drawing.Point(276, 605);
            this.btnModificarGrupo.Name = "btnModificarGrupo";
            this.btnModificarGrupo.Size = new System.Drawing.Size(108, 33);
            this.btnModificarGrupo.TabIndex = 52;
            this.btnModificarGrupo.Text = "Modificar Grupo";
            this.btnModificarGrupo.UseVisualStyleBackColor = true;
            this.btnModificarGrupo.Click += new System.EventHandler(this.btnModificarGrupo_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 664);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 60;
            this.label14.Text = "Fecha";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 638);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 58;
            this.label16.Text = "Descripcion";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 612);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 57;
            this.label17.Text = "Nombre Grupo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 661);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 56;
            // 
            // textBoxIDescripcionGrupo
            // 
            this.textBoxIDescripcionGrupo.Location = new System.Drawing.Point(95, 631);
            this.textBoxIDescripcionGrupo.Name = "textBoxIDescripcionGrupo";
            this.textBoxIDescripcionGrupo.Size = new System.Drawing.Size(175, 20);
            this.textBoxIDescripcionGrupo.TabIndex = 54;
            // 
            // textBoxNombreGrupo
            // 
            this.textBoxNombreGrupo.Location = new System.Drawing.Point(95, 605);
            this.textBoxNombreGrupo.Name = "textBoxNombreGrupo";
            this.textBoxNombreGrupo.Size = new System.Drawing.Size(175, 20);
            this.textBoxNombreGrupo.TabIndex = 53;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 664);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 59;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1086, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 52);
            this.button1.TabIndex = 61;
            this.button1.Text = "ABMC POST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backoffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxIDescripcionGrupo);
            this.Controls.Add(this.textBoxNombreGrupo);
            this.Controls.Add(this.btnModificarGrupo);
            this.Controls.Add(this.btnHabilitarGrupo);
            this.Controls.Add(this.btnBloquearGrupo);
            this.Controls.Add(this.dataGridViewGrupos);
            this.Controls.Add(this.btnCrearGrupo);
            this.Controls.Add(this.BtnDesbloquearEvento);
            this.Controls.Add(this.BtnBloquearEvento);
            this.Controls.Add(this.BtnModificarEvento);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxNuevaFechaEvento);
            this.Controls.Add(this.textBoxNuevoLugarEvento);
            this.Controls.Add(this.textBoxNuevaInfoEvento);
            this.Controls.Add(this.textBoxNuevoNombreEvento);
            this.Controls.Add(this.dataGridViewEventos);
            this.Controls.Add(this.textBoxFechaDeNacimiento);
            this.Controls.Add(this.BtnCrearEvento);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.textBoxCambiarEmail);
            this.Controls.Add(this.textBoxCambiarTelefono);
            this.Controls.Add(this.textBoxCambiarApellido);
            this.Controls.Add(this.textBoxCambiarNombre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.dataGridViewInfoUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUnlockTheUser);
            this.Controls.Add(this.btnBlockTheUser);
            this.Controls.Add(this.btnSearchUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "backoffice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfoUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.Button btnBlockTheUser;
        private System.Windows.Forms.Button btnUnlockTheUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewInfoUser;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCambiarNombre;
        private System.Windows.Forms.TextBox textBoxCambiarApellido;
        private System.Windows.Forms.TextBox textBoxCambiarTelefono;
        private System.Windows.Forms.TextBox textBoxCambiarEmail;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCrearEvento;
        private System.Windows.Forms.TextBox textBoxFechaDeNacimiento;
        private System.Windows.Forms.DataGridView dataGridViewEventos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxNuevaFechaEvento;
        private System.Windows.Forms.TextBox textBoxNuevoLugarEvento;
        private System.Windows.Forms.TextBox textBoxNuevaInfoEvento;
        private System.Windows.Forms.TextBox textBoxNuevoNombreEvento;
        private System.Windows.Forms.Button BtnModificarEvento;
        private System.Windows.Forms.Button BtnBloquearEvento;
        private System.Windows.Forms.Button BtnDesbloquearEvento;
        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.DataGridView dataGridViewGrupos;
        private System.Windows.Forms.Button btnBloquearGrupo;
        private System.Windows.Forms.Button btnHabilitarGrupo;
        private System.Windows.Forms.Button btnModificarGrupo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxIDescripcionGrupo;
        private System.Windows.Forms.TextBox textBoxNombreGrupo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
    }
}