namespace ListViewTest
{
    using System.Diagnostics;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddListviewItems();

            this.listView1.ColumnReordered += new ColumnReorderedEventHandler(this.ListView1_ColumnReordered);
            this.listView1.ColumnWidthChanging += new ColumnWidthChangingEventHandler(this.ListView1_ColumnWidthChanging);
        }


        private void AddListviewItems()
        {
            this.listView1.Columns.Add("Item Colunm 0", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Item Colunm 1", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Item Colunm 2", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Item Colunm 3", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("ProgressBar", -2, HorizontalAlignment.Left);

            this.listView1.View = View.Details;
            this.listView1.LabelEdit = false;
            this.listView1.AllowColumnReorder = true;
            this.listView1.CheckBoxes = true;

            for (int i = 0; i < 10; i++)
            {
                ProgressBar prg = new ProgressBar();
                prg.Value = 100 / (i + 1);
                var item1 = new ListViewItem("item" + i.ToString(), 0);
                item1.Checked = true;
                var subitem0 = item1.SubItems.Add("1");
                subitem0.Name = "1";

                var subitem1 = item1.SubItems.Add("2");
                subitem1.Name = "2";

                var subitem2 = item1.SubItems.Add("3");
                subitem2.Name = "3";

                var subitem = item1.SubItems.Add("-------");
                subitem.Tag = prg;
                subitem.Name = "Progress";

                this.listView1.Controls.Add(prg);

                var subitem4 = item1.SubItems.Add("5");
                subitem4.Name = "3";
                this.listView1.Items.Add(item1);
            }
        }

        private void Trace()
        {
            int j = 0;
            var indexes = new Dictionary<int, int>();
            foreach (ColumnHeader header in this.listView1.Columns)
            {
                indexes[header.DisplayIndex] = header.Index;
            }
            int tmp = 0;
            foreach (KeyValuePair<int, int> item in indexes)
            {
                Debug.WriteLine($"{item.Key} => {item.Value}");
                tmp++;
            }

            foreach (ColumnHeader header in this.listView1.Columns)
            {
                Debug.WriteLine($"Index {header.Index} DisplayIndex {header.DisplayIndex} Width {header.Width}");
            }
            foreach (ListViewItem item in this.listView1.Items)
            {
                for ( int i = 0; i <= 4; i++ )
                {
                    ListViewItem.ListViewSubItem subitem = item.SubItems[i];
                    var bounds = subitem.Bounds;
                    Debug.WriteLine($"[{j}][{i}] {bounds} {subitem.Text} {subitem.Name}");
                }
                j++;
            }
        }

        private void ResizeProgressBar()
        {
            foreach (ListViewItem item in this.listView1.Items)
            {
                var subitem = item.SubItems[4];
                var progress = (ProgressBar)subitem.Tag;
                var bounds = subitem.Bounds;
                progress.Bounds = bounds;
            }
        }

        private void ListView1_ColumnReordered(object? sender, ColumnReorderedEventArgs e)
        {
            ResizeProgressBar();
        }

        private void ListView1_ColumnWidthChanging(object? sender, ColumnWidthChangingEventArgs e)
        {
            ResizeProgressBar();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResizeProgressBar();
        }
    }
}