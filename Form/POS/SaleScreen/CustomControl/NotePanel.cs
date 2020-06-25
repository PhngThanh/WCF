using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POS.Common;
using POS.Repository.ViewModels;
using POS.Repository;

namespace POS.SaleScreen.CustomControl
{
    public partial class NotePanel : UserControl
    {
        private int _categoryId;
        private PropertyGroupControl _ingredientAdjustGroup;
        private CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        private string _adjustmentNote = "";
        private OrderDetailEditViewModel _mainOrderDetail;

        public NotePanel(int categoryId, OrderDetailEditViewModel mainOrderDetail)
        {
            _categoryId = categoryId;
            _mainOrderDetail = mainOrderDetail;
            InitializeComponent();

            if (MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtNotes);
            }

            GenerateNotes();

            this.label1.Text = MainForm.ResManager.GetString("Sys_Note_Title", MainForm.CultureInfo);
        }

        private void GenerateNotes()
        {
            #region Render Notes

            // Set adjustment note for each category
            var cate = Program.context.getAvailableCategories().FirstOrDefault(c => c.Code == _categoryId);

            if (cate == null || string.IsNullOrEmpty(cate.AdjustmentNote))
            {
                return;
            }

            _adjustmentNote = cate.AdjustmentNote;
            var notes = _adjustmentNote.Split('|');

            var noteProperty = new List<PropertyControl>();
            int index = 0;
            for (int i = 0; i < notes.Length; i++)
            {
                string[] note = notes[i].Split('-');
                for (int j = 0; j < note.Length; j++)
                {
                    var isSelected = false;
                    if (!string.IsNullOrWhiteSpace(_mainOrderDetail.Notes))
                    {
                        isSelected = _mainOrderDetail.Notes.Contains(note[j]);
                    }
                    noteProperty.Add(new PropertyControl()
                    {
                        ButtonType = ButtonType.Toggle,
                        Group = i,
                        Type = (int)PropertyTypeEnum.IngredientAdjustment,
                        DisplayText = note[j],
                        TextSize = 10,
                        IsActive = isSelected,
                        X = j,
                        Y = i,
                    });
                    ++index;
                }
            }

            _ingredientAdjustGroup = new PropertyGroupControl(noteProperty)
            {
                Name = "",
                SortIndex = index,
                AutoSize = true,
                Location = new Point(10,60)
                //Width = 250,
                //Height = 300,
            };
            _ingredientAdjustGroup.PropertyClick += IngredientAdjustGroupOnPropertyClick;
            pnlMain.Controls.Add(_ingredientAdjustGroup);

            txtNotes.Text = _mainOrderDetail.Notes;

            #endregion
        }

        private void IngredientAdjustGroupOnPropertyClick(PropertyControl obj)
        {
            // Reset all
            if (obj == null)
            {
                //                foreach (var od in _orderDetails)
                //                {
                //                    //Reset discount
                //                    od.DiscountRate = 0;
                //                    od.Discount = 0;
                //                    od.FinalAmount = od.TotalAmount;
                //
                //                    //Update Adjustment
                //                    od.Notes = "";
                //                }
                _mainOrderDetail.Notes = "";
            }
            else
            {
                string notes = "";

                foreach (var property in _ingredientAdjustGroup.Properties)
                {
                    if (property.IsActive)
                    {
                        //nodes += property.Name + "|";
                        notes += property.DisplayText + "|";
                    }
                }

                currentOrderManager.UpdateNoteOfOrderDetail(_mainOrderDetail, notes);
            }

            txtNotes.Text = _mainOrderDetail.Notes;
        }

        /// <summary>
        /// Save Notes to CurrentOrderManager.OrderEditViewModel
        /// </summary>+
        private void UpdateNotes()
        {
            _mainOrderDetail.Notes = txtNotes.Text;
            currentOrderManager.UpdateNoteOfOrderDetail(_mainOrderDetail, _mainOrderDetail.Notes);
        }

        private void txtNotes_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateNotes();
        }
    }
}
