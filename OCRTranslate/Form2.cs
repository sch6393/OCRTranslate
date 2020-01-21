using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCRTranslate
{
    public partial class Form2 : Form
    {
        private Rectangle m_rectangle = new Rectangle();
        private Point m_pointStart, m_pointEnd;
        private bool m_bDraw = false;

        #region Get

        public int Get_iX1
        {
            get;
            set;
        }

        public int Get_iY1
        {
            get;
            set;
        }

        public int Get_iX2
        {
            get;
            set;
        }

        public int Get_iY2
        {
            get;
            set;
        }

        public int Get_iWidth
        {
            get;
            set;
        }

        public int Get_iHeight
        {
            get;
            set;
        }

        #endregion

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Close();
            }
            else
            {
                m_bDraw = true;

                m_pointStart = e.Location;
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bDraw)
            {
                m_pointEnd = e.Location;

                Refresh();
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bDraw)
            {
                m_pointEnd = e.Location;

                m_bDraw = false;

                Get_iX1 = m_pointStart.X < m_pointEnd.X ? m_pointStart.X : m_pointEnd.X;
                Get_iX2 = m_pointStart.X < m_pointEnd.X ? m_pointEnd.X : m_pointStart.X;
                Get_iY1 = m_pointStart.Y < m_pointEnd.Y ? m_pointStart.Y : m_pointEnd.Y;
                Get_iY2 = m_pointStart.Y < m_pointEnd.Y ? m_pointEnd.Y : m_pointStart.Y;
                Get_iWidth = Math.Abs(Get_iX1 - Get_iX2);
                Get_iHeight = Math.Abs(Get_iY1 - Get_iY2);

                Close();
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            if (m_rectangle != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightSkyBlue), GetRectangle(m_rectangle));
                e.Graphics.DrawRectangle(Pens.Blue, GetRectangle(m_rectangle));
            }
        }

        private Rectangle GetRectangle(Rectangle rectangle)
        {
            rectangle = new Rectangle();

            rectangle.X = Math.Min(m_pointStart.X, m_pointEnd.X);
            rectangle.Y = Math.Min(m_pointStart.Y, m_pointEnd.Y);
            rectangle.Width = Math.Abs(m_pointStart.X - m_pointEnd.X);
            rectangle.Height = Math.Abs(m_pointStart.Y - m_pointEnd.Y);

            return rectangle;
        }
    }
}
