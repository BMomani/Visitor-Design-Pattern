using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace LaptopStore
{
    public partial class Form1 : MetroForm
    {
        private ILaptop laptop;
        public Form1()
        {
            InitializeComponent();
        }

        //combo box
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 0)
            {
                laptop = new Appel();
                pictureBox1.Image = LaptopStore.Properties.Resources.Apple;
                if (metroToggle1.Checked)
                    richTextBox1.Text = laptop.Accept(new DetailedDescription());
                else
                    richTextBox1.Text = laptop.Accept(new BriefDescription());
            }
            else if (metroComboBox1.SelectedIndex == 1)
            {
                laptop = new Lenove();
                pictureBox1.Image = LaptopStore.Properties.Resources.Lenovo;
                if (metroToggle1.Checked)
                    richTextBox1.Text = laptop.Accept(new DetailedDescription());
                else
                    richTextBox1.Text = laptop.Accept(new BriefDescription());
            }
            else if (metroComboBox1.SelectedIndex == 2)
            {
                laptop = new HP();
                pictureBox1.Image = LaptopStore.Properties.Resources.Hp;
                if (metroToggle1.Checked)
                    richTextBox1.Text = laptop.Accept(new DetailedDescription());
                else
                    richTextBox1.Text = laptop.Accept(new BriefDescription());
            }
        }

        //toggle 
        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            metroComboBox1_SelectedIndexChanged(null, null);
        }

        //contributors 
        private void metroButton1_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Basheer ALMOMANI\n Reed Mryyan", "Visitor Design Pattern Contributers", MessageBoxButtons.OK,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
        }
    }


    #region Laptop Component

    public interface ILaptop
    {
        string Name { get; }
        string Accept(IVisitor v);
    }

    #region Laptop Types

    public class Lenove : ILaptop
    {
        public string Name => "Lenovo Laptop";

        //Bitmap 

        public string Accept(IVisitor v)
        {
            return v.Visit(this);
        }
    }

    public class Appel : ILaptop
    {
        public string Name => "Appel Laptop";

        public string Accept(IVisitor v)
        {
            return v.Visit(this);
        }
    }

    public class HP : ILaptop
    {
        public string Name => "HP Laptop";

        public string Accept(IVisitor v)
        {
            return v.Visit(this);
        }
    }

    #endregion

    #endregion


    #region Visiting Component

    public interface IVisitor
    {
        string Visit(ILaptop e);
    }

    #region Visiting Type

    public class BriefDescription : IVisitor
    {
        string IVisitor.Visit(ILaptop e)
        {
            if (e is Lenove)
                return Visit((Lenove) e);
            if (e is Appel)
                return Visit((Appel) e);
            if (e is HP)
                return Visit((HP) e);
            return null;
        }

        private static string Visit(Lenove lenove)
        {
            return String.Format("{0}\n{1}\n{2}", " Audio : High Definition (HD) Audio ",
                "Microprocessor : Intel® Core™ i5 processor i5-520M with dual-core",
                "Memory : 512MB DDR2 System Memory (2 Dimm)");
        }

        private static string Visit(Appel appel)
        {
            return String.Format("{0}\n{1}\n{2}", " Memory : 4GB of 1600MHz DDR3 memory ",
                "processor : Intel Core i5 processor (Turbo Boost up to 3.1GHz) with 3MB L3 cach ", " Storage: 500GB");
        }

        private static string Visit(HP hp)
        {
            return String.Format("{0}\n{1}\n{2}", " US Product Number : RG253UA#ABA",
                "Microprocessor : 2.0 GHz AMD Turion™ 64 Mobile Technology MK-36"
                , "Memory : 512MB DDR2 System Memory (2 Dimm)");
        }
    }

    public class DetailedDescription : IVisitor
    {
        public string Visit(ILaptop e)
        {
            if (e is Lenove)
                return Visit((Lenove) e);
            if (e is Appel)
                return Visit((Appel) e);
            if (e is HP)
                return Visit((HP) e);
            return null;
        }

        private static string Visit(Lenove lenove)
        {

            return String.Format("{0}\n{1}\n{2} \n {3}\n{4}\n{5}\n{6}\n{7}\n{8} ", lenove.Name
                , "US Product Number : RG253UA#ABA", "Microprocessor : 2.0 GHz AMD Turion™ 64 Mobile Technology MK-36"
                , "Memory : 512MB DDR2 System Memory (2 Dimm)", "Microprocessor Cache : 512KB L2 Cache ",
                " Memory Max : 2048MB"
                , "Video Graphics :NVIDIA GeForce Go 6150 (UMA)", "Hard Drive : 80GB 5400RPM (SATA)", "Weight : 6.8lbs");
        }

        private static string Visit(Appel appel)
        {
            return String.Format("{0}\n{1}\n{2} \n {3}\n{4}\n{5}\n{6} ", appel.Name,
                "processor : Intel Core i5 processor (Turbo Boost up to 3.1GHz) with 3MB L3 cach "
                , " Camera : 720p FaceTime HD camera "
                , " Memory Max : 2048MB",
                "Video Graphics :NVIDIA GeForce Go 6150 (UMA)",
                "Hard Drive : 80GB 5400RPM (SATA)",
                "Weight : 8.6lbs");
        }

        private static string Visit(HP hp)
        {
            return String.Format("{0}\n{1}\n{2} \n {3}\n{4}\n{5}\n{6}\n{7}\n{8} ", hp.Name,
                " US Product Number : RG253UA#ABA",
                "Microprocessor : 2.0 GHz AMD Turion™ 64 Mobile Technology MK-36",
                "Memory : 512MB DDR2 System Memory (2 Dimm)",
                "Microprocessor Cache : 512KB L2 Cache ",
                " Memory Max : 2048MB",
                "Video Graphics :NVIDIA GeForce Go 6150 (UMA)",
                "Hard Drive : 80GB 5400RPM (SATA)",
                "Weight : 6.8lbs");
        }
    }

    #endregion

    #endregion


}
