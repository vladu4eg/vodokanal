﻿namespace GIS_DogWimForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProjectDogovor = new System.Windows.Forms.Button();
            this.btnNewDogovor = new System.Windows.Forms.Button();
            this.btnNewLS = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnPY = new System.Windows.Forms.Button();
            this.btnPokaz = new System.Windows.Forms.Button();
            this.btnKvit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpdAdressOnly = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProjectDogovor
            // 
            this.btnProjectDogovor.Location = new System.Drawing.Point(12, 12);
            this.btnProjectDogovor.Name = "btnProjectDogovor";
            this.btnProjectDogovor.Size = new System.Drawing.Size(95, 47);
            this.btnProjectDogovor.TabIndex = 19;
            this.btnProjectDogovor.Text = "Проекты договоров";
            this.btnProjectDogovor.UseVisualStyleBackColor = true;
            this.btnProjectDogovor.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnNewDogovor
            // 
            this.btnNewDogovor.Location = new System.Drawing.Point(113, 12);
            this.btnNewDogovor.Name = "btnNewDogovor";
            this.btnNewDogovor.Size = new System.Drawing.Size(95, 47);
            this.btnNewDogovor.TabIndex = 20;
            this.btnNewDogovor.Text = "Новый договор";
            this.btnNewDogovor.UseVisualStyleBackColor = true;
            this.btnNewDogovor.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnNewLS
            // 
            this.btnNewLS.Location = new System.Drawing.Point(12, 135);
            this.btnNewLS.Name = "btnNewLS";
            this.btnNewLS.Size = new System.Drawing.Size(95, 47);
            this.btnNewLS.TabIndex = 24;
            this.btnNewLS.Text = "Добавить ЛС";
            this.btnNewLS.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(12, 65);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(95, 64);
            this.btnHome.TabIndex = 22;
            this.btnHome.Text = "Обьекты жил фонда МКД жил";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnPY
            // 
            this.btnPY.Location = new System.Drawing.Point(12, 188);
            this.btnPY.Name = "btnPY";
            this.btnPY.Size = new System.Drawing.Size(95, 47);
            this.btnPY.TabIndex = 23;
            this.btnPY.Text = "ПУ";
            this.btnPY.UseVisualStyleBackColor = true;
            this.btnPY.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnPokaz
            // 
            this.btnPokaz.Location = new System.Drawing.Point(12, 241);
            this.btnPokaz.Name = "btnPokaz";
            this.btnPokaz.Size = new System.Drawing.Size(95, 47);
            this.btnPokaz.TabIndex = 25;
            this.btnPokaz.Text = "Показания";
            this.btnPokaz.UseVisualStyleBackColor = true;
            this.btnPokaz.Click += new System.EventHandler(this.btnPokaz_Click);
            // 
            // btnKvit
            // 
            this.btnKvit.Location = new System.Drawing.Point(12, 294);
            this.btnKvit.Name = "btnKvit";
            this.btnKvit.Size = new System.Drawing.Size(95, 47);
            this.btnKvit.TabIndex = 26;
            this.btnKvit.Text = "Квитанции";
            this.btnKvit.UseVisualStyleBackColor = true;
            this.btnKvit.Click += new System.EventHandler(this.btnKvit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 47);
            this.button1.TabIndex = 27;
            this.button1.Text = "Фиксики для ПУ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(412, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 47);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Обновление БД";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUpdAdressOnly
            // 
            this.btnUpdAdressOnly.Location = new System.Drawing.Point(412, 65);
            this.btnUpdAdressOnly.Name = "btnUpdAdressOnly";
            this.btnUpdAdressOnly.Size = new System.Drawing.Size(101, 64);
            this.btnUpdAdressOnly.TabIndex = 29;
            this.btnUpdAdressOnly.Text = "Обновление только адресов";
            this.btnUpdAdressOnly.UseVisualStyleBackColor = true;
            this.btnUpdAdressOnly.Click += new System.EventHandler(this.btnUpdAdressOnly_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(525, 361);
            this.Controls.Add(this.btnUpdAdressOnly);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnKvit);
            this.Controls.Add(this.btnPokaz);
            this.Controls.Add(this.btnPY);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnNewLS);
            this.Controls.Add(this.btnNewDogovor);
            this.Controls.Add(this.btnProjectDogovor);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnProjectDogovor;
        private System.Windows.Forms.Button btnNewDogovor;
        private System.Windows.Forms.Button btnNewLS;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPY;
        private System.Windows.Forms.Button btnPokaz;
        private System.Windows.Forms.Button btnKvit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnUpdAdressOnly;
    }
}

