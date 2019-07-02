using MovieFilter.Data;
using MovieFilter.FilterLogic;
using MovieFilter.Filters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MovieFilter
{
    public partial class AdditionalDataForm : Form
    {
        private DefaultFilter defaultFilter;
        private FilterDataLogic<string, Actor> filterDataLogic;
        public int index;
        List<CheckBox> checkBoxes;

        public AdditionalDataForm()
        {
            InitializeComponent();

            defaultFilter = new DefaultFilter();
            filterDataLogic = new FilterDataLogic<string, Actor>(defaultFilter);
        }

        private void AdditionalDataForm_Load(object sender, EventArgs e)
        {
            try
            {
                checkBoxes = new List<CheckBox>();

                filterDataLogic.FilterDataGrid("FilterValuesActors", filtersGroupBox, out checkBoxes, index);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void filter_button_Click(object sender, EventArgs e)
        {
            filterDataLogic.FilterData(dataGridViewActors, "FilteredDataActors", checkBoxes, index);
        }
    }
}
