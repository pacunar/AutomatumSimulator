namespace AutomatumSimulator
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.minimiza = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Animate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.Lineas = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.afdDraw = new System.Windows.Forms.Panel();
            this.explicacion = new System.Windows.Forms.Label();
            this.topleft = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cerrar = new System.Windows.Forms.Button();
            this.topright = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.States = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.afnReset = new System.Windows.Forms.Button();
            this.afnAnimate = new System.Windows.Forms.Button();
            this.afnLimpiar = new System.Windows.Forms.Button();
            this.afnBorrar = new System.Windows.Forms.Button();
            this.afnLineas = new System.Windows.Forms.Button();
            this.afnEstados = new System.Windows.Forms.Button();
            this.afnDraw = new System.Windows.Forms.Panel();
            this.afnminimizar = new System.Windows.Forms.Button();
            this.afnlabel2 = new System.Windows.Forms.Label();
            this.afntopleft = new System.Windows.Forms.Button();
            this.afnleft = new System.Windows.Forms.Button();
            this.afnclose = new System.Windows.Forms.Button();
            this.afntopright = new System.Windows.Forms.Button();
            this.afnright = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.afnmatricial = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.afnTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.afdDraw.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.afnDraw.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimiza
            // 
            this.minimiza.ForeColor = System.Drawing.Color.Black;
            this.minimiza.Location = new System.Drawing.Point(685, 553);
            this.minimiza.Name = "minimiza";
            this.minimiza.Size = new System.Drawing.Size(95, 36);
            this.minimiza.TabIndex = 1;
            this.minimiza.Text = "Minimize";
            this.minimiza.Click += new System.EventHandler(this.minimiza_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.cerrarToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.archivoToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cerrarToolStripMenuItem.Text = "Close";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Animate
            // 
            this.Animate.ForeColor = System.Drawing.Color.Black;
            this.Animate.Location = new System.Drawing.Point(591, 553);
            this.Animate.Name = "Animate";
            this.Animate.Size = new System.Drawing.Size(88, 36);
            this.Animate.TabIndex = 6;
            this.Animate.Text = "Evaluate";
            this.Animate.Click += new System.EventHandler(this.Animate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(440, 553);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 29);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // delete
            // 
            this.delete.ForeColor = System.Drawing.Color.Black;
            this.delete.Location = new System.Drawing.Point(208, 553);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(87, 36);
            this.delete.TabIndex = 9;
            this.delete.Text = "Delete";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Lineas
            // 
            this.Lineas.ForeColor = System.Drawing.Color.Black;
            this.Lineas.Location = new System.Drawing.Point(113, 553);
            this.Lineas.Name = "Lineas";
            this.Lineas.Size = new System.Drawing.Size(87, 36);
            this.Lineas.TabIndex = 10;
            this.Lineas.Text = "Line";
            this.Lineas.Click += new System.EventHandler(this.Lineas_Click);
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(13, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 621);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Lavender;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.afdDraw);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.reset);
            this.tabPage1.Controls.Add(this.clear);
            this.tabPage1.Controls.Add(this.minimiza);
            this.tabPage1.Controls.Add(this.Animate);
            this.tabPage1.Controls.Add(this.delete);
            this.tabPage1.Controls.Add(this.Lineas);
            this.tabPage1.Controls.Add(this.States);
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(881, 595);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DFA";
            // 
            // afdDraw
            // 
            this.afdDraw.BackColor = System.Drawing.Color.White;
            this.afdDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.afdDraw.Controls.Add(this.explicacion);
            this.afdDraw.Controls.Add(this.topleft);
            this.afdDraw.Controls.Add(this.left);
            this.afdDraw.Controls.Add(this.panel1);
            this.afdDraw.Controls.Add(this.cerrar);
            this.afdDraw.Controls.Add(this.topright);
            this.afdDraw.Controls.Add(this.right);
            this.afdDraw.Location = new System.Drawing.Point(7, 7);
            this.afdDraw.Name = "afdDraw";
            this.afdDraw.Size = new System.Drawing.Size(857, 540);
            this.afdDraw.TabIndex = 37;
            this.afdDraw.Click += new System.EventHandler(this.afdDraw_Click);
            this.afdDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.afdDraw_Paint);
            this.afdDraw.DoubleClick += new System.EventHandler(this.afdDraw_DoubleClick);
            // 
            // explicacion
            // 
            this.explicacion.AutoSize = true;
            this.explicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.explicacion.ForeColor = System.Drawing.Color.Black;
            this.explicacion.Location = new System.Drawing.Point(412, 35);
            this.explicacion.Name = "explicacion";
            this.explicacion.Size = new System.Drawing.Size(51, 16);
            this.explicacion.TabIndex = 6;
            this.explicacion.Text = "label2";
            this.explicacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.explicacion.Visible = false;
            // 
            // topleft
            // 
            this.topleft.Enabled = false;
            this.topleft.ForeColor = System.Drawing.Color.Black;
            this.topleft.Location = new System.Drawing.Point(342, 4);
            this.topleft.Name = "topleft";
            this.topleft.Size = new System.Drawing.Size(28, 24);
            this.topleft.TabIndex = 1;
            this.topleft.Text = "<<";
            this.topleft.Visible = false;
            this.topleft.Click += new System.EventHandler(this.topleft_Click);
            // 
            // left
            // 
            this.left.Enabled = false;
            this.left.ForeColor = System.Drawing.Color.Black;
            this.left.Location = new System.Drawing.Point(377, 4);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(28, 24);
            this.left.TabIndex = 2;
            this.left.Text = "<";
            this.left.Visible = false;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 479);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 49);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cerrar
            // 
            this.cerrar.ForeColor = System.Drawing.Color.Black;
            this.cerrar.Location = new System.Drawing.Point(412, 4);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(42, 24);
            this.cerrar.TabIndex = 5;
            this.cerrar.Text = "close";
            this.cerrar.Visible = false;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // topright
            // 
            this.topright.Enabled = false;
            this.topright.ForeColor = System.Drawing.Color.Black;
            this.topright.Location = new System.Drawing.Point(496, 4);
            this.topright.Name = "topright";
            this.topright.Size = new System.Drawing.Size(28, 24);
            this.topright.TabIndex = 4;
            this.topright.Text = ">>";
            this.topright.Visible = false;
            this.topright.Click += new System.EventHandler(this.topright_Click);
            // 
            // right
            // 
            this.right.Enabled = false;
            this.right.ForeColor = System.Drawing.Color.Black;
            this.right.Location = new System.Drawing.Point(461, 4);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(28, 24);
            this.right.TabIndex = 3;
            this.right.Text = ">";
            this.right.Visible = false;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(392, 560);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Input:";
            // 
            // reset
            // 
            this.reset.Enabled = false;
            this.reset.ForeColor = System.Drawing.Color.Black;
            this.reset.Location = new System.Drawing.Point(786, 553);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(80, 36);
            this.reset.TabIndex = 31;
            this.reset.Text = "Reset";
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // clear
            // 
            this.clear.ForeColor = System.Drawing.Color.Black;
            this.clear.Location = new System.Drawing.Point(301, 553);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(85, 36);
            this.clear.TabIndex = 26;
            this.clear.Text = "Clear";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // States
            // 
            this.States.AllowDrop = true;
            this.States.ForeColor = System.Drawing.Color.Black;
            this.States.Location = new System.Drawing.Point(16, 553);
            this.States.Name = "States";
            this.States.Size = new System.Drawing.Size(91, 36);
            this.States.TabIndex = 11;
            this.States.Text = "State";
            this.States.Click += new System.EventHandler(this.States_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.ForeColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(881, 595);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DFA: Matrix";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            this.tabPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage2_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 586);
            this.panel2.TabIndex = 1;
            this.panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel2_Scroll);
            this.panel2.Click += new System.EventHandler(this.tabPage2_Click);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage2_Paint);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(881, 595);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "NFA";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lavender;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.afnReset);
            this.panel3.Controls.Add(this.afnAnimate);
            this.panel3.Controls.Add(this.afnLimpiar);
            this.panel3.Controls.Add(this.afnBorrar);
            this.panel3.Controls.Add(this.afnLineas);
            this.panel3.Controls.Add(this.afnEstados);
            this.panel3.Controls.Add(this.afnDraw);
            this.panel3.Location = new System.Drawing.Point(-4, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(885, 598);
            this.panel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(389, 556);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Input:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(435, 556);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 29);
            this.textBox2.TabIndex = 8;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(689, 556);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(95, 32);
            this.button6.TabIndex = 2;
            this.button6.Text = "AFN->AFD";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // afnReset
            // 
            this.afnReset.Enabled = false;
            this.afnReset.Location = new System.Drawing.Point(788, 556);
            this.afnReset.Name = "afnReset";
            this.afnReset.Size = new System.Drawing.Size(80, 32);
            this.afnReset.TabIndex = 32;
            this.afnReset.Text = "Reset";
            this.afnReset.Click += new System.EventHandler(this.afnReset_Click);
            // 
            // afnAnimate
            // 
            this.afnAnimate.Location = new System.Drawing.Point(594, 556);
            this.afnAnimate.Name = "afnAnimate";
            this.afnAnimate.Size = new System.Drawing.Size(88, 32);
            this.afnAnimate.TabIndex = 7;
            this.afnAnimate.Text = "Animate";
            this.afnAnimate.Click += new System.EventHandler(this.afnAnimate_Click);
            // 
            // afnLimpiar
            // 
            this.afnLimpiar.Location = new System.Drawing.Point(298, 547);
            this.afnLimpiar.Name = "afnLimpiar";
            this.afnLimpiar.Size = new System.Drawing.Size(85, 41);
            this.afnLimpiar.TabIndex = 27;
            this.afnLimpiar.Text = "Clear";
            this.afnLimpiar.Click += new System.EventHandler(this.afnLimpiar_Click);
            // 
            // afnBorrar
            // 
            this.afnBorrar.Location = new System.Drawing.Point(205, 547);
            this.afnBorrar.Name = "afnBorrar";
            this.afnBorrar.Size = new System.Drawing.Size(87, 41);
            this.afnBorrar.TabIndex = 13;
            this.afnBorrar.Text = "Delete";
            this.afnBorrar.Click += new System.EventHandler(this.afnBorrar_Click);
            // 
            // afnLineas
            // 
            this.afnLineas.Location = new System.Drawing.Point(111, 547);
            this.afnLineas.Name = "afnLineas";
            this.afnLineas.Size = new System.Drawing.Size(87, 41);
            this.afnLineas.TabIndex = 11;
            this.afnLineas.Text = "Line";
            this.afnLineas.Click += new System.EventHandler(this.afnLineas_Click);
            // 
            // afnEstados
            // 
            this.afnEstados.AllowDrop = true;
            this.afnEstados.Location = new System.Drawing.Point(11, 547);
            this.afnEstados.Name = "afnEstados";
            this.afnEstados.Size = new System.Drawing.Size(91, 41);
            this.afnEstados.TabIndex = 12;
            this.afnEstados.Text = "State";
            this.afnEstados.Click += new System.EventHandler(this.afnEstados_Click);
            // 
            // afnDraw
            // 
            this.afnDraw.BackColor = System.Drawing.Color.White;
            this.afnDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.afnDraw.Controls.Add(this.afnminimizar);
            this.afnDraw.Controls.Add(this.afnlabel2);
            this.afnDraw.Controls.Add(this.afntopleft);
            this.afnDraw.Controls.Add(this.afnleft);
            this.afnDraw.Controls.Add(this.afnclose);
            this.afnDraw.Controls.Add(this.afntopright);
            this.afnDraw.Controls.Add(this.afnright);
            this.afnDraw.Controls.Add(this.panel5);
            this.afnDraw.Location = new System.Drawing.Point(8, 8);
            this.afnDraw.Name = "afnDraw";
            this.afnDraw.Size = new System.Drawing.Size(867, 533);
            this.afnDraw.TabIndex = 0;
            this.afnDraw.Click += new System.EventHandler(this.afnDraw_Click);
            this.afnDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.afnDraw_Paint);
            this.afnDraw.DoubleClick += new System.EventHandler(this.afnDraw_DoubleClick);
            // 
            // afnminimizar
            // 
            this.afnminimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.afnminimizar.Location = new System.Drawing.Point(778, 487);
            this.afnminimizar.Name = "afnminimizar";
            this.afnminimizar.Size = new System.Drawing.Size(65, 28);
            this.afnminimizar.TabIndex = 13;
            this.afnminimizar.Text = "Minimize";
            this.afnminimizar.Visible = false;
            this.afnminimizar.Click += new System.EventHandler(this.afnminimizar_Click);
            // 
            // afnlabel2
            // 
            this.afnlabel2.AutoSize = true;
            this.afnlabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afnlabel2.ForeColor = System.Drawing.Color.Black;
            this.afnlabel2.Location = new System.Drawing.Point(422, 35);
            this.afnlabel2.Name = "afnlabel2";
            this.afnlabel2.Size = new System.Drawing.Size(72, 16);
            this.afnlabel2.TabIndex = 12;
            this.afnlabel2.Text = "afnlabel2";
            this.afnlabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.afnlabel2.Visible = false;
            // 
            // afntopleft
            // 
            this.afntopleft.Enabled = false;
            this.afntopleft.ForeColor = System.Drawing.Color.Black;
            this.afntopleft.Location = new System.Drawing.Point(352, 4);
            this.afntopleft.Name = "afntopleft";
            this.afntopleft.Size = new System.Drawing.Size(28, 24);
            this.afntopleft.TabIndex = 7;
            this.afntopleft.Text = "<<";
            this.afntopleft.Visible = false;
            this.afntopleft.Click += new System.EventHandler(this.afntopleft_Click);
            // 
            // afnleft
            // 
            this.afnleft.Enabled = false;
            this.afnleft.ForeColor = System.Drawing.Color.Black;
            this.afnleft.Location = new System.Drawing.Point(387, 4);
            this.afnleft.Name = "afnleft";
            this.afnleft.Size = new System.Drawing.Size(28, 24);
            this.afnleft.TabIndex = 8;
            this.afnleft.Text = "<";
            this.afnleft.Visible = false;
            this.afnleft.Click += new System.EventHandler(this.afnleft_Click);
            // 
            // afnclose
            // 
            this.afnclose.ForeColor = System.Drawing.Color.Black;
            this.afnclose.Location = new System.Drawing.Point(422, 4);
            this.afnclose.Name = "afnclose";
            this.afnclose.Size = new System.Drawing.Size(42, 24);
            this.afnclose.TabIndex = 11;
            this.afnclose.Text = "close";
            this.afnclose.Visible = false;
            this.afnclose.Click += new System.EventHandler(this.afnclose_Click);
            // 
            // afntopright
            // 
            this.afntopright.Enabled = false;
            this.afntopright.ForeColor = System.Drawing.Color.Black;
            this.afntopright.Location = new System.Drawing.Point(506, 4);
            this.afntopright.Name = "afntopright";
            this.afntopright.Size = new System.Drawing.Size(28, 24);
            this.afntopright.TabIndex = 10;
            this.afntopright.Text = ">>";
            this.afntopright.Visible = false;
            this.afntopright.Click += new System.EventHandler(this.afntopright_Click);
            // 
            // afnright
            // 
            this.afnright.Enabled = false;
            this.afnright.ForeColor = System.Drawing.Color.Black;
            this.afnright.Location = new System.Drawing.Point(471, 4);
            this.afnright.Name = "afnright";
            this.afnright.Size = new System.Drawing.Size(28, 24);
            this.afnright.TabIndex = 9;
            this.afnright.Text = ">";
            this.afnright.Visible = false;
            this.afnright.Click += new System.EventHandler(this.afnright_Click);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(7, 476);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(848, 49);
            this.panel5.TabIndex = 1;
            this.panel5.Visible = false;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage4.Controls.Add(this.afnmatricial);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(881, 595);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "NFA: Matrix";
            this.tabPage4.Click += new System.EventHandler(this.afnmatricial_Click);
            this.tabPage4.Paint += new System.Windows.Forms.PaintEventHandler(this.afnmatricial_Paint);
            // 
            // afnmatricial
            // 
            this.afnmatricial.BackColor = System.Drawing.Color.White;
            this.afnmatricial.Location = new System.Drawing.Point(3, 3);
            this.afnmatricial.Name = "afnmatricial";
            this.afnmatricial.Size = new System.Drawing.Size(876, 586);
            this.afnmatricial.TabIndex = 2;
            this.afnmatricial.Scroll += new System.Windows.Forms.ScrollEventHandler(this.afnmatricial_Scroll);
            this.afnmatricial.Click += new System.EventHandler(this.afnmatricial_Click);
            this.afnmatricial.Paint += new System.Windows.Forms.PaintEventHandler(this.afnmatricial_Paint);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "as";
            this.openFileDialog1.Filter = "Archivos AS (*.as)|*.as|Todos Archivos (*.*) | *.*";
            this.openFileDialog1.InitialDirectory = ".";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "as";
            this.saveFileDialog1.Filter = "Archivos AS (*.as)|*.as|Todos Archivos (*.*) | *.*";
            this.saveFileDialog1.InitialDirectory = ".";
            // 
            // afnTimer
            // 
            this.afnTimer.Interval = 1000;
            this.afnTimer.Tick += new System.EventHandler(this.afnTimer_Tick);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(914, 662);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(914, 662);
            this.toolStripContainer1.TabIndex = 22;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // MainWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(914, 662);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutomatumSimulator";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.afdDraw.ResumeLayout(false);
            this.afdDraw.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.afnDraw.ResumeLayout(false);
            this.afnDraw.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button minimiza;
        /*private System.Windows.Forms.RaftingContainer leftRaftingContainer;
        private System.Windows.Forms.RaftingContainer rightRaftingContainer;
        private System.Windows.Forms.RaftingContainer topRaftingContainer;
        private System.Windows.Forms.RaftingContainer bottomRaftingContainer;*/
        private System.Windows.Forms.Button Animate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button Lineas;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button States;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button topright;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button topleft;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.Label explicacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel afdDraw;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button afnReset;
        private System.Windows.Forms.Button afnAnimate;
        private System.Windows.Forms.Button afnLimpiar;
        private System.Windows.Forms.Button afnBorrar;
        private System.Windows.Forms.Button afnLineas;
        private System.Windows.Forms.Button afnEstados;
        private System.Windows.Forms.Panel afnDraw;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Timer afnTimer;
        private System.Windows.Forms.Panel afnmatricial;
        private System.Windows.Forms.Label afnlabel2;
        private System.Windows.Forms.Button afntopleft;
        private System.Windows.Forms.Button afnleft;
        private System.Windows.Forms.Button afnclose;
        private System.Windows.Forms.Button afntopright;
        private System.Windows.Forms.Button afnright;
        private System.Windows.Forms.Button afnminimizar;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}