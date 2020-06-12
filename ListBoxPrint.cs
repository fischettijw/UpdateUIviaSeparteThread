using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateUIviaSeparteThread
{
    public class ListBoxPrint
    {
        public ListBox Lbx { get; set; }
        public int W1 { get; set; }
        public int W2 { get; set; }
        public int W3 { get; set; }
        public int W4 { get; set; }
        public int W5 { get; set; }
        public int W6 { get; set; }
        public int W7 { get; set; }
        public int W8 { get; set; }

        public ListBoxPrint(ListBox lbx, int w1 = 0, int w2 = 0, int w3 = 0, int w4 = 0,
                                         int w5 = 0, int w6 = 0, int w7 = 0, int w8 = 0)
        {
            Lbx = lbx;
            W1 = w1;
            W2 = w2;
            W3 = w3;
            W4 = w4;
            W5 = w4;
            W6 = w1;
            W7 = w2;
            W8 = w3;
        }

        public void Print(object V1 = null, object V2 = null, object V3 = null, object V4 = null,
                          object V5 = null, object V6 = null, object V7 = null, object V8 = null)
        {
            string output = "";
            string v1 = ""; string v2 = ""; string v3 = ""; string v4 = "";
            string v5 = ""; string v6 = ""; string v7 = ""; string v8 = "";
            if (V1 != null) v1 = V1.ToString().RJ(W1);
            if (V2 != null) v2 = V2.ToString().RJ(W2);
            if (V3 != null) v3 = V3.ToString().RJ(W3);
            if (V4 != null) v4 = V4.ToString().RJ(W4);
            if (V5 != null) v5 = V5.ToString().RJ(W1);
            if (V6 != null) v6 = V6.ToString().RJ(W2);
            if (V7 != null) v7 = V7.ToString().RJ(W3);
            if (V8 != null) v8 = V8.ToString().RJ(W4);
            output = v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8;
            Lbx.Items.Add(output);
            Top();
        }

        public void Clear(int nLines = 0)
        {
            if (nLines == 0)
            {
                Lbx.Items.Clear();
            }
            else
            {
                for (int i = 0; i < nLines; i++)
                {
                    Print("");
                }
            }
        }

        public void Top()
        {
            Lbx.TopIndex = 0;
        }

        public void Bottom()
        {
            Lbx.TopIndex = Lbx.Items.Count - 1;
        }

    }
}
