using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace program2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(921, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 754);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;

    

        public void init()
        {
            button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "111";
            if (graphics == null)
                graphics = this.CreateGraphics();
          
              drawTree(50,300, 350, 70, System.Math.PI / 2);
        }
        private Graphics graphics;
        double th1 = 5 * System.Math.PI / 180;
        double th2 = 10 * System.Math.PI / 180;
        double per1 = 0.8;
        double per2 = 0.8;
        void drawTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            //课本上是用 + 号 而实际上原点在窗口左上角 + 会使得 树 倒立！！！
            double x1 = x0 -leng * Math.Cos(th);
            double y1 = y0 - leng * Math.Sin(th);
            double x2 = x0 + leng * Math.Cos(th);
            double y2 = y0 - leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawLine(x0, y0, x2, y2);

            drawTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawTree(n - 1, x2, y2, per2 * leng, th + th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            //从(x0,y0)到(x1,y1)
            graphics.DrawLine(
                Pens.Gold,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }
    }
}

