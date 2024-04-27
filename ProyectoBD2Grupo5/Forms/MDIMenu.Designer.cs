﻿namespace ProyectoBD2Grupo5.Forms
{
    partial class MDIMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            productorToolStripMenuItem = new ToolStripMenuItem();
            listaProductoresToolStripMenuItem = new ToolStripMenuItem();
            fincasToolStripMenuItem = new ToolStripMenuItem();
            cultivosToolStripMenuItem = new ToolStripMenuItem();
            agregarToolStripMenuItem = new ToolStripMenuItem();
            comprasToolStripMenuItem = new ToolStripMenuItem();
            insumosToolStripMenuItem = new ToolStripMenuItem();
            comprasToolStripMenuItem1 = new ToolStripMenuItem();
            proveedoresToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            inventarioToolStripMenuItem = new ToolStripMenuItem();
            pagoCultivoToolStripMenuItem = new ToolStripMenuItem();
            pagosAProductorToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { productorToolStripMenuItem, comprasToolStripMenuItem, productosToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(737, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // productorToolStripMenuItem
            // 
            productorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listaProductoresToolStripMenuItem, fincasToolStripMenuItem, cultivosToolStripMenuItem, agregarToolStripMenuItem });
            productorToolStripMenuItem.Name = "productorToolStripMenuItem";
            productorToolStripMenuItem.Size = new Size(72, 20);
            productorToolStripMenuItem.Text = "Productor";
            // 
            // listaProductoresToolStripMenuItem
            // 
            listaProductoresToolStripMenuItem.Name = "listaProductoresToolStripMenuItem";
            listaProductoresToolStripMenuItem.Size = new Size(180, 22);
            listaProductoresToolStripMenuItem.Text = "Lista Productores";
            listaProductoresToolStripMenuItem.Click += listaProductoresToolStripMenuItem_Click;
            // 
            // fincasToolStripMenuItem
            // 
            fincasToolStripMenuItem.Name = "fincasToolStripMenuItem";
            fincasToolStripMenuItem.Size = new Size(180, 22);
            fincasToolStripMenuItem.Text = "Lista Fincas";
            fincasToolStripMenuItem.Click += fincasToolStripMenuItem_Click;
            // 
            // cultivosToolStripMenuItem
            // 
            cultivosToolStripMenuItem.Name = "cultivosToolStripMenuItem";
            cultivosToolStripMenuItem.Size = new Size(180, 22);
            cultivosToolStripMenuItem.Text = "Cultivos";
            cultivosToolStripMenuItem.Click += cultivosToolStripMenuItem_Click;
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            agregarToolStripMenuItem.Size = new Size(180, 22);
            agregarToolStripMenuItem.Text = "Agregar Finca ";
            agregarToolStripMenuItem.Click += agregarToolStripMenuItem_Click;
            // 
            // comprasToolStripMenuItem
            // 
            comprasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { insumosToolStripMenuItem, comprasToolStripMenuItem1, proveedoresToolStripMenuItem });
            comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            comprasToolStripMenuItem.Size = new Size(67, 20);
            comprasToolStripMenuItem.Text = "Compras";
            // 
            // insumosToolStripMenuItem
            // 
            insumosToolStripMenuItem.Name = "insumosToolStripMenuItem";
            insumosToolStripMenuItem.Size = new Size(139, 22);
            insumosToolStripMenuItem.Text = "Insumos";
            // 
            // comprasToolStripMenuItem1
            // 
            comprasToolStripMenuItem1.Name = "comprasToolStripMenuItem1";
            comprasToolStripMenuItem1.Size = new Size(139, 22);
            comprasToolStripMenuItem1.Text = "Compras";
            // 
            // proveedoresToolStripMenuItem
            // 
            proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            proveedoresToolStripMenuItem.Size = new Size(139, 22);
            proveedoresToolStripMenuItem.Text = "Proveedores";
            proveedoresToolStripMenuItem.Click += proveedoresToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inventarioToolStripMenuItem, pagoCultivoToolStripMenuItem, pagosAProductorToolStripMenuItem });
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(73, 20);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // inventarioToolStripMenuItem
            // 
            inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            inventarioToolStripMenuItem.Size = new Size(171, 22);
            inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // pagoCultivoToolStripMenuItem
            // 
            pagoCultivoToolStripMenuItem.Name = "pagoCultivoToolStripMenuItem";
            pagoCultivoToolStripMenuItem.Size = new Size(171, 22);
            pagoCultivoToolStripMenuItem.Text = "Cosecha";
            pagoCultivoToolStripMenuItem.Click += pagoCultivoToolStripMenuItem_Click;
            // 
            // pagosAProductorToolStripMenuItem
            // 
            pagosAProductorToolStripMenuItem.Name = "pagosAProductorToolStripMenuItem";
            pagosAProductorToolStripMenuItem.Size = new Size(171, 22);
            pagosAProductorToolStripMenuItem.Text = "Pagos a Productor";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 501);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(737, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(42, 17);
            toolStripStatusLabel.Text = "Estado";
            // 
            // MDIMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 523);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MDIMenu";
            Text = "MDIMenu";
            Load += MDIMenu_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolTip toolTip;
        private ToolStripMenuItem productorToolStripMenuItem;
        private ToolStripMenuItem fincasToolStripMenuItem;
        private ToolStripMenuItem cultivosToolStripMenuItem;
        private ToolStripMenuItem comprasToolStripMenuItem;
        private ToolStripMenuItem insumosToolStripMenuItem;
        private ToolStripMenuItem comprasToolStripMenuItem1;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem pagoCultivoToolStripMenuItem;
        private ToolStripMenuItem pagosAProductorToolStripMenuItem;
        private ToolStripMenuItem proveedoresToolStripMenuItem;
        private ToolStripMenuItem listaProductoresToolStripMenuItem;
        private ToolStripMenuItem agregarToolStripMenuItem;
    }
}



