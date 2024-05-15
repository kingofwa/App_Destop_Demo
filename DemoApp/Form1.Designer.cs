using System;

namespace DemoApp
{
    partial class MainForm
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.clbCategories = new System.Windows.Forms.CheckedListBox();
            this.lblSelectedItems = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(7, 114);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(885, 390);
            this.dgvProducts.TabIndex = 0;
            // 
            // clbCategories
            // 
            this.clbCategories.FormattingEnabled = true;
            this.clbCategories.Location = new System.Drawing.Point(12, 12);
            this.clbCategories.Name = "clbCategories";
            this.clbCategories.Size = new System.Drawing.Size(172, 89);
            this.clbCategories.TabIndex = 2;
            this.clbCategories.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCategories_ItemCheck);
            //this.clbCategories.MouseUp += new System.Windows.Forms.MouseEventHandler(this.clbCategories_MouseUp);
            // 
            // lblSelectedItems
            // 
            this.lblSelectedItems.AutoSize = true;
            this.lblSelectedItems.Location = new System.Drawing.Point(677, 20);
            this.lblSelectedItems.Name = "lblSelectedItems";
            this.lblSelectedItems.Size = new System.Drawing.Size(0, 16);
            this.lblSelectedItems.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(543, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search for:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 516);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSelectedItems);
            this.Controls.Add(this.clbCategories);
            this.Controls.Add(this.dgvProducts);
            this.Name = "MainForm";
            this.Text = "List Product From API";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.CheckedListBox clbCategories;
        private System.Windows.Forms.Label lblSelectedItems;
        private System.Windows.Forms.Label label1;
    }
}

